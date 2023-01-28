using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Web.Http;
using SparklesAPI.Models;
using SparklesAPI.FrameWork;

namespace SparklesAPI.Controllers
{
    [Authorize]
    [Route("api")]
    public class ItemsController : ApiController
    {

        [HttpPost]
        [Route("api/GetStoreItemRecord")]
        public IHttpActionResult GetStores([FromBody] ItemsFilter filter)
        {

            var re = Request;
            var headers = re.Headers;

            string ShipIMO = filter.ShipIMO;
            string StartDate = filter.StartDate;
            string EndDate = filter.EndDate;




            DateTime fromdate;
            DateTime todate;
            try
            {
                fromdate = DateTime.ParseExact(StartDate, "MMddyyyy", CultureInfo.InvariantCulture);
                todate = DateTime.ParseExact(EndDate, "MMddyyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid Date format");

            }
            //var stores = repository.GetStores(ShipIMO, fromdate, todate);

            List<SqlParameter> sqlparam = new List<SqlParameter>();
            SqlParameter sqlparamimo;
            SqlParameter sqlparamfromdate;
            SqlParameter sqlparamtodate;

            sqlparamimo = new SqlParameter("@IMONUMBER", SqlDbType.VarChar, 50);
            sqlparamimo.Direction = ParameterDirection.Input;
            sqlparamimo.Value = ShipIMO;

            sqlparam.Add(sqlparamimo);

            sqlparamfromdate = new SqlParameter("@STARTDATE", SqlDbType.DateTime, 10);
            sqlparamfromdate.Direction = ParameterDirection.Input;
            sqlparamfromdate.Value = fromdate;

            sqlparam.Add(sqlparamfromdate);

            sqlparamtodate = new SqlParameter("@ENDDATE", SqlDbType.DateTime, 10);
            sqlparamtodate.Direction = ParameterDirection.Input;
            sqlparamtodate.Value = todate;

            sqlparam.Add(sqlparamtodate);

            List<Items> Items = new List<Items>();
            DataSet ds = DataAccess.ExecSPReturnDataSet("PRPURCHASEDATAFORVERIFAVIA", sqlparam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var item = new Items();
                    DateTime? received = null;
                    DateTime tt;
                    item.ShipIMO = dr["ShipIMO"].ToString();
                    item.OrderDate = DateTime.Parse(dr["OrderDate"].ToString());

                    if (DateTime.TryParse(dr["OrderRcvDate"].ToString(), out tt))
                        received = tt;

                    item.OrderRcvDate = received;
                    item.Supplier = dr["Supplier"].ToString();
                    item.Supplier_Email1 = dr["Supplier_Email1"].ToString();
                    item.Supplier_Email2 = dr["Supplier_Email2"].ToString();
                    item.Supplier_Email3 = dr["Supplier_Email3"].ToString();
                    item.Supplier_Phone1 = dr["Supplier_Phone1"].ToString();
                    item.Supplier_Phone2 = dr["Supplier_Phone2"].ToString();
                    item.PO_Number = dr["PO_Number"].ToString();
                    item.Product = dr["Product"].ToString();
                    item.Brand = dr["Brand"].ToString();
                    item.PartDescription = dr["PartDescription"].ToString();
                    item.PartExecution = dr["PartExecution"].ToString();
                    item.Qty_Ord = Decimal.Parse(dr["Qty_Ord"].ToString());
                    item.Unit = dr["Unit"].ToString();

                    Items.Add(item);

                }
                return Ok(Items);
            }
            else
            {
                return Ok("No Records Found");
            }

        }
        [HttpPost]
        [Route("api/GetSpareItemRecord")]
        public IHttpActionResult GetSpares([FromBody] ItemsFilter filter)
        {

            var re = Request;
            var headers = re.Headers;

            string ShipIMO = filter.ShipIMO;
            string StartDate = filter.StartDate;
            string EndDate = filter.EndDate;

            DateTime fromdate;
            DateTime todate;
            try
            {
                fromdate = DateTime.ParseExact(StartDate, "MMddyyyy", CultureInfo.InvariantCulture);
                todate = DateTime.ParseExact(EndDate, "MMddyyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid Date format");

            }
            //var stores = repository.GetStores(ShipIMO, fromdate, todate);

            List<SqlParameter> sqlparam = new List<SqlParameter>();
            SqlParameter sqlparamimo;
            SqlParameter sqlparamfromdate;
            SqlParameter sqlparamtodate;

            sqlparamimo = new SqlParameter("@IMONUMBER", SqlDbType.VarChar, 50);
            sqlparamimo.Direction = ParameterDirection.Input;
            sqlparamimo.Value = ShipIMO;

            sqlparam.Add(sqlparamimo);

            sqlparamfromdate = new SqlParameter("@STARTDATE", SqlDbType.DateTime, 10);
            sqlparamfromdate.Direction = ParameterDirection.Input;
            sqlparamfromdate.Value = fromdate;

            sqlparam.Add(sqlparamfromdate);

            sqlparamtodate = new SqlParameter("@ENDDATE", SqlDbType.DateTime, 10);
            sqlparamtodate.Direction = ParameterDirection.Input;
            sqlparamtodate.Value = todate;

            sqlparam.Add(sqlparamtodate);

            List<Items> Items = new List<Items>();
            DataSet ds = DataAccess.ExecSPReturnDataSet("PRPURCHASESPARESDATAFORVERIFAVIA", sqlparam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var item = new Items();
                    DateTime? received = null;
                    DateTime tt;
                    item.ShipIMO = dr["ShipIMO"].ToString();
                    item.OrderDate = DateTime.Parse(dr["OrderDate"].ToString());

                    if (DateTime.TryParse(dr["OrderRcvDate"].ToString(), out tt))
                        received = tt;

                    item.OrderRcvDate = received;
                    item.Supplier = dr["Supplier"].ToString();
                    item.Supplier_Email1 = dr["Supplier_Email1"].ToString();
                    item.Supplier_Email2 = dr["Supplier_Email2"].ToString();
                    item.Supplier_Email3 = dr["Supplier_Email3"].ToString();
                    item.Supplier_Phone1 = dr["Supplier_Phone1"].ToString();
                    item.Supplier_Phone2 = dr["Supplier_Phone2"].ToString();
                    item.PO_Number = dr["PO_Number"].ToString();
                    item.Product = dr["Product"].ToString();
                    item.Brand = dr["Brand"].ToString();
                    item.PartDescription = dr["PartDescription"].ToString();
                    item.PartExecution = dr["PartExecution"].ToString();
                    item.Qty_Ord = Decimal.Parse(dr["Qty_Ord"].ToString());
                    item.Unit = dr["Unit"].ToString();

                    Items.Add(item);
                }
                return Ok(Items);
            }
            else
            {
                return Ok("No Records Found");
            }


            

        }
    }
            
}
