using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class SmsNotification
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("SMS Notification: senting sms..."+ e.Video.Title);
        }
    }
}
