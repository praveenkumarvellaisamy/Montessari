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
    public class UserCreditCardController : ApiController
    {
        [HttpPost]
        [Route("api/GetUserCreditCard")]
        [AllowAnonymous]
        public List<UserCreditCard> GetUserCreditCard(UserCreditCard objUserCreditCard)
        {
            List<UserCreditCard> lstUserCreditCard = new List<UserCreditCard>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCREDITCARDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.CardID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRUSERCREDITCARDLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objUserCreditCard.CardID = Convert.ToInt16(items["FLDCARDID"].ToString());
                    objUserCreditCard.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objUserCreditCard.UserProfileID = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    objUserCreditCard.CardHolderName = items["FLDCARDHOLDERNAME"].ToString();
                    objUserCreditCard.CardType = items["FLDCARDTYPE"].ToString();
                    objUserCreditCard.CardNumber = items["FLDCARDNUMBER"].ToString();
                    objUserCreditCard.ExpiryDate = Convert.ToDateTime(items["FLDEXPIRYDATE"].ToString());
                    lstUserCreditCard.Add(objUserCreditCard);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstUserCreditCard;
        }
        [HttpPost]
        [Route("api/UserCreditCardInsert")]
        [AllowAnonymous]
        public void UserCreditCardInsert(UserCreditCard objUserCreditCard)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDHOLDERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserCreditCard.CardHolderName));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDTYPE", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objUserCreditCard.CardType));
                ParameterList.Add(DataAccess.GetDBParameter("@EXPIRYDATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objUserCreditCard.ExpiryDate));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objUserCreditCard.CardNumber));
                DataAccess.ExecSPReturnInt("PRUSERCREDITCARDINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/UserCreditCardUpdate")]
        [AllowAnonymous]
        public void UserCreditCardUpdate(UserCreditCard objUserCreditCard)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.CardID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDHOLDERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserCreditCard.CardHolderName));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDTYPE", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objUserCreditCard.CardType));
                ParameterList.Add(DataAccess.GetDBParameter("@EXPIRYDATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objUserCreditCard.ExpiryDate));
                ParameterList.Add(DataAccess.GetDBParameter("@CARDNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_50, ParameterDirection.Input, objUserCreditCard.CardNumber));
                DataAccess.ExecSPReturnInt("PRUSERCREDITCARDUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/UserCreditCardDelete")]
        [AllowAnonymous]
        public void UserCreditCardDelete(UserCreditCard objUserCreditCard)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCREDITCARDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserCreditCard.CardID));
                DataAccess.ExecSPReturnInt("PRUSERCREDITCARDDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}