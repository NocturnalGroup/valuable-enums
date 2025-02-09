using Shouldly;

namespace NocturnalGroup.ValuableEnums.Tests.Unit;

public class NonNamespacedTests
{
	[Fact]
	public void DefaultValues_Should_ReturnDefaultValues()
	{
		NonNamespacedEnum.DefaultValues.GetTypeBool().ShouldBe(true);
		NonNamespacedEnum.DefaultValues.GetTypeBoolArray().ShouldBe([true, true]);

		NonNamespacedEnum.DefaultValues.GetTypeSByte().ShouldBe((sbyte)32);
		NonNamespacedEnum.DefaultValues.GetTypeSByteArray().ShouldBe([32, 32]);

		NonNamespacedEnum.DefaultValues.GetTypeShort().ShouldBe((short)32);
		NonNamespacedEnum.DefaultValues.GetTypeShortArray().ShouldBe([32, 32]);

		NonNamespacedEnum.DefaultValues.GetTypeInt().ShouldBe(32);
		NonNamespacedEnum.DefaultValues.GetTypeIntArray().ShouldBe([32, 32]);

		NonNamespacedEnum.DefaultValues.GetTypeLong().ShouldBe(32);
		NonNamespacedEnum.DefaultValues.GetTypeLongArray().ShouldBe([32, 32]);

		NonNamespacedEnum.DefaultValues.GetTypeByte().ShouldBe((byte)32);
		NonNamespacedEnum.DefaultValues.GetTypeByteArray().ShouldBe([32, 32]);

		NonNamespacedEnum.DefaultValues.GetTypeUShort().ShouldBe((ushort)32);
		NonNamespacedEnum.DefaultValues.GetTypeUShortArray().ShouldBe([32, 32]);

		NonNamespacedEnum.DefaultValues.GetTypeUInt().ShouldBe((uint)32);
		NonNamespacedEnum.DefaultValues.GetTypeUIntArray().ShouldBe([32, 32]);

		NonNamespacedEnum.DefaultValues.GetTypeULong().ShouldBe((ulong)32);
		NonNamespacedEnum.DefaultValues.GetTypeULongArray().ShouldBe([32, 32]);

		NonNamespacedEnum.DefaultValues.GetTypeFloat().ShouldBe(3.2f);
		NonNamespacedEnum.DefaultValues.GetTypeFloatArray().ShouldBe([3.2f, 3.2f]);

		NonNamespacedEnum.DefaultValues.GetTypeDouble().ShouldBe(3.2d);
		NonNamespacedEnum.DefaultValues.GetTypeDoubleArray().ShouldBe([3.2d, 3.2d]);

		NonNamespacedEnum.DefaultValues.GetTypeChar().ShouldBe('n');
		NonNamespacedEnum.DefaultValues.GetTypeCharArray().ShouldBe(['n', 'n']);

		NonNamespacedEnum.DefaultValues.GetTypeString().ShouldBe("{[Nocturnal]}");
		NonNamespacedEnum.DefaultValues.GetTypeStringArray().ShouldBe(["Nocturnal", "Nocturnal"]);

		NonNamespacedEnum.DefaultValues.GetTypeEnum().ShouldBe(TestEnum2.Default);
		NonNamespacedEnum.DefaultValues.GetTypeEnumArray().ShouldBe([TestEnum2.Default, TestEnum2.Default]);
		NonNamespacedEnum.DefaultValues.GetTypeEnumArrayExpression().ShouldBe([TestEnum2.Default, TestEnum2.Default]);
	}

	[Fact]
	public void OneOverride_Should_ReturnDefaultValues_OtherThan_TypeBool()
	{
		NonNamespacedEnum.OneOverride.GetTypeBool().ShouldBe(false);
		NonNamespacedEnum.OneOverride.GetTypeBoolArray().ShouldBe([true, true]);

		NonNamespacedEnum.OneOverride.GetTypeSByte().ShouldBe((sbyte)32);
		NonNamespacedEnum.OneOverride.GetTypeSByteArray().ShouldBe([32, 32]);

		NonNamespacedEnum.OneOverride.GetTypeShort().ShouldBe((short)32);
		NonNamespacedEnum.OneOverride.GetTypeShortArray().ShouldBe([32, 32]);

		NonNamespacedEnum.OneOverride.GetTypeInt().ShouldBe(32);
		NonNamespacedEnum.OneOverride.GetTypeIntArray().ShouldBe([32, 32]);

		NonNamespacedEnum.OneOverride.GetTypeLong().ShouldBe(32);
		NonNamespacedEnum.OneOverride.GetTypeLongArray().ShouldBe([32, 32]);

		NonNamespacedEnum.OneOverride.GetTypeByte().ShouldBe((byte)32);
		NonNamespacedEnum.OneOverride.GetTypeByteArray().ShouldBe([32, 32]);

		NonNamespacedEnum.OneOverride.GetTypeUShort().ShouldBe((ushort)32);
		NonNamespacedEnum.OneOverride.GetTypeUShortArray().ShouldBe([32, 32]);

		NonNamespacedEnum.OneOverride.GetTypeUInt().ShouldBe((uint)32);
		NonNamespacedEnum.OneOverride.GetTypeUIntArray().ShouldBe([32, 32]);

		NonNamespacedEnum.OneOverride.GetTypeULong().ShouldBe((ulong)32);
		NonNamespacedEnum.OneOverride.GetTypeULongArray().ShouldBe([32, 32]);

		NonNamespacedEnum.OneOverride.GetTypeFloat().ShouldBe(3.2f);
		NonNamespacedEnum.OneOverride.GetTypeFloatArray().ShouldBe([3.2f, 3.2f]);

		NonNamespacedEnum.OneOverride.GetTypeDouble().ShouldBe(3.2d);
		NonNamespacedEnum.OneOverride.GetTypeDoubleArray().ShouldBe([3.2d, 3.2d]);

		NonNamespacedEnum.OneOverride.GetTypeChar().ShouldBe('n');
		NonNamespacedEnum.OneOverride.GetTypeCharArray().ShouldBe(['n', 'n']);

		NonNamespacedEnum.OneOverride.GetTypeString().ShouldBe("{[Nocturnal]}");
		NonNamespacedEnum.OneOverride.GetTypeStringArray().ShouldBe(["Nocturnal", "Nocturnal"]);

		NonNamespacedEnum.OneOverride.GetTypeEnum().ShouldBe(TestEnum2.Default);
		NonNamespacedEnum.OneOverride.GetTypeEnumArray().ShouldBe([TestEnum2.Default, TestEnum2.Default]);
		NonNamespacedEnum.OneOverride.GetTypeEnumArrayExpression().ShouldBe([TestEnum2.Default, TestEnum2.Default]);
	}

	[Fact]
	public void AllOverrides_Should_ReturnOverrideValues()
	{
		NonNamespacedEnum.AllOverrides.GetTypeBool().ShouldBe(false);
		NonNamespacedEnum.AllOverrides.GetTypeBoolArray().ShouldBe([false, false]);

		NonNamespacedEnum.AllOverrides.GetTypeSByte().ShouldBe((sbyte)64);
		NonNamespacedEnum.AllOverrides.GetTypeSByteArray().ShouldBe([64, 64]);

		NonNamespacedEnum.AllOverrides.GetTypeShort().ShouldBe((short)64);
		NonNamespacedEnum.AllOverrides.GetTypeShortArray().ShouldBe([64, 64]);

		NonNamespacedEnum.AllOverrides.GetTypeInt().ShouldBe(64);
		NonNamespacedEnum.AllOverrides.GetTypeIntArray().ShouldBe([64, 64]);

		NonNamespacedEnum.AllOverrides.GetTypeLong().ShouldBe(64);
		NonNamespacedEnum.AllOverrides.GetTypeLongArray().ShouldBe([64, 64]);

		NonNamespacedEnum.AllOverrides.GetTypeByte().ShouldBe((byte)64);
		NonNamespacedEnum.AllOverrides.GetTypeByteArray().ShouldBe([64, 64]);

		NonNamespacedEnum.AllOverrides.GetTypeUShort().ShouldBe((ushort)64);
		NonNamespacedEnum.AllOverrides.GetTypeUShortArray().ShouldBe([64, 64]);

		NonNamespacedEnum.AllOverrides.GetTypeUInt().ShouldBe((uint)64);
		NonNamespacedEnum.AllOverrides.GetTypeUIntArray().ShouldBe([64, 64]);

		NonNamespacedEnum.AllOverrides.GetTypeULong().ShouldBe((ulong)64);
		NonNamespacedEnum.AllOverrides.GetTypeULongArray().ShouldBe([64, 64]);

		NonNamespacedEnum.AllOverrides.GetTypeFloat().ShouldBe(6.4f);
		NonNamespacedEnum.AllOverrides.GetTypeFloatArray().ShouldBe([6.4f, 6.4f]);

		NonNamespacedEnum.AllOverrides.GetTypeDouble().ShouldBe(6.4d);
		NonNamespacedEnum.AllOverrides.GetTypeDoubleArray().ShouldBe([6.4d, 6.4d]);

		NonNamespacedEnum.AllOverrides.GetTypeChar().ShouldBe('g');
		NonNamespacedEnum.AllOverrides.GetTypeCharArray().ShouldBe(['g', 'g']);

		NonNamespacedEnum.AllOverrides.GetTypeString().ShouldBe("{[Group]}");
		NonNamespacedEnum.AllOverrides.GetTypeStringArray().ShouldBe(["Group", "Group"]);

		NonNamespacedEnum.AllOverrides.GetTypeEnum().ShouldBe(TestEnum2.Override);
		NonNamespacedEnum.AllOverrides.GetTypeEnumArray().ShouldBe([TestEnum2.Override, TestEnum2.Override]);
		NonNamespacedEnum.AllOverrides.GetTypeEnumArrayExpression().ShouldBe([TestEnum2.Override, TestEnum2.Override]);
	}
}
