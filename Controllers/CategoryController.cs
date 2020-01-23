using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_DW.Models;

namespace WebAPI_DW.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        CubeConnection cc = new CubeConnection();
        [Route("")]
        public IEnumerable<ProductCat> GetCategory()
        {
            ProductCat[] result = cc.GetProductsByCategory();
            return result;
        }
    }
}
