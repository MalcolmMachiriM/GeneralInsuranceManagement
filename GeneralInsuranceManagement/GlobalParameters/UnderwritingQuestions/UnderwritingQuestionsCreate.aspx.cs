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
                if (Request.QueryString["underwritingQuestionId"] !=null )
                {
                    underwritingQuestionId.Value = Request.QueryString["underwritingQuestionId"];
                }
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
                Id = int.Parse(underwritingQuestionId.Value),
                QuestionType = QuestionTypes.Text,
                QuestionDescription = QuestionDescription.Text
            };
            try
            {
                if (qs.Save())
                {
                    SuccessAlert("Success");
                }
            }
            catch (Exception x)
            {

                RedAlert(x.Message);
            }
        }
    }
}