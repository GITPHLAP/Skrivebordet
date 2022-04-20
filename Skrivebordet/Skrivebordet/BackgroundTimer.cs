using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Skrivebordet
{
    public class BackgroundTimer
    {
        public static event EventHandler? BackgroundChange;

        private DateTime old_dateTime;

        private Calendar calendar = CultureInfo.CurrentCulture.Calendar;

        public TimeChangeSetting TimeSetting { get; set; }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            switch (TimeSetting)
            {
                case TimeChangeSetting.hour:
                    
                    break;
                case TimeChangeSetting.daily:
                    break;
                case TimeChangeSetting.weekly:
                    break;
                default:
                    break;
            }


            //if (DateTime.Now.Minute == 0)
            //{
            //    BackgroundChange?.Invoke(sender, e);
            //}
            //BackgroundChange?.Invoke(this, EventArgs.Empty);
        }

        public void Start()
        {
            Timer timer = new(10000);
            timer.Elapsed += OnTick;
        }

        private void HourlyTimeCheck()
        {
            if (old_dateTime.AddHours(1).Hour == DateTime.Now.Hour)
            {
                // change background
            }
        }

        private void DailyTimeCheck()
        {
            if (old_dateTime.AddDays(1).Day == DateTime.Now.Day)
            {
                // change background
            }
        }

        private void WeeklyTimeCheck()
        {
            if (calendar.GetWeekOfYear(old_dateTime) == DateTime.Now.Hour)
            {
                // change background
            }
        }
    }

    public enum TimeChangeSetting
    {
        hour,
        daily,
        weekly
    }
}
