using GeneralInsuranceBusinessLogic;
using GeneralInsuranceManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlApprove.Visible = false;
                if (Request.QueryString["UserId"] != null && Request.QueryString["UserId"] != "0")
                {
                    pagetitle.Text = "Approve User";
                    UserId.Value = Request.QueryString["UserId"].ToString();
                    GetUserDetails(long.Parse(UserId.Value));

                }
                else
                {
                    UserId.Value = "0";
                    pagetitle.Text = "Create User";
                }
                getDepartments();
                getRoles();
            }
        }


        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Username.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, password.Text);
            IdentityResult result = manager.Create(user, "Pass@123");
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                SaveUserAccount();

            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
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
        private void GetUserDetails(long userId)
        {
            try
            {
                Users user = new Users("cn", 1);
                if (user.Retrieve(userId))
                {
                    FirstName.Text = user.Firstnames;
                    FirstName.ReadOnly = true;
                    Lastname.Text = user.Surname;
                    Lastname.ReadOnly = true;
                    Username.Text = user.Username;
                    Username.ReadOnly = true;
                    Email.Text = user.EmailAddress;
                    Email.ReadOnly = true;
                    PhoneNumber.Text = user.ContactNumber;
                    PhoneNumber.ReadOnly = true;
                    PasswordLifeSpan.Text = user.PasswordLifeSpan.ToString();
                    PasswordLifeSpan.ReadOnly = true;
                    UserRoleID.SelectedValue = user.UserRoleID.ToString();
                    DepartmentId.SelectedValue = user.DepartmentID.ToString();
                    AllowPasswordReuse.Checked = user.AllowPasswordReuse;
                    PasswordExpires.Checked = user.PasswordExpires;
                    pnlSave.Visible = false;
                    pnlApprove.Visible = true;
                }
            }
            catch (Exception ex)
            {

                RedAlert(ex.Message);
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

        protected void SaveUserAccount()
        {
            try
            {
                Users U = new Users("cn", 1);
                U.ID = long.Parse(UserId.Value);
                U.Username = Username.Text;
                U.Firstnames = FirstName.Text;
                U.Surname = Lastname.Text;
                U.EmailAddress = Email.Text;
                U.DepartmentID = int.Parse(DepartmentId.SelectedValue);
                U.PasswordLifeSpan = int.Parse(PasswordLifeSpan.Text);
                U.UserRoleID = int.Parse(UserRoleID.SelectedValue);
                U.ContactNumber = PhoneNumber.Text;
                U.Password = "pass@123";
                U.AllowPasswordReuse = AllowPasswordReuse.Checked ? true : false;
                U.PasswordExpires = PasswordExpires.Checked ? true : false;

                if (U.Save() == true)
                {
                    SuccessAlert($"{U.Firstnames} Saved Successfully");
                    UserId.Value = U.ID.ToString();
                    ClearForm();
                    UserAccountAuthorizationLog ual = new UserAccountAuthorizationLog("cn", 1)
                    {
                        ID = 0,
                        UserID = long.Parse(UserId.Value),
                        RecordUpdateTypeID = 0,
                        CurrentStatusID = U.StatusID,
                        RequestStatusID = 1,
                        RequestUpdateBy = 1,

                    };
                    if (ual.Save() == true)
                    {
                        U.getSavedUsers();//dataset for grid 
                    }
                }
            }
            catch (Exception x)
            {
                ErrorMessage.Text = x.Message;
            }
        }
        protected void ClearForm()
        {
            FirstName.Text = string.Empty;
            Lastname.Text = string.Empty;
            Username.Text = string.Empty;
            Email.Text = string.Empty;
            PhoneNumber.Text = string.Empty;
            //Password.Text = string.Empty;
            PasswordLifeSpan.Text = string.Empty;
            UserRoleID.SelectedIndex = 0;
            DepartmentId.SelectedIndex = 0;
            AllowPasswordReuse.Checked = false;
            PasswordExpires.Checked = false;

        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            Users user = new Users("cn", 1);
            if (user.ActionUserAccountStatusRequest(int.Parse(UserId.Value),2,2,1))
            {
                SuccessAlert("Approved");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Users user = new Users("cn", 1);
            if (user.ActionUserAccountStatusRequest(int.Parse(UserId.Value), 2, 2, 1))
            {
                SuccessAlert("Approved");
            }
        }
    }
}