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
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
    }
}