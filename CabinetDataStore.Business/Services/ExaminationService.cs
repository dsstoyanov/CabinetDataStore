using AutoMapper;
using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.Business.CabinetDataStoreContext;
using CabinetDataStore.BusinessService.ExaminationModels;
using CabinetDataStore.Business.Models;
using CabinetDataStore.BusinessService.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using System.Security.Cryptography.X509Certificates;
using System.Data.Entity;

namespace CabinetDataStore.Business.Services
{
    public class ExaminationService : IExamination
    {
        public List<ExaminationModel> GetAllExaminationsByPatientID(long patientId)
        {
            try
            {
                using (CabinetEntities context = new CabinetEntities())
                {
                    var Examinations = context.ExaminationsData.Where(x => x.PatientId == patientId).ToList();
                    
                    return Mapper.Map<List<ExaminationModel>>(Examinations);
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Informational($"Critical at class::{this.GetType().Name}");
                LoggerManager.Critical(ex);
                return null;
            }
        }

        public List<ExaminationModel> GetExaminationsForToday()
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                var Examinations = context.ExaminationsData.Where(x => x.ExaminationDate.Day == DateTime.Now.Day && x.ExaminationDate.Month == DateTime.Now.Month && x.ExaminationDate.Year == DateTime.Now.Year).ToList();

                return Mapper.Map<List<ExaminationModel>>(Examinations);
            }
        }

        public ExaminationModel GetExaminationById(long examinationId)
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                var Examinations = context.ExaminationsData.Where(x => x.ExaminationId == examinationId).FirstOrDefault();

                return Mapper.Map<ExaminationModel>(Examinations);
            }
        }

        public bool InsertExamination(ExaminationModel examinationModel)
        {
            bool result = false;
            using (CabinetEntities context = new CabinetEntities())
            {
                var examination = Mapper.Map<ExaminationsData>(examinationModel);

                try
                {
                    context.ExaminationsData.Add(examination);
                    context.SaveChanges();
                    result = true;
                    return result;
                }
                catch (Exception ex)
                {
                    
                    return result;
                }
            }
        }

        public bool UpdateExamination(ExaminationModel newExamination, ExaminationModel oldExamination)
        {
            bool result = false;
            using (CabinetEntities context = new CabinetEntities())
            {
                try
                {
                    var Examination = context.ExaminationsData.Where(x => x.ExaminationId == oldExamination.ExaminationID).FirstOrDefault();
                    
                    Examination.Births = newExamination.BirthsCount;
                    Examination.Bleeding = newExamination.Bleeding;
                    Examination.Colposcopy = newExamination.Colposcopy;
                    Examination.Diagnosis = newExamination.Diagnosis;
                    Examination.Echography = newExamination.Echography;
                    Examination.Fluorine = newExamination.Fluorine;
                    Examination.Operations = newExamination.Operations;
                    Examination.Others = newExamination.Others;
                    Examination.Pain = newExamination.Pain;
                    Examination.Picture = newExamination.Photo;
                    Examination.PRM = newExamination.PRM;
                    Examination.Recommendations = newExamination.Recommendations;
                    Examination.Results = newExamination.Results;
                    Examination.Therapy = newExamination.Therapy;

                    context.SaveChanges();
                    
                    return true;
                }
                catch (Exception ex)
                {

                    return result;
                }
            }
        }

        public int ExaminationsCount()
        {
            try 
            {
                using (CabinetEntities context = new CabinetEntities())
                {
                    var examinations = context.ExaminationsData.Count();

                    return examinations;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerManager.Critical(ex);
                return 0;
            }
        }

        public List<ExaminationModel> GetExaminationsByDate(DateTime date)
        {
            try
            {
                using (CabinetEntities context = new CabinetEntities())
                {
                    var examinations = context.ExaminationsData.Where(x => DbFunctions.TruncateTime(x.ExaminationDate) == date.Date).ToList();

                    return Mapper.Map<List<ExaminationModel>>(examinations);
                }

            }
            catch(Exception ex) 
            {
                LoggerManager.Informational($"Critical at class::{this.GetType().Name}");
                LoggerManager.Critical(ex);
                return null;
            }
        }
    }
}
