namespace Ildasm.Me
{
    public class Entity
    {
        public bool Boolean { get; set; }
        public bool? NullableBoolean { get; set; }
        public byte Byte { get; set; }
        public byte? NullableByte { get; set; }
        public sbyte SByte { get; set; }
        public sbyte? NullableSByte { get; set; }
        public char Char { get; set; }
        public char? NullableChar { get; set; }
        public decimal Decimal { get; set; }
        public decimal? NullableDecimal { get; set; }
        public double Double { get; set; }
        public double? NullableDouble { get; set; }
        public float Single { get; set; }
        public float? NullableSingle { get; set; }
        public int Int32 { get; set; }
        public int? NullableInt32 { get; set; }
        public uint UInt32 { get; set; }
        public uint? NullableUInt32 { get; set; }
        public long Int64 { get; set; }
        public long? NullableInt64 { get; set; }
        public ulong UInt64 { get; set; }
        public ulong? NullableUInt64 { get; set; }
        public short Int16 { get; set; }
        public short? NullableInt16 { get; set; }
        public ushort UInt16 { get; set; }
        public ushort? NullableUInt16 { get; set; }
        public string String { get; set; }

        public Nested Nested { get; set; }

        protected bool Equals(Entity other)
        {
            return Boolean == other.Boolean && NullableBoolean == other.NullableBoolean && Byte == other.Byte && NullableByte == other.NullableByte && SByte == other.SByte && NullableSByte == other.NullableSByte
                   && Char == other.Char && NullableChar == other.NullableChar && Decimal == other.Decimal && NullableDecimal == other.NullableDecimal && Double.Equals(other.Double)
                   && NullableDouble.Equals(other.NullableDouble) && Single.Equals(other.Single) && NullableSingle.Equals(other.NullableSingle) && Int32 == other.Int32 && NullableInt32 == other.NullableInt32
                   && UInt32 == other.UInt32 && NullableUInt32 == other.NullableUInt32 && Int64 == other.Int64 && NullableInt64 == other.NullableInt64 && UInt64 == other.UInt64 && NullableUInt64 == other.NullableUInt64
                   && Int16 == other.Int16 && NullableInt16 == other.NullableInt16 && UInt16 == other.UInt16 && NullableUInt16 == other.NullableUInt16 && string.Equals(String, other.String)
                   && Equals(Nested, other.Nested);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Entity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Boolean.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableBoolean.GetHashCode();
                hashCode = (hashCode * 397) ^ Byte.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableByte.GetHashCode();
                hashCode = (hashCode * 397) ^ SByte.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableSByte.GetHashCode();
                hashCode = (hashCode * 397) ^ Char.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableChar.GetHashCode();
                hashCode = (hashCode * 397) ^ Decimal.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableDecimal.GetHashCode();
                hashCode = (hashCode * 397) ^ Double.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableDouble.GetHashCode();
                hashCode = (hashCode * 397) ^ Single.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableSingle.GetHashCode();
                hashCode = (hashCode * 397) ^ Int32;
                hashCode = (hashCode * 397) ^ NullableInt32.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) UInt32;
                hashCode = (hashCode * 397) ^ NullableUInt32.GetHashCode();
                hashCode = (hashCode * 397) ^ Int64.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableInt64.GetHashCode();
                hashCode = (hashCode * 397) ^ UInt64.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableUInt64.GetHashCode();
                hashCode = (hashCode * 397) ^ Int16.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableInt16.GetHashCode();
                hashCode = (hashCode * 397) ^ UInt16.GetHashCode();
                hashCode = (hashCode * 397) ^ NullableUInt16.GetHashCode();
                hashCode = (hashCode * 397) ^ (String != null ? String.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Nested != null ? Nested.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
