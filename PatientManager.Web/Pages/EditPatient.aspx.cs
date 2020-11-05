using PatientManager.Business.Interfaces;
using PatientManager.Domain.Dto;
using System;

namespace PatientManager.Web.Pages
{
    public partial class EditPatient : System.Web.UI.Page
    {
        private readonly IPatientBusiness patientBusiness;

        public EditPatient(IPatientBusiness patientBusiness)
        {
            this.patientBusiness = patientBusiness;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                long id = long.Parse(Request.QueryString["id"]);
                var patient = patientBusiness.GetPatientById(id);

                txtEmail.Text = patient.Email;
                txtFirstName.Text = patient.FirstName;
                ddlGender.SelectedValue = patient.Gender;
                txtLastName.Text = patient.LastName;
                txaNote.Text = patient.Notes;
                txtPhone.Text = patient.Phone;
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            var patientDto = new PatientDto
            {
                Id = long.Parse(Request.QueryString["id"]),
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                Gender = ddlGender.SelectedValue,
                LastName = txtLastName.Text,
                Notes = txaNote.Text,
                Phone = txtPhone.Text
            };

            patientBusiness.EditPatient(patientDto);
        }
    }
}