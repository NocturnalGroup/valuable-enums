using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NocturnalGroup.ValuableEnums;

internal static class StringExtensions
{
	/// <summary>
	/// Capitalizes the first letter of the provided string.
	/// </summary>
	public static string Capitalize(this string input)
	{
		if (string.IsNullOrEmpty(input))
			return input;

		if (input.Length is 1)
			return input.ToUpperInvariant();

		return input.Substring(0, 1).ToUpperInvariant() + input.Substring(1);
	}

	/// <summary>
	/// Removes quote marks from the provided string.
	/// </summary>
	public static string RemoveQuotes(this string input)
	{
		return string.IsNullOrEmpty(input) ? input : input.Replace("\"", "").Replace("'", "");
	}

	/// <summary>
	/// Removes square brackets from the provided string.
	/// </summary>
	public static string RemoveSquareBrackets(this string input)
	{
		return string.IsNullOrEmpty(input) ? input : input.Replace("[", "").Replace("]", "");
	}

	/// <summary>
	/// Adds an indentation to the <see cref="StringBuilder"/>.
	/// </summary>
	public static StringBuilder AppendIndent(this StringBuilder builder, int amount = 1)
	{
		return builder.Append(new string(' ', amount * 4));
	}
}

internal static class RoslynExtensions
{
	/// <summary>
	/// Gets the name of the type, prefixed with its namespace.
	/// </summary>
	internal static string GetNamespacedName(this BaseTypeDeclarationSyntax baseTypeDeclaration)
	{
		// Enums can be contained inside other types.
		// So we need to walk through every parent to find the full namespace.
		var nameBuilder = new StringBuilder(baseTypeDeclaration.Identifier.ToString());
		var currentParent = baseTypeDeclaration.Parent;

		// Work back through all the parent types.
		while (currentParent is BaseTypeDeclarationSyntax parentSyntax)
		{
			nameBuilder.Insert(0, '.');
			nameBuilder.Insert(0, parentSyntax.Identifier.ToString());
			currentParent = parentSyntax.Parent;
		}

		// Work back through the namespaces
		while (currentParent is BaseNamespaceDeclarationSyntax namespaceParent)
		{
			nameBuilder.Insert(0, '.');
			nameBuilder.Insert(0, namespaceParent.Name.ToString());
			currentParent = namespaceParent.Parent;
		}

		// Combine all the parts
		return nameBuilder.ToString();
	}

	/// <summary>
	/// Gets the name of the type, prefixed with its namespace.
	/// </summary>
	internal static string? GetNamespacedName(this AttributeSyntax attributeSyntax, SemanticModel semanticModel)
	{
		if (semanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
			throw new Exception("Unable to get the symbol of the provided attribute.");

		return attributeSymbol.ContainingType.ToDisplayString();
	}
}
