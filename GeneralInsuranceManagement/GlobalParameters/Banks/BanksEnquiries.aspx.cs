using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Banks
{
    public partial class BanksEnquiries : System.Web.UI.Page
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
                getBanks();
            }
        }

        private void getBanks()
        {
            Models.GlobalParameters.Banks banks = new Models.GlobalParameters.Banks("cn", long.Parse(txtuserid.Value));
            string sql = "select * from Banks";
            DataSet ds = banks.GetUsers(sql);
            if (ds != null)
            {
                grdAcctypes.DataSource = ds;
                grdAcctypes.DataBind();
            }
            else
            {
                grdAcctypes.DataSource = null;
                grdAcctypes.DataBind();
                WarningAlert("No Banks found");
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
                Response.Redirect(string.Format("~/GlobalParameters/Banks/BanksCreate?BankId=" + Id, Id), false);
            }
            if (e.CommandName == "deleteRecord")
            {
                Models.GlobalParameters.Banks banks = new Models.GlobalParameters.Banks("cn", 1);
                if (banks.Retrieve(long.Parse(Id)))
                {
                    if (banks.Delete())
                    {
                        SuccessAlert("Record Successfully Deleted");
                        getBanks();
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