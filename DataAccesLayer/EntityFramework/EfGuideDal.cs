using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public void ChangeToFalseByGuide(int id)
        {
            using (var context = new Context())
            {
                var values = context.Guides.Find(id);
                if (values != null)
                {
                    values.Status = false;
                    context.Update(values);
                    context.SaveChanges();
                }
            }
        }

        public void ChangeToTrueByGuide(int id)
        {
            using (var context = new Context())
            {
                var values = context.Guides.Find(id);
                if (values != null)
                {
                    values.Status = true;
                    context.Update(values);
                    context.SaveChanges();
                }
            }
        }

    }
}
