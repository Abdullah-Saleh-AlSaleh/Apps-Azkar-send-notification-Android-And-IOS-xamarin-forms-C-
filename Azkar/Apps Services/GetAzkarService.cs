﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Azkar.Apps_Interface;
using Azkar.Models;
namespace Azkar.Apps_Services
{
    public class GetAzkarService
    {
        readonly bool stopping = false;
        ICustomNotification notification;

        public GetAzkarService()
        {
            notification = DependencyService.Get<ICustomNotification>();
        }

        public async Task Run(CancellationToken token)
        {
            await Task.Run(async () =>
            {
                while (!stopping)
                {
                    token.ThrowIfCancellationRequested();
                    try
                    {
                        await Task.Delay(2000);



                        Device.BeginInvokeOnMainThread(() =>
                        {
                            double Timer = Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmss"));
                            foreach (var Data in db.GetDataNotifications)
                            {

                                double ss = Convert.ToDouble(Data.Date.ToString("yyyyMMddHHmmss"));
                                if (Timer == ss)
                                {

                                    int Hours = Data.Date.Hour;
                                    switch (Hours)
                                    {
                                        case 0:
                                            string azkar0 = "أسْتَغْفِرُ اللهَ العَظِيمَ الَّذِي لاَ إلَهَ إلاَّ هُوَ، الحَيُّ القَيُّومُ، وَأتُوبُ إلَيهِ. ";
                                            notification.send(Data.Title, azkar0);


                                            break;
                                        case 1:
                                            string azkar1 = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                                            notification.send(Data.Title, azkar1);

                                            break;

                                        case 2:
                                            string azkar2 = "اللّهُـمَّ ما أَصْبَـَحَ بي مِـنْ نِعْـمَةٍ أَو بِأَحَـدٍ مِـنْ خَلْـقِك ، فَمِـنْكَ وَحْـدَكَ لا شريكَ لَـك ، فَلَـكَ الْحَمْـدُ وَلَـكَ الشُّكْـر. ";
                                            notification.send(Data.Title, azkar2);

                                            break;
                                        case 3:
                                            string azkar3 = "حَسْبِـيَ اللّهُ لا إلهَ إلاّ هُوَ عَلَـيهِ تَوَكَّـلتُ وَهُوَ رَبُّ العَرْشِ العَظـيم. ";
                                            notification.send(Data.Title, azkar3);

                                            break;
                                        case 4:
                                            string azkar4 = "بِسـمِ اللهِ الذي لا يَضُـرُّ مَعَ اسمِـهِ شَيءٌ في الأرْضِ وَلا في السّمـاءِ وَهـوَ السّمـيعُ العَلـيم.";
                                            notification.send(Data.Title, azkar4);

                                            break;
                                        case 5:
                                            string azkar5 = @"
اللّهُـمَّ بِكَ أَصْـبَحْنا وَبِكَ أَمْسَـينا ، وَبِكَ نَحْـيا وَبِكَ نَمُـوتُ وَإِلَـيْكَ النُّـشُور.
أَعُوذُ بِاللهِ مِنْ الشَّيْطَانِ الرَّجِيمِ 
)اللّهُ لاَ إِلَـهَ إِلاَّ هُوَ الْحَيُّ الْقَيُّومُ لاَ تَأْخُذُهُ سِنَةٌ وَلاَ نَوْمٌ لَّهُ مَا فِي السَّمَاوَاتِ وَمَا فِي الأَرْضِ مَن ذَا الَّذِي يَشْفَعُ عِنْدَهُ إِلاَّ بِإِذْنِهِ يَعْلَمُ مَا بَيْنَ أَيْدِيهِمْ وَمَا خَلْفَهُمْ وَلاَ يُحِيطُونَ بِشَيْءٍ مِّنْ عِلْمِهِ إِلاَّ بِمَا شَاء وَسِعَ كُرْسِيُّهُ السَّمَاوَاتِ وَالأَرْضَ وَلاَ يَؤُودُهُ حِفْظُهُمَا وَهُوَ الْعَلِيُّ الْعَظِيمُ).  [آية الكرسى - البقرة 255].
" + "( بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ هُوَ ٱللَّهُ أَحَدٌ، ٱللَّهُ ٱلصَّمَدُ، لَمْ يَلِدْ وَلَمْ يُولَدْ، وَلَمْ يَكُن لَّهُۥ كُفُوًا أَحَدٌۢ." +
                "(بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ أَعُوذُ بِرَبِّ ٱلْفَلَقِ، مِن شَرِّ مَا خَلَقَ، وَمِن شَرِّ غَاسِقٍ إِذَا وَقَبَ، وَمِن شَرِّ ٱلنَّفَّٰثَٰتِ فِى ٱلْعُقَدِ، وَمِن شَرِّ حَاسِدٍ إِذَا حَسَدَ." +
                "(بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ أَعُوذُ بِرَبِّ ٱلنَّاسِ، مَلِكِ ٱلنَّاسِ، إِلَٰهِ ٱلنَّاسِ، مِن شَرِّ ٱلْوَسْوَاسِ ٱلْخَنَّاسِ، ٱلَّذِى يُوَسْوِسُ فِى صُدُورِ ٱلنَّاسِ، مِنَ ٱلْجِنَّةِ وَٱلنَّاسِ)." + "أَصْـبَحْنا وَأَصْـبَحَ المُـلْكُ لله وَالحَمدُ لله ، لا إلهَ إلاّ اللّهُ وَحدَهُ لا شَريكَ لهُ، لهُ المُـلكُ ولهُ الحَمْـد، وهُوَ على كلّ شَيءٍ قدير ، رَبِّ أسْـأَلُـكَ خَـيرَ ما في هـذا اليوم وَخَـيرَ ما بَعْـدَه ، وَأَعـوذُ بِكَ مِنْ شَـرِّ ما في هـذا اليوم وَشَرِّ ما بَعْـدَه، رَبِّ أَعـوذُبِكَ مِنَ الْكَسَـلِ وَسـوءِ الْكِـبَر ، رَبِّ أَعـوذُ بِكَ مِنْ عَـذابٍ في النّـارِ وَعَـذابٍ في القَـبْر"
                ;
                                            notification.send(Data.Title, azkar5);

                                            break;

                                        case 6:
                                            string azkar6 = "اللّهـمَّ أَنْتَ رَبِّـي لا إلهَ إلاّ أَنْتَ ، خَلَقْتَنـي وَأَنا عَبْـدُك ، وَأَنا عَلـى عَهْـدِكَ وَوَعْـدِكَ ما اسْتَـطَعْـت ، أَعـوذُبِكَ مِنْ شَـرِّ ما صَنَـعْت ، أَبـوءُ لَـكَ بِنِعْـمَتِـكَ عَلَـيَّ وَأَبـوءُ بِذَنْـبي فَاغْفـِرْ لي فَإِنَّـهُ لا يَغْـفِرُ الذُّنـوبَ إِلاّ أَنْتَ .";
                                            notification.send(Data.Title, azkar6);


                                            break;
                                        case 7:
                                            string azkar7 = "اللّهـمَّ أَنْتَ رَبِّـي لا إلهَ إلاّ أَنْتَ ، خَلَقْتَنـي وَأَنا عَبْـدُك ، وَأَنا عَلـى عَهْـدِكَ وَوَعْـدِكَ ما اسْتَـطَعْـت ، أَعـوذُبِكَ مِنْ شَـرِّ ما صَنَـعْت ، أَبـوءُ لَـكَ بِنِعْـمَتِـكَ عَلَـيَّ وَأَبـوءُ بِذَنْـبي فَاغْفـِرْ لي فَإِنَّـهُ لا يَغْـفِرُ الذُّنـوبَ إِلاّ أَنْتَ .";
                                            notification.send(Data.Title, azkar7);

                                            break;
                                        case 8:
                                            string azkar8 = "رَضيـتُ بِاللهِ رَبَّـاً وَبِالإسْلامِ ديـناً وَبِمُحَـمَّدٍ صلى الله عليه وسلم نَبِيّـاً.";
                                            notification.send(Data.Title, azkar8);

                                            break;
                                        case 9:
                                            string azkar9 = "اللّهُـمَّ إِنِّـي أَصْبَـحْتُ أُشْـهِدُك ، وَأُشْـهِدُ حَمَلَـةَ عَـرْشِـك ، وَمَلَائِكَتَكَ ، وَجَمـيعَ خَلْـقِك ، أَنَّـكَ أَنْـتَ اللهُ لا إلهَ إلاّ أَنْـتَ وَحْـدَكَ لا شَريكَ لَـك ، وَأَنَّ ُ مُحَمّـداً عَبْـدُكَ وَرَسـولُـك. ";
                                            notification.send(Data.Title, azkar9);

                                            break;

                                        case 10:
                                            string azkar10 = "اللّهُـمَّ عافِـني في بَدَنـي ، اللّهُـمَّ عافِـني في سَمْـعي ، اللّهُـمَّ عافِـني في بَصَـري ، لا إلهَ إلاّ أَنْـتَ. ";
                                            notification.send(Data.Title, azkar10);

                                            break;
                                        case 11:
                                            string azkar11 = "سُبْحـانَ اللهِ وَبِحَمْـدِهِ عَدَدَ خَلْـقِه ، وَرِضـا نَفْسِـه ، وَزِنَـةَ عَـرْشِـه ، وَمِـدادَ كَلِمـاتِـه.";
                                            notification.send(Data.Title, azkar11);

                                            break;
                                        case 12:
                                            string azkar12 = "اللّهُـمَّ إِنّـي أَعـوذُ بِكَ مِنَ الْكُـفر ، وَالفَـقْر ، وَأَعـوذُ بِكَ مِنْ عَذابِ القَـبْر ، لا إلهَ إلاّ أَنْـتَ. ";
                                            notification.send(Data.Title, azkar12);

                                            break;
                                        case 13:
                                            string azkar13 = "اللّهُـمَّ إِنِّـي أسْـأَلُـكَ العَـفْوَ وَالعـافِـيةَ في الدُّنْـيا وَالآخِـرَة ، اللّهُـمَّ إِنِّـي أسْـأَلُـكَ العَـفْوَ وَالعـافِـيةَ في ديني وَدُنْـيايَ وَأهْـلي وَمالـي ، اللّهُـمَّ اسْتُـرْ عـوْراتي وَآمِـنْ رَوْعاتـي ، اللّهُـمَّ احْفَظْـني مِن بَـينِ يَدَيَّ وَمِن خَلْفـي وَعَن يَمـيني وَعَن شِمـالي ، وَمِن فَوْقـي ، وَأَعـوذُ بِعَظَمَـتِكَ أَن أُغْـتالَ مِن تَحْتـي. ";
                                            notification.send(Data.Title, azkar13);

                                            break;
                                        case 14:
                                            string azkar14 = "يَا حَيُّ يَا قيُّومُ بِرَحْمَتِكَ أسْتَغِيثُ أصْلِحْ لِي شَأنِي كُلَّهُ وَلاَ تَكِلْنِي إلَى نَفْسِي طَـرْفَةَ عَيْنٍ. ";
                                            notification.send(Data.Title, azkar14);

                                            break;
                                        case 15:
                                            string azkar15 = "أَعـوذُ بِكَلِمـاتِ اللّهِ التّـامّـاتِ مِنْ شَـرِّ ما خَلَـق. ";
                                            notification.send(Data.Title, azkar15);

                                            break;
                                        case 16:
                                            string azkar16 = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                                            notification.send(Data.Title, azkar16);

                                            break;
                                        case 17:
                                            string azkar17 = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                                            notification.send(Data.Title, azkar17);

                                            break;
                                        case 18:
                                            string azkar18 = "اللَّهُمَّ إِنَّا نَعُوذُ بِكَ مِنْ أَنْ نُشْرِكَ بِكَ شَيْئًا نَعْلَمُهُ ، وَنَسْتَغْفِرُكَ لِمَا لَا نَعْلَمُهُ. ";
                                            notification.send(Data.Title, azkar18);

                                            break;

                                        case 19:
                                            string azkar19 = "يَا رَبِّ , لَكَ الْحَمْدُ كَمَا يَنْبَغِي لِجَلَالِ وَجْهِكَ , وَلِعَظِيمِ سُلْطَانِكَ. ";
                                            notification.send(Data.Title, azkar19);

                                            break;
                                        case 20:
                                            string azkar20 = "لَا إلَه إلّا اللهُ وَحْدَهُ لَا شَرِيكَ لَهُ، لَهُ الْمُلْكُ وَلَهُ الْحَمْدُ وَهُوَ عَلَى كُلِّ شَيْءِ قَدِيرِ. ";
                                            notification.send(Data.Title, azkar20);

                                            break;

                                        case 21:
                                            string azkar21 = "أسْتَغْفِرُ اللهَ وَأتُوبُ إلَيْهِ ";
                                            notification.send(Data.Title, azkar21);

                                            break;
                                        case 22:
                                            string azkar22 = "سُبْحَانَ اللهِ العَظِيمِ وَبِحَمْدِهِ ";
                                            notification.send(Data.Title, azkar22);

                                            break;

                                        case 23:
                                            string azkar23 = "اللَّهُمَّ أَنْتَ رَبِّي لا إِلَهَ إِلا أَنْتَ ، عَلَيْكَ تَوَكَّلْتُ ، وَأَنْتَ رَبُّ الْعَرْشِ الْعَظِيمِ , مَا شَاءَ اللَّهُ كَانَ ، وَمَا لَمْ يَشَأْ لَمْ يَكُنْ ، وَلا حَوْلَ وَلا قُوَّةَ إِلا بِاللَّهِ الْعَلِيِّ الْعَظِيمِ , أَعْلَمُ أَنَّ اللَّهَ عَلَى كُلِّ شَيْءٍ قَدِيرٌ ، وَأَنَّ اللَّهَ قَدْ أَحَاطَ بِكُلِّ شَيْءٍ عِلْمًا , اللَّهُمَّ إِنِّي أَعُوذُ بِكَ مِنْ شَرِّ نَفْسِي ، وَمِنْ شَرِّ كُلِّ دَابَّةٍ أَنْتَ آخِذٌ بِنَاصِيَتِهَا ، إِنَّ رَبِّي عَلَى صِرَاطٍ مُسْتَقِيمٍ.";
                                            notification.send(Data.Title, azkar23);

                                            break;


                                        default:
                                            break;
                                    }



                                }
                            }
                        });

                        //                        double Timer = Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmss"));
                        //                        foreach (var Data in db.GetDataNotifications)
                        //                        {

                        //                            double ss = Convert.ToDouble(Data.Date.ToString("yyyyMMddHHmmss"));
                        //                            if (Timer == ss)
                        //                            {

                        //                                int Hours = Data.Date.Hour;
                        //                                switch (Hours)
                        //                                {
                        //                                    case 0:
                        //                                        string azkar0 = "أسْتَغْفِرُ اللهَ العَظِيمَ الَّذِي لاَ إلَهَ إلاَّ هُوَ، الحَيُّ القَيُّومُ، وَأتُوبُ إلَيهِ. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                        .send(Data.Title, azkar0);
                        //                                        break;
                        //                                    case 1:
                        //                                        string azkar1 = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar1);
                        //                                        break;

                        //                                    case 2:
                        //                                        string azkar2 = "اللّهُـمَّ ما أَصْبَـَحَ بي مِـنْ نِعْـمَةٍ أَو بِأَحَـدٍ مِـنْ خَلْـقِك ، فَمِـنْكَ وَحْـدَكَ لا شريكَ لَـك ، فَلَـكَ الْحَمْـدُ وَلَـكَ الشُّكْـر. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                      .send(Data.Title, azkar2);

                        //                                        break;
                        //                                    case 3:
                        //                                        string azkar3 = "حَسْبِـيَ اللّهُ لا إلهَ إلاّ هُوَ عَلَـيهِ تَوَكَّـلتُ وَهُوَ رَبُّ العَرْشِ العَظـيم. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                      .send(Data.Title, azkar3);

                        //                                        break;
                        //                                    case 4:
                        //                                        string azkar4 = "بِسـمِ اللهِ الذي لا يَضُـرُّ مَعَ اسمِـهِ شَيءٌ في الأرْضِ وَلا في السّمـاءِ وَهـوَ السّمـيعُ العَلـيم.";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar4);

                        //                                        break;
                        //                                    case 5:
                        //                                        string azkar5 = @"
                        //اللّهُـمَّ بِكَ أَصْـبَحْنا وَبِكَ أَمْسَـينا ، وَبِكَ نَحْـيا وَبِكَ نَمُـوتُ وَإِلَـيْكَ النُّـشُور.
                        //أَعُوذُ بِاللهِ مِنْ الشَّيْطَانِ الرَّجِيمِ 
                        //)اللّهُ لاَ إِلَـهَ إِلاَّ هُوَ الْحَيُّ الْقَيُّومُ لاَ تَأْخُذُهُ سِنَةٌ وَلاَ نَوْمٌ لَّهُ مَا فِي السَّمَاوَاتِ وَمَا فِي الأَرْضِ مَن ذَا الَّذِي يَشْفَعُ عِنْدَهُ إِلاَّ بِإِذْنِهِ يَعْلَمُ مَا بَيْنَ أَيْدِيهِمْ وَمَا خَلْفَهُمْ وَلاَ يُحِيطُونَ بِشَيْءٍ مِّنْ عِلْمِهِ إِلاَّ بِمَا شَاء وَسِعَ كُرْسِيُّهُ السَّمَاوَاتِ وَالأَرْضَ وَلاَ يَؤُودُهُ حِفْظُهُمَا وَهُوَ الْعَلِيُّ الْعَظِيمُ).  [آية الكرسى - البقرة 255].
                        //" + "( بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ هُوَ ٱللَّهُ أَحَدٌ، ٱللَّهُ ٱلصَّمَدُ، لَمْ يَلِدْ وَلَمْ يُولَدْ، وَلَمْ يَكُن لَّهُۥ كُفُوًا أَحَدٌۢ." +
                        //            "(بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ أَعُوذُ بِرَبِّ ٱلْفَلَقِ، مِن شَرِّ مَا خَلَقَ، وَمِن شَرِّ غَاسِقٍ إِذَا وَقَبَ، وَمِن شَرِّ ٱلنَّفَّٰثَٰتِ فِى ٱلْعُقَدِ، وَمِن شَرِّ حَاسِدٍ إِذَا حَسَدَ." +
                        //            "(بِسْمِ اللهِ الرَّحْمنِ الرَّحِيم (قُلْ أَعُوذُ بِرَبِّ ٱلنَّاسِ، مَلِكِ ٱلنَّاسِ، إِلَٰهِ ٱلنَّاسِ، مِن شَرِّ ٱلْوَسْوَاسِ ٱلْخَنَّاسِ، ٱلَّذِى يُوَسْوِسُ فِى صُدُورِ ٱلنَّاسِ، مِنَ ٱلْجِنَّةِ وَٱلنَّاسِ)." + "أَصْـبَحْنا وَأَصْـبَحَ المُـلْكُ لله وَالحَمدُ لله ، لا إلهَ إلاّ اللّهُ وَحدَهُ لا شَريكَ لهُ، لهُ المُـلكُ ولهُ الحَمْـد، وهُوَ على كلّ شَيءٍ قدير ، رَبِّ أسْـأَلُـكَ خَـيرَ ما في هـذا اليوم وَخَـيرَ ما بَعْـدَه ، وَأَعـوذُ بِكَ مِنْ شَـرِّ ما في هـذا اليوم وَشَرِّ ما بَعْـدَه، رَبِّ أَعـوذُبِكَ مِنَ الْكَسَـلِ وَسـوءِ الْكِـبَر ، رَبِّ أَعـوذُ بِكَ مِنْ عَـذابٍ في النّـارِ وَعَـذابٍ في القَـبْر"
                        //            ;
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar5);

                        //                                        break;

                        //                                    case 6:
                        //                                        string azkar6 = "اللّهـمَّ أَنْتَ رَبِّـي لا إلهَ إلاّ أَنْتَ ، خَلَقْتَنـي وَأَنا عَبْـدُك ، وَأَنا عَلـى عَهْـدِكَ وَوَعْـدِكَ ما اسْتَـطَعْـت ، أَعـوذُبِكَ مِنْ شَـرِّ ما صَنَـعْت ، أَبـوءُ لَـكَ بِنِعْـمَتِـكَ عَلَـيَّ وَأَبـوءُ بِذَنْـبي فَاغْفـِرْ لي فَإِنَّـهُ لا يَغْـفِرُ الذُّنـوبَ إِلاّ أَنْتَ .";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar6);


                        //                                        break;
                        //                                    case 7:
                        //                                        string azkar7 = "اللّهـمَّ أَنْتَ رَبِّـي لا إلهَ إلاّ أَنْتَ ، خَلَقْتَنـي وَأَنا عَبْـدُك ، وَأَنا عَلـى عَهْـدِكَ وَوَعْـدِكَ ما اسْتَـطَعْـت ، أَعـوذُبِكَ مِنْ شَـرِّ ما صَنَـعْت ، أَبـوءُ لَـكَ بِنِعْـمَتِـكَ عَلَـيَّ وَأَبـوءُ بِذَنْـبي فَاغْفـِرْ لي فَإِنَّـهُ لا يَغْـفِرُ الذُّنـوبَ إِلاّ أَنْتَ .";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar7);
                        //                                        break;
                        //                                    case 8:
                        //                                        string azkar8 = "رَضيـتُ بِاللهِ رَبَّـاً وَبِالإسْلامِ ديـناً وَبِمُحَـمَّدٍ صلى الله عليه وسلم نَبِيّـاً.";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar8);

                        //                                        break;
                        //                                    case 9:
                        //                                        string azkar9 = "اللّهُـمَّ إِنِّـي أَصْبَـحْتُ أُشْـهِدُك ، وَأُشْـهِدُ حَمَلَـةَ عَـرْشِـك ، وَمَلَائِكَتَكَ ، وَجَمـيعَ خَلْـقِك ، أَنَّـكَ أَنْـتَ اللهُ لا إلهَ إلاّ أَنْـتَ وَحْـدَكَ لا شَريكَ لَـك ، وَأَنَّ ُ مُحَمّـداً عَبْـدُكَ وَرَسـولُـك. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                      .send(Data.Title, azkar9);

                        //                                        break;

                        //                                    case 10:
                        //                                        string azkar10 = "اللّهُـمَّ عافِـني في بَدَنـي ، اللّهُـمَّ عافِـني في سَمْـعي ، اللّهُـمَّ عافِـني في بَصَـري ، لا إلهَ إلاّ أَنْـتَ. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                      .send(Data.Title, azkar10);

                        //                                        break;
                        //                                    case 11:
                        //                                        string azkar11 = "سُبْحـانَ اللهِ وَبِحَمْـدِهِ عَدَدَ خَلْـقِه ، وَرِضـا نَفْسِـه ، وَزِنَـةَ عَـرْشِـه ، وَمِـدادَ كَلِمـاتِـه.";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar11);

                        //                                        break;
                        //                                    case 12:
                        //                                        string azkar12 = "اللّهُـمَّ إِنّـي أَعـوذُ بِكَ مِنَ الْكُـفر ، وَالفَـقْر ، وَأَعـوذُ بِكَ مِنْ عَذابِ القَـبْر ، لا إلهَ إلاّ أَنْـتَ. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar12);

                        //                                        break;
                        //                                    case 13:
                        //                                        string azkar13 = "اللّهُـمَّ إِنِّـي أسْـأَلُـكَ العَـفْوَ وَالعـافِـيةَ في الدُّنْـيا وَالآخِـرَة ، اللّهُـمَّ إِنِّـي أسْـأَلُـكَ العَـفْوَ وَالعـافِـيةَ في ديني وَدُنْـيايَ وَأهْـلي وَمالـي ، اللّهُـمَّ اسْتُـرْ عـوْراتي وَآمِـنْ رَوْعاتـي ، اللّهُـمَّ احْفَظْـني مِن بَـينِ يَدَيَّ وَمِن خَلْفـي وَعَن يَمـيني وَعَن شِمـالي ، وَمِن فَوْقـي ، وَأَعـوذُ بِعَظَمَـتِكَ أَن أُغْـتالَ مِن تَحْتـي. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar13);
                        //                                        break;
                        //                                    case 14:
                        //                                        string azkar14 = "يَا حَيُّ يَا قيُّومُ بِرَحْمَتِكَ أسْتَغِيثُ أصْلِحْ لِي شَأنِي كُلَّهُ وَلاَ تَكِلْنِي إلَى نَفْسِي طَـرْفَةَ عَيْنٍ. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar14);
                        //                                        break;
                        //                                    case 15:
                        //                                        string azkar15 = "أَعـوذُ بِكَلِمـاتِ اللّهِ التّـامّـاتِ مِنْ شَـرِّ ما خَلَـق. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                         .send(Data.Title, azkar15);

                        //                                        break;
                        //                                    case 16:
                        //                                        string azkar16 = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                      .send(Data.Title, azkar16);
                        //                                        break;
                        //                                    case 17:
                        //                                        string azkar17 = "اللَّهُمَّ صَلِّ وَسَلِّمْ وَبَارِكْ على نَبِيِّنَا مُحمَّد. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar17);
                        //                                        break;
                        //                                    case 18:
                        //                                        string azkar18 = "اللَّهُمَّ إِنَّا نَعُوذُ بِكَ مِنْ أَنْ نُشْرِكَ بِكَ شَيْئًا نَعْلَمُهُ ، وَنَسْتَغْفِرُكَ لِمَا لَا نَعْلَمُهُ. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                      .send(Data.Title, azkar18);
                        //                                        break;

                        //                                    case 19:
                        //                                        string azkar19 = "يَا رَبِّ , لَكَ الْحَمْدُ كَمَا يَنْبَغِي لِجَلَالِ وَجْهِكَ , وَلِعَظِيمِ سُلْطَانِكَ. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar19);
                        //                                        break;
                        //                                    case 20:
                        //                                        string azkar20 = "لَا إلَه إلّا اللهُ وَحْدَهُ لَا شَرِيكَ لَهُ، لَهُ الْمُلْكُ وَلَهُ الْحَمْدُ وَهُوَ عَلَى كُلِّ شَيْءِ قَدِيرِ. ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                      .send(Data.Title, azkar20);
                        //                                        break;

                        //                                    case 21:
                        //                                        string azkar21 = "أسْتَغْفِرُ اللهَ وَأتُوبُ إلَيْهِ ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                        .send(Data.Title, azkar21);
                        //                                        break;
                        //                                    case 22:
                        //                                        string azkar22 = "سُبْحَانَ اللهِ العَظِيمِ وَبِحَمْدِهِ ";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                      .send(Data.Title, azkar22);

                        //                                        break;

                        //                                    case 23:
                        //                                        string azkar23 = "اللَّهُمَّ أَنْتَ رَبِّي لا إِلَهَ إِلا أَنْتَ ، عَلَيْكَ تَوَكَّلْتُ ، وَأَنْتَ رَبُّ الْعَرْشِ الْعَظِيمِ , مَا شَاءَ اللَّهُ كَانَ ، وَمَا لَمْ يَشَأْ لَمْ يَكُنْ ، وَلا حَوْلَ وَلا قُوَّةَ إِلا بِاللَّهِ الْعَلِيِّ الْعَظِيمِ , أَعْلَمُ أَنَّ اللَّهَ عَلَى كُلِّ شَيْءٍ قَدِيرٌ ، وَأَنَّ اللَّهَ قَدْ أَحَاطَ بِكُلِّ شَيْءٍ عِلْمًا , اللَّهُمَّ إِنِّي أَعُوذُ بِكَ مِنْ شَرِّ نَفْسِي ، وَمِنْ شَرِّ كُلِّ دَابَّةٍ أَنْتَ آخِذٌ بِنَاصِيَتِهَا ، إِنَّ رَبِّي عَلَى صِرَاطٍ مُسْتَقِيمٍ.";
                        //                                        DependencyService.Get<ICustomNotification>()
                        //                                       .send(Data.Title, azkar23);
                        //                                        break;


                        //                                    default:
                        //                                        break;
                        //                                }



                        //                            }
                        //                        }
                    }
                    catch (Exception ex)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            var errormessage = new LocationErrorMessage();
                            MessagingCenter.Send(errormessage, "LocationError");
                        });
                    }
                }
                return;
            }, token);
        }
    }
}

