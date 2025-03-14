using CabinetDataStore.BusinessService.ExaminationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Business.Abstraction
{
    public interface IExamination
    {
        List<ExaminationModel> GetAllExaminationsByPatientID(long patientId);

        List<ExaminationModel> GetExaminationsForToday();

        ExaminationModel GetExaminationById(long examinationId);

        bool InsertExamination(ExaminationModel examination);

        bool UpdateExamination(ExaminationModel newExamination, ExaminationModel oldExamination);

        int ExaminationsCount();

        List<ExaminationModel> GetExaminationsByDate(DateTime date);
    }
}
