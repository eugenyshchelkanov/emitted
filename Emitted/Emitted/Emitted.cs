using System;
using System.Collections.Generic;

namespace Emitted
{
    public static class Emitted
    {
        private static readonly IDictionary<Type, Delegate> cache = new Dictionary<Type, Delegate>();
        private static readonly object @lock = new object();

        public static bool Equals(object self, object other)
        {
            if (ReferenceEquals(self, other))
                return true;
            if (ReferenceEquals(self, null) || ReferenceEquals(other, null))
                return false;
            if (self.GetType() != other.GetType())
                return false;

            var type = self.GetType();

            Delegate @delegate;
            if (!cache.TryGetValue(type, out @delegate))
            {
                lock (@lock)
                {
                    if (!cache.TryGetValue(type, out @delegate))
                        @delegate = cache[type] = EqualsEmitter.Emit(type);
                }
            }
            return (bool)@delegate.DynamicInvoke(self, other);
        }
    }
}