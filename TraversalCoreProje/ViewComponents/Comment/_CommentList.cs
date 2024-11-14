using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        CommentManager commentManager =new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        { 
            ViewBag.v = 10;
            var values  = commentManager.TGetListCommentWithDestinationAndUser(id);
            return View(values); 
        }
    }
}
