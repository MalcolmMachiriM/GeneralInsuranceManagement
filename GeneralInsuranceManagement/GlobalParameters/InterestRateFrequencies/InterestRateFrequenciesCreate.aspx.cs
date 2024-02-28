using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.InterestRateFrequencies
{
    public partial class InterestRateFrequencies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["InterestRatefreqId"] != null)
                {
                    InterestRatefreqId.Value = Request.QueryString["InterestRatefreqId"].ToString();
                    getdetails(InterestRatefreqId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    InterestRatefreqId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.InterestRateFrequencies interestfrq = new Models.GlobalParameters.InterestRateFrequencies("cn", 1);
            if (interestfrq.Retrieve(long.Parse(value)))
            {
                InterestFrequency.Text = interestfrq.Description;
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
                Models.GlobalParameters.InterestRateFrequencies interestfrq = new Models.GlobalParameters.InterestRateFrequencies("cn", 1)
                {
                    Id = int.Parse(InterestRatefreqId.Value),
                    Description = InterestFrequency.Text,

                };
                if (interestfrq.Save())
                {
                    SuccessAlert($"{InterestFrequency.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/InterestRateFrequencies/InterestRateFrequenciesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}