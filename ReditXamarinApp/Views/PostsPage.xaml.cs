using System;
using System.Collections.Generic;
using ReditXamarinApp.ViewModels;
using Xamarin.Forms;

namespace ReditXamarinApp.Views
{
    public partial class PostsPage : MasterDetailPage
    {
        public PostsPage()
        {
            InitializeComponent();
            this.BindingContext = new PostsPageViewModel();

            Detail = new NavigationPage(new PostsPageDetailPage());
        }
        public void OpenPost_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
        }

    }
}
