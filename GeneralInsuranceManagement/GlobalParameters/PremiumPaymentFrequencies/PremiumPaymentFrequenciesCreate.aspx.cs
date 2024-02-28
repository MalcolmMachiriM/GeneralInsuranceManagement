using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.PremiumPaymentFrequencies
{
    public partial class PremiumPaymentFrequenciesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PaymentfreqId"] != null)
                {
                    PaymentfreqId.Value = Request.QueryString["PaymentfreqId"].ToString();
                    getdetails(PaymentfreqId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    PaymentfreqId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.PremiumPaymentFrequencies premiumFreq = new Models.GlobalParameters.PremiumPaymentFrequencies("cn", 1);
            if (premiumFreq.Retrieve(long.Parse(value)))
            {
                PaymentFrequency.Text = premiumFreq.Frequency;
                FrequencyCode.Text = premiumFreq.Code;
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
                Models.GlobalParameters.PremiumPaymentFrequencies premiumfrq = new Models.GlobalParameters.PremiumPaymentFrequencies("cn", 1)
                {
                    Id = int.Parse(PaymentfreqId.Value),
                    Frequency = PaymentFrequency.Text,
                    Code = FrequencyCode.Text,

                };
                if (premiumfrq.Save())
                {
                    SuccessAlert($"{PaymentFrequency.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/PremiumPaymentFrequencies/PremiumPaymentFrequenciesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}