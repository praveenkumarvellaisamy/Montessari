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
    public class SlotBranchMapBranchMapController : ApiController
    {

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelSlotBranchMap> GetSlotBranchMap(ModelSlotBranchMap objModelSlotBranchMap)
        {
            List<ModelSlotBranchMap> lstModelSlotBranchMap = new List<ModelSlotBranchMap>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBRANCHMAPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.SlotMapID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRSLOTBRANCHMAPLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelSlotBranchMap.SlotMapID = Convert.ToInt16(items["FLDSLOTMAPID"].ToString());
                    objModelSlotBranchMap.BranchID = Convert.ToInt32(items["FLDBRANCHID"].ToString());
                    objModelSlotBranchMap.SlotID = Convert.ToInt32(items["FLDSLOTID"].ToString());
                    objModelSlotBranchMap.MaxChild = Convert.ToInt32(items["FLDMAXCHILD"].ToString());
                    lstModelSlotBranchMap.Add(objModelSlotBranchMap);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelSlotBranchMap;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBranchMapInsert(ModelSlotBranchMap objModelSlotBranchMap)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXCHILD", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.MaxChild));
                DataAccess.ExecSPReturnInt("PRSLOTBRANCHMAPINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBranchMapUpdate(ModelSlotBranchMap objModelSlotBranchMap)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTMAPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.SlotMapID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXCHILD", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.MaxChild));
                DataAccess.ExecSPReturnInt("PRSLOTBRANCHMAPUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBranchMapDelete(ModelSlotBranchMap objModelSlotBranchMap)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTMAPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBranchMap.SlotMapID));
                DataAccess.ExecSPReturnInt("PRSLOTBRANCHMAPDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}