using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using GeneralInsuranceManagement.Models;
using GeneralInsuranceBusinessLogic;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace GeneralInsuranceManagement.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

            // Enable this after setting up two-factor authentientication
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                TxtUserId.Value = Session["UserID"].ToString();
                getUserDetails(long.Parse(TxtUserId.Value));
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                getDepartments();
                getRoles();

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }

        public void getUserDetails(long UserId)
        {
            Users user = new Users("cn",1);
            if (user.Retrieve(UserId))
            {
                FirstName.Text = user.Firstnames;
                Lastname.Text = user.Surname;
                Username.Text = user.Username;
                Email.Text = user.EmailAddress;
                PhoneNumber.Text = user.ContactNumber;
                PasswordLifeSpan.Text = user.PasswordLifeSpan.ToString();
                UserRoleID.Text = user.UserRoleID.ToString();
                DepartmentId.Text = user.DepartmentID.ToString();
                AllowPasswordReuse.Checked = user.AllowPasswordReuse;
                PasswordExpires.Checked = user.PasswordExpires;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Users user = new Users("cn", 1)
            {
                ID = long.Parse(TxtUserId.Value),
                Firstnames = FirstName.Text,
                Surname = Lastname.Text,
                Username = Username.Text,
                EmailAddress = Email.Text,
                ContactNumber = PhoneNumber.Text,
                UserRoleID = long.Parse(UserRoleID.SelectedValue),
                DepartmentID = long.Parse(DepartmentId.SelectedValue),
                AllowPasswordReuse = AllowPasswordReuse.Checked,
                PasswordExpires = PasswordExpires.Checked,
            };
            if (user.Save())
            {
                SuccessAlert($"{FirstName.Text} {Lastname.Text} Updated Successfully");
            }
            else
            {
                RedAlert("Failed to update");
            }

        }
        private void getRoles()
        {

            try
            {
                Users agm = new Users("cn", 1);
                DataSet ds = agm.getUserRoles();
                if (ds != null)
                {
                    ListItem listItem = new ListItem("Select Role", "0");
                    UserRoleID.DataSource = ds;
                    UserRoleID.DataValueField = "ID";
                    UserRoleID.DataTextField = "Description";
                    UserRoleID.DataBind();
                    UserRoleID.Items.Insert(0, listItem);
                }
                else
                {
                    ListItem li = new ListItem("No role found", "0");
                    UserRoleID.Items.Clear();
                    UserRoleID.DataSource = null;
                    UserRoleID.DataBind();
                    UserRoleID.Items.Insert(0, li);
                }
            }
            catch (Exception a)
            {

                RedAlert(a.Message);
            }
        }
        private void getDepartments()
        {

            try
            {
                Users agm = new Users("cn", 1);
                DataSet ds = agm.getDepartments();
                if (ds != null)
                {
                    ListItem listItem = new ListItem("Select department", "0");
                    DepartmentId.DataSource = ds;
                    DepartmentId.DataValueField = "ID";
                    DepartmentId.DataTextField = "DepartmentName";
                    DepartmentId.DataBind();
                    DepartmentId.Items.Insert(0, listItem);
                }
                else
                {
                    ListItem li = new ListItem("No departments found", "0");
                    DepartmentId.Items.Clear();
                    DepartmentId.DataSource = null;
                    DepartmentId.DataBind();
                    DepartmentId.Items.Insert(0, li);
                }
            }
            catch (Exception a)
            {

                RedAlert(a.Message);
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