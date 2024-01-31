using GeneralInsuranceBusinessLogic;
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
                Users users = new Users("cn", 1);
                DataSet ds = users.getSavedUsers();
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