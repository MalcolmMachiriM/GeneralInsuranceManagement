using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.IncomeTypes
{
    public partial class IncomeTypesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["IncomeTypesId"] != null)
                {
                    IncomeTypesId.Value = Request.QueryString["IncomeTypesId"].ToString();
                    getdetails(IncomeTypesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    IncomeTypesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.IncomeTypes incomeTypes = new Models.GlobalParameters.IncomeTypes("cn", 1);
            if (incomeTypes.Retrieve(long.Parse(value)))
            {
                IncomeType.Text = incomeTypes.IncomeType;
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
                Models.GlobalParameters.IncomeTypes incomeTypes = new Models.GlobalParameters.IncomeTypes("cn", 1)
                {
                    Id = int.Parse(IncomeTypesId.Value),
                    IncomeType = IncomeType.Text,

                };
                if (incomeTypes.Save())
                {
                    SuccessAlert($"{IncomeType.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/IncomeTypes/IncomeTypesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}