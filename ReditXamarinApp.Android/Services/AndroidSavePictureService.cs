using System;
using System.Net;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using ReditXamarinApp.Droid.Services;
using ReditXamarinApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidSavePictureService))]
namespace ReditXamarinApp.Droid.Services
{
    public class AndroidSavePictureService : ISavePictureService
    {
        public Task<bool> SaveFromUrl(string url)
        {
            bool retVal = false;
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                   using (var webClient = new WebClient())
                    {
                        var imageBytes = webClient.DownloadData(url);
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            string name = "RedditImage-" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                            var file = new Java.IO.File(GetDirectoryForPictures("REDDIT"), name);

                            System.IO.File.WriteAllBytes(file.Path, imageBytes);

                            try
                            {
                                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                                Android.Net.Uri contentUri = Android.Net.Uri.FromFile(new Java.IO.File(file.Path));
                                mediaScanIntent.SetData(contentUri);
                                Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
                                retVal = true;
                            }
                            catch (Exception ex)
                            {

                                System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
            return Task.FromResult(retVal);
        }

        Java.IO.File GetDirectoryForPictures(string collectionName)
        {
            var fileDir = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), collectionName);
            if (!fileDir.Exists())
            {
                fileDir.Mkdirs();
            }

            return fileDir;

        }

    }
}