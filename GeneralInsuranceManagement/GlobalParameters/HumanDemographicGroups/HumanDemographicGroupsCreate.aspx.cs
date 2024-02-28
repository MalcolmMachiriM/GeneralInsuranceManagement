using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.HumanDemographicGroups
{
    public partial class HumanDemographicGroupsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["HumanGroupsId"] != null)
                {
                    HumanGroupsId.Value = Request.QueryString["HumanGroupsId"].ToString();
                    getdetails(HumanGroupsId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    HumanGroupsId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.HumanDemographicGroups humanGroups = new Models.GlobalParameters.HumanDemographicGroups("cn", 1);
            if (humanGroups.Retrieve(long.Parse(value)))
            {
                HumanGroups.Text = humanGroups.Description;
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
            SaveHumanGroups();
        }

        private void SaveHumanGroups()
        {
            Models.GlobalParameters.HumanDemographicGroups humanGroups = new Models.GlobalParameters.HumanDemographicGroups("cn", 1)
            {
                Id = int.Parse(HumanGroupsId.Value),
                Description = HumanGroups.Text
            };
            try
            {
                if (humanGroups.Save())
                {
                    SuccessAlert("Human Demographic group saved");
                    Response.Redirect("~/GlobalParameters/HumanDemographicGroups/HumanDemographicGroupsEnquiries");
                }
            }
            catch (Exception ex)
            {

                RedAlert(ex.Message);
            }

        }
    }
}