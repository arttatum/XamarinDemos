using FirstXamarinApp.ViewModels.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinApp.Views.Colours
{

    public partial class ColourVoteDetailPage : ContentPage
    {

        public ColourVoteDetailPage()
        {
            InitializeComponent();
            BindingContext = new ColourVoteDetailViewModel();
        }
    }
}