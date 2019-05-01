using Xamarin.Forms;
using System;
using ReditXamarinApp.Models;
using ReditXamarinApp.Services;

namespace ReditXamarinApp.Views
{
    public partial class PostsPageDetailPage : ContentPage
    {
        public PostsPageDetailPage()
        {
            InitializeComponent();

        }

        public async void Save_Handle_Clicked(object sender, EventArgs e)
        {
            var param = ((Button)sender).CommandParameter;
            var result=await DependencyService.Get<ISavePictureService>().SaveFromUrl($"{param}");
            if (result)
            {
                await DisplayAlert("Yayyy", "Image saved succesfully", "Ok");
            }
            else
            {
                await DisplayAlert("Ooops", "Couldn't save image", "Ok");
            }
        }

    }
}
