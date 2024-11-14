using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        public readonly IDestinationalDal _destinationalDal;


        public DestinationManager(IDestinationalDal destinationalDal)
        {
            _destinationalDal = destinationalDal;
        }

        public Destination TGetDestinationWithGuide(int id)
        {
            return _destinationalDal.GetDestinationWithGuide(id);
        }

        public void TAdd(Destination t)
        {
            _destinationalDal.Insert(t);
        }

        public void TDelete(Destination t)
        {
            _destinationalDal.Delete(t);
        }

        public Destination TGetByID(int id)
        {
            using var c = new Context();
            return c.Set<Destination>().SingleOrDefault(x => x.DestinationID == id);
        }

        public List<Destination> TGetList()
        {
            return _destinationalDal.GetList();
        }

        public void TUpdate(Destination t)
        {
            _destinationalDal.Update(t);
        }

        public List<Destination> TGetLast4Destinations()
        {
            return _destinationalDal.GetLast4Destinations();
        }
    }
}
