using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Qualifications
{
    public partial class QualificationsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["QualificationsId"] != null)
                {
                    QualificationsId.Value = Request.QueryString["QualificationsId"].ToString();
                    getdetails(QualificationsId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    QualificationsId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.Qualifications qualifications = new Models.GlobalParameters.Qualifications("cn", 1);
            if (qualifications.Retrieve(long.Parse(value)))
            {
                QualificationName.Text = qualifications.QualificationName;
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
                Models.GlobalParameters.Qualifications quali = new Models.GlobalParameters.Qualifications("cn", 1)
                {
                    Id = int.Parse(QualificationsId.Value),
                    QualificationName = QualificationName.Text,

                };
                if (quali.Save())
                {
                    SuccessAlert($"{QualificationName.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/Qualifications/QualificationsEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}