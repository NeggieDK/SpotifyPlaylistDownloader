using SpotifyDownloader.Core.Extensions;
using Xunit;

namespace SpotifyMusicDownloader.Tests.UnitTests.YoutubeDlBuilderTests
{
    public class YoutubeDlBuilderFullTests
    {
        [Fact]
        public void FullWorkingTest()
        {
            var builder = new YoutubeDlBuilder(@"C:\Users\aaron\Downloads\youtube-dl.exe");
            builder.AddTitle("Netsky Hold On")
                .AddOutputFolder(@"C:\Users\Aaron\Downloads\YoutubeDownloads\filename")
                .PickFormat(AudioFormat.Opus)
                .PickQuality(5)
                .Silent();

            var expected = @"/C C:\Users\aaron\Downloads\youtube-dl.exe ""ytsearch1:Netsky Hold On"" -x -o ""C:\Users\Aaron\Downloads\YoutubeDownloads\filename.%(ext)s"" --audio-format opus --audio-quality 5 -q";
            Assert.Equal(expected, builder.Get());
        }

    }
}
