using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public static class StaticHelper
{
    public static string ToGetParam<T>(this T obj)
    {
        var parameter = string.Empty;

        var propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property);

        foreach(var propertyInfo in propertyInfos)
        {
            parameter += propertyInfo.Name + "=" + propertyInfo.GetValue(obj) + "&";
        }

        return parameter.Substring(0, parameter.Length - 1);
    }
}
