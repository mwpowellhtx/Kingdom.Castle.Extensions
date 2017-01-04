using System;
using System.Linq;
using System.Reflection;

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

        private static void InjectObjectProperty<T>(this IWindsorContainer container, T obj,
            PropertyInfo propertyInfo)
        {
            propertyInfo.SetValue(obj, container.Resolve(propertyInfo.PropertyType));
        }

        /// <summary>
        /// Injects the Object corresponding with the <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static IWindsorContainer InjectObject<T>(this IWindsorContainer container, T obj)
        {
            const BindingFlags propertyBindingAttr = Public | Instance | SetProperty;

            var properties = obj.GetType().GetProperties(propertyBindingAttr);

            foreach (var property in properties.Where(p => p.HasAttribute<InjectAttribute>()))
            {
                container.InjectObjectProperty(obj, property);
            }

            return container;
        }
    }
}
