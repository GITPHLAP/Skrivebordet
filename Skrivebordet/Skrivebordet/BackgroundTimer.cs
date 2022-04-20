using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Skrivebordet
{
    public class BackgroundTimer
    {
        public static event EventHandler? BackgroundChange;

        private static void OnTick(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Minute == 0)
            {
                BackgroundChange?.Invoke(sender, e);
            }
            //BackgroundChange?.Invoke(this, EventArgs.Empty);
        }

        public static void Start()
        {
            Timer timer = new(10000);
            timer.Elapsed += OnTick;
        }
    }
}
