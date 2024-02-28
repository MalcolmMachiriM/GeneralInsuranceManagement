using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Occupations
{
    public partial class OccupationsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OccupationsId"] != null)
                {
                    OccupationsId.Value = Request.QueryString["OccupationsId"].ToString();
                    getdetails(OccupationsId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    OccupationsId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.Occupations occupations = new Models.GlobalParameters.Occupations("cn", 1);
            if (occupations.Retrieve(long.Parse(value)))
            {
                Occupation.Text = occupations.Description;
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
                Models.GlobalParameters.Occupations medicals = new Models.GlobalParameters.Occupations("cn", 1)
                {
                    Id = int.Parse(OccupationsId.Value),
                    Description = Occupation.Text,

                };
                if (medicals.Save())
                {
                    SuccessAlert($"{Occupation.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/Occupations/OccupationsEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}