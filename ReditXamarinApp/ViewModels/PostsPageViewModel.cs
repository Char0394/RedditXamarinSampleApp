using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ReditXamarinApp.Models;
using Xamarin.Forms;

namespace ReditXamarinApp.ViewModels
{
    public class PostsPageViewModel: BaseViewModel
    {
        public ObservableCollection<PostItem> Posts { get; set; }
        public ICommand LoadMoreCommand { get; set; }
        public ICommand GetDataCommand { get; set; }
        public ICommand RefreshDataCommand { get; set; }
        public bool IsRefreshing { get; set; }
        string _nextPageId;
        string _actualPageId;

        public PostsPageViewModel()
        {
            LoadMoreCommand = new Command(async () => await LoadMoreDataAysnc());
            GetDataCommand = new Command(async () => await GetDataAsync());
            RefreshDataCommand = new Command(async () => await GetDataAsync(false, true));

            GetDataCommand.Execute(null);
        }

        async Task LoadMoreDataAysnc()
        {
            if (!string.IsNullOrEmpty(_nextPageId))
            {
                _actualPageId = _nextPageId;
                await GetDataAsync(true);
            }
        }

        async Task GetDataAsync(bool loadMore = false, bool isRefreshing = false)
        {
            IsBusy = !isRefreshing;
            IsRefreshing = isRefreshing;

            var posts = await ApiManager.GetPostsAsync(_actualPageId);
            _nextPageId = posts?.After;

            if (posts?.Children?.Count > 0)
            {
                if (loadMore)
                {
                    foreach (var item in posts.Children)
                    {
                        Posts.Add(item);
                    }
                }
                else
                {
                    Posts = new ObservableCollection<PostItem>(posts.Children);
                }
            }
            IsBusy = IsRefreshing=false;
        }
    }
}
