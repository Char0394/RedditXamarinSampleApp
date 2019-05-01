using System;
using System.Globalization;
using System.Linq;
using ReditXamarinApp.Models;
using Xamarin.Forms;

namespace ReditXamarinApp.Helpers
{
    public class UrlToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Preview preview && preview.Images != null && preview.Images.Count > 0)
            {
                return preview.Images.First().Source.Url;
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
