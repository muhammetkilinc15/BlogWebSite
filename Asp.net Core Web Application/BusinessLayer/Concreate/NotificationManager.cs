using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _dal;

        public NotificationManager(INotificationDal dal)
        {
            _dal = dal;
        }

        public List<Notification> GetList()
        {
            return _dal.GetListAll();
        }

        public void TAdd(Notification entity)
        {
           _dal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
          _dal.Delete(entity);
        }

        public Notification TGetById(int id)
        {
            return _dal.GetByID(id);
        }

        public void TUpdate(Notification entity)
        {
            _dal.Update(entity);
        }
    }
}
