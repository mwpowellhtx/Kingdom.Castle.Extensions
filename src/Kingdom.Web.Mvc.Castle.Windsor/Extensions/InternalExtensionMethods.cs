using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.Core.Internal;
    using Castle.Windsor;
    using static BindingFlags;

    internal static class InternalExtensionMethods
    {
        internal static bool IsAssignableTo<T>(this Type type)
        {
            return typeof(T).IsAssignableFrom(type);
        }

        private static void InjectFilterProperty(this IWindsorContainer container, IMvcFilter filter,
            PropertyInfo propertyInfo)
        {
            propertyInfo.SetValue(filter, container.Resolve(propertyInfo.PropertyType));
        }

        internal static IWindsorContainer InjectFilter(this IWindsorContainer container, IMvcFilter filter)
        {
            const BindingFlags propertyBindingAttr = Public | Instance | SetProperty;

            var properties = filter.GetType().GetProperties(propertyBindingAttr);

            foreach (var property in properties.Where(p => p.HasAttribute<InjectAttribute>()))
            {
                container.InjectFilterProperty(filter, property);
            }

            return container;
        }
    }
}
