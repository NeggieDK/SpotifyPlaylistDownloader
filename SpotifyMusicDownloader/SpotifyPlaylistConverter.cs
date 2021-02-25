using SpotifyAPI.Web;
using SpotifyDownloader.Core.Extensions;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyMusicDownloader
{
    public class SpotifyPlayListConverter
    {
        private readonly SpotifyApiWrapper _spotifyWrapper;
        private readonly YoutubeDlWrapper _youtubeDlWrapper;
        private readonly ConcurrentQueue<FullTrack> _trackQueue;
        private int done;
        private int todo;

        public SpotifyPlayListConverter()
        {
            _spotifyWrapper = new SpotifyApiWrapper();
            _youtubeDlWrapper = new YoutubeDlWrapper();
            _trackQueue = new ConcurrentQueue<FullTrack>();
            done = 0;
            todo = 0;
        }

        public async Task DownloadPlaylist(string id)
        {
            var tracks = await _spotifyWrapper.GetAllTracksInPlaylist(id);
            todo = tracks.Count;
            foreach (var track in tracks)
            {
                _trackQueue.Enqueue(track);
            }

            var th = new ThreadStart(async () => await PollQueue());
            var threadList = new List<Thread>();
            for (var i = 0; i < 8; i++)
            {
                var thread = new Thread(th);
                thread.Start();
                threadList.Add(thread);
            }
            foreach (var thread in threadList)
            {
                thread.Join();
            }
        }

        private async Task PollQueue()
        {
            while (!_trackQueue.IsEmpty)
            {
                if (_trackQueue.TryDequeue(out var result))
                {
                    YoutubeDlWrapper.DownloadAudioByTitle($"{result.Artists.FirstOrDefault().Name} {result.Name}", AudioFormat.Wav, $"{result.Artists.FirstOrDefault().Name} - {result.Name}", false);
                    done++;
                    System.Console.WriteLine($"{done}/{todo}");
                }
            }
        }
    }
}
