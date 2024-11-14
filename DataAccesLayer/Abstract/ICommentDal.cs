using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        public List<Comment> GetListCommentsWithDestination();
        public List<Comment> GetListCommentWithDestinationAndUser(int id);
    }
}
