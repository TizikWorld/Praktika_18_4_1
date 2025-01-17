using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Praktika_18_4_1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Ссылка на видео
            string urlvideo = "https://youtu.be/U9Her470V_0?si=w6u3JNRgjfR7F7kq";
            string name = "video";

            //Использование предыдущей версии библиотеки для обхождение региональных ограничений
            var youtube = new YoutubeClient();

            //Получение названия и описания
            Description description = new (youtube,urlvideo);
            await description.Done();

            //Директория для скачивания
            
            string FullPath = Path.Combine(Directory.GetCurrentDirectory(),name) ;

            //Скачивание видео
            DownloadVideo download = new(youtube,urlvideo,FullPath);
            await download.Done();

        }
    }
}
