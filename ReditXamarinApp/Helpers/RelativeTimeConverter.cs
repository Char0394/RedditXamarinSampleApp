using System;
using System.Globalization;
using Xamarin.Forms;

namespace ReditXamarinApp.Helpers
{
    public class RelativeTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dt = UnixTimeStampToDateTime(Double.Parse(value.ToString()));

            var current_day = DateTime.Today;
            var postedData = (DateTime)dt;

            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - postedData.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
            {
                if (ts.Seconds < 0)
                {
                    return "sometime ago";
                }
                return ts.Seconds == 1 ? "One second ago" : ts.Seconds + " seconds ago";
            }

            if (delta < 2 * MINUTE)
                return "A minute ago";

            if (delta < 45 * MINUTE)
            {
                if (ts.Seconds < 0)
                {
                    return "sometime ago";
                }
                return ts.Minutes + " minutes ago";
            }

            if (delta <= 90 * MINUTE)
                return "An hour ago";

            if (delta < 24 * HOUR)
            {
                if (ts.Hours < 0)
                {
                    return "sometime ago";
                }

                if (ts.Hours == 1)
                    return "1 hour ago";

                return ts.Hours + " hours ago";
            }

            if (delta < 48 * HOUR)
                return $"Yesterday at {postedData.ToString("t")}";

            if (delta < 30 * DAY)
            {
                if (ts.Days == 1)
                    return "1 day ago";

                return ts.Days + " days ago";
            }


            if (delta < 12 * MONTH)
            {
                int months = (int)(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = (int)(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}