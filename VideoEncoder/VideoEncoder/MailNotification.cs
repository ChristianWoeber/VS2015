using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoder
{
    public class MailNotification : INotificationChannel
    {
        public void SendNotification(Video video)
        {
            Console.WriteLine("Notification for {0} has been sent by Mail", video.Title);
        }
    }
}
