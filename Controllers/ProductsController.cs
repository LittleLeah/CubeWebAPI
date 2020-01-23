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
    [RoutePrefix("api/sales/products")]
    public class ProductsController : ApiController
    {
        CubeConnection cc = new CubeConnection();

        [Route("year")]
        public IEnumerable<SCCatY> GetYear()
        {
            SCCatY[] result = cc.GetProductSalesPrYear();
            return result;
        }

        [Route("month")]
        public IEnumerable<SCCatM> GetMonths()
        {
            SCCatM[] result = cc.GetProductSalesPrMonth();
            return result;
        }

        [Route("day")]
        public IEnumerable<SCCatD> GetDays()
        {
            SCCatD[] result = cc.GetProductSalesPrDay();
            return result;
        }

        
    }
}
