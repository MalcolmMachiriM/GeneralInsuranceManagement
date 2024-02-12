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
            SaveTitle();
        }

        private void SaveTitle()
        {
            Models.GlobalParameters.StopOrders title = new Models.GlobalParameters.StopOrders("cn", 1)
            {
                Id = int.Parse(Id.Value),
                Name = StopOrderName.Text,
                EmployerName = StopOrderName.Text,
                EmployeeNumber = int.Parse(EmployeeNumber.Text)
            };
            try
            {
                if (title.Save())
                {
                    SuccessAlert("Title saved");
                }
            }
            catch (Exception ex)
            {

                RedAlert(ex.Message);
            }

        }
    }
}