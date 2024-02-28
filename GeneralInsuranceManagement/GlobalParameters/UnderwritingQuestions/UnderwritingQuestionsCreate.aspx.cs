using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeneralInsuranceManagement.Models.GlobalParameters;

namespace GeneralInsuranceManagement.GlobalParameters.UnderwritingQuestions
{
    public partial class UnderwritingQuestionsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UnderwritingQuestionId"] != null)
                {
                    UnderwritingQuestionId.Value = Request.QueryString["UnderwritingQuestionId"].ToString();
                    getdetails(UnderwritingQuestionId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    UnderwritingQuestionId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.UnderwritingQuestions underwritingQ = new Models.GlobalParameters.UnderwritingQuestions("cn", 1);
            if (underwritingQ.Retrieve(long.Parse(value)))
            {
                QuestionTypes.Text = underwritingQ.QuestionType;
                QuestionDescription.Text = underwritingQ.QuestionDescription;
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
            Models.GlobalParameters.UnderwritingQuestions qs = new Models.GlobalParameters.UnderwritingQuestions("cn", 1)
            {
                Id = int.Parse(UnderwritingQuestionId.Value),
                QuestionType = QuestionTypes.Text,
                QuestionDescription = QuestionDescription.Text
            };
            try
            {
                if (qs.Save())
                {
                    SuccessAlert("Questions saved successfully");
                    Response.Redirect("~/GlobalParameters/UnderwritingQuestions/UnderwritingQuestionsEnquiries");
                }
            }
            catch (Exception x)
            {

                RedAlert(x.Message);
            }
        }
    }
}