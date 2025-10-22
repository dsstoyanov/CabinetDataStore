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
using System.Linq.Expressions;
using CabinetDataStore.BusinessService.NotificationModels;
using System.Diagnostics;

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
                LoggerManager.Informational($"Critical at namespace::{this.GetType().FullName}");
                LoggerManager.Critical(ex);
                return null;
            }
        }

        public List<ExaminationModel> GetExaminationsForToday()
        {
            try
            {
                using (CabinetEntities context = new CabinetEntities())
                {
                    var Examinations = context.ExaminationsData
                        .Include(x => x.Patient)
                        .Where(x => x.ExaminationDate.Day == DateTime.Now.Day && x.ExaminationDate.Month == DateTime.Now.Month && x.ExaminationDate.Year == DateTime.Now.Year)
                        .ToList();
                    
                    return Mapper.Map<List<ExaminationModel>>(Examinations);
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Informational($"Critical at namespace::{this.GetType().FullName}");
                Logger.LoggerManager.Critical(ex);
                return null;
            }
        }

        public ExaminationModel GetExaminationById(long examinationId)
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                var Examinations = context.ExaminationsData
                    .Include(x=>x.Patient)
                    .Where(x => x.ExaminationId == examinationId)
                    .FirstOrDefault();

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
                    LoggerManager.Informational($"Critical at namespace::{this.GetType().FullName}");
                    Logger.LoggerManager.Critical(ex);
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
                    LoggerManager.Informational($"Critical at namespace::{this.GetType().FullName}");
                    Logger.LoggerManager.Critical(ex);
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
                LoggerManager.Informational($"Critical at namespace::{this.GetType().FullName}");
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
                    var examinations = context.ExaminationsData
                        .Include(x => x.Patient)
                        .Where(x => DbFunctions.TruncateTime(x.ExaminationDate) == date.Date)
                        .ToList();

                    return Mapper.Map<List<ExaminationModel>>(examinations);
                }

            }
            catch(Exception ex) 
            {
                LoggerManager.Informational($"Critical at namespace::{this.GetType().FullName}");
                LoggerManager.Critical(ex);
                return null;
            }
        }

        public List<ExaminationModel> GetExaminationsByTimeRange(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                using (var context = new CabinetEntities())
                {
                    var examsInRange = context.ExaminationsData
                        .AsNoTracking()
                        .Where(x =>
                            DbFunctions.TruncateTime(x.ExaminationDate) >= dateFrom &&
                            DbFunctions.TruncateTime(x.ExaminationDate) <= dateTo &&
                            // ❗ Exclude patients who have later examinations
                            !context.ExaminationsData
                                .Any(y => y.PatientId == x.PatientId &&
                                          DbFunctions.TruncateTime(y.ExaminationDate) > dateTo))
                        .GroupBy(x => x.PatientId)
                        .Select(g => g.OrderByDescending(x => x.ExaminationDate).FirstOrDefault())
                        .Select(x => new
                        {
                            x.ExaminationId,
                            x.ExaminationDate,
                            x.PatientId,
                            PatientName = x.Patient.PatientName,
                            PhoneNumber = x.Patient.PhoneNumber,
                            Notifications = x.Notifications.Select(n => new
                            {
                                n.NotificationId,
                                n.isNotified
                            }).ToList()
                        }).ToList();

                    Logger.LoggerManager.Informational($"[Step1] Get each patient's latest exam time: {s.ElapsedMilliseconds}ms");

                    // Step 2: Filter out patients who have any exam *after* dateTo
                    var finalList = examsInRange
                        .Where(exam => !context.ExaminationsData.Any(
                            e2 => e2.PatientId == exam.PatientId && e2.ExaminationDate > dateTo))
                        .ToList();

                    Logger.LoggerManager.Informational($"[Step2] Filter out patients time: {s.ElapsedMilliseconds}ms");

                    // Step 3: Map to your view models
                    var result = examsInRange.Select(x => new ExaminationModel
                    {
                        ExaminationID = x.ExaminationId,
                        ExaminationDate = x.ExaminationDate,
                        Patient = new PatientModel
                        {
                            PatientId = Convert.ToInt32(x.PatientId),
                            PatientName = x.PatientName,
                            PhoneNumber = x.PhoneNumber
                        },
                        Notifications = x.Notifications.Select(n => new NotificationModel
                        {
                            NotificationId = n.NotificationId,
                            isNotified = n.isNotified
                        }).ToList()
                    }).ToList();

                    s.Stop();
                    LoggerManager.Informational($"[GetExaminationsByTimeRange] executed time overall: {s.ElapsedMilliseconds}ms");

                    return result;
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Informational($"Critical at namespace::{this.GetType().FullName}");
                LoggerManager.Critical(ex);
                return null;
            }
        }
    }
}
