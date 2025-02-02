using System.Text;

namespace NocturnalGroup.ValuableEnums;

internal static class Templates
{
	/// <summary>
	/// Generates the static C# code to be added to the build.
	/// </summary>
	public static string GenerateStaticCode()
	{
		return """
			namespace NocturnalGroup.ValuableEnums
			{
				/// <summary>
				/// A default or override value for an enum field.
				/// Attach this attribute to the enum to set a default value.
				/// Attach to an enum member to set an override value.
				/// </summary>
				/// <typeparam name="TValue">The type of value the field holds.</typeparam>
				/// <code>
				/// // 👇 Here you can set a default value for the field.
				/// [EnumField&lt;string&gt;(&quot;desc&quot;, &quot;No description provided&quot;)]
				///	public enum Command
				/// {
				///     // 👇 Members that don't provide an override will use the default value.
				///     CreateEntry = 1,
				///
				///     // 👇 Members that provide an override will use it instead of the default.
				///     [EnumField&lt;string&gt;(&quot;description&quot;, &quot;Creates a new entry.&quot;)]
				///     ListEntries = 2,
				///
				///     // 👇 If you don't set a default value, the default value will be `null`.
				///     [EnumField&lt;string&gt;(&quot;usage&quot;, &quot;delete {id}&quot;)]
				///     DeleteEntry = 3,
				/// }
				/// </code>
				[System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Enum, AllowMultiple = true)]
				public sealed class EnumFieldAttribute<TValue> : System.Attribute
				{
					public string Name { get; }
					public TValue Value { get; }

					/// <inheritdoc cref="EnumFieldAttribute{TValue}"/>
					/// <param name="enumValueName">The enum-wide name of the field.</param>
					/// <param name="value">The value stored in the enum field.</param>
					public EnumFieldAttribute(string enumValueName, TValue value)
					{
						Name = enumValueName;
						Value = value;
					}
				}
			}
			""";
	}

	/// <summary>
	/// Generates the C# code for a set of enum fields.
	/// </summary>
	/// <param name="enumFields">The enum fields to generate the extension methods for.</param>
	public static string GenerateEnumFieldExtensions(IReadOnlyList<EnumField> enumFields)
	{
		var builder = new StringBuilder();
		builder.Append("#nullable enable").AppendLine();
		builder.Append("namespace NocturnalGroup.ValuableEnums").AppendLine();
		builder.Append("{").AppendLine();
		builder.AppendIndent().Append("public static class ValuableEnumsExtensions").AppendLine();
		builder.AppendIndent().Append("{").AppendLine();
		foreach (var enumField in enumFields)
		{
			GenerateEnumFieldExtension(builder, enumField);
			builder.AppendLine();
		}
		builder.AppendIndent().Append("}").AppendLine();
		builder.Append("}").AppendLine();
		builder.Append("#nullable disable").AppendLine();
		return builder.ToString();
	}

	/// <summary>
	/// Generates the C# code for an enum field.
	/// </summary>
	/// <param name="builder">The <see cref="StringBuilder"/> to add the method to.</param>
	/// <param name="enumField">The enum field to generate the extension method for.</param>
	private static void GenerateEnumFieldExtension(StringBuilder builder, EnumField enumField)
	{
		// Function Signature
		builder.AppendIndent(2);
		builder.Append("public static ");
		builder.Append(enumField.FieldType);
		if (enumField.DefaultValue.FieldValue == "null")
		{
			builder.Append('?');
		}
		builder.Append(" Get").Append(enumField.FieldName.RemoveQuotes().Capitalize());
		builder.Append("(this ").Append(enumField.EnumName).Append(" value)").AppendLine();

		// Function Body Start
		builder.AppendIndent(2).Append("{").AppendLine();

		// Function Body Contents
		builder.AppendIndent(3).Append("return value switch").AppendLine();
		builder.AppendIndent(3).Append("{").AppendLine();
		foreach (var fieldValue in enumField.OverrideValues)
		{
			builder.AppendIndent(4);
			builder.Append(fieldValue.EnumName).Append('.').Append(fieldValue.EnumMember);
			builder.Append(" => ");
			builder.Append(fieldValue.FieldValue).Append(',');
			builder.AppendLine();
		}
		builder.AppendIndent(4).Append("_ => ").Append(enumField.DefaultValue.FieldValue).Append(',').AppendLine();
		builder.AppendIndent(3).Append("};").AppendLine();

		// Function Body End
		builder.AppendIndent(2).Append("}").AppendLine();
	}
}
