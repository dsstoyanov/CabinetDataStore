using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.BusinessService.PatientModels
{
    public class PatientModel
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string EmailAddress { get; set; }
    }
}
