using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CabinetDataStore.Business.Models
{
    [Table("Notifications", Schema = "public")]
    public class NotificationsData
    {
        [Key]
        public long NotificationId { get; set; }
        public long ExaminationId { get; set; }
        public long PatientId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool isNotified { get; set; }
    }
}
