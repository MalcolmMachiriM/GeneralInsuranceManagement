using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Titles
{
    public partial class TitlesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["TitleId"] != null)
                {
                    TitleId.Value = Request.QueryString["TitleId"].ToString();
                    getdetails(TitleId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    TitleId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.Titles titles = new Models.GlobalParameters.Titles("cn", 1);
            if (titles.Retrieve(long.Parse(value)))
            {
                Titles.Text = titles.Name;
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
            SaveTitle();
        }

        private void SaveTitle()
        {
            Models.GlobalParameters.Titles title = new Models.GlobalParameters.Titles("cn", 1)
            {
                Id = int.Parse(TitleId.Value),
                Name = Titles.Text
            };
            try
            {
                if (title.Save())
                {
                    SuccessAlert("Title saved");
                    Response.Redirect("~/GlobalParameters/Titles/TitlesEnquiries");
                }
            }
            catch (Exception ex)
            {

                RedAlert(ex.Message);
            }

        }
    }
}