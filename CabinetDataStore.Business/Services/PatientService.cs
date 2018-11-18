using AutoMapper;
using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.BusinessService.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Business.Services
{
    public class PatientService : IPatient
    {
        public List<PatientModel> GetAllPatients()
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                var Patients = context.PatientDatas.ToList();

                return Mapper.Map<List<PatientModel>>(Patients);
            }

        }
    }
}
