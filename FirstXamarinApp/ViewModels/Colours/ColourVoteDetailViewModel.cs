using FirstXamarinApp.Models;
using FirstXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinApp.ViewModels.Votes
{
    [QueryProperty(nameof(ColourId), nameof(ColourId))]
    public class ColourVoteDetailViewModel : BaseViewModel
    {
        public ColourVoteDetailViewModel()
        {
            VoteForColour = new Command(async () => await CastVote(ColourId));
        }

        public IDataStore<ColourVoteTracker> DataStore => DependencyService.Get<IDataStore<ColourVoteTracker>>();

        private string colourId;
        private System.Drawing.Color colour;
        private int numberOfVotes;
        private DateTime lastVoteCast;
        private string colourHex;

        public string Id { get; set; }

        public int NumberOfVotes
        {
            get => numberOfVotes;
            set => SetProperty(ref numberOfVotes, value); 
        }

        public string ColourHex
        {
            get => colourHex;
            set => SetProperty(ref colourHex, value);
        }

        public System.Drawing.Color Colour
        {
            get => colour;
            set => SetProperty(ref colour, value);
        }

        public DateTime LastVoteCast
        {
            get => lastVoteCast;
            set => SetProperty(ref lastVoteCast, value);
        }

        public string ColourId
        {
            get
            {
                return colourId;
            }
            set
            {
                Task.Run(async () =>
                {
                    colourId = value;
                    await LoadColourId(value);
                });
            }
        }

        public async Task LoadColourId(string colourId)
        {
            try
            {
                var voteTracker = await DataStore.GetItemAsync(colourId);
                LastVoteCast = voteTracker.LastVoteCast;
                NumberOfVotes = voteTracker.NumberOfVotes;
                Id = voteTracker.Id;
                Colour = voteTracker.Colour;
                ColourHex = voteTracker.ColourHex;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Colour");
            }
        }

        public ICommand VoteForColour { get; }

        private async Task CastVote(string colourId)
        {
            var voteTracker = await DataStore.GetItemAsync(colourId);
            voteTracker.NumberOfVotes++;
            voteTracker.LastVoteCast = DateTime.Now;
            await DataStore.UpdateItemAsync(voteTracker);
            await LoadColourId(colourId);
        }
    }
}
