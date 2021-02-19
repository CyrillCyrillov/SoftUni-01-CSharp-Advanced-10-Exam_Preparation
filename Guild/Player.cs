using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        
        public Player(string name, string classText)
        {
            Name = name;
            Class = classText;
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; } = "Trial";
        public string Description { get; set; } = "n/a";


        public override string ToString()
        {
            StringBuilder playerIno = new StringBuilder();
            playerIno.AppendLine($"Player {Name}: {Class}");
            playerIno.AppendLine($"Rank: {Rank}");
            playerIno.AppendLine($"Description: {Description}");

            return playerIno.ToString();
        }

    }
}
