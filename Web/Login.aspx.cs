using Montessari.API;
using Montessari.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    private ModelUser ModelUserList1;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            int IsValidInput = 0;
            if (txtUserNameInput.Text == "" || txtPasswordInput.Text == "")
                IsValidInput = 1;
            string EndPoint = "api/User/CheckUser";
            var Params = new
            {
                UserName = txtUserNameInput.Text,
                Password = txtPasswordInput.Text
            };
            var APIResponse = MontessoriAPI.WebPOST(EndPoint, Params);

            if(IsValidInput == 1)
            {
                divError.Visible = true;
                lblErrorMessage.Text = "Please Enter Username or Password!";
            }
            else if (APIResponse != "True")
            {
                divError.Visible = true;
                lblErrorMessage.Text = "You are not an authorized person!";
            }
            else
            {
                divError.Visible = false;
                Response.Redirect("Profile.aspx");
            }
            // ModelUserList1 = JsonConvert.DeserializeObject<ModelUser>(Response);
            //DataTable dt = ModelUserList1.UserList.ToDataTable();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            string EndPoint = "api/User/UserInsert";
            var Params = new
            {
                UserName = txtUserNameInput.Text,
                Password = txtPasswordInput.Text,
                EMail = txtEmail.Text,
                EMailVerifiedYN = 1,
                MobileNo = txtMobileNumber.Text,
                MobileVerifiedYN = "1",
                UserCode = "1"
            };
            var APIResponse = MontessoriAPI.WebPOST(EndPoint, Params);
            divErrorMessage.Visible = true;
            lblErrorMessageRegiter.Text = "Saved Successfully";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSendOTP_Click(object sender, EventArgs e)
    {

    }
}
