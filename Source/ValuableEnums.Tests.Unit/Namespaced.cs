namespace NocturnalGroup.ValuableEnums.Tests.Unit;

[EnumField<bool>("typeBool", true)]
[EnumField<bool[]>("typeBoolArray", [true, true])]

[EnumField<sbyte>("typeSByte", 32)]
[EnumField<sbyte[]>("typeSByteArray", [32, 32])]

[EnumField<short>("typeShort", 32)]
[EnumField<short[]>("typeShortArray", [32, 32])]

[EnumField<int>("typeInt", 32)]
[EnumField<int[]>("typeIntArray", [32, 32])]

[EnumField<long>("typeLong", 32)]
[EnumField<long[]>("typeLongArray", [32, 32])]

[EnumField<byte>("typeByte", 32)]
[EnumField<byte[]>("typeByteArray", [32, 32])]

[EnumField<ushort>("typeUShort", 32)]
[EnumField<ushort[]>("typeUShortArray", [32, 32])]

[EnumField<uint>("typeUInt", 32)]
[EnumField<uint[]>("typeUIntArray", [32, 32])]

[EnumField<ulong>("typeULong", 32)]
[EnumField<ulong[]>("typeULongArray", [32, 32])]

[EnumField<float>("typeFloat", 3.2f)]
[EnumField<float[]>("typeFloatArray", [3.2f, 3.2f])]

[EnumField<double>("typeDouble", 3.2d)]
[EnumField<double[]>("typeDoubleArray", [3.2d, 3.2d])]

[EnumField<char>("typeChar", 'n')]
[EnumField<char[]>("typeCharArray", ['n', 'n'])]

[EnumField<string>("typeString", "{[Nocturnal]}")] // Brackets to test array parsing
[EnumField<string[]>("typeStringArray", ["Nocturnal", "Nocturnal"])]

[EnumField<TestEnum>("typeEnum", TestEnum.Default)]
[EnumField<TestEnum[]>("typeEnumArray", new TestEnum[] {TestEnum.Default, TestEnum.Default})]
[EnumField<TestEnum[]>("typeEnumArrayExpression", [TestEnum.Default, TestEnum.Default])]
public enum NamespacedEnum
{
	DefaultValues = 0,

	[EnumField<bool>("typeBool", false)]
	OneOverride = 1,

	[EnumField<bool>("typeBool", false)]
	[EnumField<bool[]>("typeBoolArray", [false, false])]

	[EnumField<sbyte>("typeSByte", 64)]
	[EnumField<sbyte[]>("typeSByteArray", [64, 64])]

	[EnumField<short>("typeShort", 64)]
	[EnumField<short[]>("typeShortArray", [64, 64])]

	[EnumField<int>("typeInt", 64)]
	[EnumField<int[]>("typeIntArray", [64, 64])]

	[EnumField<long>("typeLong", 64)]
	[EnumField<long[]>("typeLongArray", [64, 64])]

	[EnumField<byte>("typeByte", 64)]
	[EnumField<byte[]>("typeByteArray", [64, 64])]

	[EnumField<ushort>("typeUShort", 64)]
	[EnumField<ushort[]>("typeUShortArray", [64, 64])]

	[EnumField<uint>("typeUInt", 64)]
	[EnumField<uint[]>("typeUIntArray", [64, 64])]

	[EnumField<ulong>("typeULong", 64)]
	[EnumField<ulong[]>("typeULongArray", [64, 64])]

	[EnumField<float>("typeFloat", 6.4f)]
	[EnumField<float[]>("typeFloatArray", [6.4f, 6.4f])]

	[EnumField<double>("typeDouble", 6.4d)]
	[EnumField<double[]>("typeDoubleArray", [6.4d, 6.4d])]

	[EnumField<char>("typeChar", 'g')]
	[EnumField<char[]>("typeCharArray", ['g', 'g'])]

	[EnumField<string>("typeString", "{[Group]}")]
	[EnumField<string[]>("typeStringArray", ["Group", "Group"])]

	[EnumField<TestEnum>("typeEnum", TestEnum.Override)]
	[EnumField<TestEnum[]>("typeEnumArray", new TestEnum[] {TestEnum.Override, TestEnum.Override})]
	[EnumField<TestEnum[]>("typeEnumArrayExpression", [TestEnum.Override, TestEnum.Override])]
	AllOverrides = 2,
}

public enum TestEnum
{
	Default = 0,
	Override = 1,
}
