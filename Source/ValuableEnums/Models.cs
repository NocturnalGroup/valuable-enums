namespace NocturnalGroup.ValuableEnums;

/// <summary>
/// A convenience type that wraps and organises <see cref="EnumFieldValue"/>s.
/// </summary>
internal sealed class EnumField
{
	/// <inheritdoc cref="EnumFieldValue.EnumName"/>
	public string EnumName => DefaultValue.EnumName;

	/// <inheritdoc cref="EnumFieldValue.FieldName"/>
	public string FieldName => DefaultValue.FieldName;

	/// <inheritdoc cref="EnumFieldValue.FieldType"/>
	public string FieldType => DefaultValue.FieldType;

	/// <summary>
	/// The value to use if an enum member doesn't specify an override.
	/// </summary>
	public EnumFieldValue DefaultValue { get; }

	/// <summary>
	/// Override values for specific enum members.
	/// </summary>
	public EnumFieldValue[] OverrideValues { get; }

	/// <summary>
	/// Validates the provided values and creates an EnumField from them.
	/// </summary>
	public EnumField(EnumFieldValue[] values)
	{
		// Sanity check we were given values to work with.
		if (values.Length is 0)
			throw new Exception("Tried to create an EnumField with no values.");

		// Distribute the incoming values by their kind.
		OverrideValues = values.Where(x => !x.IsDefaultValue).ToArray();
		DefaultValue = values.LastOrDefault(x => x.IsDefaultValue) ?? new EnumFieldValue(values[0], null, "null");

		// Validate all values are for the same enum.
		var enumNameMatches = OverrideValues.All(x => x.EnumName == DefaultValue.EnumName);
		if (!enumNameMatches)
			throw new Exception($"Inconsistent enum names: {ToString()}");

		// Validate members don't have multiple overrides for the same field.
		var allUnique = OverrideValues.GroupBy(x => x.EnumMember).All(g => g.Count() == 1);
		if (!allUnique)
			throw new Exception($"Duplicate overrides found: {ToString()}");

		// Validate all the values are for the same field.
		var fieldNameMatches = OverrideValues.All(x => x.FieldName == DefaultValue.FieldName);
		if (!fieldNameMatches)
			throw new Exception($"Inconsistent field names: {ToString()}");

		// Validate all the values have the same value type.
		var fieldTypeMatches = OverrideValues.All(x => x.FieldType == DefaultValue.FieldType);
		if (!fieldTypeMatches)
			throw new Exception($"Inconsistent field type: {ToString()}");
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return $"Enum Field {DefaultValue.FieldName} on {DefaultValue.EnumName}";
	}
}

/// <summary>
/// A default or override enum field value.
/// </summary>
internal sealed class EnumFieldValue
{
	/// <summary>
	/// The fully qualified name of the enum the field is attached to.
	/// </summary>
	public string EnumName { get; }

	/// <summary>
	/// The enum member this override is attached to, or null if this is a default value.
	/// </summary>
	public string? EnumMember { get; }

	/// <summary>
	/// True if this is a default value, otherwise false.
	/// </summary>
	public bool IsDefaultValue => EnumMember is null;

	/// <summary>
	/// The enum-wide name of the field.
	/// </summary>
	public string FieldName { get; }

	/// <summary>
	/// The type of value the field holds.
	/// </summary>
	public string FieldType { get; }

	/// <summary>
	/// The value extracted from the attribute.
	/// </summary>
	public string FieldValue { get; }

	/// <summary>
	/// Creates a new <see cref="EnumFieldValue"/> from an existing field value.
	/// </summary>
	/// <remarks>Providing a null enumMember turns this into a default value.</remarks>
	public EnumFieldValue(EnumFieldValue otherValue, string? enumMember, string fieldValue)
	{
		EnumName = otherValue.EnumName;
		EnumMember = enumMember;
		FieldName = otherValue.FieldName;
		FieldType = otherValue.FieldType;
		FieldValue = fieldValue;
	}

	/// <summary>
	/// Creates a new <see cref="EnumFieldValue"/>.
	/// </summary>
	/// <remarks>Providing a null enumMember turns this into a default value.</remarks>
	public EnumFieldValue(string enumName, string? enumMember, string fieldName, string fieldType, string fieldValue)
	{
		EnumName = enumName;
		EnumMember = enumMember;
		FieldName = fieldName;
		FieldType = fieldType;
		FieldValue = fieldValue;
	}
}
