using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class VideoEncoder
    {
        public VideoEncoder()
        {

        }
        //1. Define a Delegate
        //2. Define an Event based on that Delegate
        //3. Raise the Event
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;

        public void Encode (Video video)
        {
            //Encoding logic
            Console.WriteLine("Video is beeing encoded...");
            Thread.Sleep(3500);

            OnVideoEncoded(video);
        }

        protected internal void OnVideoEncoded(Video Video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() {Video = Video });
        }
    }
}
