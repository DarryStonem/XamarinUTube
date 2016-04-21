using System.Net;

namespace Utube.Models
{
    public abstract class MYoutubeBase
    {
        public abstract string DefaultContent { get; }
        public abstract string DefaultImageUrl { get; }
        public abstract string DefaultSummary { get; }
        public abstract string DefaultTitle { get; }
    }
}
