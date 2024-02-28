using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Banks
{
    public partial class BanksCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["BankId"] != null)
                {
                    BankId.Value = Request.QueryString["BankId"].ToString();
                    getdetails(BankId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    BankId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.Banks banks = new Models.GlobalParameters.Banks("cn", 1);
            if (banks.Retrieve(long.Parse(value)))
            {
                BankCode.Text = banks.Code;
                BankName.Text = banks.BankName;
                BranchNumbers.Text = banks.NumberOfBranches.ToString();
                NumberLength.Text = banks.AccountNumberLength.ToString();
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
                Models.GlobalParameters.Banks bank = new Models.GlobalParameters.Banks("cn", 1)
                {
                    Id = int.Parse(BankId.Value),
                    Code = BankCode.Text,
                    BankName = BankName.Text,
                    NumberOfBranches = int.Parse(BranchNumbers.Text),
                    AccountNumberLength = int.Parse(NumberLength.Text)

                };
                if (bank.Save())
                {
                    SuccessAlert($"{BankName.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/Banks/BanksEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}