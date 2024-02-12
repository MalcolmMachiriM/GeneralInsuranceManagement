using GeneralInsuranceManagement.Models;
using System;
using System.Data;
using System.Web.UI;

namespace GeneralInsuranceManagement.Products
{
    public partial class ProductEnquiries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                getProducts();
            }
        }

        private void getProducts()
        {
            ProductCategory products = new ProductCategory("cn",1);
            DataSet ds = products.GetAllProductCategory();
            if (ds != null )
            {
                grdProducts.DataSource = ds ;
                grdProducts.DataBind();
            }
            else
            {
                grdProducts.DataSource= null ;
                grdProducts.DataBind();
                WarningAlert("No Products Defined");
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

        protected void grdProducts_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectRecord")
            {
                long index = long.Parse(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/Products/ProductCreation?ProductId=" + index, index), false);
            }
        }
    }
}