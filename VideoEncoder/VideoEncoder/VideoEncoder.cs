using System;
using System.Collections.Generic;
using System.Threading;

namespace VideoEncoder
{

    public class VideoEncoder
    {
        private readonly IList<INotificationChannel> _lstNotifications;

        public VideoEncoder()
        {
            _lstNotifications = new List<INotificationChannel>();
        }

        public void Encode(Video video)
        {
            //VideoEncoding Logic

            Console.WriteLine("Video " + video.Title + "is beeing encoded");
            Thread.Sleep(3000);
            Console.WriteLine("Encoding finished for "+ video.Title);


            foreach (var notification in _lstNotifications)
            {
                notification.SendNotification(video);
            }

        }

        public void RegisterNotificationService(INotificationChannel channel)
        {
            _lstNotifications.Add(channel);
        }
    }
}
