using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.AddressTypes
{
    public partial class AddressTypesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["AddressTypesId"] != null)
                {
                    AddressTypesId.Value = Request.QueryString["AddressTypesId"].ToString();
                    getdetails(AddressTypesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    AddressTypesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.AddressTypes addressTypes = new Models.GlobalParameters.AddressTypes("cn", 1);
            if (addressTypes.Retrieve(long.Parse(value)))
            {
                AddressTypes.Text = addressTypes.Description;
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
                Models.GlobalParameters.AddressTypes account = new Models.GlobalParameters.AddressTypes("cn", 1)
                {
                    Id = int.Parse(AddressTypesId.Value),
                    Description = AddressTypes.Text,

                };
                if (account.Save())
                {
                    SuccessAlert($"{AddressTypes.Text} saved successfully");
                    Response.Redirect("~/GlobalParameters/AddressTypes/AddressTypesEnquiries");
                }
            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }
    }
}