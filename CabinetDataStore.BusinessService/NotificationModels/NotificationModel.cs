using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.BusinessService.NotificationModels
{
    public class NotificationModel
    {
        public long NotificationId { get; set; }
        public long ExaminationId { get; set; }
        public long PatientId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool isNotified { get; set; }
    }
}
