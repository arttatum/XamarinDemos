using FirstXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace FirstXamarinApp.Services
{
    public class MockDogVoteStore : IDataStore<DogVoteTracker>
    {
        List<DogVoteTracker> dogVotes;
        public MockDogVoteStore()
        {
            dogVotes = new List<DogVoteTracker>();

            MockDogStore dogStore = new MockDogStore();
            foreach(var dogId in dogStore.GetItemsAsync().GetAwaiter().GetResult().Select(x => x.DogId))
            {
                dogVotes.Add(new DogVoteTracker() { DogId = dogId, NumberOfVotes = 0 });
            }
        }

        public Task<bool> AddItemAsync(DogVoteTracker item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<DogVoteTracker> GetItemAsync(string id)
        {
            return await Task.FromResult(dogVotes.FirstOrDefault(s => s.DogId == id));
        }

        public async Task<IEnumerable<DogVoteTracker>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(dogVotes);
        }

        public async Task<bool> UpdateItemAsync(DogVoteTracker item)
        {
            var oldItem = dogVotes.FirstOrDefault(x => x.DogId == item.DogId);
            dogVotes.Remove(oldItem);
            dogVotes.Add(item);

            return await Task.FromResult(true);
        }
    }
}
