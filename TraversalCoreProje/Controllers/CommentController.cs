using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;

        public CommentController(CommentManager commentManager, UserManager<AppUser> userManager)
        {
            _commentManager = commentManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<PartialViewResult> AddComment(int id)
        {
            ViewBag.destid = id;
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
           ViewBag.UserID = 4;
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            _commentManager.TAdd(p);
            return RedirectToAction("Index","Destination");
        }
    }
}
