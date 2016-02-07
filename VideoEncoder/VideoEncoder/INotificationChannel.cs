using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoder
{
    public interface INotificationChannel
    {
        void SendNotification(Video video);
    }
}
