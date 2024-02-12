//using GeneralInsuranceBusinessLogic;
using GeneralInsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.Products
{
    public partial class ProductCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SchemeId"] != null)
                {
                    SchemeId.Value = Request.QueryString["SchemeId"];
                }
                if (Request.QueryString["ProductId"] !=null)
                {
                    ProductId.Value = Request.QueryString["ProductId"].ToString();
                    pagetitle.Text = "Update Product Category";
                    pnlSave.Visible = false;
                }
                else
                {
                    pagetitle.Text = "Create Product Category";
                    pnlApprove.Visible = false;
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
            ProductCategory product = new ProductCategory("cn", 1)
            {
                ID = long.Parse(ProductId.Value),
                Name = Name.Text,
                SchemeID = long.Parse(SchemeId.Value),
                Description = Description.Text,
            };
            try
            {
                if (product.Save())
                {
                    SuccessAlert("Product created successfully");
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
    }
}