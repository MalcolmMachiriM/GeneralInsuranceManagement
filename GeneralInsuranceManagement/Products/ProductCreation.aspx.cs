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
                getInstitutions();
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
        private void getInstitutions()
        {
            Users users = new Users("cn",1);
            DataSet ds = users.GetUsers();
            if (ds!=null && ds.Tables["0"] !=null && ds.Tables["0"].Rows.Count<0)
            {
                ListItem li = new ListItem("Select Institution ", "0");
                InstitutionalClientId.DataSource = ds;
                InstitutionalClientId.DataValueField = "ID";
                InstitutionalClientId.DataTextField = "Name";
                InstitutionalClientId.DataBind();
                InstitutionalClientId.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("No Institutions Found", "0");
                InstitutionalClientId.Items.Clear();
                InstitutionalClientId.DataSource = null;
                InstitutionalClientId.DataBind();
                InstitutionalClientId.Items.Insert(0,li);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ProductCategory product = new ProductCategory("cn", 1)
            {
                ID = long.Parse(ProductId.Value),
                Name = RegNo.Text,
                SchemeID = long.Parse(ProductId.Value),
                Description = ReassuranceNo.Text,
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