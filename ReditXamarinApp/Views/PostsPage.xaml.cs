using System;
using System.Collections.Generic;
using ReditXamarinApp.ViewModels;
using Xamarin.Forms;

namespace ReditXamarinApp.Views
{
    public partial class PostsPage : ContentPage
    {
        public PostsPage()
        {
            InitializeComponent();
            this.BindingContext = new PostsPageViewModel();
        }
    }
}
