using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.PE1.OmedMilat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PictureDetail : ContentPage
	{
		public PictureDetail ()
		{
			InitializeComponent ();
            //var image = new Image { Aspect= Aspect.Fill , Source = "jessica1.jpg" };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Image image = ((Image)sender);
            if (image.Scale == 1)
            {
                image.Scale = 1.5;
            }
            else
                image.Scale = 1.0;
        }
    }
}