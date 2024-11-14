using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Feature:ViewComponent
    {
        FeatureManager featureManager=new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values= featureManager.TGetList();
            return View(values);
        }
    }
}
