using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using AndroidX.Core.App;
using Xamarin.Forms;
using Azkar.Apps_Services;
using Azkar.Models;
using OperationCanceledException = Android.OS.OperationCanceledException;
using Xamarin.Essentials;
using System.Timers;

namespace Azkar.Droid
{
	[Service]
	public class AndroidAzkarService : Service
	{
        private static System.Timers.Timer aTimer;
        CancellationTokenSource _cts;
		public const int SERVICE_RUNNING_NOTIFICATION_ID = 10001;
		private static string foregroundChannelId = "9001";
		private static Context context = global::Android.App.Application.Context;
        private int numMessages;

        public override IBinder OnBind(Intent intent)
		{
			return null;
		}
        public static  string AzkarText()
        {
           
        
                string Text = string.Empty;
                int Hours = DateTime.Now.Hour;
                if (Hours == 0)
                {
                    return Text = "أسْتَغْفِرُ اللهَ العَظِيمَ الَّذِي لاَ إلَهَ إلاَّ هُوَ، الحَيُّ القَيُّومُ، وَأتُوبُ إلَيهِ. ";
                }
                else if (Hours == 1)
                {
                    return Text = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                }
                else if (Hours == 2)
                {
                    return Text = "اللّهُـمَّ ما أَصْبَـَحَ بي مِـنْ نِعْـمَةٍ أَو بِأَحَـدٍ مِـنْ خَلْـقِك ، فَمِـنْكَ وَحْـدَكَ لا شريكَ لَـك ، فَلَـكَ الْحَمْـدُ وَلَـكَ الشُّكْـر. ";
                }
                else if (Hours == 3)
                {
                    return Text = "حَسْبِـيَ اللّهُ لا إلهَ إلاّ هُوَ عَلَـيهِ تَوَكَّـلتُ وَهُوَ رَبُّ العَرْشِ العَظـيم. ";
                }
                else if (Hours == 4)
                {
                    return "بِسـمِ اللهِ الذي لا يَضُـرُّ مَعَ اسمِـهِ شَيءٌ في الأرْضِ وَلا في السّمـاءِ وَهـوَ السّمـيعُ العَلـيم.";
                }
                else if (Hours == 5)
                {
                    return Text = @"
اللّهُـمَّ بِكَ أَصْـبَحْنا وَبِكَ أَمْسَـينا ، وَبِكَ نَحْـيا وَبِكَ نَمُـوتُ وَإِلَـيْكَ النُّـشُور.
أَعُوذُ بِاللهِ مِنْ الشَّيْطَانِ الرَّجِيمِ 
)اللّهُ لاَ إِلَـهَ إِلاَّ هُوَ الْحَيُّ الْقَيُّومُ لاَ تَأْخُذُهُ سِنَةٌ وَلاَ نَوْمٌ لَّهُ مَا فِي السَّمَاوَاتِ وَمَا فِي الأَرْضِ مَن ذَا الَّذِي يَشْفَعُ عِنْدَهُ إِلاَّ بِإِذْنِهِ يَعْلَمُ مَا بَيْنَ أَيْدِيهِمْ وَمَا خَلْفَهُمْ وَلاَ يُحِيطُونَ بِشَيْءٍ مِّنْ عِلْمِهِ إِلاَّ بِمَا شَاء وَسِعَ كُرْسِيُّهُ السَّمَاوَاتِ وَالأَرْضَ وَلاَ يَؤُودُهُ حِفْظُهُمَا وَهُوَ الْعَلِيُّ الْعَظِيمُ).  [آية الكرسى - البقرة 255].
" + "( بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ هُوَ ٱللَّهُ أَحَدٌ، ٱللَّهُ ٱلصَّمَدُ، لَمْ يَلِدْ وَلَمْ يُولَدْ، وَلَمْ يَكُن لَّهُۥ كُفُوًا أَحَدٌۢ." +
    "(بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ أَعُوذُ بِرَبِّ ٱلْفَلَقِ، مِن شَرِّ مَا خَلَقَ، وَمِن شَرِّ غَاسِقٍ إِذَا وَقَبَ، وَمِن شَرِّ ٱلنَّفَّٰثَٰتِ فِى ٱلْعُقَدِ، وَمِن شَرِّ حَاسِدٍ إِذَا حَسَدَ." +
    "(بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ أَعُوذُ بِرَبِّ ٱلنَّاسِ، مَلِكِ ٱلنَّاسِ، إِلَٰهِ ٱلنَّاسِ، مِن شَرِّ ٱلْوَسْوَاسِ ٱلْخَنَّاسِ، ٱلَّذِى يُوَسْوِسُ فِى صُدُورِ ٱلنَّاسِ، مِنَ ٱلْجِنَّةِ وَٱلنَّاسِ)." + "أَصْـبَحْنا وَأَصْـبَحَ المُـلْكُ لله وَالحَمدُ لله ، لا إلهَ إلاّ اللّهُ وَحدَهُ لا شَريكَ لهُ، لهُ المُـلكُ ولهُ الحَمْـد، وهُوَ على كلّ شَيءٍ قدير ، رَبِّ أسْـأَلُـكَ خَـيرَ ما في هـذا اليوم وَخَـيرَ ما بَعْـدَه ، وَأَعـوذُ بِكَ مِنْ شَـرِّ ما في هـذا اليوم وَشَرِّ ما بَعْـدَه، رَبِّ أَعـوذُبِكَ مِنَ الْكَسَـلِ وَسـوءِ الْكِـبَر ، رَبِّ أَعـوذُ بِكَ مِنْ عَـذابٍ في النّـارِ وَعَـذابٍ في القَـبْر"
    ;
                }
                else if (Hours == 6)
                {
                    return Text = "اللّهـمَّ أَنْتَ رَبِّـي لا إلهَ إلاّ أَنْتَ ، خَلَقْتَنـي وَأَنا عَبْـدُك ، وَأَنا عَلـى عَهْـدِكَ وَوَعْـدِكَ ما اسْتَـطَعْـت ، أَعـوذُبِكَ مِنْ شَـرِّ ما صَنَـعْت ، أَبـوءُ لَـكَ بِنِعْـمَتِـكَ عَلَـيَّ وَأَبـوءُ بِذَنْـبي فَاغْفـِرْ لي فَإِنَّـهُ لا يَغْـفِرُ الذُّنـوبَ إِلاّ أَنْتَ .";
                }
                else if (Hours == 7)
                {
                    return Text = "اللّهـمَّ أَنْتَ رَبِّـي لا إلهَ إلاّ أَنْتَ ، خَلَقْتَنـي وَأَنا عَبْـدُك ، وَأَنا عَلـى عَهْـدِكَ وَوَعْـدِكَ ما اسْتَـطَعْـت ، أَعـوذُبِكَ مِنْ شَـرِّ ما صَنَـعْت ، أَبـوءُ لَـكَ بِنِعْـمَتِـكَ عَلَـيَّ وَأَبـوءُ بِذَنْـبي فَاغْفـِرْ لي فَإِنَّـهُ لا يَغْـفِرُ الذُّنـوبَ إِلاّ أَنْتَ .";
                }
                else if (Hours == 8)
                {
                    return "رَضيـتُ بِاللهِ رَبَّـاً وَبِالإسْلامِ ديـناً وَبِمُحَـمَّدٍ صلى الله عليه وسلم نَبِيّـاً.";
                }
                else if (Hours == 9)
                {
                    return Text = "اللّهُـمَّ إِنِّـي أَصْبَـحْتُ أُشْـهِدُك ، وَأُشْـهِدُ حَمَلَـةَ عَـرْشِـك ، وَمَلَائِكَتَكَ ، وَجَمـيعَ خَلْـقِك ، أَنَّـكَ أَنْـتَ اللهُ لا إلهَ إلاّ أَنْـتَ وَحْـدَكَ لا شَريكَ لَـك ، وَأَنَّ ُ مُحَمّـداً عَبْـدُكَ وَرَسـولُـك. ";
                }
                else if (Hours == 10)
                {
                    return Text = "اللّهُـمَّ عافِـني في بَدَنـي ، اللّهُـمَّ عافِـني في سَمْـعي ، اللّهُـمَّ عافِـني في بَصَـري ، لا إلهَ إلاّ أَنْـتَ. ";
                }
                else if (Hours == 11)
                {
                    return Text = "سُبْحـانَ اللهِ وَبِحَمْـدِهِ عَدَدَ خَلْـقِه ، وَرِضـا نَفْسِـه ، وَزِنَـةَ عَـرْشِـه ، وَمِـدادَ كَلِمـاتِـه.";
                }
                else if (Hours == 12)
                {
                    return Text = "اللّهُـمَّ إِنّـي أَعـوذُ بِكَ مِنَ الْكُـفر ، وَالفَـقْر ، وَأَعـوذُ بِكَ مِنْ عَذابِ القَـبْر ، لا إلهَ إلاّ أَنْـتَ. ";
                }
                else if (Hours == 13)
                {
                    return Text = "اللّهُـمَّ إِنِّـي أسْـأَلُـكَ العَـفْوَ وَالعـافِـيةَ في الدُّنْـيا وَالآخِـرَة ، اللّهُـمَّ إِنِّـي أسْـأَلُـكَ العَـفْوَ وَالعـافِـيةَ في ديني وَدُنْـيايَ وَأهْـلي وَمالـي ، اللّهُـمَّ اسْتُـرْ عـوْراتي وَآمِـنْ رَوْعاتـي ، اللّهُـمَّ احْفَظْـني مِن بَـينِ يَدَيَّ وَمِن خَلْفـي وَعَن يَمـيني وَعَن شِمـالي ، وَمِن فَوْقـي ، وَأَعـوذُ بِعَظَمَـتِكَ أَن أُغْـتالَ مِن تَحْتـي. ";
                }
                else if (Hours == 14)
                {
                    return Text = "يَا حَيُّ يَا قيُّومُ بِرَحْمَتِكَ أسْتَغِيثُ أصْلِحْ لِي شَأنِي كُلَّهُ وَلاَ تَكِلْنِي إلَى نَفْسِي طَـرْفَةَ عَيْنٍ. ";
                }
                else if (Hours == 15)
                {
                    return Text = "أَعـوذُ بِكَلِمـاتِ اللّهِ التّـامّـاتِ مِنْ شَـرِّ ما خَلَـق. ";
                }
                else if (Hours == 16)
                {
                    return Text = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                }
                else if (Hours == 17)
                {
                    return Text = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                }
                else if (Hours == 18)
                {
                    return Text = "اللَّهُمَّ إِنَّا نَعُوذُ بِكَ مِنْ أَنْ نُشْرِكَ بِكَ شَيْئًا نَعْلَمُهُ ، وَنَسْتَغْفِرُكَ لِمَا لَا نَعْلَمُهُ. ";
                }
                else if (Hours == 19)
                {
                    return Text = "يَا رَبِّ , لَكَ الْحَمْدُ كَمَا يَنْبَغِي لِجَلَالِ وَجْهِكَ , وَلِعَظِيمِ سُلْطَانِكَ. ";
                }
                else if (Hours == 20)
                {
                    return Text = "لَا إلَه إلّا اللهُ وَحْدَهُ لَا شَرِيكَ لَهُ، لَهُ الْمُلْكُ وَلَهُ الْحَمْدُ وَهُوَ عَلَى كُلِّ شَيْءِ قَدِيرِ. ";
                }
                else if (Hours == 21)
                {
                    return Text = "أسْتَغْفِرُ اللهَ وَأتُوبُ إلَيْهِ ";
                }
                else if (Hours == 22)
                {
                    return Text = "سُبْحَانَ اللهِ العَظِيمِ وَبِحَمْدِهِ ";
                }
                else if (Hours == 23)
                {

                    return Text = "اللَّهُمَّ أَنْتَ رَبِّي لا إِلَهَ إِلا أَنْتَ ، عَلَيْكَ تَوَكَّلْتُ ، وَأَنْتَ رَبُّ الْعَرْشِ الْعَظِيمِ , مَا شَاءَ اللَّهُ كَانَ ، وَمَا لَمْ يَشَأْ لَمْ يَكُنْ ، وَلا حَوْلَ وَلا قُوَّةَ إِلا بِاللَّهِ الْعَلِيِّ الْعَظِيمِ , أَعْلَمُ أَنَّ اللَّهَ عَلَى كُلِّ شَيْءٍ قَدِيرٌ ، وَأَنَّ اللَّهَ قَدْ أَحَاطَ بِكُلِّ شَيْءٍ عِلْمًا , اللَّهُمَّ إِنِّي أَعُوذُ بِكَ مِنْ شَرِّ نَفْسِي ، وَمِنْ شَرِّ كُلِّ دَابَّةٍ أَنْتَ آخِذٌ بِنَاصِيَتِهَا ، إِنَّ رَبِّي عَلَى صِرَاطٍ مُسْتَقِيمٍ.";

                }

                return Text;
            
           

        }
        public  void  GetServiceStartedNotification()
		{
		

				var intent = new Intent(context, typeof(MainActivity));
				intent.AddFlags(ActivityFlags.SingleTop);
				intent.PutExtra("خدمات الأذكار", "Message");

				var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.UpdateCurrent);
            numMessages = 0;

            var notificationBuilder = new NotificationCompat.Builder(context, foregroundChannelId);         
            notificationBuilder.SetContentTitle("أذكار");
            notificationBuilder.SetContentText("اذكر الله يذكرك").SetNumber(numMessages++);
                    // notificationBuilder.SetContentText(AzkarText());
				 notificationBuilder.SetSmallIcon(Resource.Drawable.azkarto);
                
                 notificationBuilder.SetOngoing(true);
                   notificationBuilder.SetContentIntent(pendingIntent);	
           
          //  notificationBuilder.SetContentText(DateTime.Now.ToString("F")).SetNumber(numMessages++);    

            if (global::Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.O)
				{
					NotificationChannel notificationChannel = new NotificationChannel(foregroundChannelId, "خدمات الأذكار", NotificationImportance.High);
					notificationChannel.Importance = NotificationImportance.High;
					notificationChannel.EnableLights(true);
					notificationChannel.EnableVibration(true);
					notificationChannel.SetShowBadge(true);
					notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300 });

					var notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
					if (notificationManager != null)
					{
						notificationBuilder.SetChannelId(foregroundChannelId);
						notificationManager.CreateNotificationChannel(notificationChannel);
					}
				}

		

            StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notificationBuilder.Build());


        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			_cts = new CancellationTokenSource();

            //Notification notification = new NotificationHelper().GetServiceStartedNotification();
            //StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notification);
            // 
        GetServiceStartedNotification();

           
                Task.Run(() => {
				try
				{
					var locShared = new GetAzkarService();
					locShared.Run(_cts.Token).Wait();

                 }
				catch (OperationCanceledException)
				{
                    
				}
				finally
				{
					if (_cts.IsCancellationRequested)
					{
						var message = new StopServiceMessage();
						Device.BeginInvokeOnMainThread(
							() => MessagingCenter.Send(message, "ServiceStopped")
						);
					}
				}
			}, _cts.Token);

			return StartCommandResult.Sticky;
		}



        public override void OnDestroy()
		{
			if (_cts != null)
			{
				_cts.Token.ThrowIfCancellationRequested();
				_cts.Cancel();
			}
			base.OnDestroy();
		}
	}

   
}

