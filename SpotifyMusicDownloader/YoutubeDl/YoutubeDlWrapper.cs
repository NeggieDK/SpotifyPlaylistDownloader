using SpotifyDownloader.Core.Extensions;
using System.Diagnostics;

namespace SpotifyMusicDownloader
{
    public class YoutubeDlWrapper
    {
        public static void DownloadAudioByTitle(string title, AudioFormat format, string outputFileName, bool verbose = true)
        {
            var builder = new YoutubeDlBuilder(@"C:\Users\aaron\Downloads\youtube-dl.exe")
                .AddTitle(title)
                .PickQuality(0)
                .PickFormat(format)
                .AddOutputFolder(outputFileName);

            if (!verbose)
            {
                builder.Silent();
            }

            var process = Process.Start("CMD.exe", builder.Get());
            process.WaitForExit();
        }
    }
}
