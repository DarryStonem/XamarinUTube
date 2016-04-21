using System;
using System.Collections.Generic;

namespace Utube.Models
{
    public class YouTubeResult<T>
    {
        public string error { get; set; }
        public List<T> items { get; set; }
    }

    public class YouTubeChannelLookupResult
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public Contentdetails contentDetails { get; set; }
    }

    public class Contentdetails
    {
        public Relatedplaylists relatedPlaylists { get; set; }
    }

    public class Relatedplaylists
    {
        public string favorites { get; set; }
        public string uploads { get; set; }
    }

    public class YouTubePlaylistResult
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public YouTubePlaylistSnippet snippet { get; set; }
    }

    public class YouTubePlaylistSnippet
    {
        public DateTime publishedAt { get; set; }
        public string channelId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumbnails thumbnails { get; set; }
        public string channelTitle { get; set; }
        public string playlistId { get; set; }
        public int position { get; set; }
        public Resourceid resourceId { get; set; }
    }

    public class Resourceid
    {
        public string kind { get; set; }
        public string videoId { get; set; }
    }

    public class Thumbnails
    {
        public Default _default { get; set; }
        public Medium medium { get; set; }
        public High high { get; set; }
    }

    public class Default
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class High
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
