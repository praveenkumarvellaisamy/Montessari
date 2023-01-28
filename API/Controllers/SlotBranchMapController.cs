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
    public class SlotBranchMapController : ApiController
    {
        [HttpPost]
        [Route("api/GetSlotBranchMap")]
        [AllowAnonymous]
        public List<SlotBranchMap> GetSlotBranchMap(SlotBranchMap objSlotBranchMap)
        {
            List<SlotBranchMap> lstSlotBranchMap = new List<SlotBranchMap>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBRANCHMAPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.SlotMapID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRSLOTBRANCHMAPLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objSlotBranchMap.SlotMapID = Convert.ToInt16(items["FLDSLOTMAPID"].ToString());
                    objSlotBranchMap.BranchID = Convert.ToInt32(items["FLDBRANCHID"].ToString());
                    objSlotBranchMap.SlotID = Convert.ToInt32(items["FLDSLOTID"].ToString());
                    objSlotBranchMap.MaxChild = Convert.ToInt32(items["FLDMAXCHILD"].ToString());
                    lstSlotBranchMap.Add(objSlotBranchMap);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstSlotBranchMap;
        }
        [HttpPost]
        [Route("api/SlotBranchMapInsert")]
        [AllowAnonymous]
        public void SlotBranchMapInsert(SlotBranchMap objSlotBranchMap)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXCHILD", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.MaxChild));
                DataAccess.ExecSPReturnInt("PRSLOTBRANCHMAPINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/SlotBranchMapUpdate")]
        [AllowAnonymous]
        public void SlotBranchMapUpdate(SlotBranchMap objSlotBranchMap)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTMAPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.SlotMapID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXCHILD", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.MaxChild));
                DataAccess.ExecSPReturnInt("PRSLOTBRANCHMAPUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/SlotBranchMapDelete")]
        [AllowAnonymous]
        public void SlotBranchMapDelete(SlotBranchMap objSlotBranchMap)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTMAPID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBranchMap.SlotMapID));
                DataAccess.ExecSPReturnInt("PRSLOTBRANCHMAPDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}