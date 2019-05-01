using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace ReditXamarinApp.Services
{
    [Headers("Content-Type: application/json")]
    public interface IRedditApi
    {
        [Get("/new.json?sort=top&raw_json=1&limit={limit}&after={nextPage}")]
        Task<HttpResponseMessage> GetPosts(int limit, string nextPage);
    }
}
