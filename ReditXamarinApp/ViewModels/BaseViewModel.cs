using System;
using System.ComponentModel;

namespace ReditXamarinApp.ViewModels
{
    public class BaseViewModel: INotifyPropertyChanged
    {

        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
