using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinApp.Models
{
    public class VoteTracker
    {
        public string Id { get; set; }
        public System.Drawing.Color Colour { get; set; }

        public string ColourHex { get => "#" + this.Colour.R.ToString("X2") + this.Colour.G.ToString("X2") + this.Colour.B.ToString("X2"); }

        public int NumberOfVotes { get; set; }

        public DateTime LastVoteCast { get; set; }
    }
}
