using SpotifyDownloader.Core.Extensions;
using Xunit;

namespace SpotifyMusicDownloader.Tests.UnitTests.YoutubeDlBuilderTests
{
    public class YoutubeDlBuilderTests
    {
        [Fact]
        public void ChainCallsTests()
        {
            var x = new YoutubeDlBuilder("youtube-dl");
            x.AddArgument("One", "1")
                .AddArgument("Two", "2")
                .AddArgument("Three", "3")
                .AddArgument("Four", "4")
                .AddArgument("Five", "5");
            Assert.Equal("/C youtube-dl -x One 1 Two 2 Three 3 Four 4 Five 5", x.Get());
        }

        [Fact]
        public void OutputTests()
        {
            var x = new YoutubeDlBuilder("youtube-dl");
            x.AddOutputFolder("FileNameTest");
            Assert.Equal("/C youtube-dl -x -o \"FileNameTest.%(ext)s\"", x.Get());
        }

        [Fact]
        public void PickFormatTests()
        {
            var x = new YoutubeDlBuilder("youtube-dl");
            x.PickFormat(AudioFormat.Flac);
            Assert.Equal("/C youtube-dl -x --audio-format flac", x.Get());
        }

        [Fact]
        public void PickQualityTests()
        {
            var x = new YoutubeDlBuilder("youtube-dl");
            x.PickQuality(1);
            Assert.Equal("/C youtube-dl -x --audio-quality 1", x.Get());
        }

        [Fact]
        public void SilentTests()
        {
            var x = new YoutubeDlBuilder("youtube-dl");
            x.Silent();
            Assert.Equal("/C youtube-dl -x -q", x.Get());
        }

        [Fact]
        public void AddArgumentNullTests()
        {
            var x = new YoutubeDlBuilder("youtube-dl");
            x.AddArgument(null, null);
            Assert.Equal("/C youtube-dl -x", x.Get());
        }
    }
}
