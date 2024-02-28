using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.InterestRateTypes
{
    public partial class InterestRateTypesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["InterestRateTypesId"] != null)
                {
                    InterestRateTypesId.Value = Request.QueryString["InterestRateTypesId"].ToString();
                    getdetails(InterestRateTypesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    InterestRateTypesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.InterestRateType interestRateType = new Models.GlobalParameters.InterestRateType("cn", 1);
            if (interestRateType.Retrieve(long.Parse(value)))
            {
                InterestRateType.Text = interestRateType.Description;
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
                Models.GlobalParameters.InterestRateType interesttype = new Models.GlobalParameters.InterestRateType("cn", 1)
                {
                    Id = int.Parse(InterestRateTypesId.Value),
                    Description = InterestRateType.Text,

                };
                if (interesttype.Save())
                {
                    SuccessAlert($"{InterestRateType.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/InterestRateTypes/InterestRateTypesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}