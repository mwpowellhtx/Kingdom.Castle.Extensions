using System;

namespace Kingdom.Web.Mvc.Castle.Windsor.Website
{
    public class Fixture : IFixture
    {
        public int Value { get; }

        public Fixture()
        {
            Value = new Random().Next(1, 1000);
        }
    }
}
