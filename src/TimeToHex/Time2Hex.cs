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
                return "#FFFFFFFF";
            }
        }
    }
}
