using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Rezervation>
    {
        List<Rezervation> GetListWithReservationByWaitApproval(int id);
        List<Rezervation> GetListWithoutReservationByAccepted(int id);
        List<Rezervation> GetListWithoutReservationByPrevious(int id);
    }
}
