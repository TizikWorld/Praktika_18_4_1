using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Praktika_18_4_1
{
    public class DownloadVideo
    {
        private YoutubeClient client;
        private string url;
        private string path;
        public DownloadVideo(YoutubeClient client, string url, string path)
        {
            this.client = client;
            this.url = url;
            this.path = path;
        }

        public async Task Done()
        {
            try
            {
                var video = await client.Videos.GetAsync(url);
                var streamManifest = await client.Videos.Streams.GetManifestAsync(video.Id);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                if (streamInfo is null)
                {
                    Console.Error.WriteLine("This video has no muxed streams.");
                    return;
                }
                await client.Videos.Streams.DownloadAsync(streamInfo, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
