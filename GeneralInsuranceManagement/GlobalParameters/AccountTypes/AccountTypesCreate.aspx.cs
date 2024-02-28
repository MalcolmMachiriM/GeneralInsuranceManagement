using System;
using System.Web.UI;

namespace GeneralInsuranceManagement.GlobalParameters.AccountTypes
{
    public partial class AccountTypesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["AccountTypeId"] != null)
                {
                    AccountTypeId.Value = Request.QueryString["AccountTypeId"].ToString();
                    getdetails(AccountTypeId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    AccountTypeId.Value = "0";
                }
            }
        }

        private void getdetails(string value)
        {
            Models.GlobalParameters.AccountTypes accountTypes = new Models.GlobalParameters.AccountTypes("cn", 1);
            if (accountTypes.Retrieve(long.Parse(value)))
            {
                AccountTypes.Text = accountTypes.Type;
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
                Models.GlobalParameters.AccountTypes account = new Models.GlobalParameters.AccountTypes("cn", 1)
                {
                    Id = int.Parse(AccountTypeId.Value),
                    Type = AccountTypes.Text,

                };
                if (account.Save())
                {
                    SuccessAlert($"{AccountTypes.Text} saved successfully");
                    Response.Redirect("~/GlobalParameters/AccountTypes/AccountTypesEnquiries");
                }
            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }
    }
}