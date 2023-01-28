using SparklesAPI.FrameWork;
using SparklesAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace SparklesAPI.Controllers
{
    [Route("api")]
    [Authorize]
    public class BranchController : ApiController
    {
        [HttpPost]
        [Route("api/GetBranch")]
        [AllowAnonymous]
        public List<Branch> GetBranch(Branch objBranch)
        {
            List<Branch> lstBranch = new List<Branch>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objBranch.BranchID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRBRANCHLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objBranch.BranchID = Convert.ToInt16(items["FLDBranchID"].ToString());
                    objBranch.BranchName = items["FLDBRANCHNAME"].ToString();
                    objBranch.AddressLine1 = items["FLDADDRESSLINE1"].ToString();
                    objBranch.AddressLine2 = items["FLDADDRESSLINE2"].ToString();
                    objBranch.AddressLine3 = items["FLDADDRESSLINE3"].ToString();
                    objBranch.Country = items["FLDCOUNTRY"].ToString();
                    objBranch.State = items["FLDSTATE"].ToString();
                    objBranch.City = items["FLDCITY"].ToString();
                    objBranch.BranchPH = items["FLDBRANCHPH"].ToString();
                    objBranch.MobilePH = items["FLDMOBILEPH"].ToString();
                    objBranch.Longitude = items["FLDORGNAME"].ToString();
                    objBranch.Latitude = items["FLDLATITUDE"].ToString();
                    objBranch.ContactPerson = items["FLDCONTACTPERSON"].ToString();
                    lstBranch.Add(objBranch);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstBranch;
        }
        [HttpPost]
        [Route("api/BranchInsert")]
        [AllowAnonymous]
        public void BranchInsert(Branch objBranch)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objBranch.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.BranchName));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE1", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.AddressLine1));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE2", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.AddressLine2));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE3", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.AddressLine3));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.Country));
                ParameterList.Add(DataAccess.GetDBParameter("@STATE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.State));
                ParameterList.Add(DataAccess.GetDBParameter("@CITY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.City));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objBranch.BranchPH));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objBranch.MobilePH));
                ParameterList.Add(DataAccess.GetDBParameter("@LATITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.Latitude));
                ParameterList.Add(DataAccess.GetDBParameter("@LONGITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.Longitude));
                ParameterList.Add(DataAccess.GetDBParameter("@CONTACTPERSON", SqlDbType.VarChar, DbConstant.VARCHAR_5, ParameterDirection.Input, objBranch.ContactPerson));
                DataAccess.ExecSPReturnInt("PRBRANCHINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/BranchUpdate")]
        [AllowAnonymous]
        public void BranchUpdate(Branch objBranch)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objBranch.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objBranch.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.BranchName));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE1", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.AddressLine1));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE2", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.AddressLine2));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE3", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.AddressLine3));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.Country));
                ParameterList.Add(DataAccess.GetDBParameter("@STATE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.State));
                ParameterList.Add(DataAccess.GetDBParameter("@CITY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.City));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objBranch.BranchPH));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objBranch.MobilePH));
                ParameterList.Add(DataAccess.GetDBParameter("@LATITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.Latitude));
                ParameterList.Add(DataAccess.GetDBParameter("@LONGITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objBranch.Longitude));
                ParameterList.Add(DataAccess.GetDBParameter("@CONTACTPERSON", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objBranch.ContactPerson));
                DataAccess.ExecSPReturnInt("PRBRANCHUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/BranchDelete")]
        [AllowAnonymous]
        public void BranchDelete(Branch objBranch)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objBranch.BranchID));
                DataAccess.ExecSPReturnInt("PRBRANCHDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}