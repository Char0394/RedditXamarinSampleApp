using System;
using System.Collections.Generic;
using ReditXamarinApp.ViewModels;
using Xamarin.Forms;

namespace ReditXamarinApp.Views
{
    public partial class PostsPageDetailPage : ContentPage
    {
        public PostsPageDetailPage()
        {
            InitializeComponent();
            this.BindingContext = new PostsPageDetailViewModel();
        }
    }
}
