using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.HabitsAndInterests
{
    public partial class HabitsAndInterestsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["HabitsAndInterestsId"] != null)
                {
                    HabitsAndInterestsId.Value = Request.QueryString["HabitsAndInterestsId"].ToString();
                    getdetails(HabitsAndInterestsId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    HabitsAndInterestsId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.HabitsAndInterests habitsAndInterests = new Models.GlobalParameters.HabitsAndInterests("cn", 1);
            if (habitsAndInterests.Retrieve(long.Parse(value)))
            {
                HabitsAndInterests.Text = habitsAndInterests.Description;
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
                Models.GlobalParameters.HabitsAndInterests country = new Models.GlobalParameters.HabitsAndInterests("cn", 1)
                {
                    Id = int.Parse(HabitsAndInterestsId.Value),
                    Description = HabitsAndInterests.Text,

                };
                if (country.Save())
                {
                    SuccessAlert($"{HabitsAndInterests.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/HabitsAndInterests/HabitsAndInterestsEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}