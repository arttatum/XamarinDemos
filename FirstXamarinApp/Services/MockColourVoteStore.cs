using FirstXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstXamarinApp.Services
{
    public class MockColourVoteStore : IDataStore<ColourVoteTracker>
    {
        List<ColourVoteTracker> votes;

        public MockColourVoteStore()
        {
            votes = new List<ColourVoteTracker>()
            {
                new ColourVoteTracker{ Colour = System.Drawing.Color.Blue, NumberOfVotes = 2, Id = Guid.NewGuid().ToString(), LastVoteCast = DateTime.Now},
                new ColourVoteTracker{ Colour = System.Drawing.Color.Brown, NumberOfVotes = 1, Id = Guid.NewGuid().ToString(), LastVoteCast = DateTime.Now}, 
                new ColourVoteTracker{ Colour = System.Drawing.Color.Black, NumberOfVotes = 9, Id =  Guid.NewGuid().ToString(), LastVoteCast = DateTime.Now},
                new ColourVoteTracker{ Colour = System.Drawing.Color.BurlyWood, NumberOfVotes = 0, Id =  Guid.NewGuid().ToString(), LastVoteCast = DateTime.Now}
            };
        }

        public Task<bool> AddItemAsync(ColourVoteTracker item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ColourVoteTracker> GetItemAsync(string id)
        {
            return await Task.FromResult(votes.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<ColourVoteTracker>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(votes);
        }

        public async Task<bool> UpdateItemAsync(ColourVoteTracker item)
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
