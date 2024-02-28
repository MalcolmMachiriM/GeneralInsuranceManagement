using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Timegroups
{
    public partial class TimegroupsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["TimegroupsId"] != null)
                {
                    TimegroupsId.Value = Request.QueryString["TimegroupsId"].ToString();
                    getdetails(TimegroupsId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    TimegroupsId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.TImeGroups timegroups = new Models.GlobalParameters.TImeGroups("cn", 1);
            if (timegroups.Retrieve(long.Parse(value)))
            {
                Timegroups.Text = timegroups.Description;
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
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            SaveTimeGroup();
        }

        private void SaveTimeGroup()
        {
            Models.GlobalParameters.TImeGroups title = new Models.GlobalParameters.TImeGroups("cn", 1)
            {
                Id = int.Parse(TimegroupsId.Value),
                Description = Timegroups.Text
            };
            try
            {
                if (title.Save())
                {
                    SuccessAlert("Time group saved");
                    Response.Redirect("~/GlobalParameters/Timegroups/TimegroupsEnquiries");
                }
            }
            catch (Exception ex)
            {

                RedAlert(ex.Message);
            }

        }
    }
}