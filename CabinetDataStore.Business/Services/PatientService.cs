using AutoMapper;
using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.Business.CabinetDataStoreContext;
using CabinetDataStore.Business.Models;
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
                var Patients = context.PatientsData.ToList();

                return Mapper.Map<List<PatientModel>>(Patients);
            }

        }

        public List<PatientModel> GetPatientByFilter(SearchTypes srchType, object value)
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                List<PatientsData> Patient = new List<PatientsData>();
                switch (srchType)
                {
                    case SearchTypes.Name:
                        Patient = context.PatientsData.Where(x => x.PatientName.ToLower() == (string)value.ToString().ToLower()).ToList();
                        break;

                    case SearchTypes.PhoneNumber:
                        Patient = context.PatientsData.Where(x => x.PhoneNumber == (string)value).ToList();
                        break;

                    case SearchTypes.DateOfBirth:
                        var birthdate = value.ToString();
                        var casted = DateTime.Parse(birthdate);
                        Patient = context.PatientsData.Where(x => x.BirthDay == casted).ToList();
                        break;

                    default: Patient = null;
                        break;
                }
                
                return Mapper.Map<List<PatientModel>>(Patient);
            }
        }

        public PatientModel GetPatientById(long patientId)
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                var Patient = context.PatientsData.Where(x => x.PatientId == patientId).FirstOrDefault();

                return Mapper.Map<PatientModel>(Patient);
            }
        }

        public bool InsertPatient(PatientModel patientModel)
        {
            bool result = false;
            using (CabinetEntities context = new CabinetEntities())
            {
                var patient = Mapper.Map<PatientsData>(patientModel);

                try
                {
                    context.PatientsData.Add(patient);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    return result;
                }
            }
        }
    }
}
