using PatientManager.Business.Interfaces;
using PatientManager.Domain.Dto;
using System;

namespace PatientManager.Web.Pages
{
    public partial class AddNew : System.Web.UI.Page
    {
        private readonly IPatientBusiness patientBusiness;
        public AddNew(IPatientBusiness patientBusiness)
        {
            this.patientBusiness = patientBusiness;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                patientBusiness.AddPatient(new PatientDto
                {
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
                    Gender = ddlGender.SelectedValue,
                    LastName = txtLastName.Text,
                    Notes = txaNote.Text,
                    Phone = txtPhone.Text
                });

                txtEmail.Text = "";
                txtConfirmEmail.Text = "";
                txtFirstName.Text = "";
                ddlGender.SelectedValue = "";
                txtLastName.Text = "";
                txaNote.Text = "";
                txtPhone.Text = "";

                lblRegisterMessage.Text = "Patiend added";
            }
            catch
            {
                lblRegisterMessage.Text = "Error to add a patient";
            }
        }
    }
}