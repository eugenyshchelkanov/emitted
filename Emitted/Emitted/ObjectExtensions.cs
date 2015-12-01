namespace Emitted
{
    public static class ObjectExtensions
    {
        public static bool EmittedEquals<T>(this T self, T other)
        {
            return Emitted.Equals(self, other);
        }
    }
}
