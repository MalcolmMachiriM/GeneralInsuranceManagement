using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Countries
{
    public partial class CountriesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CountriesId"] != null)
                {
                    CountriesId.Value = Request.QueryString["CountriesId"].ToString();
                    getdetails(CountriesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    CountriesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.Countries countries = new Models.GlobalParameters.Countries("cn", 1);
            if (countries.Retrieve(long.Parse(value)))
            {
                CountryName.Text = countries.CountryName;
                CountryCode.Text = countries.Code;
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
            Save();
        }

        private void Save()
        {
            try
            {
                Models.GlobalParameters.Countries country = new Models.GlobalParameters.Countries("cn", 1)
                {
                    Id = int.Parse(CountriesId.Value),
                    CountryName = CountryName.Text,
                    Code = CountryCode.Text,

                };
                if (country.Save())
                {
                    SuccessAlert($"{CountryName.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/Countries/CountriesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}