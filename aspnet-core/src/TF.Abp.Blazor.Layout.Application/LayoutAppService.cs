using System;
using System.Collections.Generic;
using System.Text;
using TF.Abp.Blazor.Layout.Localization;
using Volo.Abp.Application.Services;

namespace TF.Abp.Blazor.Layout
{
    /* Inherit your application services from this class.
     */
    public abstract class LayoutAppService : ApplicationService
    {
        protected LayoutAppService()
        {
            LocalizationResource = typeof(LayoutResource);
        }
    }
}
