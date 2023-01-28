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
    public class AgeGroupController : ApiController
    {
        [HttpPost]
        [Route("api/GetAgeGroup")]
        [AllowAnonymous]
        public List<AgeGroup> GetAgeGroup(AgeGroup objAgeGroup)
        {
            List<AgeGroup> lstAgeGroup = new List<AgeGroup>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@AGEGROUPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.AgeGroupID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRAGEGROUPLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objAgeGroup.AgeGroupID = Convert.ToInt16(items["FLDAgeGroupID"].ToString());
                    objAgeGroup.Name = items["FLDNAME"].ToString();
                    objAgeGroup.AgeFrom = Convert.ToInt32(items["FLDAGEFROM"].ToString());
                    objAgeGroup.AgeTo = Convert.ToInt32(items["FLDAGETO"].ToString());
                    lstAgeGroup.Add(objAgeGroup);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstAgeGroup;
        }
        [HttpPost]
        [Route("api/AgeGroupInsert")]
        [AllowAnonymous]
        public void AgeGroupInsert(AgeGroup objAgeGroup)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objAgeGroup.Name));
                ParameterList.Add(DataAccess.GetDBParameter("@AGEFROM", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.AgeFrom));
                ParameterList.Add(DataAccess.GetDBParameter("@AGETO", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.AgeTo));
                DataAccess.ExecSPReturnInt("PRAGEGROUPINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/AgeGroupUpdate")]
        [AllowAnonymous]
        public void AgeGroupUpdate(AgeGroup objAgeGroup)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@AGEGROUPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.AgeGroupID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objAgeGroup.Name));
                ParameterList.Add(DataAccess.GetDBParameter("@AGEFROM", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.AgeFrom));
                ParameterList.Add(DataAccess.GetDBParameter("@AGETO", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.AgeTo));
                DataAccess.ExecSPReturnInt("PRAGEGROUPUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/AgeGroupDelete")]
        [AllowAnonymous]
        public void AgeGroupDelete(AgeGroup objAgeGroup)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@AGEGROUPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objAgeGroup.AgeGroupID));
                DataAccess.ExecSPReturnInt("PRAGEGROUPDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}