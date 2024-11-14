using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Testimonial:ViewComponent
    {
        TestimonialManager manager =new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values = manager.TGetList();
            return View(values);
        }
    }
}
