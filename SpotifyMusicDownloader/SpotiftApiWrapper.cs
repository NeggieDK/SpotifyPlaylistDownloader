using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyMusicDownloader
{
    public class SpotifyApiWrapper
    {
        private readonly SpotifyClientConfig _spotifyClientConfig;
        private string clientId = "";
        private string clientSecret = "";
        private ClientCredentialsTokenResponse accessToken;

        public SpotifyApiWrapper()
        {
            _spotifyClientConfig = SpotifyClientConfig.CreateDefault();
        }
        public async Task<List<FullTrack>> GetAllTracksInPlaylist(string playlistId)
        {
            await GetTokenIfExpired();
            var spotify = new SpotifyClient(accessToken.AccessToken);
            var playlistPagination = await spotify.Playlists.GetItems("1nkCfKB3TF9ws4AyquB0aI");
            var tracks = await spotify.PaginateAll(playlistPagination);
            return (tracks).Select(i => i.Track).ToList().Cast<FullTrack>().ToList();
        }

        private async Task GetTokenIfExpired()
        {
            if (accessToken != null && !accessToken.IsExpired) return;
            var request = new ClientCredentialsRequest(clientId, clientSecret);
            accessToken = await new OAuthClient(_spotifyClientConfig).RequestToken(request);
        }
    }
}
