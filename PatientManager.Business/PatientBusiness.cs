using PatientManager.Business.Interfaces;
using PatientManager.Domain.Dto;
using PatientManager.Domain.Entity;
using PatientManager.Infra.Framework.Security;
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
                Email = HashHelper.Encrypt(patient.Email),
                FirstName = HashHelper.Encrypt(patient.FirstName),
                Gender = HashHelper.Encrypt(patient.Gender),
                LastName = HashHelper.Encrypt(patient.LastName),
                Notes = HashHelper.Encrypt(patient.Notes),
                Phone = HashHelper.Encrypt(patient.Phone)
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
                Email = HashHelper.Encrypt(patient.Email),
                FirstName = HashHelper.Encrypt(patient.FirstName),
                Gender = HashHelper.Encrypt(patient.Gender),
                LastName = HashHelper.Encrypt(patient.LastName),
                Notes = HashHelper.Encrypt(patient.Notes),
                Phone = HashHelper.Encrypt(patient.Phone)
            });
        }

        public IEnumerable<PatientDto> GetAllPatients()
        {
            return patientRepository.GetAllPatients().Select(x => new PatientDto
            {
                Id = x.Id,
                Email = HashHelper.Decrypt(x.Email),
                FirstName = HashHelper.Decrypt(x.FirstName),
                Gender = HashHelper.Decrypt(x.Gender),
                LastName = HashHelper.Decrypt(x.LastName),
                Notes = HashHelper.Decrypt(x.Notes),
                Phone = HashHelper.Decrypt(x.Phone)
            });
        }

        public PatientDto GetPatientById(long id)
        {
            var patientDto = patientRepository.GetPatientById(id);

            return new PatientDto
            {
                Id = patientDto.Id,
                Email = HashHelper.Decrypt(patientDto.Email),
                FirstName = HashHelper.Decrypt(patientDto.FirstName),
                Gender = HashHelper.Decrypt(patientDto.Gender),
                LastName = HashHelper.Decrypt(patientDto.LastName),
                Notes = HashHelper.Decrypt(patientDto.Notes),
                Phone = HashHelper.Decrypt(patientDto.Phone)
            };
        }
    }
}
