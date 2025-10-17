using AutoMapper;
using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.Business.CabinetDataStoreContext;
using CabinetDataStore.Business.Models;
using CabinetDataStore.BusinessService.NotificationModels;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Business.Services
{
    public class NotificationService : INotification
    {
        public List<NotificationModel> GetNotifications()
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                var Notifications = context.NotificationsData.ToList();

                return Mapper.Map<List<NotificationModel>>(Notifications);
            }
        }

        public long? InsertNotification(long patientId, long examinationId, DateTime examinationDate)
        {
            using (CabinetEntities context = new CabinetEntities())
            {
                try
                {
                    NotificationsData notification = new NotificationsData();

                    notification.PatientId = patientId;
                    notification.ExaminationId = examinationId;
                    notification.ExaminationDate = examinationDate;
                    notification.NotificationDate = DateTime.Now;
                    notification.isNotified = true;

                    context.NotificationsData.Add(notification);
                    context.SaveChanges();

                    return notification.NotificationId;
                }
                catch (Exception ex)
                {
                    LoggerManager.Informational($"Critical at namespace::{this.GetType().FullName}");
                    Logger.LoggerManager.Critical(ex);
                    return null;
                }
            }
        }

        public bool UpdateNotification(long NotificationId, bool isNotified)
        {
            bool result = false;
            using (CabinetEntities context = new CabinetEntities())
            {
                try
                {
                    var notification = context.NotificationsData.Where(x => x.NotificationId == NotificationId).FirstOrDefault();

                    notification.isNotified = isNotified;

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
    }
}
