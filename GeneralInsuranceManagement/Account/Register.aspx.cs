using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using GeneralInsuranceManagement.Models;
using GeneralInsuranceBusinessLogic;
using System.Data;

namespace GeneralInsuranceManagement.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null && Request.QueryString["UserId"]!="0")
                {
                    UserId.Value = Request.QueryString["UserId"].ToString();
                    GetUserDetails(long.Parse(UserId.Value));

                }
            }
            UserId.Value = "0";
        }


        //protected void CreateUser_Click(object sender, EventArgs e)
        //{
        //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
        //    var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
        //    //IdentityResult result = manager.Create(user, password.Text);
        //    IdentityResult result = manager.Create(user, "pass@123");
        //    if (result.Succeeded)
        //    {
        //        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
        //        //string code = manager.GenerateEmailConfirmationToken(user.Id);
        //        //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
        //        //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

        //        signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
        //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //    }
        //    else 
        //    {
        //        ErrorMessage.Text = result.Errors.FirstOrDefault();
        //    }
        //}

        private void GetUserDetails(long userId)
        {
            Users user = new Users("cn",1);
            if (user.Retrieve(userId))
            {
                FirstName.Text = user.Firstnames;
                Lastname.Text = user.Surname;
                Username.Text = user.Username;
                Email.Text = user.EmailAddress;
                PhoneNumber.Text = user.ContactNumber;
                PasswordLifeSpan.Text = user.PasswordLifeSpan.ToString();
                UserRoleID.SelectedValue = user.UserRoleID.ToString();
                DepartmentId.SelectedValue = user.DepartmentID.ToString();
                if (user.AllowPasswordReuse )
                {
                    All
                }

            } 
        }

        protected void SaveUserAccount()
        {
            try
            {
                Users U = new Users("cn",1);
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
                    ErrorMessage.Text = $"{U.Firstnames} Saved Successfully";
                    UserId.Value = U.ID.ToString();
                    ClearForm();
                    UserAccountAuthorizationLog ual = new UserAccountAuthorizationLog("cn", 1)
                    {
                        ID=0,
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

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            SaveUserAccount();
        }
    }
}