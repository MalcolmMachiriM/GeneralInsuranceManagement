using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.StopOrdersNames
{
    public partial class StopOrderNamesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["StopOrderNamesId"] != null)
                {
                    StopOrderNamesId.Value = Request.QueryString["StopOrderNamesId"].ToString();
                    getdetails(StopOrderNamesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    StopOrderNamesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.StopOrders stopOrders = new Models.GlobalParameters.StopOrders("cn", 1);
            if (stopOrders.Retrieve(long.Parse(value)))
            {
                StopOrderName.Text = stopOrders.Name;
                EmployerName.Text = stopOrders.EmployerName;
                EmployeeNumber.Text = stopOrders.EmployeeNumber;
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
            SaveStopOrder();
        }

        private void SaveStopOrder()
        {
            Models.GlobalParameters.StopOrders stopOrders = new Models.GlobalParameters.StopOrders("cn", 1)
            {
                Id = int.Parse(StopOrderNamesId.Value),
                Name = StopOrderName.Text,
                EmployerName = EmployerName.Text,
                EmployeeNumber = EmployeeNumber.Text
            };
            try
            {
                if (stopOrders.Save())
                {
                    SuccessAlert($"{StopOrderName.Text} saved successfully");
                    Response.Redirect("~/GlobalParameters/StopOrdersNames/StopOrdersNamesEnquiries");
                }
            }
            catch (Exception ex)
            {

                RedAlert(ex.Message);
            }

        }
    }
}