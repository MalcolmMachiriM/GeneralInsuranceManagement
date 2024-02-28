using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.BusinessDecisions
{
    public partial class BusinessDecisionsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["BusinessDecisionId"] != null)
                {
                    BusinessDecisionId.Value = Request.QueryString["BusinessDecisionId"].ToString();
                    getdetails(BusinessDecisionId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    BusinessDecisionId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.BusinessDecisions businessDecisions = new Models.GlobalParameters.BusinessDecisions("cn", 1);
            if (businessDecisions.Retrieve(long.Parse(value)))
            {
                BusinessDecisionCode.Text = businessDecisions.Code;
                BusinessDecision.Text = businessDecisions.Description;
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
            Save();
        }

        private void Save()
        {
            try
            {
                Models.GlobalParameters.BusinessDecisions bdecision = new Models.GlobalParameters.BusinessDecisions("cn", 1)
                {
                    Id = int.Parse(BusinessDecisionId.Value),
                    Code = BusinessDecisionCode.Text,
                    Description = BusinessDecision.Text,

                };
                if (bdecision.Save())
                {
                    SuccessAlert($"{BusinessDecision.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/BusinessDecisions/BusinessDecisionsEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}