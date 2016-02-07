using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var encoder = new VideoEncoder();
            encoder.RegisterNotificationService(new MailNotification());
            encoder.RegisterNotificationService(new SmsNotification());
            encoder.Encode(new Video { Title = "Terminator" });
        }
    }
}
