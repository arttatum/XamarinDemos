using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinApp.Views.Dogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogDetailPage : ContentPage
    {
        public DogDetailPage()
        {
            InitializeComponent();
        }
    }
}