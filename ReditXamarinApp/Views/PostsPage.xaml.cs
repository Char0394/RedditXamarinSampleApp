using ReditXamarinApp.Models;
using ReditXamarinApp.ViewModels;
using Xamarin.Forms;

namespace ReditXamarinApp.Views
{
    public partial class PostsPage : MasterDetailPage
    {
        PostsPageDetailPage postsPage= new PostsPageDetailPage();
        public PostsPage()
        {
            InitializeComponent();
            this.BindingContext = new PostsPageViewModel();
            Detail = new NavigationPage(postsPage);
        }
        public void OpenPost_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            IsPresented = false;
            var data = (PostItem)e.Item;
            data.Data.NotReaded = false;

            postsPage.BindingContext = data;
            Detail = new NavigationPage(postsPage);
        }
    }
}
