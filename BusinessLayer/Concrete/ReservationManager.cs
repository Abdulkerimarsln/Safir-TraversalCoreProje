using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Rezervation> GetListApprovalReservationByAccepted(int id)
        {
            return _reservationDal.GetListWithoutReservationByAccepted(id);
        }

        public List<Rezervation> GetListApprovalReservationByPrevious(int id)
        {
            return _reservationDal.GetListWithoutReservationByPrevious(id);

        }

        public List<Rezervation> GetListApprovalReservationByWaitAproval(int id)
        {
            return _reservationDal.GetListWithReservationByWaitApproval(id);
        }

        public void TAdd(Rezervation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Rezervation t)
        {
            _reservationDal.Delete(t);
        }

        public Rezervation TGetByID(int id)
        {
            return _reservationDal.GetByID(id);
          
        }

        public List<Rezervation> TGetList()
        {
            return _reservationDal.GetList();

        }

        public void TUpdate(Rezervation t)
        {
            _reservationDal.Update(t);
        }
    }
}
