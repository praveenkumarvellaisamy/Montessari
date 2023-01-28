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
    public class OrganisationController : ApiController
    {
        [HttpPost]
        [Route("api/GetOrganisation")]
        [AllowAnonymous]
        public List<Organisation> GetOrganisation(Organisation objOrganisation)
        {
            List<Organisation> lstOrganisation = new List<Organisation>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@ORGANISATIONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objOrganisation.OrganisationID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRORGANISATIONLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objOrganisation.OrganisationID = Convert.ToInt16(items["FLDORGANISATIONID"].ToString());
                    objOrganisation.OrgName = items["FLDORGNAME"].ToString();
                    objOrganisation.OrgRegNumber = items["FLDORGREGNUMBER"].ToString();
                    objOrganisation.AddressLine1 = items["FLDADDRESSLINE1"].ToString();
                    objOrganisation.AddressLine2 = items["FLDADDRESSLINE2"].ToString();
                    objOrganisation.AddressLine3 = items["FLDADDRESSLINE3"].ToString();
                    objOrganisation.Country = items["FLDCOUNTRY"].ToString();
                    objOrganisation.State = items["FLDSTATE"].ToString();
                    objOrganisation.City = items["FLDCITY"].ToString();
                    objOrganisation.OfficePH = items["FLDOFFICEPH"].ToString();
                    objOrganisation.MobilePH = items["FLDMOBILEPH"].ToString();
                    objOrganisation.Longitude = items["FLDORGNAME"].ToString();
                    objOrganisation.Latitude = items["FLDLATITUDE"].ToString();
                    objOrganisation.BaseCurrency = items["FLDBASECURRENCY"].ToString();
                    lstOrganisation.Add(objOrganisation);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstOrganisation;
        }
        [HttpPost]
        [Route("api/OrganisationInsert")]
        [AllowAnonymous]
        public void OrganisationInsert(Organisation objOrganisation)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objOrganisation.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@ORGNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.OrgName));
                ParameterList.Add(DataAccess.GetDBParameter("@ORGREGNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.OrgRegNumber));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE1", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.AddressLine1));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE2", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.AddressLine2));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE3", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.AddressLine3));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.Country));
                ParameterList.Add(DataAccess.GetDBParameter("@STATE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.State));
                ParameterList.Add(DataAccess.GetDBParameter("@CITY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.City));
                ParameterList.Add(DataAccess.GetDBParameter("@OFFICEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objOrganisation.OfficePH));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objOrganisation.MobilePH));
                ParameterList.Add(DataAccess.GetDBParameter("@LATITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.Latitude));
                ParameterList.Add(DataAccess.GetDBParameter("@LONGITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.Longitude));
                ParameterList.Add(DataAccess.GetDBParameter("@BASECURRENCY", SqlDbType.VarChar, DbConstant.VARCHAR_5, ParameterDirection.Input, objOrganisation.BaseCurrency));
                DataAccess.ExecSPReturnInt("PRORGANISATIONINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/OrganisationUpdate")]
        [AllowAnonymous]
        public void OrganisationUpdate(Organisation objOrganisation)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@ORGANISATIONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objOrganisation.OrganisationID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objOrganisation.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@ORGNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.OrgName));
                ParameterList.Add(DataAccess.GetDBParameter("@ORGREGNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.OrgRegNumber));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE1", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.AddressLine1));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE2", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.AddressLine2));
                ParameterList.Add(DataAccess.GetDBParameter("@ADDRESSLINE3", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objOrganisation.AddressLine3));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.Country));
                ParameterList.Add(DataAccess.GetDBParameter("@STATE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.State));
                ParameterList.Add(DataAccess.GetDBParameter("@CITY", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.City));
                ParameterList.Add(DataAccess.GetDBParameter("@OFFICEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objOrganisation.OfficePH));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILEPH", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objOrganisation.MobilePH));
                ParameterList.Add(DataAccess.GetDBParameter("@LATITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.Latitude));
                ParameterList.Add(DataAccess.GetDBParameter("@LONGITUDE", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objOrganisation.Longitude));
                ParameterList.Add(DataAccess.GetDBParameter("@BASECURRENCY", SqlDbType.VarChar, DbConstant.VARCHAR_5, ParameterDirection.Input, objOrganisation.BaseCurrency));
                DataAccess.ExecSPReturnInt("PRORGANISATIONUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/OrganisationDelete")]
        [AllowAnonymous]
        public void OrganisationDelete(Organisation objOrganisation)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@ORGANISATIONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objOrganisation.OrganisationID));
                DataAccess.ExecSPReturnInt("PRORGANISATIONDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}