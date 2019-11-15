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

        ///  UGLY  DUMMY DATA = no culture 
        const double demoSum = 99.99;

        public static MainPageViewModel MainPageViewModeDE
        {
            get { return new MainPageViewModel(null) { Title = "Deutsch", ButtonText = "Rechnungen".ToUpper() + "€" };  }
        }

        public static MainPageViewModel MainPageViewModePL
        {
            get { return new MainPageViewModel(null) { UglyCurtureTextForSample= "PL", Title = "Polski", ButtonText = "Faktury " + demoSum + "PLN" }; }
        }

        public static MainPageViewModel MainPageViewModeEL
        {
            get { return new MainPageViewModel(null) { Title = "ελληνικά", ButtonText = "τιμολόγια " }; } //usp... "forgot to add"
        }

        public static MainPageViewModel MainPageViewModeEn
        {
            get { return new MainPageViewModel(null) { UglyCurtureTextForSample = "UK", Title = "English", ButtonText = "Invoices " + "€ " + demoSum }; } //I'm ugly and I know 
        }
        public static MainPageViewModel MainPageViewModeEn2
        {
            get { return new MainPageViewModel(null) { UglyCurtureTextForSample = "UK", Title = "English2", ButtonText = "Invoices" + "£ " + demoSum }; }
        }
    }
}