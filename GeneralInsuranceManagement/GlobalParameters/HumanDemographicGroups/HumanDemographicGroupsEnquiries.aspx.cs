using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.HumanDemographicGroups
{
    public partial class HumanDemographicGroupsEnquiries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    txtuserid.Value = Session["UserId"].ToString();
                }
                else
                {
                    txtuserid.Value = "0";
                }
                getHumanGroups();
            }
        }

        private void getHumanGroups()
        {
            Models.GlobalParameters.HumanDemographicGroups humanGroups = new Models.GlobalParameters.HumanDemographicGroups("cn", long.Parse(txtuserid.Value));
            string sql = "select * from HumanDemographicGroups";
            DataSet ds = humanGroups.GetUsers(sql);
            if (ds != null)
            {
                grdAcctypes.DataSource = ds;
                grdAcctypes.DataBind();
            }
            else
            {
                grdAcctypes.DataSource = null;
                grdAcctypes.DataBind();
                WarningAlert("No Human Demographic Groups found");
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

        #region rowcommand
        protected void grdAcctypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var Id = e.CommandArgument.ToString();
            if (e.CommandName == "selectRecord")
            {
                Response.Redirect(string.Format("~/GlobalParameters/HumanDemographicGroups/HumanDemographicGroupsCreate?HumanGroupsId=" + Id, Id), false);
            }
            if (e.CommandName == "deleteRecord")
            {
                Models.GlobalParameters.HumanDemographicGroups humanGroups = new Models.GlobalParameters.HumanDemographicGroups("cn", 1);
                if (humanGroups.Retrieve(long.Parse(Id)))
                {
                    if (humanGroups.Delete())
                    {
                        SuccessAlert("Record Successfully Deleted");
                        getHumanGroups();
                    }
                    else
                    {
                        WarningAlert("Failed to Delete Record");
                    }
                }
                else
                {
                    WarningAlert("Record not Found");
                }

            }


        }
        #endregion
    }
}