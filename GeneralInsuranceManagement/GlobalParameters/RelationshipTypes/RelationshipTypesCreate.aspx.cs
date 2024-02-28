using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.RelationshipTypes
{
    public partial class RelationshipTypesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["RelationshipTypeId"] != null)
                {
                    RelationshipTypeId.Value = Request.QueryString["RelationshipTypeId"].ToString();
                    getdetails(RelationshipTypeId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    RelationshipTypeId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.RelationshipTypes relationship = new Models.GlobalParameters.RelationshipTypes("cn", 1);
            if (relationship.Retrieve(long.Parse(value)))
            {
                RelationshipTypes.Text = relationship.Description;
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
                Models.GlobalParameters.RelationshipTypes relationship = new Models.GlobalParameters.RelationshipTypes("cn", 1)
                {
                    Id = int.Parse(RelationshipTypeId.Value),
                    Description = RelationshipTypes.Text,

                };
                if (relationship.Save())
                {
                    SuccessAlert($"{RelationshipTypes.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/RelationshipTypes/RelationshipTypesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}