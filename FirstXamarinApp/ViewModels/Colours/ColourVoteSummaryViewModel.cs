using FirstXamarinApp.Models;
using FirstXamarinApp.Services;
using FirstXamarinApp.Views;
using FirstXamarinApp.Views.Colours;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstXamarinApp.ViewModels.Votes
{
    public class ColourVoteSummaryViewModel : BaseViewModel
    {
        public IDataStore<ColourVoteTracker> DataStore => DependencyService.Get<IDataStore<ColourVoteTracker>>();

        private ColourVoteTracker _selectedColour;

        public ObservableCollection<ColourVoteTracker> ColourVoteTrackers { get; }
        public Command LoadColoursCommand { get; }
        public Command<ColourVoteTracker> ColourTapped { get; }

        public ColourVoteSummaryViewModel()
        {
            Title = "Colours Summary";
            ColourVoteTrackers = new ObservableCollection<ColourVoteTracker>();
            LoadColoursCommand = new Command(async () => await ExecuteLoadColoursCommand());
            ColourTapped = new Command<ColourVoteTracker>(OnColourSelected);
        }


        async Task ExecuteLoadColoursCommand()
        {
            IsBusy = true;

            try
            {
                if (ColourVoteTrackers.Count() > 0)
                    return;

                var colours = await DataStore.GetItemsAsync(true);
                foreach (var colour in colours)
                {
                    ColourVoteTrackers.Add(colour);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ColourVoteTracker SelectedItem
        {
            get => _selectedColour;
            set
            {
                SetProperty(ref _selectedColour, value);
                
                OnColourSelected(value);
            }
        }

        async void OnColourSelected(ColourVoteTracker item)
        {
            if (item == null)
                return;

            // This will push the ColourVoteDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ColourVoteDetailPage)}?{nameof(ColourVoteDetailViewModel.ColourId)}={item.Id}");
        }

    }
}
