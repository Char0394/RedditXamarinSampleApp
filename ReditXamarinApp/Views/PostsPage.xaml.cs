using System.Threading.Tasks;
using Newtonsoft.Json;
using ReditXamarinApp.Models;
using ReditXamarinApp.ViewModels;
using Xamarin.Essentials;
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
            GetPostSelected();
        }
        public void OpenPost_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            IsPresented = false;
            var data = (PostItem)e.Item;
            data.Data.NotReaded = false;

            postsPage.BindingContext = data;
            Detail = new NavigationPage(postsPage);
            SavePostSelected(data);
        }

        //App state-preservation/restoration logic
        async void SavePostSelected(PostItem data)
        {
            var result = await Task.Run(() => JsonConvert.SerializeObject(data));
            Preferences.Set(Config.LastPostSelectedKey, result);
        }

        async void GetPostSelected()
        {
            var myValue = Preferences.Get(Config.LastPostSelectedKey,string.Empty);
            if (!string.IsNullOrEmpty(myValue))
            {
                var result = await Task.Run(() => JsonConvert.DeserializeObject<PostItem>(myValue));
                postsPage.BindingContext = result;
                Detail = new NavigationPage(postsPage);
            }
        }
    }
}
