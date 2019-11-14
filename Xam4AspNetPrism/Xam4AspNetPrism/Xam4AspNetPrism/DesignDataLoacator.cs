using System;
using System.Collections.Generic;
using System.Text;
using Xam4AspNetPrism.ViewModels;

namespace Xam4AspNetPrism
{
    public static class DesignDataLoacator
    {
        public static MainPageViewModel MainPageViewModeBasic
        {
            get { return new MainPageViewModel(null) { Title = "Basic" }; }
        }
        public static MainPageViewModel MainPageViewModeBogush
        {
            get { return new MainPageViewModel(null) { Title = "Bogush Bogush Bogush" }; }
        }
    }
}