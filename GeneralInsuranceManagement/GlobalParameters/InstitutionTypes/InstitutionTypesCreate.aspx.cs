using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.InstitutionTypes
{
    public partial class InstitutionTypesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["InstitutionTypesId"] != null)
                {
                    InstitutionTypesId.Value = Request.QueryString["InstitutionTypesId"].ToString();
                    getdetails(InstitutionTypesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    InstitutionTypesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.InstitutionTypes institution = new Models.GlobalParameters.InstitutionTypes("cn", 1);
            if (institution.Retrieve(long.Parse(value)))
            {
                InstitutionType.Text = institution.Description;
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
                Models.GlobalParameters.InstitutionTypes institution = new Models.GlobalParameters.InstitutionTypes("cn", 1)
                {
                    Id = int.Parse(InstitutionTypesId.Value),
                    Description = InstitutionType.Text

                };
                if (institution.Save())
                {
                    SuccessAlert($"{InstitutionType.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/InstitutionTypes/InstitutionTypesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}