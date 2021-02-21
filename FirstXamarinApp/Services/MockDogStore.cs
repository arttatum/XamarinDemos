using FirstXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstXamarinApp.Services
{
    public class MockDogStore : IDataStore<Dog>
    {
        readonly List<Dog> dogs;
        public MockDogStore()
        {
            dogs = new List<Dog>()
            {
                new Dog(){ DogId = Guid.NewGuid().ToString(), ImageUrl = new Uri("https://th.bing.com/th/id/OIP.-ttuIWzHwSYrDiitAFvisgHaFj?w=247&h=185&c=7&o=5&pid=1.7"), Breed = "Pug", AverageHeight = 12, AverageWeight = 16, Description = "The pug is a breed of dog with physically distinctive features of a wrinkly, short-muzzled face, and curled tail. The breed has a fine, glossy coat that comes in a variety of colours, most often light brown or black, and a compact, square body with well-developed muscles."},
                new Dog(){ DogId = Guid.NewGuid().ToString(), ImageUrl = new Uri("https://th.bing.com/th/id/OIP.HhKu5IhCN_bfIGnvvKst1wHaEH?w=298&h=180&c=7&o=5&pid=1.7"), Breed = "German Shepherd", AverageHeight = 25, AverageWeight = 100, Description = "The German Shepherd is a breed of medium to large-sized working dog that originated in Germany. According to the FCI, the breed's English language name is German Shepherd Dog. The breed was officially known as the 'Alsatian Wolf Dog' in the UK from after the First World War until 1977 when its name was changed back to German Shepherd. Despite its wolf-like appearance, the German Shepherd is a relatively modern breed of dog, with their origin dating to 1899."},
                new Dog(){ DogId = Guid.NewGuid().ToString(), ImageUrl = new Uri("https://th.bing.com/th/id/OIP.LX0CP3ZnzX32QaMRJoMgjwHaEo?w=270&h=180&c=7&o=5&pid=1.7"), Breed = "Poodle", AverageHeight = 16, AverageWeight = 55, Description = "As a very intelligent dog, Poodles can get bored quite easily if not enough mental and physical stimulation is provided. This needs to be in the form of exercise, play, learning and obedience. The Poodle is very capable of learning new commands and has a talent for learning tricks, the reason why, along with its showy appearance, it used to be used on a regular basis in circuses. They are playful patient and loyal to the family, but can be reserved with strangers until they get to know them."},
                new Dog(){ DogId = Guid.NewGuid().ToString(), ImageUrl = new Uri("https://th.bing.com/th/id/OIP.E0ic9D7j06Sc6GrLX2igBQHaFj?w=261&h=196&c=7&o=5&pid=1.7"), Breed = "Jack Russel", AverageHeight = 13, AverageWeight = 15, Description = "The Jack Russell is one of the most popular companion dogs and family pets in the UK as well as elsewhere in the world and for good reason. They are bold, happy and high energy dogs that thrive on being around people. However, because they have such a lot of energy, they need the right amount of exercise and mental stimulation for them to be truly happy, well-behaved dogs."},
                new Dog(){ DogId = Guid.NewGuid().ToString(), ImageUrl = new Uri("https://th.bing.com/th/id/OIP.PsXNMHubTUEgbYopacSjrgHaJw?w=142&h=187&c=7&o=5&pid=1.7"), Breed = "Golden Labrador", AverageHeight = 20, AverageWeight = 70, Description = " The Golden Labrador is a large dog with a square shaped head that is slightly rounded at the top. The ears are long and floppy and this attractive furry companion has a wide tapered muzzle with the teeth meeting in a scissors bite. They say that the eyes are the mirror to the soul, and this is definitely true with the Goldador."},
                new Dog(){ DogId = Guid.NewGuid().ToString(), ImageUrl = new Uri("https://th.bing.com/th/id/OIP.6mN9KPSCVNGEpTBNF5gDWQHaE9?w=280&h=187&c=7&o=5&pid=1.7"), Breed = "Border Collie", AverageHeight = 20, AverageWeight = 37, Description = "This highly intelligent, graceful dog is born with an instinct to work and responds extremely well to training, which is why they are often used as a mountain-rescue or sniffer dog. Border Collies make loyal, faithful pets that thrive on company and stimulation."}
            };
        }

        public Task<bool> AddItemAsync(Dog item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dog> GetItemAsync(string id)
        {
            return await Task.FromResult(dogs.FirstOrDefault(s => s.DogId == id));
        }

        public async Task<IEnumerable<Dog>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(dogs);
        }

        public Task<bool> UpdateItemAsync(Dog item)
        {
            throw new NotImplementedException();
        }
    }
}
