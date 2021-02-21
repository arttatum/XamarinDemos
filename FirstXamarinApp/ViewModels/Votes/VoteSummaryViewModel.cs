﻿using FirstXamarinApp.Models;
using FirstXamarinApp.Services;
using FirstXamarinApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstXamarinApp.ViewModels.Votes
{
    public class VoteSummaryViewModel : BaseViewModel
    {
        public IDataStore<ColourVoteTracker> DataStore => DependencyService.Get<IDataStore<ColourVoteTracker>>();

        private ColourVoteTracker _selectedColour;

        public ObservableCollection<ColourVoteTracker> VoteTrackers { get; }
        public Command LoadColoursCommand { get; }
        public Command<ColourVoteTracker> ColourTapped { get; }

        public VoteSummaryViewModel()
        {
            Title = "Browse";
            VoteTrackers = new ObservableCollection<ColourVoteTracker>();
            LoadColoursCommand = new Command(async () => await ExecuteLoadColoursCommand());
            ColourTapped = new Command<ColourVoteTracker>(OnColourSelected);
        }


        async Task ExecuteLoadColoursCommand()
        {
            IsBusy = true;

            try
            {
                if (VoteTrackers.Count() > 0)
                    return;

                var colours = await DataStore.GetItemsAsync(true);
                foreach (var colour in colours)
                {
                    VoteTrackers.Add(colour);
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

            // This will push the VoteDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(VoteDetailPage)}?{nameof(VoteDetailViewModel.ColourId)}={item.Id}");
        }

    }
}
