using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Utube
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            MainPage = new VideosList();
        }
    }
}
