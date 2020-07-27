using System;
using System.Text;

namespace Bookswagon.Screenshots
{
    public class TakeScreenshot
    {
        //Updates the number of screenshots that we took during the execution and provides name to taken screenshot
        public StringBuilder TakesScreenshotWithDate()
        {
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            return TimeAndDate;
        }
    }
}
