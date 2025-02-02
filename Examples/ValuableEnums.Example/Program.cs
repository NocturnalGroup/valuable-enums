using NocturnalGroup.ValuableEnums;

// ValuableEnums allows you to add static values to enum members.
// This allows you to easily extend enums, making them more powerful.
//
// The concept is that a "field" is created on the enum.
// A field has a default value, and override values for certain members.
// Values must be compile-time constants, due to the nature of attributes.
//
// It's worth noting we're not doing anything magical!
// Our source generator creates an extension method for you.
// For example, lets get the value of the "usage" field for this enum member.
Console.Out.WriteLine("Create Entry usage:");
Console.Out.WriteLine(Command.CreateEntry.GetUsage()); // "create {name}"

// Extension methods aren't generated for every enum.
// We only generate them for enums that have one or more EnumField attributes.
public enum Permission
{
	Destructive = 1,
}

// An enum field is created through value definitions.
// This means we don't have to explicitly "create" the field.
//
// Every field has a name (1st argument).
// This name is used to generate the extension method.
// They're enum scoped, meaning multiple enums can have a field with the same name.
//
// Fields can hold any constant values.
// Normally this is strings, numeric types and enums.
// This means you can use an enum which has fields itself!
//
// Using the attribute at the enum level assigns a default value.
// If you don't provide a default value, the default will be `null`.
// So if you're using a value type, it might be worth providing a default value.
//
// For example, here we provide a default value for the "usage" field.
[EnumField<string>("usage", "No example provided.")]
public enum Command
{
	// This enum member doesn't have any overrides.
	// This means it will return the following values:
	//   GetUsage()      -> "No example provided."
	//	 GetPermission() -> null
	Unknown = 0,

	// Using the attribute at the member level assigns an override value.
	// For example, here we provide an override value for the usage field.
	// This means it will return the following values:
	//   GetUsage()      -> "create {name}"
	//	 GetPermission() -> null
	[EnumField<string>("usage", "create {name}")]
	CreateEntry = 1,

	// Here we declare a value for the "permission" field.
	// This will create a field on this enum with just this override.
	// All other members will return `null` when GetPermission() is called.
	//   GetUsage()      -> "No example provided."
	//	 GetPermission() -> Permission.Destructive
	[EnumField<Permission>("permission", Permission.Destructive)]
	DeleteEntry = 2,
}
