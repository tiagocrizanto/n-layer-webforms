using PatientManager.Domain.Dto;
using System.Collections.Generic;

namespace PatientManager.Business.Interfaces
{
    public interface IPatientBusiness
    {
        void AddPatient(PatientDto patient);
        void EditPatient(PatientDto patient);
        void DeletePatientById(long id);
        IEnumerable<PatientDto> GetAllPatients();
        PatientDto GetPatientById(long id);
    }
}
