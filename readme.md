<img align="right" width="256" height="256" src="Assets/Logo.png">

<div id="user-content-toc">
  <ul align="center" style="list-style: none;">
    <summary>
      <h1>ValuableEnums</h1>
    </summary>
  </ul>
</div>

### Making enums more valuable

About · [Getting Started](tutorial.md) · [License](license.txt) · [Contributing](contributing.md)

---

ValuableEnums is a source generator that emulates fields on enums.
This lets you add compile time values to an enum member, similar to Java's enums.

## Installing

You can install ValuableEnums with [NuGet](https://www.nuget.org/packages/NocturnalGroup.ValuableEnums):

```shell
dotnet add package NocturnalGroup.ValuableEnums
```

## Quickstart

For a detailed walkthrough of ValuableEnums, check out our [tutorial](tutorial.md).

```csharp
// 👇 Here you can set a default value for the field.
[EnumField<string>("description", "No description provided.")]
public enum Command
{
  // 👇 Members that don't provide an override will use the default value.
  CreateEntry = 1,

  // 👇 Members that provide an override will use it instead of the default.
  [EnumField<string>("description", "Creates a new entry.")]
  ListEntries = 2,

  // 👇 If you don't set a default value, the default value will be `null`.
  [EnumField<string>("usage", "delete {id}")]
  DeleteEntry = 3,
}

// 👇 Use the generated getters to retrieve the field values
Console.WriteLine(Command.CreateEntry.GetDescription()); // "No description provided."
Console.WriteLine(Command.ListEntries.GetDescription()); // "Creates a new entry."
Console.WriteLine(Command.DeleteEntry.GetDescription()); // "No description provided."
Console.WriteLine(Command.CreateEntry.GetUsage()); // null
Console.WriteLine(Command.ListEntries.GetUsage()); // null
Console.WriteLine(Command.DeleteEntry.GetUsage()); // "delete {id}"
```

## Versioning

We use [Semantic Versioning](https://semver.org/) to clearly communicate changes:

- Major version changes indicate breaking updates
- Minor version changes add features in a backward-compatible way
- Patch version changes include backward-compatible bug fixes
