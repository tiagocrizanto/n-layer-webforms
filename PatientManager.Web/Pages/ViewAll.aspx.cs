using PatientManager.Business.Interfaces;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatientManager.Web.Pages
{
    public partial class ViewAll : Page
    {
        private readonly IPatientBusiness patientBusiness;

        public ViewAll(IPatientBusiness patientBusiness)
        {
            this.patientBusiness = patientBusiness;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //TODO: Add pagination
                grvPatients.DataSource = patientBusiness.GetAllPatients();
                grvPatients.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Button btn = (Button)sender;
                patientBusiness.DeletePatientById(long.Parse(btn.CommandArgument.ToString()));
                grvPatients.DataSource = patientBusiness.GetAllPatients();

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Patient deleted')", true);
                Response.Redirect("~/Pages/ViewAll");
            }
            else
            {
                return;
            }
        }
    }
}