using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Business.Models
{
    [Table("ExaminationsData", Schema = "public")]
    public class ExaminationsData
    {
        [Key]
        public long ExaminationId { get; set; }
        public long PatientId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public DateTime PRM { get; set; }
        public int Births { get; set; }
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
        public byte[] Picture { get; set; }
        
    }
}
