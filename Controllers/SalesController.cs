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
    [RoutePrefix("api/sales")]
    public class SalesController : ApiController
    {
        CubeConnection cc = new CubeConnection();

        [Route("Year")]
        public IEnumerable<SCYear> GetYear()
        {
            SCYear[] result = cc.GetSalesPrYear();
            return result;
        }

        [Route("month")]
        public IEnumerable<SCMonth> GetMonths()
        {
            SCMonth[] result = cc.GetSalesPrMonth();
            return result;
        }

        [Route("day")]
        public IEnumerable<SCDay> GetDays()
        {
            SCDay[] result = cc.GetSalesPrDay();
            return result;
        }

        [Route("members")]
        public IEnumerable<MemberSales> GetMembers()
        {
            MemberSales[] result = cc.GetSalesPrMember();
            return result;
        }

        [Route("semester")]
        public IEnumerable<SemesterSales> GetSemesters()
        {
            SemesterSales[] result = cc.GetSalesPrSemester();
            return result;
        }
    }
}
