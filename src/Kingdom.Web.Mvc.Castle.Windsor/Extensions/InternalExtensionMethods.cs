using System.Reflection;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.Windsor;
    using static BindingFlags;

    internal static class InternalExtensionMethods
    {
        private static void InjectFilterProperty(this IWindsorContainer container, IMvcFilter filter,
            PropertyInfo propertyInfo)
        {
            propertyInfo.SetValue(filter, container.Resolve(propertyInfo.PropertyType));
        }

        internal static IWindsorContainer InjectFilter(this IWindsorContainer container, IMvcFilter filter)
        {
            const BindingFlags propertyBindingAttr = Public | Instance | SetProperty;

            var properties = filter.GetType().GetProperties(propertyBindingAttr);

            foreach (var property in properties)
            {
                container.InjectFilterProperty(filter, property);
            }

            return container;
        }
    }
}
