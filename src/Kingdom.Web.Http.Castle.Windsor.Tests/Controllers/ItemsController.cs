using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Kingdom.Web.Http.Controllers
{
    public class ItemsController : ApiController
    {
        public IEnumerable<int> Get()
        {
            return ExpectedItems.ToArray();
        }

        public IEnumerable<int> Get(int id)
        {
            return ExpectedItems.Where(x => x == id).ToArray();
        }

        internal static IEnumerable<int> ExpectedItems
        {
            get
            {
                yield return 0;
                yield return 1;
                yield return 2;
                yield return 3;
                yield return 4;
                yield return 5;
                yield return 6;
            }
        }
    }
}
