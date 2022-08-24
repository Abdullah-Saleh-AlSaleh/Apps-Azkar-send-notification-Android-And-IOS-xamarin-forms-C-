using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azkar.Models
{
    public class db
    {
        public static List<NotificationText> GetDataNotifications { get { return GetData(); } set { GetDataNotifications = value; } }
        public static List<NotificationText> GetData()
        {
            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            int Day = DateTime.Now.Day;
            int Hour = DateTime.Now.Hour;

            DateTime dt1 = new DateTime(Year, Month, Day, Hour, 00, 00);

            string title = " أذكار";
            string test = @"لَا إلَه إلّا اللهُ وَحْدَهُ لَا شَرِيكَ لَهُ، لَهُ الْمُلْكُ وَلَهُ الْحَمْدُ وَهُوَ عَلَى كُلِّ شَيْءِ قَدِيرِ." + " سُبْحـانَ اللهِ وَبِحَمْـدِهِ." + "أسْتَغْفِرُ اللهَ وَأتُوبُ إلَيْهِ" + " رَضيـتُ بِاللهِ رَبَّـاً وَبِالإسْلامِ ديـناً وَبِمُحَـمَّدٍ صلى الله عليه وسلم نَبِيّـا.";





            var notificationText = new List<NotificationText>()
            {
                 new NotificationText(){Id=1,Text=test,Title=title,Date=dt1},





            };
            return notificationText.ToList();
        }
    }
    public class NotificationText
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }

}
