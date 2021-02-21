using FirstXamarinApp.Models;
using FirstXamarinApp.Services;
using FirstXamarinApp.Views.Dogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstXamarinApp.ViewModels.Dogs
{
    public class DogCarouselViewModel : BaseViewModel
    {
        public IDataStore<Dog> DogStore => DependencyService.Get<IDataStore<Dog>>();

        private Dog _selectedDog;

        public ObservableCollection<Dog> Dogs { get; set; }

        public Command LoadDogsCommand { get; }
        public Command<Dog> DogTapped { get; }

        public DogCarouselViewModel()
        {
            Title = "Dog Carousel";
            Dogs = new ObservableCollection<Dog>();
            Task.Run(async () => await ExecuteLoadDogsCommand());
            DogTapped = new Command<Dog>(OnDogSelected);
        }

        async Task ExecuteLoadDogsCommand()
        {
            IsBusy = true;

            try
            {
                if (Dogs.Count() > 0)
                    return;

                var dogs = await DogStore.GetItemsAsync(true);
                foreach (var dog in dogs)
                {
                    Dogs.Add(dog);
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
            SelectedDog = null;
        }


        public Dog SelectedDog
        {
            get => _selectedDog;
            set
            {
                SetProperty(ref _selectedDog, value);

                OnDogSelected(value);
            }
        }

        async void OnDogSelected(Dog item)
        {
            if (item == null)
                return;

            // This will push the ColourVoteDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DogDetailPage)}?{nameof(DogDetailViewModel.DogId)}={item.DogId}");
        }
    }
}
