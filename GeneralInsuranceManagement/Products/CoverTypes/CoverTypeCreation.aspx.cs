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
    public partial class CoverTypeCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CoverTypeId"]!=null)
                {
                    CoverTypeId.Value = Request.QueryString["CoverTypeId"].ToString();
                }
                else
                {
                    CoverTypeId.Value = "0";
                }
                getProducts();
                getSumAssuredBasis();
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
        private void getProducts()
        {
            ProductCategory products = new ProductCategory("cn",1);
            DataSet ds = products.GetAllProductCategory();
            if (ds !=null)
            {
                ListItem li = new ListItem("Select product", "0");
                drpProduct.DataSource = ds;
                drpProduct.DataValueField = "ID";
                drpProduct.DataTextField = "Name";
                drpProduct.DataBind();
                drpProduct.Items.Insert(0,li);
            }
            else
            {
                ListItem li = new ListItem("No Products Found", "0");
                drpProduct.DataSource = null;
                drpProduct.DataBind();
                drpProduct.Items.Insert(0, li);
            }
        }

        private void getSumAssuredBasis()
        {
            ProductCategory products = new ProductCategory("cn", 1);
            DataSet ds = products.GetAllProductCategory();
            if (ds!=null)
            {
                ListItem li = new ListItem("Select Sum Assured Basis", "0");
                drpSumAssureBasis.DataSource = ds;
                drpSumAssureBasis.DataValueField = "ID";
                drpSumAssureBasis.DataTextField = "Name";
                drpSumAssureBasis.DataBind();
                drpSumAssureBasis.Items.Insert(0,li);
            }
            else
            {
                ListItem li = new ListItem("No Sum Assured Basis Found", "0");
                drpSumAssureBasis.DataSource = null;
                drpSumAssureBasis.DataBind();
                drpSumAssureBasis.Items.Insert(0, li);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            CategoryPackages package = new CategoryPackages("cn", 1)
            {
                ID = long.Parse(CoverTypeId.Value),
                ProductID = long.Parse(drpProduct.SelectedValue),
                ProcessTime = int.Parse(ProcessTime.Text),
                SumAssuredBasis =long.Parse(drpSumAssureBasis.SelectedValue),
                MaxPremiumTerm = long.Parse(MaxPremiumTerm.Text),
                EffectiveDate = EffectiveDate.Text,
                Retention = Retention.Text,
                MinSumAssured = MinimumSumAssured.Text,
                MaxSumAssured = MaximumSumAssured.Text,
                Package = Package.Text,
                Description = Description.Text,
            };
            if (package.Save())
            {
                Clear();
                SuccessAlert("Package saved");
            }
            else
            {
                RedAlert("Failed to save package");
            }
               
            
        }
        private void Clear()
        {
            drpProduct.SelectedIndex = 0;
            Package.Text = string.Empty; 
            ProcessTime.Text = string.Empty;
            Retention.Text = string.Empty;
            drpSumAssureBasis.SelectedIndex = 0;
            EffectiveDate.Text = string.Empty;
            MaxPremiumTerm.Text = string.Empty;
            MinimumSumAssured.Text = string.Empty;
            MaximumSumAssured.Text = string.Empty;
            Description.Text = string.Empty;

        }
    }
}