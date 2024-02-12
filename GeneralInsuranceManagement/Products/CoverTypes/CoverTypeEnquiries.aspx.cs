using GeneralInsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.Products.CoverTypes
{
    public partial class CoverTypeEnquiries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                getCategoryPackages();
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
        private void getCategoryPackages()
        {
            CategoryPackages packages = new CategoryPackages("cn",1);
            DataSet ds = packages.GetAllCategoryPackages();
            if (ds != null)
            {
                grdPackages.DataSource = ds;
                grdPackages.DataBind();
            }
            else
            {
                grdPackages.DataSource=null;
                grdPackages.DataBind();
                WarningAlert("No Category Packages Found");
            }
        }
    }
}