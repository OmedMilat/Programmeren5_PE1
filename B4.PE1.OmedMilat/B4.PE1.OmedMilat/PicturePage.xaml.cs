using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.PE1.OmedMilat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicturePage : ContentPage
    {
        public PicturePage()
        {
            InitializeComponent();
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Image image = ((Image)sender);
            FileImageSource FileName = image.Source as FileImageSource;
            PictureName source = new PictureName
            {
                PictureSource = FileName.File
            };
            PictureDetail PictureDetail = new PictureDetail();
            PictureDetail.BindingContext = source;
            await Navigation.PushAsync(PictureDetail);
        }
    }
}