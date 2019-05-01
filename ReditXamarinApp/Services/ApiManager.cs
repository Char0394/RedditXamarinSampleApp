using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReditXamarinApp.Models;
using Refit;
using Xamarin.Essentials;

namespace ReditXamarinApp.Services
{
    public class ApiManager: IApiManager
    {
        public async Task<PostData> GetPostsAsync(string nextPage)
        {
            try
            {
                if(HaveInternetConnection())
                {
                    var nsAPI = RestService.For<IRedditApi>(Config.RedditApiUrl);
                    var postsResponse = await nsAPI.GetPosts(20, nextPage);

                    if (postsResponse.IsSuccessStatusCode)
                    {
                        var responseContent = await postsResponse.Content.ReadAsStringAsync();
                        var result = await Task.Run(() => JsonConvert.DeserializeObject<Post>(responseContent));
                        return result?.Data;
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Please check your internet connection", "Ok");
                }
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            await App.Current.MainPage.DisplayAlert("Error", "Unable to get data", "Ok");
            return null;
        }


        bool HaveInternetConnection()
        {
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }
    }
}
