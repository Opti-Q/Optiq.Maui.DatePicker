using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;

namespace Optiq.DatePicker.Platforms;

public static class ReflectionExtension
{

    public static IEnumerable<FieldInfo> GetFields(this Type type)
    {
        return GetParts(type, i => i.DeclaredFields);
    }

    static IEnumerable<T> GetParts<T>(Type type, Func<TypeInfo, IEnumerable<T>> selector)
    {
        Type? t = type;
        while (t != null)
        {
            TypeInfo ti = t.GetTypeInfo();
            foreach (T f in selector(ti))
                yield return f;
            t = ti.BaseType;
        }
    }
}