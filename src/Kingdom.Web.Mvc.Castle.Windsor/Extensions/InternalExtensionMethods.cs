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

        private static void InjectObjectField<T>(this IWindsorContainer container, T obj,
            FieldInfo fieldInfo)
        {
            fieldInfo.SetValue(obj, container.Resolve(fieldInfo.FieldType));
        }

        /// <summary>
        /// <see cref="Public"/>, <see cref="NonPublic"/>, <see cref="Instance"/>
        /// </summary>
        private const BindingFlags PublicNonPublicInstance = Public | NonPublic | Instance;

        /// <summary>
        /// Injects the <paramref name="obj"/> corresponding to the given
        /// <paramref name="baseFlags"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="obj"></param>
        /// <param name="baseFlags"></param>
        /// <returns></returns>
        /// <see cref="InjectAttribute"/>
        /// <see cref="InjectObject{TAttribute}"/>
        internal static IWindsorContainer InjectObject(this IWindsorContainer container,
            object obj, BindingFlags baseFlags = PublicNonPublicInstance)
        {
            return container.InjectObject<InjectAttribute>(obj, baseFlags);
        }

        /// <summary>
        /// Injects the <paramref name="obj"/> corresponding to the given
        /// <paramref name="baseFlags"/>, defaulting to <see cref="Public"/>,
        /// <see cref="NonPublic"/>, <see cref="Instance"/>, <see cref="SetProperty"/>,
        /// and <see cref="SetField"/>.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="container"></param>
        /// <param name="obj"></param>
        /// <param name="baseFlags"></param>
        /// <returns></returns>
        internal static IWindsorContainer InjectObject<TAttribute>(this IWindsorContainer container,
            object obj, BindingFlags baseFlags = PublicNonPublicInstance)
            where TAttribute : Attribute, IInjectionAttribute
        {
            if (obj == null) return container;

            var objType = obj.GetType();

            {
                var properties = objType.GetProperties(baseFlags | SetProperty);

                foreach (var property in properties.Where(p => p.HasAttribute<TAttribute>()))
                {
                    container.InjectObjectProperty(obj, property);
                }
            }

            {
                var fields = objType.GetFields(baseFlags | SetField);

                foreach (var field in fields.Where(f => f.HasAttribute<TAttribute>()))
                {
                    container.InjectObjectField(obj, field);
                }
            }

            return container;
        }
    }
}
