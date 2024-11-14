using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentsWithDestination()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x=>x.Destination).ToList();
            }
           
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            using (var c = new Context())
            {
                return c.Comments.Where(x=>x.DestinationID==id).Include(x => x.AppUser).ToList();
            }
        }
    }
}
