using System;
using System.Threading.Tasks;

namespace ReditXamarinApp.Services
{
    public interface ISavePictureService
    {
        Task<bool> SaveFromUrl(string url);
    }
}
