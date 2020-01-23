using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Microsoft.AnalysisServices.AdomdClient;
using WebAPI_DW.Models;


namespace WebAPI_DW.Controllers
{
    public class CubeConnection
    {
        
        public SCYear[] GetSalesPrYear()
        {
            
            StringBuilder result = new StringBuilder();

            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT [Measures].[Fact Sale Count] ON COLUMNS,
	                                NONEMPTY( {[Dim Date].[Year].[Year]} ) ON ROWS
                                    FROM [F Club DW]";
                CellSet cs = cmd.ExecuteCellSet();


                TupleCollection tuplesOnColumns = cs.Axes[0].Set.Tuples;

                TupleCollection tupleCollection = cs.Axes[1].Set.Tuples;
                SCYear[] yearSales = new SCYear[tupleCollection.Count];
                for (int row = 0; row < tupleCollection.Count; row++)
                {
                    SCYear year = new SCYear();
                    year.year = int.Parse(tupleCollection[row].Members[0].Caption);

                    for (int col = 0; col < tuplesOnColumns.Count; col++)
                    {

                        year.saleCount = int.Parse(cs.Cells[col, row].FormattedValue);
                        yearSales[row] = year;
                    }
                
                }
                
                conn.Close();
                
                return yearSales;
               
            }
           
        }

        public SCMonth[] GetSalesPrMonth()
        {

            StringBuilder result = new StringBuilder();

            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT [Measures].[Fact Sale Count] ON COLUMNS,
	                                NONEMPTY( {[Dim Date].[Month].[Month]} ) ON ROWS
                                    FROM [F Club DW]";
                CellSet cs = cmd.ExecuteCellSet();


                TupleCollection tuplesOnColumns = cs.Axes[0].Set.Tuples;

                TupleCollection tupleCollection = cs.Axes[1].Set.Tuples;
                SCMonth[] monthSales = new SCMonth[tupleCollection.Count];
                for (int row = 0; row < tupleCollection.Count; row++)
                {
                    SCMonth month = new SCMonth();
                    month.month = int.Parse(tupleCollection[row].Members[0].Caption);

                    for (int col = 0; col < tuplesOnColumns.Count; col++)
                    {

                        month.saleCount = int.Parse(cs.Cells[col, row].FormattedValue);
                        monthSales[row] = month;
                    }

                }

                conn.Close();

                return monthSales;

            }

        }

        public SCDay[] GetSalesPrDay()
        {

            StringBuilder result = new StringBuilder();

            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT [Measures].[Fact Sale Count] ON COLUMNS,
	                                NONEMPTY( {[Dim Date].[Day].[Day]} ) ON ROWS
                                    FROM [F Club DW]";
                CellSet cs = cmd.ExecuteCellSet();

                TupleCollection tuplesOnColumns = cs.Axes[0].Set.Tuples;

                TupleCollection tupleCollection = cs.Axes[1].Set.Tuples;
                SCDay[] daySales = new SCDay[tupleCollection.Count];
                for (int row = 0; row < tupleCollection.Count; row++)
                {
                    SCDay day = new SCDay
                    {
                        day = int.Parse(tupleCollection[row].Members[0].Caption)
                    };
                    

                    for (int col = 0; col < tuplesOnColumns.Count; col++)
                    {

                        day.saleCount = int.Parse(cs.Cells[col, row].FormattedValue);
                        daySales[row] = day;
                    }

                }

                conn.Close();

                return daySales;

            }

        }

        public SCCatY[] GetProductSalesPrYear()
        {

          
            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                                    SELECT [Measures].[Fact Sale Count] ON COLUMNS,
                                        NONEMPTY( [Dim Product].[Category].[Category]*[Dim Date].[Year].[Year]) ON ROWS
                                    FROM [F Club DW]";
                AdomdDataReader dr = cmd.ExecuteReader();
                List<SCCatY> years = new List<SCCatY>();
                while (dr.Read())
                {
                    SCCatY year = new SCCatY
                    {
                        cat = dr[0].ToString(),
                        year = int.Parse(dr[1].ToString()),
                        saleCount = int.Parse(dr[2].ToString())
                    };

                    years.Add(year);

                }
                dr.Close();


                SCCatY[] yearSales = years.ToArray();
               
                conn.Close();

                return yearSales;

            }

        }

        public SCCatM[] GetProductSalesPrMonth()
        {

            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                                    SELECT [Measures].[Fact Sale Count] ON COLUMNS,
                                        NONEMPTY( [Dim Product].[Category].[Category]*[Dim Date].[Month].[Month]) ON ROWS
                                    FROM [F Club DW]";
                AdomdDataReader dr = cmd.ExecuteReader();
                List<SCCatM> months = new List<SCCatM>();
                while (dr.Read())
                {
                    SCCatM month = new SCCatM
                    {
                        cat = dr[0].ToString(),
                        month = int.Parse(dr[1].ToString()),
                        saleCount = int.Parse(dr[2].ToString())
                    };

                    months.Add(month);

                }
                dr.Close();

                SCCatM[] monthSales = months.ToArray();

                conn.Close();

                return monthSales;

            }

        }

        public SCCatD[] GetProductSalesPrDay()
        {

            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                                    SELECT [Measures].[Fact Sale Count] ON COLUMNS,
                                        NONEMPTY( [Dim Product].[Category].[Category]*[Dim Date].[Day].[Day]) ON ROWS
                                    FROM [F Club DW]";
                AdomdDataReader dr = cmd.ExecuteReader();
                List<SCCatD> days = new List<SCCatD>();
                while (dr.Read())
                {
                    SCCatD day = new SCCatD
                    {
                        cat = dr[0].ToString(),
                        day = int.Parse(dr[1].ToString()),
                        saleCount = int.Parse(dr[2].ToString())
                    };

                    days.Add(day);

                }
                dr.Close();

                SCCatD[] daySales = days.ToArray();

                conn.Close();

                return daySales;

            }
        }
        public MemberSales[] GetSalesPrMember()
        {
            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                                   SELECT [Measures].[Fact Sale Count] ON COLUMNS,
                                        NONEMPTY([Dim Member].[Semester].[Semester]*[Dim Product].[Sub Sub Category].[Sub Sub Category]) ON ROWS
                                   FROM [F Club DW]";
                AdomdDataReader dr = cmd.ExecuteReader();
                List<MemberSales> members = new List<MemberSales>();
                while (dr.Read())
                {
                    MemberSales member = new MemberSales
                    {
                        memberID = int.Parse(dr[0].ToString()),
                        
                        saleCount = int.Parse(dr[1].ToString())
                    };

                    members.Add(member);

                }
                dr.Close();

                MemberSales[] memberSales = members.ToArray();

                conn.Close();

                return memberSales;

            }
        }
        
        public ProductCat[] GetProductsByCategory()
        {
            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT
                                    [Measures].[Fact Sale Count] ON COLUMNS,
                                        {[Dim Product].[Product Id].[Product Id]*[Dim Product].[Name].[Name]*[Dim Product].[Category].[Category]*[Dim Product].[Sub Category].[Sub Category]*[Dim Product].[Sub Sub Category].[Sub Sub Category]} ON ROWS
                                    From [F Club DW]";
                AdomdDataReader dr = cmd.ExecuteReader();
                List<ProductCat> productCats = new List<ProductCat>();
                while (dr.Read())
                {
                    ProductCat productCat = new ProductCat
                    {
                        productID = int.Parse(dr[0].ToString()),
                        name = dr[1].ToString(),
                        cat = dr[2].ToString(),
                        subCat = dr[3].ToString(),
                        subSubCat = dr[4].ToString(),
                       
                    };

                    productCats.Add(productCat);

                }
                dr.Close();

                ProductCat[] productSubCats = productCats.ToArray();

                conn.Close();

                return productSubCats;

            }
        }

        public SemesterSales[] GetSalesPrSemester()
        {
            using (AdomdConnection conn = new AdomdConnection("DataSource = localhost; Initial Catalog = FClubCube"))
            {
                conn.Open();
                AdomdCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                                   SELECT [Measures].[Fact Sale Count] ON COLUMNS,
                                        NONEMPTY([Dim Member].[Semester].[Semester]*[Dim Product].[Sub Sub Category].[Sub Sub Category]) ON ROWS
                                   FROM [F Club DW]";
                AdomdDataReader dr = cmd.ExecuteReader();
                List<SemesterSales> semesters = new List<SemesterSales>();
                while (dr.Read())
                {
                    SemesterSales semester = new SemesterSales
                    {
                        semester = dr[0].ToString(),
                        SubSubCategory = dr[1].ToString(),
                        saleCount = int.Parse(dr[2].ToString())
                    };

                    semesters.Add(semester);

                }
                dr.Close();

                SemesterSales[] semesterSales = semesters.FindAll(FindBeer).ToArray();

                conn.Close();

                return semesterSales;

            }


        }

        private static bool FindBeer(SemesterSales ss)
        {

            if (ss.SubSubCategory == "Beer")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}