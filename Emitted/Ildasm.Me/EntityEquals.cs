namespace Ildasm.Me
{
    public class EntityEquals
    {
        public bool Equals(Entity a, Entity b)
        {
            return a.Boolean == b.Boolean && a.NullableBoolean == b.NullableBoolean && a.Byte == b.Byte && a.NullableByte == b.NullableByte && a.SByte == b.SByte && a.NullableSByte == b.NullableSByte && a.Char == b.Char
                   && a.NullableChar == b.NullableChar && a.Decimal == b.Decimal && a.NullableDecimal == b.NullableDecimal && a.Double.Equals(b.Double) && a.NullableDouble.Equals(b.NullableDouble)
                   && a.Single.Equals(b.Single) && a.NullableSingle.Equals(b.NullableSingle) && a.Int32 == b.Int32 && a.NullableInt32 == b.NullableInt32 && a.UInt32 == b.UInt32 && a.NullableUInt32 == b.NullableUInt32
                   && a.Int64 == b.Int64 && a.NullableInt64 == b.NullableInt64 && a.UInt64 == b.UInt64 && a.NullableUInt64 == b.NullableUInt64 && a.Int16 == b.Int16 && a.NullableInt16 == b.NullableInt16
                   && a.UInt16 == b.UInt16 && a.NullableUInt16 == b.NullableUInt16 && string.Equals(a.String, b.String) && Equals(a.Nested, b.Nested);
        }
    }
}
