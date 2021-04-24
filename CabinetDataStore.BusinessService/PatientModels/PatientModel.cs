using CabinetDataStore.BusinessService.ExaminationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.BusinessService.PatientModels
{
    public class PatientModel
    {
        public PatientModel()
        {
            this.Examinations = new HashSet<ExaminationModel>();
        }
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string EmailAddress { get; set; }

        public ICollection<ExaminationModel> Examinations { get; set; }
    }
}
