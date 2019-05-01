using Foundation;
using UIKit;
using Photos;
using System.Threading.Tasks;
using ReditXamarinApp.Services;
using System;
using ReditXamarinApp.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSSavePictureService))]
namespace ReditXamarinApp.iOS.Services
{
    public class IOSSavePictureService : NSObject, ISavePictureService
    {
        public async Task<bool> SaveFromUrl(string url)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            if (!string.IsNullOrEmpty(url))
            {
                if (PHPhotoLibrary.AuthorizationStatus == PHAuthorizationStatus.Denied)
                {
                    tcs.TrySetResult(false);
                }
                else
                {
                    try
                    {
                        var image = UIImage.LoadFromData(NSData.FromUrl(NSUrl.FromString(url)));
                        if (PHPhotoLibrary.AuthorizationStatus == PHAuthorizationStatus.Authorized)
                        {
                            tcs.TrySetResult(await SaveImage(image));

                        }
                        else
                        {
                            PHPhotoLibrary.RequestAuthorization(async (status) =>
                            {
                                if (status == PHAuthorizationStatus.Authorized)
                                {
                                    tcs.TrySetResult(await SaveImage(image));
                                }
                                else
                                {
                                    tcs.TrySetResult(false);
                                }

                            });
                        }



                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());

                        tcs.TrySetResult(false);
                    }
                }

            }
            else
            {
                tcs.TrySetResult(false);
            }

            return await tcs.Task;

        }

        async Task<bool> SaveImage(UIImage image)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            InvokeOnMainThread(() =>
            {
                image.SaveToPhotosAlbum((uiImage, nsError) =>
                {
                    if (nsError != null)
                    {
                        tcs.TrySetResult(false);
                        System.Diagnostics.Debug.WriteLine(nsError.Description);
                    }
                    else
                    {
                        tcs.TrySetResult(true);
                    }

                });

            });

            return await tcs.Task;
        }
    }
}