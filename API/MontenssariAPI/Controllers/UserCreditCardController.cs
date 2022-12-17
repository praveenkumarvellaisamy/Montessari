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
    public class UserCreditCardController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelUserCreditCard> GetUserCreditCard(ModelUserCreditCard objModelUserCreditCard)
        {
            List<ModelUserCreditCard> lstModelUserCreditCard = new List<ModelUserCreditCard>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCREDITCARDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.CardID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRUSERCREDITCARDLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelUserCreditCard.CardID = Convert.ToInt16(items["FLDCARDID"].ToString());
                    objModelUserCreditCard.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objModelUserCreditCard.UserProfileID = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    objModelUserCreditCard.CardHolderName = items["FLDCARDHOLDERNAME"].ToString();
                    objModelUserCreditCard.CardType = items["FLDCARDTYPE"].ToString();
                    objModelUserCreditCard.CardNumber = items["FLDCARDNUMBER"].ToString();
                    objModelUserCreditCard.ExpiryDate =Convert.ToDateTime(items["FLDEXPIRYDATE"].ToString());
                    lstModelUserCreditCard.Add(objModelUserCreditCard);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelUserCreditCard;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void UserCreditCardInsert(ModelUserCreditCard objModelUserCreditCard)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDHOLDERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserCreditCard.CardHolderName));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDTYPE", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objModelUserCreditCard.CardType));
                ParameterList.Add(DataAccess.GetDBParameter("@EXPIRYDATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelUserCreditCard.ExpiryDate));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelUserCreditCard.CardNumber));
                DataAccess.ExecSPReturnInt("PRUSERCREDITCARDINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void UserCreditCardUpdate(ModelUserCreditCard objModelUserCreditCard)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.CardID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDHOLDERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserCreditCard.CardHolderName));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDTYPE", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objModelUserCreditCard.CardType));
                ParameterList.Add(DataAccess.GetDBParameter("@EXPIRYDATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelUserCreditCard.ExpiryDate));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objModelUserCreditCard.CardNumber));
                DataAccess.ExecSPReturnInt("PRUSERCREDITCARDUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void UserCreditCardDelete(ModelUserCreditCard objModelUserCreditCard)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCREDITCARDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserCreditCard.CardID));
                DataAccess.ExecSPReturnInt("PRUSERCREDITCARDDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}