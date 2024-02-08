using GeneralInsuranceBusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.UserManagement
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null && Request.QueryString["UserId"] != "0")
                {
                    pagetitle.Text = "Approve User";
                    UserId.Value = Request.QueryString["UserId"].ToString();
                    GetUserDetails(long.Parse(UserId.Value));
                }
                getDepartments();
                getRoles();
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

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UserManagement/UserLogs?UserId=" + UserId.Value, UserId.Value), false);
        }
    }
}