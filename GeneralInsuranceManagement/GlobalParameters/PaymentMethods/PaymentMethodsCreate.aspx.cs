using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.PaymentMethods
{
    public partial class PaymentMethodsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PaymentMethodsId"] != null)
                {
                    PaymentMethodsId.Value = Request.QueryString["PaymentMethodsId"].ToString();
                    getdetails(PaymentMethodsId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    PaymentMethodsId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.PaymentMethod paymentMethod = new Models.GlobalParameters.PaymentMethod("cn", 1);
            if (paymentMethod.Retrieve(long.Parse(value)))
            {
                PaymentMethod.Text = paymentMethod.Method;
                PaymentMethodCode.Text = paymentMethod.Code;
                DetailsBank.Checked = paymentMethod.BankDetailsRequired;
                NumberRequired.Checked = paymentMethod.MobileNumberRequired;
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
                PaymentMethod payment = new PaymentMethod("cn", 1)
                {
                    Id = int.Parse(PaymentMethodsId.Value),
                    Method = PaymentMethod.Text,
                    Code = PaymentMethodCode.Text,
                    BankDetailsRequired = DetailsBank.Checked,
                    MobileNumberRequired = NumberRequired.Checked

                };
                if (payment.Save())
                {
                    SuccessAlert($"{PaymentMethod.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/PaymentMethods/PaymentMethodsEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
            
        }
    }
}