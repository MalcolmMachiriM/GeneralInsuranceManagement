using GeneralInsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.Policies
{
    public partial class PolicyCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"]!=null)
                {
                    UserId.Value = Session["UserId"].ToString();

                }
                else
                {
                    UserId.Value = "0";
                }
                if (Session["SchemeID"]!= null )
                {
                    SchemeId.Value = Session["SchemeID"].ToString();
                   
                }
                else
                {
                    SchemeId.Value = "0";

				}
				getProducts(long.Parse(SchemeId.Value));
            }
        }

		private void getProducts(long c)
		{
			ProductCategory prods = new ProductCategory("cn", long.Parse(UserId.Value));
			DataSet ds = prods.GetAllProductCategory(c);
			
			if (ds !=null)
			{
				ListItem li = new ListItem("Select Product","0");
				drpProductId.DataSource = ds;
				drpProductId.DataValueField = "ID";
				drpProductId.DataTextField = "Name";
				drpProductId.DataBind();
				drpProductId.Items.Insert(0, li);
			}
			else
			{
				ListItem li = new ListItem("No products found", "0");
				drpProductId.DataSource = null;
				drpProductId.DataBind();
				drpProductId.Items.Insert(0, li);
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
	}
}