using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.BusinessService.ExaminationModels
{
    public class ExaminationModel
    {
        public long ExaminationID { get; set; }

        public long PatientId { get; set; }

        public DateTime ExaminationDate { get; set; }
        
        public DateTime PRM { get; set; }

        public int BirthsCount { get; set; }

        public string Operations { get; set; }

        public string Pain { get; set; }

        public string Bleeding { get; set; }

        public string Fluorine { get; set; }

        public string Others { get; set; }

        public string Colposcopy { get; set; }

        public string Echography { get; set; }

        public string Results { get; set; }

        public string Therapy { get; set; }

        public string Recommendations { get; set; }

        public string Diagnosis { get; set; }

        public byte[] Photo { get; set; }
    }
}
