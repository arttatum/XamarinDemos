using FirstXamarinApp.Models;
using FirstXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinApp.ViewModels.Dogs
{
    [QueryProperty(nameof(DogId), nameof(DogId))]
    public class DogDetailViewModel : BaseViewModel
    {
        public IDataStore<Dog> DogStore => DependencyService.Get<IDataStore<Dog>>();
        public IDataStore<DogVoteTracker> DogVoteStore => DependencyService.Get<IDataStore<DogVoteTracker>>();
        public DogDetailViewModel()
        {
            VoteForDog = new Command(async () => await CastVote(DogId));
        }

        ICommand VoteForDog { get; }       

        private string dogId;
        public string DogId
        {
            get => dogId;
            set
            {
                Task.Run(async () => {
                    dogId = value;
                    await LoadDogId(value);
                });
            }
        }

        private int averageHeight;
        public int AverageHeight
        {
            get => averageHeight;
            set => SetProperty(ref averageHeight, value);
        }

        private int averageWeight;
        public int AverageWeight
        {
            get => averageWeight;
            set => SetProperty(ref averageWeight, value);
        }

        private string breed;
        public string Breed
        {
            get => breed;
            set => SetProperty(ref breed, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private int numberOfVotes;
        public int NumberOfVotes
        {
            get => numberOfVotes;
            set => SetProperty(ref numberOfVotes, value);
        }

        private async Task CastVote(string DogId)
        {
            var oldDogVotes = await DogVoteStore.GetItemAsync(DogId);
            oldDogVotes.NumberOfVotes++;
            await DogVoteStore.UpdateItemAsync(oldDogVotes);
            await LoadDogId(DogId);
        }

        private async Task LoadDogId(string DogId)
        {
            try
            {
                var dog = await DogStore.GetItemAsync(DogId);
                var dogVotes = await DogVoteStore.GetItemAsync(DogId);

                Breed = dog.Breed;
                AverageWeight = dog.AverageWeight;
                AverageHeight = dog.AverageHeight;
                Description = dog.Description;            
                NumberOfVotes = dogVotes.NumberOfVotes;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Dog Data");
            }
        }
    }
}
