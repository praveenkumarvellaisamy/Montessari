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
    public class AgeGroupController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelAgeGroup> GetAgeGroup(ModelAgeGroup objModelAgeGroup)
        {
            List<ModelAgeGroup> lstModelAgeGroup = new List<ModelAgeGroup>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@AGEGROUPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.AgeGroupID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRAGEGROUPLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelAgeGroup.AgeGroupID = Convert.ToInt16(items["FLDAgeGroupID"].ToString());
                    objModelAgeGroup.Name = items["FLDNAME"].ToString();
                    objModelAgeGroup.AgeFrom = Convert.ToInt32(items["FLDAGEFROM"].ToString());
                    objModelAgeGroup.AgeTo = Convert.ToInt32(items["FLDAGETO"].ToString());
                    lstModelAgeGroup.Add(objModelAgeGroup);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelAgeGroup;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void AgeGroupInsert(ModelAgeGroup objModelAgeGroup)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelAgeGroup.Name));
                ParameterList.Add(DataAccess.GetDBParameter("@AGEFROM", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.AgeFrom));
                ParameterList.Add(DataAccess.GetDBParameter("@AGETO", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.AgeTo));
                DataAccess.ExecSPReturnInt("PRAGEGROUPINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void AgeGroupUpdate(ModelAgeGroup objModelAgeGroup)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@AGEGROUPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.AgeGroupID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelAgeGroup.Name));
                ParameterList.Add(DataAccess.GetDBParameter("@AGEFROM", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.AgeFrom));
                ParameterList.Add(DataAccess.GetDBParameter("@AGETO", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.AgeTo)); 
                DataAccess.ExecSPReturnInt("PRAGEGROUPUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void AgeGroupDelete(ModelAgeGroup objModelAgeGroup)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@AGEGROUPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelAgeGroup.AgeGroupID));
                DataAccess.ExecSPReturnInt("PRAGEGROUPDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}