﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xam4AspNetPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public string SubTitle => "sksksk";

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}