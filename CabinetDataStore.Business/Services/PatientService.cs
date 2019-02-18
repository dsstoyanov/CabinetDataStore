using AutoMapper;
using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.BusinessService.Enums;
using CabinetDataStore.BusinessService.ExaminationModels;
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

        public List<PatientModel> GetPatientByFilter(SearchTypes srchType, object value)
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                List<PatientData> Patient = new List<PatientData>();
                switch (srchType)
                {
                    case SearchTypes.Name:
                        Patient = context.PatientDatas.Where(x => x.PatientName == (string)value).ToList();
                        break;

                    case SearchTypes.PhoneNumber:
                        Patient = context.PatientDatas.Where(x => x.PhoneNumber == (string)value).ToList();
                        break;

                    case SearchTypes.DateOfBirth:
                        Patient = context.PatientDatas.Where(x => x.BirthDay.ToString() == (string)value).ToList();
                        break;

                    default: Patient = null;
                        break;
                }
                
                return Mapper.Map<List<PatientModel>>(Patient);
            }
        }

        public PatientModel GetPatientById(int patientId)
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                var Patient = context.PatientDatas.Where(x => x.PatientId == patientId).FirstOrDefault();

                return Mapper.Map<PatientModel>(Patient);
            }
        }
    }
}
