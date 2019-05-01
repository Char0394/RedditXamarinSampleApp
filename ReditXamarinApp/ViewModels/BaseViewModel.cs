using System;
using System.ComponentModel;
using ReditXamarinApp.Services;

namespace ReditXamarinApp.ViewModels
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public bool IsBusy { get; set; }
        protected IApiManager ApiManager = new ApiManager();
        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
