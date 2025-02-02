using Shouldly;

namespace NocturnalGroup.ValuableEnums.Tests.Unit;

public class NamespacedTests
{
	[Fact]
	public void DefaultValues_Should_ReturnDefaultValues()
	{
		NamespacedEnum.DefaultValues.GetTypeBool().ShouldBe(true);
		NamespacedEnum.DefaultValues.GetTypeBoolArray().ShouldBe([true, true]);

		NamespacedEnum.DefaultValues.GetTypeSByte().ShouldBe((sbyte)32);
		NamespacedEnum.DefaultValues.GetTypeSByteArray().ShouldBe([32, 32]);

		NamespacedEnum.DefaultValues.GetTypeShort().ShouldBe((short)32);
		NamespacedEnum.DefaultValues.GetTypeShortArray().ShouldBe([32, 32]);

		NamespacedEnum.DefaultValues.GetTypeInt().ShouldBe(32);
		NamespacedEnum.DefaultValues.GetTypeIntArray().ShouldBe([32, 32]);

		NamespacedEnum.DefaultValues.GetTypeLong().ShouldBe(32);
		NamespacedEnum.DefaultValues.GetTypeLongArray().ShouldBe([32, 32]);

		NamespacedEnum.DefaultValues.GetTypeByte().ShouldBe((byte)32);
		NamespacedEnum.DefaultValues.GetTypeByteArray().ShouldBe([32, 32]);

		NamespacedEnum.DefaultValues.GetTypeUShort().ShouldBe((ushort)32);
		NamespacedEnum.DefaultValues.GetTypeUShortArray().ShouldBe([32, 32]);

		NamespacedEnum.DefaultValues.GetTypeUInt().ShouldBe((uint)32);
		NamespacedEnum.DefaultValues.GetTypeUIntArray().ShouldBe([32, 32]);

		NamespacedEnum.DefaultValues.GetTypeULong().ShouldBe((ulong)32);
		NamespacedEnum.DefaultValues.GetTypeULongArray().ShouldBe([32, 32]);

		NamespacedEnum.DefaultValues.GetTypeFloat().ShouldBe(3.2f);
		NamespacedEnum.DefaultValues.GetTypeFloatArray().ShouldBe([3.2f, 3.2f]);

		NamespacedEnum.DefaultValues.GetTypeDouble().ShouldBe(3.2d);
		NamespacedEnum.DefaultValues.GetTypeDoubleArray().ShouldBe([3.2d, 3.2d]);

		NamespacedEnum.DefaultValues.GetTypeChar().ShouldBe('n');
		NamespacedEnum.DefaultValues.GetTypeCharArray().ShouldBe(['n', 'n']);

		NamespacedEnum.DefaultValues.GetTypeString().ShouldBe("{[Nocturnal]}");
		NamespacedEnum.DefaultValues.GetTypeStringArray().ShouldBe(["Nocturnal", "Nocturnal"]);

		NamespacedEnum.DefaultValues.GetTypeEnum().ShouldBe(TestEnum.Default);
		NamespacedEnum.DefaultValues.GetTypeEnumArray().ShouldBe([TestEnum.Default, TestEnum.Default]);
		NamespacedEnum.DefaultValues.GetTypeEnumArrayExpression().ShouldBe([TestEnum.Default, TestEnum.Default]);
	}

	[Fact]
	public void OneOverride_Should_ReturnDefaultValues_OtherThan_TypeBool()
	{
		NamespacedEnum.OneOverride.GetTypeBool().ShouldBe(false);
		NamespacedEnum.OneOverride.GetTypeBoolArray().ShouldBe([true, true]);

		NamespacedEnum.OneOverride.GetTypeSByte().ShouldBe((sbyte)32);
		NamespacedEnum.OneOverride.GetTypeSByteArray().ShouldBe([32, 32]);

		NamespacedEnum.OneOverride.GetTypeShort().ShouldBe((short)32);
		NamespacedEnum.OneOverride.GetTypeShortArray().ShouldBe([32, 32]);

		NamespacedEnum.OneOverride.GetTypeInt().ShouldBe(32);
		NamespacedEnum.OneOverride.GetTypeIntArray().ShouldBe([32, 32]);

		NamespacedEnum.OneOverride.GetTypeLong().ShouldBe(32);
		NamespacedEnum.OneOverride.GetTypeLongArray().ShouldBe([32, 32]);

		NamespacedEnum.OneOverride.GetTypeByte().ShouldBe((byte)32);
		NamespacedEnum.OneOverride.GetTypeByteArray().ShouldBe([32, 32]);

		NamespacedEnum.OneOverride.GetTypeUShort().ShouldBe((ushort)32);
		NamespacedEnum.OneOverride.GetTypeUShortArray().ShouldBe([32, 32]);

		NamespacedEnum.OneOverride.GetTypeUInt().ShouldBe((uint)32);
		NamespacedEnum.OneOverride.GetTypeUIntArray().ShouldBe([32, 32]);

		NamespacedEnum.OneOverride.GetTypeULong().ShouldBe((ulong)32);
		NamespacedEnum.OneOverride.GetTypeULongArray().ShouldBe([32, 32]);

		NamespacedEnum.OneOverride.GetTypeFloat().ShouldBe(3.2f);
		NamespacedEnum.OneOverride.GetTypeFloatArray().ShouldBe([3.2f, 3.2f]);

		NamespacedEnum.OneOverride.GetTypeDouble().ShouldBe(3.2d);
		NamespacedEnum.OneOverride.GetTypeDoubleArray().ShouldBe([3.2d, 3.2d]);

		NamespacedEnum.OneOverride.GetTypeChar().ShouldBe('n');
		NamespacedEnum.OneOverride.GetTypeCharArray().ShouldBe(['n', 'n']);

		NamespacedEnum.OneOverride.GetTypeString().ShouldBe("{[Nocturnal]}");
		NamespacedEnum.OneOverride.GetTypeStringArray().ShouldBe(["Nocturnal", "Nocturnal"]);

		NamespacedEnum.OneOverride.GetTypeEnum().ShouldBe(TestEnum.Default);
		NamespacedEnum.OneOverride.GetTypeEnumArray().ShouldBe([TestEnum.Default, TestEnum.Default]);
		NamespacedEnum.OneOverride.GetTypeEnumArrayExpression().ShouldBe([TestEnum.Default, TestEnum.Default]);
	}

	[Fact]
	public void AllOverrides_Should_ReturnOverrideValues()
	{
		NamespacedEnum.AllOverrides.GetTypeBool().ShouldBe(false);
		NamespacedEnum.AllOverrides.GetTypeBoolArray().ShouldBe([false, false]);

		NamespacedEnum.AllOverrides.GetTypeSByte().ShouldBe((sbyte)64);
		NamespacedEnum.AllOverrides.GetTypeSByteArray().ShouldBe([64, 64]);

		NamespacedEnum.AllOverrides.GetTypeShort().ShouldBe((short)64);
		NamespacedEnum.AllOverrides.GetTypeShortArray().ShouldBe([64, 64]);

		NamespacedEnum.AllOverrides.GetTypeInt().ShouldBe(64);
		NamespacedEnum.AllOverrides.GetTypeIntArray().ShouldBe([64, 64]);

		NamespacedEnum.AllOverrides.GetTypeLong().ShouldBe(64);
		NamespacedEnum.AllOverrides.GetTypeLongArray().ShouldBe([64, 64]);

		NamespacedEnum.AllOverrides.GetTypeByte().ShouldBe((byte)64);
		NamespacedEnum.AllOverrides.GetTypeByteArray().ShouldBe([64, 64]);

		NamespacedEnum.AllOverrides.GetTypeUShort().ShouldBe((ushort)64);
		NamespacedEnum.AllOverrides.GetTypeUShortArray().ShouldBe([64, 64]);

		NamespacedEnum.AllOverrides.GetTypeUInt().ShouldBe((uint)64);
		NamespacedEnum.AllOverrides.GetTypeUIntArray().ShouldBe([64, 64]);

		NamespacedEnum.AllOverrides.GetTypeULong().ShouldBe((ulong)64);
		NamespacedEnum.AllOverrides.GetTypeULongArray().ShouldBe([64, 64]);

		NamespacedEnum.AllOverrides.GetTypeFloat().ShouldBe(6.4f);
		NamespacedEnum.AllOverrides.GetTypeFloatArray().ShouldBe([6.4f, 6.4f]);

		NamespacedEnum.AllOverrides.GetTypeDouble().ShouldBe(6.4d);
		NamespacedEnum.AllOverrides.GetTypeDoubleArray().ShouldBe([6.4d, 6.4d]);

		NamespacedEnum.AllOverrides.GetTypeChar().ShouldBe('g');
		NamespacedEnum.AllOverrides.GetTypeCharArray().ShouldBe(['g', 'g']);

		NamespacedEnum.AllOverrides.GetTypeString().ShouldBe("{[Group]}");
		NamespacedEnum.AllOverrides.GetTypeStringArray().ShouldBe(["Group", "Group"]);

		NamespacedEnum.AllOverrides.GetTypeEnum().ShouldBe(TestEnum.Override);
		NamespacedEnum.AllOverrides.GetTypeEnumArray().ShouldBe([TestEnum.Override, TestEnum.Override]);
		NamespacedEnum.AllOverrides.GetTypeEnumArrayExpression().ShouldBe([TestEnum.Override, TestEnum.Override]);
	}
}
