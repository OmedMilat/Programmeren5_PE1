using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace B4.PE1.OmedMilat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnPicture_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PicturePage());
        }

        private async void btnWiki_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WikiPage());
        }
    }
}
