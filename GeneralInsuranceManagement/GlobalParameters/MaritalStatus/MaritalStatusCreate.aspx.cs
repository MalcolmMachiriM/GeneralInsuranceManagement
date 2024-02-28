using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.MaritalStatus
{
    public partial class MaritalStatusCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MaritalStatusId"] != null)
                {
                    MaritalStatusId.Value = Request.QueryString["MaritalStatusId"].ToString();
                    getdetails(MaritalStatusId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    MaritalStatusId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.MaritalStatus maritalStatus = new Models.GlobalParameters.MaritalStatus("cn", 1);
            if (maritalStatus.Retrieve(long.Parse(value)))
            {
                MaritalStatus.Text = maritalStatus.Status;
                MaritalStatusCode.Text = maritalStatus.Code;
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
                Models.GlobalParameters.MaritalStatus marital = new Models.GlobalParameters.MaritalStatus("cn", 1)
                {
                    Id = int.Parse(MaritalStatusId.Value),
                    Status = MaritalStatus.Text,
                    Code = MaritalStatusCode.Text,

                };
                if (marital.Save())
                {
                    SuccessAlert($"{MaritalStatus.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/MaritalStatus/MaritalStatusEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}