using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.IdentificationTypes
{
    public partial class IdentificationTypesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["IdentificationTypesId"] != null)
                {
                    IdentificationTypesId.Value = Request.QueryString["IdentificationTypesId"].ToString();
                    getdetails(IdentificationTypesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    IdentificationTypesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.IdentificationTypes identification = new Models.GlobalParameters.IdentificationTypes("cn", 1);
            if (identification.Retrieve(long.Parse(value)))
            {
                IdentificationType.Text = identification.IdentificationTypeName;
                IdentificationTypesFormat.Text = identification.Format;
                MinimumLength.Text = identification.MinimumLengthRequired.ToString();
                MaximumLength.Text = identification.MaximumLengthRequired.ToString();
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
                Models.GlobalParameters.IdentificationTypes identity = new Models.GlobalParameters.IdentificationTypes("cn", 1)
                {
                    Id = int.Parse(IdentificationTypesId.Value),
                    IdentificationTypeName = IdentificationType.Text,
                    Format = IdentificationTypesFormat.Text,
                    MinimumLengthRequired = int.Parse(MinimumLength.Text),
                    MaximumLengthRequired = int.Parse(MaximumLength.Text),

                };
                if (identity.Save())
                {
                    SuccessAlert($"{IdentificationType.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/IdentificationTypes/IdentificationTypesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}