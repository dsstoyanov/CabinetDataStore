using CabinetDataStore.BusinessService.NotificationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Business.Abstraction
{
    public interface INotification
    {
        List<NotificationModel> GetNotifications();
        bool UpdateNotification(long NotificationId, bool isNotified);
        long? InsertNotification(long PatientId, long ExaminationId, DateTime ExaminationDate);
    }
}
