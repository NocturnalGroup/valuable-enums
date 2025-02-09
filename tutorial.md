<img align="right" width="256" height="256" src="Assets/Logo.png">

<div id="user-content-toc">
  <ul align="center" style="list-style: none;">
    <summary>
      <h1>ValuableEnums</h1>
    </summary>
  </ul>
</div>

### Making enums more valuable

[About](readme.md) · Getting Started · [License](license.txt) · [Contributing](contributing.md)

---

## Installing

Please see the installation instructions [here](readme.md#Installing).

## Overview

ValuableEnums allows you to add static values to enum members.
This allows you to easily extend enums, making them more powerful.

The concept is that a "field" is created on the enum.
A field has a default value, and override values for certain members.
Values must be compile-time constants, due to the nature of attributes.

It's worth noting we're not doing anything magical!
All the source generator does is create an extension method.

## Creating An Enum Field

An enum field is created through value definitions.
This means we don't have to explicitly "create" the field.

Every field has a name (1st argument).
This name is used to generate the extension method.
They're enum scoped, meaning multiple enums can have a field with the same name.

Fields can hold any constant values.
Normally this is strings, numeric types and enums.
This means you can use an enum which has fields itself!

Using the attribute at the enum level assigns a default value.
If you don't provide a default value, the default will be `null`.
So if you're using a value type, it might be worth providing a default value.

```csharp
[EnumField<string>("usage", "No example provided.")]
public enum Command
{
  // This enum member doesn't have any overrides.
  // This means it will return the following values:
  //   GetUsage()      -> "No example provided."
  //   GetPermission() -> null
  Unknown = 0,

  // Using the attribute at the member level assigns an override value.
  // For example, here we provide an override value for the usage field.
  // This means it will return the following values:
  //   GetUsage()      -> "create {name}"
  //   GetPermission() -> null
  [EnumField<string>("usage", "create {name}")]
  CreateEntry = 1,

  // Here we declare a value for the "permission" field.
  // It's worth noting the Permission type is just a normal enum.
  // This will create a field on this enum with just this override.
  // All other members will return `null` when GetPermission() is called.
  //   GetUsage()      -> "No example provided."
  //   GetPermission() -> Permission.Destructive
  [EnumField<Permission>("permission", Permission.Destructive)]
  DeleteEntry = 2,
}
```

## Accessing an Enum Field

To interact with the field, you simply call the generated extension method.
The extension method is located in the `NocturnalGroup.ValuableEnums` namespace.

```csharp
Console.Out.WriteLine("Create Entry usage:");
Console.Out.WriteLine(Command.CreateEntry.GetUsage()); // "create {name}"
```
