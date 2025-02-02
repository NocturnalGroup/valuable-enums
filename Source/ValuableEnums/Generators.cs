using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace NocturnalGroup.ValuableEnums;

[Generator]
public class EnumFieldGenerator : IIncrementalGenerator
{
	private const string AttributeName = "NocturnalGroup.ValuableEnums.EnumFieldAttribute";

	/// <inheritdoc />
	public void Initialize(IncrementalGeneratorInitializationContext ctx)
	{
		// Add static files to the generated code output.
		ctx.RegisterPostInitializationOutput(c =>
			c.AddSource(
				"NocturnalGroup.ValuableEnums.Static.g.cs",
				SourceText.From(Templates.GenerateStaticCode(), Encoding.UTF8)
			)
		);

		// Find and parse all enums and enum members with the attribute.
		var enumFieldsValues = ctx.SyntaxProvider.ForAttributeWithMetadataName(
			$"{AttributeName}`1",
			predicate: CanHaveEnumField,
			transform: ParseAttributes
		);

		// Merge all the values into one collection.
		var allValues = ctx.CompilationProvider.Combine(enumFieldsValues.Collect());

		// Generate the extension methods from the values.
		ctx.RegisterSourceOutput(allValues, static (ctx, source) => Execute(source.Right, ctx));
	}

	/// <summary>
	/// Returns true if the provided node can have an enum field, otherwise false.
	/// </summary>
	private static bool CanHaveEnumField(SyntaxNode node, CancellationToken _)
	{
		return node is EnumDeclarationSyntax or EnumMemberDeclarationSyntax;
	}

	/// <summary>
	/// Extracts the data from the EnumField attributes on the provided type.
	/// </summary>
	private static List<EnumFieldValue> ParseAttributes(GeneratorAttributeSyntaxContext ctx, CancellationToken _)
	{
		// Sanity check!
		// This should never happen, but we need to be good programmers.
		if (ctx.TargetNode is not MemberDeclarationSyntax baseType)
			return [];

		var names = ExtractNames(baseType);
		var output = new List<EnumFieldValue>();
		foreach (var attribute in baseType.AttributeLists.SelectMany(x => x.Attributes))
		{
			// This method is called once per type, even with multiple attributes.
			// So we need to validate the attribute is our before trying to pull data.
			var attributeName = attribute.GetNamespacedName(ctx.SemanticModel);
			if (attributeName is null || !attributeName.StartsWith($"{AttributeName}<"))
				continue;

			// Next we need to try and extract the attribute symbol.
			// This will allow us to read the generic parameter of the attribute.
			var attributeSymbol = ctx.SemanticModel.GetSymbolInfo(attribute).Symbol;
			if (attributeSymbol is null)
				throw new Exception("EnumField attribute has no symbol.");

			// Then, we extract the field information from the attribute.
			var fieldType = attributeSymbol.ContainingType.TypeArguments[0].ToDisplayString();
			var fieldName = attribute.ArgumentList!.Arguments[0].ToString();
			var fieldValue = attribute.ArgumentList.Arguments[1].ToString();

			// To allow enums as a field type, we need to hack a little.
			// This is because the generated extensions live in the Nocturnal namespace.
			// So we are unable to directly reference any namespaced user created types.
			// So this function appends the namespace to the enum values (single and array).
			if (!IsPrimitiveType(fieldType))
				fieldValue = AppendNamespaceToEnumValues(fieldType, fieldValue);

			// Finally we can add this value to the output.
			output.Add(new EnumFieldValue(names.enumName, names.memberName, fieldName, fieldType, fieldValue));
		}
		return output;
	}

	/// <summary>
	/// Extracts the enum and member name from the provided type.
	/// </summary>
	private static (string enumName, string? memberName) ExtractNames(MemberDeclarationSyntax baseType)
	{
		switch (baseType)
		{
			case EnumDeclarationSyntax enumNode:
			{
				return (enumNode.GetNamespacedName(), null);
			}
			case EnumMemberDeclarationSyntax memberNode:
			{
				var parentNode = (EnumDeclarationSyntax)memberNode.Parent!;
				return (parentNode.GetNamespacedName(), memberNode.Identifier.ToString());
			}
			default:
			{
				throw new Exception("Tried to a name extraction on a non enum type.");
			}
		}
	}

	/// <summary>
	/// True if the FieldType is a builtin primitive type, otherwise false.
	/// </summary>
	private static bool IsPrimitiveType(string fieldType)
	{
		return fieldType.RemoveSquareBrackets() switch
		{
			"bool"
			or "sbyte"
			or "short"
			or "int"
			or "long"
			or "byte"
			or "ushort"
			or "uint"
			or "ulong"
			or "float"
			or "double"
			or "char"
			or "string" => true,
			_ => false,
		};
	}

	/// <summary>
	/// Appends the namespace to enum values.
	/// Supports single values and the various array syntaxes.
	/// </summary>
	private static string AppendNamespaceToEnumValues(string fieldType, string fieldValue)
	{
		// Extract all values from the provided value string.
		var fieldValues = ExtractValues(fieldValue);
		if (fieldValues.Length is 0)
			return fieldValue;

		// Remove array syntax "[]" from the type name and split.
		var fieldTypeSplit = fieldType.Split('[').First().Split('.').ToArray();
		var fieldTypeLast = fieldTypeSplit.Last();

		// Append the namespace to enum values
		for (var i = 0; i < fieldValues.Length; i++)
		{
			// We now need to detect if the type is an enum member or not.
			// We can do this by checking if the value starts with the field type.
			// So to do this...
			// UserNamespace.CustomEnum     (FieldType)
			//               CustomEnum.Red (Value)
			//      We check this 👆 lines up.
			var value = fieldValues[i];
			if (!value.StartsWith(fieldTypeLast))
				continue;

			// We have an enum member value!
			// However, the enum may not have a namespace.
			// It could be declared globally, usually in Program.cs (top level statements)
			var namespaceString = string.Join(".", fieldTypeSplit.Take(fieldTypeSplit.Length - 1));
			if (!string.IsNullOrEmpty(namespaceString))
			{
				namespaceString += ".";
			}
			fieldValues[i] = namespaceString + value;
		}

		// Hopefully everything is correct!
		return fieldValues.Length is 1 ? fieldValues[0] : "[" + string.Join(", ", fieldValues) + "]";
	}

	/// <summary>
	/// Extracts the values out of a value string.
	/// </summary>
	private static string[] ExtractValues(string fieldValue)
	{
		// new [] {...} - Must come first!
		if (fieldValue.Contains("{"))
		{
			var contents = fieldValue.Split('{', '}')[1];
			return contents.Split(',').Select(x => x.Trim()).ToArray();
		}

		// [...]
		if (fieldValue.Contains("["))
		{
			var contents = fieldValue.Split('[', ']')[1];
			return contents.Split(',').Select(x => x.Trim()).ToArray();
		}

		// Single values (Everything else)
		return [fieldValue];
	}

	/// <summary>
	/// Converts the enum data to a string.
	/// The string is the generate file contents.
	/// That string is then written to a file in the build output.
	/// </summary>
	private static void Execute(ImmutableArray<List<EnumFieldValue>> allValues, SourceProductionContext ctx)
	{
		// We need to support fields with the same name on different enums.
		// So to do this we first group via the enum name, and then the field name.
		var fields = new List<EnumField>();
		foreach (var enumFields in allValues.SelectMany(x => x).GroupBy(x => x.EnumName))
		{
			foreach (var enumFieldValues in enumFields.GroupBy(x => x.FieldName).Select(x => x.ToList()))
			{
				fields.Add(new EnumField(enumFieldValues.ToArray()));
			}
		}

		var sourceCode = Templates.GenerateEnumFieldExtensions(fields);
		ctx.AddSource("NocturnalGroup.ValuableEnums.Extensions.g.cs", SourceText.From(sourceCode, Encoding.UTF8));
	}
}
