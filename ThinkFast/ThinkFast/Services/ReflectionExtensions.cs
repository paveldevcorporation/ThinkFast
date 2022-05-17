using System;
using System.Linq;
using System.Reflection;

namespace ThinkFast.Services
{
	public static class ReflectionExtensions
	{
		public static T[] GetPublicStaticReadonly<T>(this Type type)
		{
			const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

			var valueType = typeof(T);
			return type.GetFields(bindingFlags)
				.Where(f => f.FieldType == valueType)
				.Select(f => (T)f.GetValue(null))
				.ToArray();
		}
	}
}