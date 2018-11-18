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
    }
}
