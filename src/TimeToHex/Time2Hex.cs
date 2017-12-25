using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToHex
{
    class Time2Hex
    {
        public static int TimeScale = 1;
        public static bool hasTimescaleChanged = true;

        internal static int lastSeconds = DateTime.Now.Second;
        internal static int lastMinutes = DateTime.Now.Minute;
        internal static int lastHours = DateTime.Now.Hour;

        /// <summary>
        /// Returns a hex code in string format from the current time, using the public variable TimeScale
        /// </summary>
        /// <returns></returns>
        public static string GetColourFromTime()
        {
            if (TimeScale == 1)
            {
                string seconds;
                string minutes;
                string hours;

                if (DateTime.Now.Second.ToString().Length == 1)
                {
                    seconds = "0" + DateTime.Now.Second.ToString();
                }
                else { seconds = DateTime.Now.Second.ToString(); }

                if (DateTime.Now.Minute.ToString().Length == 1)
                {
                    minutes = "0" + DateTime.Now.Minute.ToString();
                }
                else { minutes = DateTime.Now.Minute.ToString(); }

                if (DateTime.Now.Hour.ToString().Length == 1)
                {
                    hours = "0" + DateTime.Now.Hour.ToString();
                }
                else { hours = DateTime.Now.Hour.ToString(); }

                return "#FF" + hours + minutes + seconds;
            }
            else
            {
                //Just add 1 each time this is called, since to change timescale , the timer updateInterval should be modified too
                if (lastSeconds == 60) { lastSeconds = 0; lastMinutes++; }
                if (lastMinutes == 60) { lastMinutes = 0; lastHours++; }
                if (lastHours == 60) { lastHours = 0; }
                lastSeconds++;

                string lastSecondsSTR = lastSeconds.ToString();
                string lastMinutesSTR = lastMinutes.ToString();
                string lastHoursSTR = lastHours.ToString();
                if (lastSecondsSTR.Length == 1) { lastSecondsSTR = "0" + lastSecondsSTR; }
                if (lastMinutesSTR.Length == 1) { lastMinutesSTR = "0" + lastMinutesSTR; }
                if (lastHoursSTR.Length == 1) { lastHoursSTR = "0" + lastHoursSTR; }

                return "#FF" + lastSecondsSTR + lastMinutesSTR + lastHoursSTR;
            }
        }
    }
}
