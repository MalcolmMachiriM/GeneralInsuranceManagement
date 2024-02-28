using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Currencies
{
    public partial class CurrenciesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CurrenciesId"] != null)
                {
                    CurrenciesId.Value = Request.QueryString["CurrenciesId"].ToString();
                    getdetails(CurrenciesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    CurrenciesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.Currencies currencies = new Models.GlobalParameters.Currencies("cn", 1);
            if (currencies.Retrieve(long.Parse(value)))
            {
                Currency.Text = currencies.Description;
                CurrencyCode.Text = currencies.Code;
                CurrencyRate.Text = currencies.Rate;
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
                Models.GlobalParameters.Currencies country = new Models.GlobalParameters.Currencies("cn", 1)
                {
                    Id = int.Parse(CurrenciesId.Value),
                    Description = Currency.Text,
                    Code = CurrencyCode.Text,
                    Rate = CurrencyRate.Text,

                };
                if (country.Save())
                {
                    SuccessAlert($"{Currency.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/Currencies/CurrenciesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}