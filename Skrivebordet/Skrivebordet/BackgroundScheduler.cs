using System;
using System.Timers;

namespace Skrivebordet
{
    public class BackgroundScheduler
    {
        public static DateTime NextTime { get; set; } = DateTime.Now;
        public static bool IsHourly {get; set;}
        public static bool IsDaily { get; set; }
        public static bool IsWeekly { get; set; }

        public static void Start()
        {
            Timer timer = new Timer(10000);
            timer.Elapsed += OnTick;
            timer.Start();
        }

        private static void OnTick(object sender, ElapsedEventArgs e)
        {
            if (ShouldChangeBackground())
            {
                string imagePath = ImageHandler.GetNextImagePath();
                if (!string.IsNullOrWhiteSpace(imagePath))
                {
                    BackgroundChanger.ChangeWallpaper(imagePath);
                }
            }
        }

        public static bool ShouldChangeBackground()
        {
            DateTime currentTime = DateTime.Now;
            if (IsHourly)
            {
                DateTime hourNextTime = new(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, 0, 0);
                hourNextTime = hourNextTime.AddHours(1);
                if (hourNextTime.Hour != NextTime.Hour)
                {
                    NextTime = hourNextTime;
                    return true;
                }
            }
            else if (IsDaily)
            {
                DateTime dailyNextTime = new(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
                dailyNextTime = dailyNextTime.AddDays(1);
                if (dailyNextTime.Day != NextTime.Day)
                {
                    NextTime = dailyNextTime;
                    return true;
                }
            }
            else if (IsWeekly)
            {
                DateTime weeklyNextTime = new(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59);
                weeklyNextTime = weeklyNextTime.AddDays(((int)DayOfWeek.Sunday - (int)currentTime.DayOfWeek + 7) % 7);
                if (weeklyNextTime != NextTime)
                {
                    NextTime = weeklyNextTime;
                    return true;
                }
            }
            return false;
        }
    }

    //    public static event EventHandler? BackgroundChange;

    //    private DateTime old_dateTime;

    //    private Calendar calendar = CultureInfo.CurrentCulture.Calendar;

    //    public TimeChangeSetting TimeSetting { get; set; }

    //    private void OnTick(object sender, ElapsedEventArgs e)
    //    {
    //        switch (TimeSetting)
    //        {
    //            case TimeChangeSetting.hour:
                    
    //                break;
    //            case TimeChangeSetting.daily:
    //                break;
    //            case TimeChangeSetting.weekly:
    //                break;
    //            default:
    //                break;
    //        }


    //        //if (DateTime.Now.Minute == 0)
    //        //{
    //        //    BackgroundChange?.Invoke(sender, e);
    //        //}
    //        //BackgroundChange?.Invoke(this, EventArgs.Empty);
    //    }

    //    public void Start()
    //    {
    //        Timer timer = new(10000);
    //        timer.Elapsed += OnTick;
    //    }

    //    private void HourlyTimeCheck()
    //    {
    //        if (old_dateTime.AddHours(1).Hour == DateTime.Now.Hour)
    //        {
    //            // change background
    //        }
    //    }

    //    private void DailyTimeCheck()
    //    {
    //        if (old_dateTime.AddDays(1).Day == DateTime.Now.Day)
    //        {
    //            // change background
    //        }
    //    }

    //    private void WeeklyTimeCheck()
    //    {
    //        if (calendar.GetWeekOfYear(old_dateTime) == DateTime.Now.Hour)
    //        {
    //            // change background
    //        }
    //    }
    //}

    //public enum TimeChangeSetting
    //{
    //    hour,
    //    daily,
    //    weekly
    //}
}
