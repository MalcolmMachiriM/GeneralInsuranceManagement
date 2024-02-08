using GeneralInsuranceBusinessLogic;
using GeneralInsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.UserManagement
{
    public partial class UserLogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"]!=null && Request.QueryString["UserId"].ToString() != "0")
                {
                    userId.Value = Request.QueryString["UserId"].ToString();
                }
                else
                {
                    userId.Value = Session["UserID"].ToString();
                }
                
                GetLogs();
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
        private void GetLogs()
        {
            try
            {
                Logs logs = new Logs("cn", 1);
                DataSet ds = logs.getAllLogs(long.Parse(userId.Value));
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    grdLogs.DataSource = ds;
                    grdLogs.DataBind();
                }
                else
                {
                    grdLogs.DataSource = null;
                    grdLogs.DataBind();
                    WarningAlert("No Logs Found");
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }


    }
}