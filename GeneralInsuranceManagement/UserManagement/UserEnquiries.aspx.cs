using GeneralInsuranceBusinessLogic;
using GeneralInsuranceManagement.Models;
using System;
using System.Data;
using System.Web.UI;

namespace GeneralInsuranceManagement.UserManagement
{
    public partial class UserEnquiries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                GetRegisteredUsers();
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
        private void GetRegisteredUsers()
        {
            try
            {
                Logs users = new Logs("cn", 1);
                string sql = "select u.ID,Firstnames,Surname,DepartmentName,ur.Description from users u" +
                    " inner join Departments d on u.DepartmentID=d.ID inner join UserRoles ur on u.UserRoleID=ur.ID where u.StatusID=0";
                DataSet ds = users.GetUsers(sql);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    grdUsers.DataSource = ds;
                    grdUsers.DataBind();
                }
                else
                {
                    grdUsers.DataSource = null;
                    grdUsers.DataBind();
                    WarningAlert("No Companies Found");
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }


        protected void grdUsers_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectRecord")
            {
                long index = long.Parse(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/Account/Register?UserId=" + index, index), false);
            }
        }
    }
}