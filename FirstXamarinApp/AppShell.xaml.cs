using FirstXamarinApp.ViewModels;
using FirstXamarinApp.Views;
using FirstXamarinApp.Views.Colours;
using FirstXamarinApp.Views.Dogs;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ColourVoteDetailPage), typeof(ColourVoteDetailPage));
            Routing.RegisterRoute(nameof(ColourVoteSummaryPage), typeof(ColourVoteSummaryPage));
            Routing.RegisterRoute(nameof(DogCarouselPage), typeof(DogCarouselPage));
            Routing.RegisterRoute(nameof(DogDetailPage), typeof(DogDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
