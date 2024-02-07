using GeneralInsuranceBusinessLogic;
using GeneralInsuranceManagement.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GeneralInsuranceManagement.Models.Logs;

namespace GeneralInsuranceManagement.UserManagement
{
    public partial class userlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Users user = new Users("cn",1);
                Logs user = new Logs("cn", 1);
                string query = $"Select ID from Users where username ='{Email.Text}'";
                DataSet ds = user.GetUsers(query);
                string userId = ds.Tables[0].Rows[0]["ID"].ToString();

                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count != 0)
                {
                    Session["UserID"] = userId;
                    //Session["Username"] = user.Username;
                }

                long loggedID = long.Parse(Session["UserId"].ToString());
                DateTime date = DateTime.Now;
                Logs log = new Logs("cn", 1)
                {
                    UserID = 0,
                    ActionID = (int)Actions.LOGIN,
                    ActionedByID = loggedID,
                    DateOfAction = date,
                };
                try
                {
                    log.Save();
                }
                catch (Exception ex)
                {
                    WarningAlert(ex.Message);
                }


                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        RedAlert("Invalid login attempt") ;                        
                        break;
                }
            }
        }
        #region alerts
        protected void RedAlert(string MsgFlg)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", "Swal.fire('Error!', '" + MsgFlg + "', 'error');", true);

        }

        protected void WarningAlert(string MsgFlg)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", "Swal.fire('Warning!', '" + MsgFlg + "', 'warning');", true);

        }

        protected void SuccessAlert(string MsgFlg)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", "Swal.fire('Success!', '" + MsgFlg + "', 'success');", true);

        }
        #endregion
    }
}