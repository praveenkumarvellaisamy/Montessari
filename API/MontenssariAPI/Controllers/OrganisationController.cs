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
    public class OrganisationController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelOrganisation> GetOrganisation(ModelOrganisation objModelOrganisation)
        {
            List<ModelOrganisation> lstModelOrganisation = new List<ModelOrganisation>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@ORGANISATIONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelOrganisation.OrganisationID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRORGANISATIONLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelOrganisation.OrganisationID = Convert.ToInt16(items["FLDORGANISATIONID"].ToString());
                    objModelOrganisation.OrgName = items["FLDORGNAME"].ToString();
                    objModelOrganisation.OrgRegNumber = items["FLDORGREGNUMBER"].ToString();
                    objModelOrganisation.AddressLine1 = items["FLDADDRESSLINE1"].ToString();
                    objModelOrganisation.AddressLine2 = items["FLDADDRESSLINE2"].ToString();
                    objModelOrganisation.AddressLine3 = items["FLDADDRESSLINE3"].ToString();
                    objModelOrganisation.Country = items["FLDCOUNTRY"].ToString();
                    objModelOrganisation.State = items["FLDSTATE"].ToString();
                    objModelOrganisation.City = items["FLDCITY"].ToString();
                    objModelOrganisation.OfficePH = items["FLDOFFICEPH"].ToString();
                    objModelOrganisation.MobilePH = items["FLDMOBILEPH"].ToString();
                    objModelOrganisation.Longitude = items["FLDORGNAME"].ToString();
                    objModelOrganisation.Latitude = items["FLDLATITUDE"].ToString();
                    objModelOrganisation.BaseCurrency = items["FLDBASECURRENCY"].ToString();
                    lstModelOrganisation.Add(objModelOrganisation);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelOrganisation;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void OrganisationInsert(ModelOrganisation objModelOrganisation)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelOrganisation.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@ORGNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.OrgName));
                ParameterList.Add(DataAccess.GetDBParameter("@ORGREGNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.OrgRegNumber));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE1", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.AddressLine1));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE2", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.AddressLine2));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE3", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.AddressLine3));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.Country));
                ParameterList.Add(DataAccess.GetDBParameter("@STATE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.State));
                ParameterList.Add(DataAccess.GetDBParameter("@CITY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.City));
                ParameterList.Add(DataAccess.GetDBParameter("@OFFICEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelOrganisation.OfficePH));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelOrganisation.MobilePH));
                ParameterList.Add(DataAccess.GetDBParameter("@LATITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.Latitude));
                ParameterList.Add(DataAccess.GetDBParameter("@LONGITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.Longitude));
                ParameterList.Add(DataAccess.GetDBParameter("@BASECURRENCY", SqlDbType.VarChar, DbConstant.VARCHAR_5, ParameterDirection.Input, objModelOrganisation.BaseCurrency));
                DataAccess.ExecSPReturnInt("PRORGANISATIONINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void OrganisationUpdate(ModelOrganisation objModelOrganisation)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@ORGANISATIONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelOrganisation.OrganisationID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelOrganisation.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@ORGNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.OrgName));
                ParameterList.Add(DataAccess.GetDBParameter("@ORGREGNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.OrgRegNumber));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE1", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.AddressLine1));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE2", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.AddressLine2));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE3", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelOrganisation.AddressLine3));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.Country));
                ParameterList.Add(DataAccess.GetDBParameter("@STATE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.State));
                ParameterList.Add(DataAccess.GetDBParameter("@CITY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.City));
                ParameterList.Add(DataAccess.GetDBParameter("@OFFICEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelOrganisation.OfficePH));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelOrganisation.MobilePH));
                ParameterList.Add(DataAccess.GetDBParameter("@LATITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.Latitude));
                ParameterList.Add(DataAccess.GetDBParameter("@LONGITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelOrganisation.Longitude));
                ParameterList.Add(DataAccess.GetDBParameter("@BASECURRENCY", SqlDbType.VarChar, DbConstant.VARCHAR_5, ParameterDirection.Input, objModelOrganisation.BaseCurrency));
                DataAccess.ExecSPReturnInt("PRORGANISATIONUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void OrganisationDelete(ModelOrganisation objModelOrganisation)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@ORGANISATIONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelOrganisation.OrganisationID));
                DataAccess.ExecSPReturnInt("PRORGANISATIONDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}