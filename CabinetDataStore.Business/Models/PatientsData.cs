using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Business.Models
{
    [Table("PatientsData", Schema = "public")]
    public class PatientsData
    {
        PatientsData()
        {
            this.Examinations = new HashSet<ExaminationsData>();
        }
        [Key]
        public long PatientId { get; set; }

        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDay { get; set; }

        public string email { get; set; }

        public virtual ICollection<ExaminationsData> Examinations { get; set; }
    }
}
