using PatientManager.Domain.Entity;
using System.Collections.Generic;

namespace PatientManager.Repository.Interfaces
{
    public interface IPatientRepository
    {
        void AddPatient(Patient patient);
        void EditPatient(Patient patient);
        void DeletePatientById(long id);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(long id);
    }
}
