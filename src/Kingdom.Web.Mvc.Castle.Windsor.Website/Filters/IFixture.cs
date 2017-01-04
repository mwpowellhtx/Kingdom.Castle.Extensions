using System.Diagnostics;

namespace Kingdom.Web.Mvc.Castle.Windsor.Website
{
    public interface IFixture
    {
        int Value { get; }
    }

    internal static class FixtureExtensionMethods
    {
        internal static void Verify<T>(this T obj)
            where T : IFixtured, IUnfixtured
        {
            Debug.Assert(obj != null);
            Debug.Assert(obj.Fixtured != null);
            Debug.Assert(obj.Unfixtured == null);
        }
    }
}
