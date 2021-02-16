using FirstXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstXamarinApp.Services
{
    public class MockVoteStore : IDataStore<VoteTracker>
    {
        List<VoteTracker> votes;

        public MockVoteStore()
        {
            votes = new List<VoteTracker>()
            {
                new VoteTracker{ Colour = System.Drawing.Color.Blue, NumberOfVotes = 2, Id = Guid.NewGuid().ToString()},
                new VoteTracker{ Colour = System.Drawing.Color.Brown, NumberOfVotes = 1, Id = Guid.NewGuid().ToString()}, 
                new VoteTracker{ Colour = System.Drawing.Color.Black, NumberOfVotes = 9, Id =  Guid.NewGuid().ToString()},
                new VoteTracker{ Colour = System.Drawing.Color.BurlyWood, NumberOfVotes = 0, Id =  Guid.NewGuid().ToString()}
            };
        }

        public Task<bool> AddItemAsync(VoteTracker item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<VoteTracker> GetItemAsync(string id)
        {
            return await Task.FromResult(votes.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<VoteTracker>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(votes);
        }

        public async Task<bool> UpdateItemAsync(VoteTracker item)
        {
            var oldItem = votes.FirstOrDefault(x => x.Id == item.Id);
            votes.Remove(oldItem);
            votes.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> IncrementVoteCount(string id)
        {
            var voteTracker = votes.FirstOrDefault(x => x.Id == id).NumberOfVotes++;

            return await Task.FromResult(true);
        }
    }
}
