using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utube.Services;
using Xamarin.Forms;

namespace Utube
{
    public partial class VideosList : ContentPage
    {
        public VideosList()
        {
            InitializeComponent();
            LoadVideos();
        }

        private async void LoadVideos()
        {
            var service = new YoutubeService();

            var channelId = await service.GetYoutubeId("paint");
            var items = await service.GetVideosAsync(channelId);

            this.listView.ItemsSource = items;
        }
    }
}
