using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace Praktika_18_4_1
{
    public class Description
    {
        private YoutubeClient client;
        private string url;
        public Description(YoutubeClient client, string url)
        {
            this.client = client;
            this.url = url;
        }

        public async Task Done()
        {
            try
            {
                var video = await client.Videos.GetAsync(url);
                Console.WriteLine($"Название: " + video.Title);
                Console.WriteLine($"Описание: " + video.Description);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
