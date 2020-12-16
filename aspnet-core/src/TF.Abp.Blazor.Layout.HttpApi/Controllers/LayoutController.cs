using TF.Abp.Blazor.Layout.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TF.Abp.Blazor.Layout.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class LayoutController : AbpController
    {
        protected LayoutController()
        {
            LocalizationResource = typeof(LayoutResource);
        }
    }
}