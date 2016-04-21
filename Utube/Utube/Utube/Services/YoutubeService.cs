using Utube.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Utube.Services
{
    public class YoutubeService
    {
        // TODO: Get the Api Key from Youtube
        public const string API_KEY = "";

        public async Task<List<MYoutubeSchema>> GetVideosAsync(string channelId)
        {
            try
            {
                string baseurl = "https://www.googleapis.com/youtube/v3";

                string url = string.Format("{0}/channels?id={1}&part=contentDetails&maxResults=1&key={2}", baseurl, channelId, API_KEY);
                WebRequest request = WebRequest.CreateHttp(url);
                request.UseDefaultCredentials = true;
                request.Method = "GET";
                var response = await request.GetResponseAsync();
                string stringResponse;
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    stringResponse = sr.ReadToEnd();
                }

                var channel = JsonConvert.DeserializeObject<YouTubeResult<YouTubeChannelLookupResult>>(stringResponse);

                if (channel != null
                    && channel.items != null
                    && channel.items.Count > 0
                    && channel.items[0].contentDetails != null
                    && channel.items[0].contentDetails.relatedPlaylists != null
                    && !string.IsNullOrEmpty(channel.items[0].contentDetails.relatedPlaylists.uploads))
                {
                    string playlistUrl = string.Format("{0}/playlistItems?playlistId={1}&part=snippet&maxResults=20&key={2}", baseurl, channel.items[0].contentDetails.relatedPlaylists.uploads, API_KEY);
                    WebRequest requestPlaylist = WebRequest.CreateHttp(playlistUrl);
                    requestPlaylist.UseDefaultCredentials = true;
                    requestPlaylist.Method = "GET";
                    var responsePlaylist = await requestPlaylist.GetResponseAsync();
                    string playlistResult;
                    using (StreamReader sr = new StreamReader(responsePlaylist.GetResponseStream()))
                    {
                        playlistResult = sr.ReadToEnd();
                    }
                    var playlist = JsonConvert.DeserializeObject<YouTubeResult<YouTubePlaylistResult>>(playlistResult);
                    if (playlist != null && playlist.items != null)
                    {
                        var items = playlist.items
                            .Select(i => new MYoutubeSchema()
                            {
                                Title = i.snippet.title,
                                ImageUrl = i.snippet.thumbnails != null ? i.snippet.thumbnails.high.url : string.Empty,
                                Summary = i.snippet.description,
                                Published = i.snippet.publishedAt,
                                VideoId = i.snippet.resourceId.videoId
                            }).ToList();
                        return items;
                    }
                    return null;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> GetYoutubeId(string user)
        {
            var url = String.Format("https://www.googleapis.com/youtube/v3/channels?key={0}&forUsername={1}&part=id", API_KEY, user);
            var json = await new System.Net.Http.HttpClient().GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<YoutubeSearch>(json);

            if (result.pageInfo.totalResults == 0)
                return String.Empty;
            
            return result.items.FirstOrDefault().id;
        }
    }
}
