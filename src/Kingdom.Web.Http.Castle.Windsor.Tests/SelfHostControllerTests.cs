using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Kingdom.Web.Http.Controllers;
using Newtonsoft.Json;

namespace Kingdom.Web.Http
{
    using Xunit;

    public class SelfHostControllerTests : SelfHostTestFixtureBase<StartupFixture>
    {
        private static string GetUrl()
        {
            // TODO: TBD: completely arbitrary port number(s)...
            var port = new Random().Next(9000, 10000 - 1);
            return $"http://localhost:{port}";
        }

        public SelfHostControllerTests()
            : base(GetUrl())
        {
        }

        [Fact]
        public void VerifyGetResponseFromServer()
        {
            // TODO: TBD: working out core Castle Windsor resolutions at the external library level...
            var response = MakeRequest(client => client.GetAsync("api/items").Result, r => r);
            Assert.NotNull(response);

            var s = response.Content.ReadAsStringAsync().Result;

            Assert.NotNull(s);
            Assert.NotEqual(string.Empty, s);

            var actualItems = JsonConvert.DeserializeObject<int[]>(s);

            Assert.True(actualItems.SequenceEqual(ItemsController.ExpectedItems));
        }

        [Theory
        , InlineData(-1, new int[0])
        , InlineData(0, new[] {0})
        , InlineData(1, new[] {1})
        , InlineData(7, new int[0])
        ]
        public void VerifyGetValueResponseFromServer(int value, int[] expected)
        {
            // TODO: TBD: working out core Castle Windsor resolutions at the external library level...
            var response = MakeRequest(client => client.GetAsync(string.Format("api/items/{0}", value)).Result, r => r);
            Assert.NotNull(response);

            var s = response.Content.ReadAsStringAsync().Result;

            Assert.NotNull(s);
            Assert.NotEqual(string.Empty, s);

            var actual = JsonConvert.DeserializeObject<int[]>(s);

            Assert.NotNull(actual);
            Assert.True(actual.SequenceEqual(expected));
        }
    }
}
