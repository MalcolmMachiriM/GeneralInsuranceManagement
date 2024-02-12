//using GeneralInsuranceBusinessLogic;
using GeneralInsuranceManagement.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GeneralInsuranceManagement.Models.Logs;

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
                else
                {
                    SchemeId.Value = "0";
                }
                if (Request.QueryString["ProductId"] !=null)
                {
                    ProductId.Value = Request.QueryString["ProductId"].ToString();
                    pagetitle.Text = "Update Product Category";
                    pnlSave.Visible = false;
                    getIndividualProduct();
                }
                else
                {
                    ProductId.Value = "0";
                    pagetitle.Text = "Create Product Category";
                    pnlApprove.Visible = false;
                }
            }
        }

        private void getIndividualProduct()
        {
            ProductCategory pro = new ProductCategory("cn",1);
            if (pro.Retrieve(long.Parse(ProductId.Value)))
            {
                Name.Text = pro.Name;
                Description.Text = pro.Description;
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
            ProductCategory product = new ProductCategory("cn", 1);

            product.ID = long.Parse(ProductId.Value);
            product.Name = Name.Text;
            product.SchemeID = long.Parse(SchemeId.Value);
            product.Description = Description.Text;
           
            
            if (product.Save())
            {
                SuccessAlert("Product created successfully");
                Clear();
            }
            else
            {
                WarningAlert("Failed to save the products");
            }
            
        }

        private void Clear()
        {
            Name.Text= string.Empty;
            Description.Text= string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductCategory pro = new ProductCategory("cn", 1)
            {
                ID = long.Parse(ProductId.Value),
                Name = Name.Text,
                Description = Description.Text,
            };
            if (pro.Save())
            {
                SuccessAlert("Product updated successfully");

                Logs log = new Logs("cn", 1)
                {
                    ActionedByID = long.Parse(Session["UserId"].ToString()),
                    ActionID = (int)Actions.UPDATE,
                    DateOfAction = DateTime.Now,
                    Description = (int)Descriptions.Success,
                    UserID = 0

                };
                if (!log.Save())
                {
                    WarningAlert("failed");
                    return;
                }
                Response.Redirect("~/Products/ProductEnquiries");

            }
            else
            {
                Logs log = new Logs("cn", 1)
                {
                    ActionedByID = long.Parse(Session["UserId"].ToString()),
                    ActionID = (int)Actions.UPDATE,
                    DateOfAction = DateTime.Now,
                    Description = (int)Descriptions.Fail,
                    UserID = 0

                };
                if (!log.Save())
                {
                    WarningAlert("failed");
                    return;
                }
            }

            Response.Redirect("~/Products/ProductEnquiries");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Products/ProductEnquiries");
        }
    }
}