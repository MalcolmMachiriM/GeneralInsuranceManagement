using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Countries
{
    public partial class Countries : System.Web.UI.Page
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
                getCountries();
            }
        }

        private void getCountries()
        {
            Models.GlobalParameters.Countries country = new Models.GlobalParameters.Countries("cn", long.Parse(txtuserid.Value));
            string sql = "select * from Countries";
            DataSet ds = country.GetUsers(sql);
            if (ds != null)
            {
                grdAcctypes.DataSource = ds;
                grdAcctypes.DataBind();
            }
            else
            {
                grdAcctypes.DataSource = null;
                grdAcctypes.DataBind();
                WarningAlert("No Countries found");
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
                Response.Redirect(string.Format("~/GlobalParameters/Countries/CountriesCreate?CountriesId=" + Id, Id), false);
            }
            if (e.CommandName == "deleteRecord")
            {
                Models.GlobalParameters.Countries countries = new Models.GlobalParameters.Countries("cn", 1);
                if (countries.Retrieve(long.Parse(Id)))
                {
                    if (countries.Delete())
                    {
                        SuccessAlert("Record Successfully Deleted");
                        getCountries();
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