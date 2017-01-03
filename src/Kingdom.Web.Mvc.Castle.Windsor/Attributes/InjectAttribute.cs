using System;

namespace Kingdom.Web.Mvc
{
    /// <summary>
    /// Decorate the properties you want Injected by the Castle Windsor property resolution
    /// strategy. At the moment this applies only for Filters that require injection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class InjectAttribute : Attribute
    {
    }
}
