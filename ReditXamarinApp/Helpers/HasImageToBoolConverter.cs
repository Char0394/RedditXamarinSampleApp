using System;
using System.Globalization;
using ReditXamarinApp.Models;
using Xamarin.Forms;

namespace ReditXamarinApp.Helpers
{
    public class HasImageToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is Preview preview && preview.Images != null && preview.Images.Count > 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
