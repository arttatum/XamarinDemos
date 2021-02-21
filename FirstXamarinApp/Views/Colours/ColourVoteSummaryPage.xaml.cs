using FirstXamarinApp.ViewModels;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColourVoteSummaryPage : ContentPage
    {
        ColourVoteSummaryViewModel _viewModel;

        public ColourVoteSummaryPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = _viewModel = new ColourVoteSummaryViewModel();

            await _viewModel.OnAppearing();
        }
    }
}