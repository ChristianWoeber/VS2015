using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var vid = new Video { Title = "Terminator" };
            var vidEncoder = new VideoEncoder();//Publisher
            var sms = new SmsNotification();//Subscriber
            var mail = new MailNotification();//Subscriber

            vidEncoder.VideoEncoded += sms.OnVideoEncoded; //Register the event
            vidEncoder.VideoEncoded += mail.OnVideoEncoded; //Register the event

            vidEncoder.Encode(vid);

        }

        
    }
}
