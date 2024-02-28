using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.RequirementsTypes
{
    public partial class RequirementsTypesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["RequirementsTypesId"] != null)
                {
                    RequirementsTypesId.Value = Request.QueryString["RequirementsTypesId"].ToString();
                    getdetails(RequirementsTypesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    RequirementsTypesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.RequirementsTypes requirements = new Models.GlobalParameters.RequirementsTypes("cn", 1);
            if (requirements.Retrieve(long.Parse(value)))
            {
                RequirementsTypes.Text = requirements.Description;
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
                Models.GlobalParameters.RequirementsTypes religion = new Models.GlobalParameters.RequirementsTypes("cn", 1)
                {
                    Id = int.Parse(RequirementsTypesId.Value),
                    Description = RequirementsTypes.Text,

                };
                if (religion.Save())
                {
                    SuccessAlert($"{RequirementsTypes.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/RequirementsTypes/RequirementsTypesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}