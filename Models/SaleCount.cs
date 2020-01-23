using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_DW.Models
{
    public class SaleCount
    {
        public int saleCount;
       
    }

    public class SCYear : SaleCount
    {
        public int year;
    }

    public class SCMonth : SaleCount
    {
        public int month;
    }

    public class SCDay : SaleCount
    {
        public int day;
    }

    public class SCCatY : SCYear
    {
        
        public string cat;
    }

    public class SCCatM : SCMonth
    {
        
        public string cat;
    }

    public class SCCatD : SCDay
    {
        
        public string cat;
    }

    public class MemberSales : SaleCount
    {
        public int memberID;
        public string semester;
    }

    public class ProductCat 
    {
        public int productID;
        public string name;
        public string cat;
        public string subCat;
        public string subSubCat;
    }

    public class SemesterSales : SaleCount
    {
        public string semester;
        public string SubSubCategory;
    }

 
}