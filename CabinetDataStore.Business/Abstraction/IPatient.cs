using CabinetDataStore.BusinessService.Enums;
using CabinetDataStore.BusinessService.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Business.Abstraction
{
    public interface IPatient
    {
        List<PatientModel> GetAllPatients();

        List<PatientModel> GetPatientByFilter(SearchTypes srchType, object value);

        PatientModel GetPatientById(long patientId);

        bool InsertPatient (PatientModel patient);

        bool UpdatePatient(PatientModel patient);

        int PatientsCount();
    }
}
