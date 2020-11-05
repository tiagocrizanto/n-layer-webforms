using PatientManager.Business.Interfaces;
using PatientManager.Domain.Dto;
using PatientManager.Domain.Entity;
using PatientManager.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PatientManager.Business
{
    /// <summary>
    /// The convertion from entity to dto it's for example
    /// It could be improved using automapper
    /// The DTO is used to reduce de payload data to UI and only required fields needed
    /// Send to UI just few entity fields instead all entity fields
    /// </summary>
    public class PatientBusiness : IPatientBusiness
    {
        private readonly IPatientRepository patientRepository;

        public PatientBusiness(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public void AddPatient(PatientDto patient)
        {
            patientRepository.AddPatient(new Patient
            {
                Email = patient.Email,
                FirstName = patient.FirstName,
                Gender = patient.Gender,
                LastName = patient.LastName,
                Notes = patient.Notes,
                Phone = patient.Phone
            });
        }

        public void DeletePatientById(long id)
        {
            patientRepository.DeletePatientById(id);
        }

        public void EditPatient(PatientDto patient)
        {
            patientRepository.EditPatient(new Patient
            {
                Id = patient.Id,
                Email = patient.Email,
                FirstName = patient.FirstName,
                Gender = patient.Gender,
                LastName = patient.LastName,
                Notes = patient.Notes,
                Phone = patient.Phone
            });
        }

        public IEnumerable<PatientDto> GetAllPatients()
        {
            return patientRepository.GetAllPatients().Select(x => new PatientDto
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                Gender = x.Gender,
                LastName = x.LastName,
                Notes = x.Notes,
                Phone = x.Phone
            });
        }

        public PatientDto GetPatientById(long id)
        {
            var patientDto = patientRepository.GetPatientById(id);

            return new PatientDto
            {
                Id = patientDto.Id,
                Email = patientDto.Email,
                FirstName = patientDto.FirstName,
                Gender = patientDto.Gender,
                LastName = patientDto.LastName,
                Notes = patientDto.Notes,
                Phone = patientDto.Phone
            };
        }
    }
}
