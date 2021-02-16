using FirstXamarinApp.ViewModels;
using FirstXamarinApp.ViewModels.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VoteSummaryPage : ContentPage
    {
        VoteSummaryViewModel _viewModel;

        public VoteSummaryPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = _viewModel = new VoteSummaryViewModel();

            _viewModel.OnAppearing();
        }
    }
}