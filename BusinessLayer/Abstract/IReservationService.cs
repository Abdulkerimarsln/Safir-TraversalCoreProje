using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Rezervation>
    {
        List<Rezervation> GetListApprovalReservationByWaitAproval(int id);
        List<Rezervation> GetListApprovalReservationByAccepted(int id);
        List<Rezervation> GetListApprovalReservationByPrevious(int id);
    }
}
