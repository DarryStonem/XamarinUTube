using System;

namespace Utube.Models
{
    public class MYoutubeSchema : MYoutubeBase
    {
        private const string YoutubeWatchBaseUrl = "http://www.youtube.com/watch?v=";
        private const string YoutubeEmbedHtmlFragment = @"http://www.youtube.com/embed/{0}?rel=0&fs=0";

        private string _title;
        private string _summary;
        private string _videoUrl;
        private string _imageUrl;
        private string _videoId;
        private DateTime _published;
        
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        public string VideoUrl
        {
            get { return _videoUrl; }
            set { _videoUrl = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public DateTime Published
        {
            get { return _published; }
            set { _published = value; }
        }

        public string VideoId
        {
            get
            {
                return _videoId;
            }
            set { _videoId = value; }
        }

        public string ExternalUrl
        {
            get { return YoutubeWatchBaseUrl + VideoId; }
        }

        public override string DefaultTitle
        {
            get { return Title; }
        }

        public override string DefaultSummary
        {
            get { return Summary; }
        }

        public override string DefaultImageUrl
        {
            get { return ImageUrl; }
        }

        public override string DefaultContent
        {
            get { return Summary; }
        }

        public string EmbedHtmlFragment
        {
            get { return string.Format(YoutubeEmbedHtmlFragment, _videoId); }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
