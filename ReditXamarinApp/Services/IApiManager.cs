using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReditXamarinApp.Models;

namespace ReditXamarinApp.Services
{
    public interface IApiManager
    {
        Task<PostData> GetPostsAsync(string nextPage);
    }
}
