using System;
using System.Reflection;

namespace EmaAPI.Helpers
{
    public static class GenericMappingHelper
    {
        public static void Map<TSource, TTarget>(TSource source, TTarget target)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source or/and Target objects are null");
            }

            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
            PropertyInfo[] targetProperties = typeof(TTarget).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var targetProperty in targetProperties)
                {
                    if (targetProperty.Name == sourceProperty.Name &&
                        targetProperty.PropertyType == sourceProperty.PropertyType &&
                        targetProperty.CanWrite)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }
        }
    }
}
