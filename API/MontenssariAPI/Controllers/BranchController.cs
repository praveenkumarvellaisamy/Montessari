using MontenssariAPI.Models;
using MontenssariAPI.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace MontenssariAPI.Controllers
{
    public class BranchController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelBranch> GetBranch(ModelBranch objModelBranch)
        {
            List<ModelBranch> lstModelBranch = new List<ModelBranch>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelBranch.BranchID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRBRANCHLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelBranch.BranchID = Convert.ToInt16(items["FLDBranchID"].ToString());
                    objModelBranch.BranchName = items["FLDBRANCHNAME"].ToString();
                    objModelBranch.AddressLine1 = items["FLDADDRESSLINE1"].ToString();
                    objModelBranch.AddressLine2 = items["FLDADDRESSLINE2"].ToString();
                    objModelBranch.AddressLine3 = items["FLDADDRESSLINE3"].ToString();
                    objModelBranch.Country = items["FLDCOUNTRY"].ToString();
                    objModelBranch.State = items["FLDSTATE"].ToString();
                    objModelBranch.City = items["FLDCITY"].ToString();
                    objModelBranch.BranchPH = items["FLDBRANCHPH"].ToString();
                    objModelBranch.MobilePH = items["FLDMOBILEPH"].ToString();
                    objModelBranch.Longitude = items["FLDORGNAME"].ToString();
                    objModelBranch.Latitude = items["FLDLATITUDE"].ToString();
                    objModelBranch.ContactPerson = items["FLDCONTACTPERSON"].ToString();
                    lstModelBranch.Add(objModelBranch);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelBranch;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void BranchInsert(ModelBranch objModelBranch)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelBranch.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.BranchName));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE1", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.AddressLine1));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE2", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.AddressLine2));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE3", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.AddressLine3));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.Country));
                ParameterList.Add(DataAccess.GetDBParameter("@STATE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.State));
                ParameterList.Add(DataAccess.GetDBParameter("@CITY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.City));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelBranch.BranchPH));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelBranch.MobilePH));
                ParameterList.Add(DataAccess.GetDBParameter("@LATITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.Latitude));
                ParameterList.Add(DataAccess.GetDBParameter("@LONGITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.Longitude));
                ParameterList.Add(DataAccess.GetDBParameter("@CONTACTPERSON", SqlDbType.VarChar, DbConstant.VARCHAR_5, ParameterDirection.Input, objModelBranch.ContactPerson));
                DataAccess.ExecSPReturnInt("PRBRANCHINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void BranchUpdate(ModelBranch objModelBranch)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelBranch.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelBranch.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.BranchName));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE1", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.AddressLine1));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE2", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.AddressLine2));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE3", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.AddressLine3));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.Country));
                ParameterList.Add(DataAccess.GetDBParameter("@STATE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.State));
                ParameterList.Add(DataAccess.GetDBParameter("@CITY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.City));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelBranch.BranchPH));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelBranch.MobilePH));
                ParameterList.Add(DataAccess.GetDBParameter("@LATITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.Latitude));
                ParameterList.Add(DataAccess.GetDBParameter("@LONGITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelBranch.Longitude));
                ParameterList.Add(DataAccess.GetDBParameter("@CONTACTPERSON", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelBranch.ContactPerson));
                DataAccess.ExecSPReturnInt("PRBRANCHUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void BranchDelete(ModelBranch objModelBranch)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelBranch.BranchID));
                DataAccess.ExecSPReturnInt("PRBRANCHDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}