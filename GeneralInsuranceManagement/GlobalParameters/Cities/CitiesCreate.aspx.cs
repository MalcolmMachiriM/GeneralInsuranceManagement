using GeneralInsuranceManagement.Models.GlobalParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralInsuranceManagement.GlobalParameters.Cities
{
    public partial class CitiesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CitiesId"] != null)
                {
                    CitiesId.Value = Request.QueryString["CitiesId"].ToString();
                    getdetails(CitiesId.Value);
                    btnCreate.Text = "Update";
                }
                else
                {
                    btnCreate.Text = "Create";
                    CitiesId.Value = "0";
                }
            }
        }
        private void getdetails(string value)
        {
            Models.GlobalParameters.Cities cities = new Models.GlobalParameters.Cities("cn", 1);
            if (cities.Retrieve(long.Parse(value)))
            {
                CountryName.Text = cities.CountryName;
                CityName.Text = cities.City;
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
                Models.GlobalParameters.Cities city = new Models.GlobalParameters.Cities("cn", 1)
                {
                    Id = int.Parse(CitiesId.Value),
                    CountryName = CountryName.Text,
                    City = CityName.Text,

                };
                if (city.Save())
                {
                    SuccessAlert($"{CityName.Text} saved successfully!");
                    Response.Redirect("~/GlobalParameters/Cities/CitiesEnquiries");
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }

        }
    }
}