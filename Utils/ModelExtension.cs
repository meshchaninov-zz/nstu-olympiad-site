using System;
using System.Reflection;

namespace nstu_olympiad_site.Utils
{
    public static class ModelExtension
    {
        public static T GetAttribute<T>(this Enum value)
            where T: Attribute    
        {
            return (T)value.GetType().GetField(value.ToString()).GetCustomAttribute(typeof(T)); 
        }
    }
}