namespace Ildasm.Me
{
    public class NullableEquals
    {
        public bool Equals_0(Entity a, Entity b)
        {
            var valueA = a.NullableInt32;
            var valueB = b.NullableInt32;
            return valueA.GetValueOrDefault() == valueB.GetValueOrDefault() && valueA.HasValue == valueB.HasValue;
        }

        public bool Equals_1(Entity a, Entity b)
        {
            return a.NullableInt32 == b.NullableInt32;
        }

        public bool Equals_3(Entity a, Entity b)
        {
            var valueA = a.NullableInt32;
            var valueB = b.NullableInt32;
            if (!valueA.HasValue && !valueB.HasValue)
                return true;
            if (valueA.HasValue != valueB.HasValue)
                return false;
            return valueA.Value == valueB.Value;
        }

        public bool Equals_2(Entity a, Entity b)
        {
            var valueA = a.NullableInt32;
            var valueB = b.NullableInt32;
            return !valueA.HasValue && !valueB.HasValue || valueA.HasValue == valueB.HasValue && valueA.Value == valueB.Value;
        }

        public bool Equals_4(Entity a, Entity b)
        {
            return !a.NullableInt32.HasValue && !b.NullableInt32.HasValue || a.NullableInt32.HasValue == b.NullableInt32.HasValue && a.NullableInt32.Value == b.NullableInt32.Value;
        }
    }
}
