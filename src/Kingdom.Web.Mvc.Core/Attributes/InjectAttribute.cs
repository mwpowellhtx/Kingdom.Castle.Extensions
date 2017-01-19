using System;
using System.Runtime.InteropServices;

namespace Kingdom.Web.Mvc
{
    using static AttributeTargets;

    /// <summary>
    /// Decorate the properties you want Injected by the Castle Windsor, Autofac, or which ever
    /// other container property resolution strategy. At the moment this applies only for Filters
    /// that require injection.
    /// </summary>
    [AttributeUsage(Property | Field)]
    public class InjectAttribute : Attribute, IInjectionAttribute
    {
    }

    /// <summary>
    /// Whichever <see cref="Attribute"/> you use, should implement <see cref="IInjectionAttribute"/>.
    /// </summary>
    public interface IInjectionAttribute : _Attribute
    {
    }
}
