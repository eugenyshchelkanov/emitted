using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using GrEmit;

namespace Emitted
{
    public class EqualsEmitter
    {
        private static readonly MethodInfo StringEquals = ((MethodCallExpression) ((Expression<Func<string, string, bool>>) ((x, y) => string.Equals(x, y))).Body).Method;
        private static readonly MethodInfo SingleEquals = ((MethodCallExpression) ((Expression<Func<float, float, bool>>) ((x, y) => x.Equals(x))).Body).Method;
        private static readonly MethodInfo DoubleEquals = ((MethodCallExpression) ((Expression<Func<double, double, bool>>) ((x, y) => x.Equals(x))).Body).Method;
        private static readonly MethodInfo DecimalEquals = ((MethodCallExpression) ((Expression<Func<decimal, decimal, bool>>) ((x, y) => decimal.Equals(x, y))).Body).Method;
        private static readonly MethodInfo ObjectEquals = ((MethodCallExpression) ((Expression<Func<object, object, bool>>) ((x, y) => x.Equals(y))).Body).Method;

        private static readonly MethodInfo EmittedEquals = ((MethodCallExpression) ((Expression<Func<object, object, bool>>) ((x, y) => Emitted.Equals(x, y))).Body).Method;

        private static readonly ISet<Type> BneTypes = new HashSet<Type>
        {
            typeof (bool),
            typeof (byte),
            typeof (sbyte),
            typeof (char),
            typeof (int),
            typeof (uint),
            typeof (long),
            typeof (ulong),
            typeof (short),
            typeof (ushort)
        };

        private static readonly IDictionary<Type, MethodInfo> StaticEqualsTypes = new Dictionary<Type, MethodInfo> { { typeof (string), StringEquals }, { typeof (decimal), DecimalEquals } };
        private static readonly IDictionary<Type, MethodInfo> InstanceEqualsTypes = new Dictionary<Type, MethodInfo> { { typeof (float), SingleEquals }, { typeof (double), DoubleEquals } };

        public static Delegate Emit(Type type)
        {
            Console.WriteLine("EMITTING " + type);
            var method = new DynamicMethod(Guid.NewGuid().ToString(), typeof (bool), new[] { type, type }, type, true);
            using (var il = new GroboIL(method))
            {
                var r0 = il.DefineLabel("Return_0", false);

                // todo: inheritance
                // todo: public/private
                // todo: fields
                // todo: options for public/private, field/property
                var props = type.GetProperties();
                foreach (var propertyInfo in props)
                {
                    // todo: nullable
                    // todo: array
                    // todo: struct (DateTime, Guid)
                    var propertyType = propertyInfo.PropertyType;
                    var nullableType = Nullable.GetUnderlyingType(propertyType);
                    if (BneTypes.Contains(propertyType) || propertyType.IsEnum)
                        EmitBne(il, propertyInfo.GetMethod, r0);
                    else if (StaticEqualsTypes.ContainsKey(propertyType))
                        EmitStatic(il, propertyInfo.GetMethod, StaticEqualsTypes[propertyType], r0);
                    else if (InstanceEqualsTypes.ContainsKey(propertyType))
                        EmitInstance(il, propertyInfo.GetMethod, InstanceEqualsTypes[propertyType], r0);
                    else if (nullableType != null && (BneTypes.Contains(nullableType) || nullableType.IsEnum))
                        EmitNullableBne(il, propertyInfo.GetMethod, r0);
                    else if (nullableType != null)
                        EmitNullableEquals(il, propertyInfo.GetMethod, r0);
                    else
                        EmitStatic(il, propertyInfo.GetMethod, EmittedEquals, r0);
                }

                il.Ldc_I4(1);
                il.Ret();

                il.MarkLabel(r0);
                il.Ldc_I4(0);
                il.Ret();
                Console.WriteLine(il.GetILCode());
            }
            return method.CreateDelegate(typeof(Func<,,>).MakeGenericType(type, type, typeof(bool)));
        }

        private static void EmitBne(GroboIL il, MethodInfo getMethod, GroboIL.Label returnFalse)
        {
            // a.Property == b.Property
            il.Ldarg(0);
            il.Call(getMethod);
            il.Ldarg(1);
            il.Call(getMethod);
            il.Bne_Un(returnFalse);
        }

        private static void EmitInstance(GroboIL il, MethodInfo getMethod, MethodInfo instanceMethod, GroboIL.Label returnFalse)
        {
            // a.Property.Equals(b.Property)
            var type = getMethod.ReturnType;
            var local = il.DeclareLocal(type);
            il.Ldarg(0);
            il.Call(getMethod);
            il.Stloc(local);
            il.Ldloca(local);
            il.Ldarg(1);
            il.Call(getMethod);
            il.Call(instanceMethod, type);
            il.Brfalse(returnFalse);
        }

        private static void EmitStatic(GroboIL il, MethodInfo getMethod, MethodInfo staticMethod, GroboIL.Label returnFalse)
        {
            // Equals(a.Property, b.Property)
            il.Ldarg(0);
            il.Call(getMethod);
            il.Ldarg(1);
            il.Call(getMethod);
            il.Call(staticMethod);
            il.Brfalse(returnFalse);
        }

        private static void EmitNullableBne(GroboIL il, MethodInfo getMethod, GroboIL.Label returnFalse)
        {
            // a.GetValueOrDefault() == b.GetValueOrDefault() && a.HasValue == b.HasValue;
            var type = getMethod.ReturnType;
            var getValueOrDefault = type.GetMethod("GetValueOrDefault", new Type[0]);
            var hasValue = type.GetMethod("get_HasValue");
            var a = il.DeclareLocal(type);
            var b = il.DeclareLocal(type);

            il.Ldarg(0);
            il.Call(getMethod);
            il.Stloc(a);
            il.Ldarg(1);
            il.Call(getMethod);
            il.Stloc(b);

            il.Ldloca(a);
            il.Call(getValueOrDefault);
            il.Ldloca(b);
            il.Call(getValueOrDefault);
            il.Bne_Un(returnFalse);

            il.Ldloca(a);
            il.Call(hasValue);
            il.Ldloca(b);
            il.Call(hasValue);
            il.Bne_Un(returnFalse);
        }

        private static void EmitNullableEquals(GroboIL il, MethodInfo getMethod, GroboIL.Label returnFalse)
        {
            // a.Equals(b)
            var type = getMethod.ReturnType;
            var local = il.DeclareLocal(type);
            il.Ldarg(0);
            il.Call(getMethod);
            il.Stloc(local);
            il.Ldloca(local);
            il.Ldarg(1);
            il.Call(getMethod);
            il.Box(type);
            il.Call(ObjectEquals, type);
            il.Brfalse(returnFalse);
        }
    }
}
