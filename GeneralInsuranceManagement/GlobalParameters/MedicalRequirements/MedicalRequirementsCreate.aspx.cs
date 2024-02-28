using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.MedicalRequirements
{
    public partial class MedicalRequirementsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MedicalRequirementsId"] != null)
                {
                    MedicalRequirementsId.Value = Request.QueryString["MedicalRequirementsId"].ToString();
                    getdetails(MedicalRequirementsId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    MedicalRequirementsId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.MedicalRequirements medicals = new Models.GlobalParameters.MedicalRequirements("cn", 1);
            if (medicals.Retrieve(long.Parse(value)))
            {
                MedicalRequirementsCode.Text = medicals.Code;
                MedicalRequirements.Text = medicals.Description;
                Tariff.Text = medicals.Tariff;
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
                Models.GlobalParameters.MedicalRequirements medicals = new Models.GlobalParameters.MedicalRequirements("cn", 1)
                {
                    Id = int.Parse(MedicalRequirementsId.Value),
                    Code = MedicalRequirementsCode.Text,
                    Description = MedicalRequirements.Text,
                    Tariff = Tariff.Text,

                };
                if (medicals.Save())
                {
                    SuccessAlert($"{MedicalRequirements.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/MedicalRequirements/MedicalRequirementsEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}