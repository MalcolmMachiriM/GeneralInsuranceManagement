using GeneralInsuranceBusinessLogic;
using GeneralInsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.Schemes
{
    public partial class SchemeCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] !=null)
                {
                    UserId.Value = Session["UserId"].ToString();
                }
                else
                {
                    UserId.Value = "0";
                }
                if (Request.QueryString["SchemeId"] !=null)
                {
                    SchemeId.Value = Session["SchemeId"].ToString();

                    pagetitle.Text = "Scheme Details";
                }
                else
                {
                    pagetitle.Text = "Scheme Creation";
                    SchemeId.Value = "0";
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
            Scheme scheme = new Scheme("cn", long.Parse(UserId.Value))
            {
                ID = long.Parse(SchemeId.Value),
                Name = Name.Text,
                ContactPerson = long.Parse(ContactPerson.SelectedValue),
                CommencementDate = DateTime.Parse(CommencementDate.Text),
                ConversionDate = DateTime.Parse(ConversionDate.Text),
                CreatedBy = long.Parse(UserId.Value),
            };
            if (scheme.Save())
            {
                SuccessAlert($"{Name.Text.ToUpperInvariant()} saved successfully");
                Clear();
            }
            else
            {
                WarningAlert("Failed to save");
            }

        }

        private void Clear()
        {
            Name.Text = string.Empty;
            ContactPerson.SelectedIndex = 0;
            ConversionDate.Text = string.Empty;
            CommencementDate.Text = string.Empty;
        }
    }
}