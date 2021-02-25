using SpotifyDownloader.Core.Extensions;
using System.Text;

namespace SpotifyMusicDownloader
{
    public class YoutubeDlBuilder
    {
        private string currentArguments;
        private string searchQuery;
        private string output;
        private string baseCommand;

        public YoutubeDlBuilder(string youtubeDlPath)
        {
            baseCommand = @$"/C {youtubeDlPath}";
            currentArguments = string.Empty;
            searchQuery = string.Empty;
        }

        public YoutubeDlBuilder AddTitle(string title)
        {
            searchQuery = $"\"ytsearch1:{title}\"";
            return this;
        }

        public YoutubeDlBuilder AddOutputFolder(string outputFileName)
        {
            output = $"{outputFileName}.%(ext)s";
            return this;
        }

        public YoutubeDlBuilder PickQuality(int quality)
        {
            return AddArgument("--audio-quality", quality.ToString());
        }

        public YoutubeDlBuilder PickFormat(AudioFormat format)
        {
            return AddArgument("--audio-format", format.ToString().ToLower());
        }

        public YoutubeDlBuilder AddArgument(string option, string argument)
        {
            currentArguments += $" {option?.Trim()} {argument?.Trim()}";
            return this;
        }

        public YoutubeDlBuilder Silent()
        {
            return AddArgument("-q", null);
        }

        public string Get()
        {
            var sb = new StringBuilder();
            sb.Append(baseCommand.Trim());

            if (!string.IsNullOrEmpty(searchQuery))
            {
                sb.Append(" ");
                sb.Append(searchQuery.Trim());
            }

            sb.Append(" -x");

            if (!string.IsNullOrEmpty(output))
            {
                sb.Append(" -o ");
                sb.Append($"\"{output.Trim().TrimEnd('\\')}\"");
            }

            if (!string.IsNullOrEmpty(currentArguments))
            {
                sb.Append(" ");
                sb.Append(currentArguments.Trim());
            }

            return sb.ToString().Trim();
        }
    }
}
