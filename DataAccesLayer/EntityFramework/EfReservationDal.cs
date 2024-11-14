using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Rezervation>, IReservationDal
    {
        public List<Rezervation> GetListWithoutReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();
            }
        }

        public List<Rezervation> GetListWithoutReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            }
        }

        public List<Rezervation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId==id).ToList();
            }
        }
    }
}
