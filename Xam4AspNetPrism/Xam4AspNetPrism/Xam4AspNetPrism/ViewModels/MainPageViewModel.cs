using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Xam4AspNetPrism.DesignDataLoacator;

namespace Xam4AspNetPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public string SubTitle => "Let's do some ugly formatting:";

        public string ButtonText { get; set; }

        #region This You WONN'T get in Previewer
        public string EntryText { get; set; }
        public string UglyCurtureTextForSample { get; set; }

        public string LabelText { get; set; }
        #endregion

        public ObservableCollection<Monkey> Monkeys { get; set; }

        public DelegateCommand SubmitCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            SubmitCommand = new DelegateCommand(Submit, CanSubmit);
        }

        #region This You WONN'T get in Previewer
        void Submit()
        {
            //implement logic
            // USGLY SAMPLE LOGIC = No cultureInfo
            LabelText = Title + " " + EntryText + " € ";

            if (UglyCurtureTextForSample == "UK")
            {
                LabelText = Title + " £" + EntryText ;
            }

            if (UglyCurtureTextForSample == "PL")
            {
                LabelText = Title + EntryText + "PLN";
            }

            RaisePropertyChanged("LabelText");
        }

        bool CanSubmit()
        {
            return true;
        }
        #endregion
    }
}