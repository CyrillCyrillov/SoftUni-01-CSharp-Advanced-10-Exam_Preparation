using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return roster.Count; } }

       
        public void AddPlayer(Player playerToAdd)
        {
            if(roster.Count < Capacity)
            {
                roster.Add(playerToAdd);
            }
        }

        
        public bool RemovePlayer(string nameToRemove)
        {
            Player playerToRemove = roster.FirstOrDefault(n => n.Name == nameToRemove);
            if(playerToRemove == null)
            {
                return false;
            }

            roster.Remove(playerToRemove);
            return true;
        }

        
        public void PromotePlayer(string nameToPromote)
        {
            Player playerToPromote = roster.FirstOrDefault(n => n.Name == nameToPromote);
            if(playerToPromote != null)
            {
                if(playerToPromote.Rank != "Member")
                {
                    playerToPromote.Rank = "Member";
                }
            }
        }


        public void DemotePlayer(string nameToDemote)
        {
            Player playerToDemote = roster.FirstOrDefault(n => n.Name == nameToDemote);
            if (playerToDemote != null)
            {
                if (playerToDemote.Rank != "Trial")
                {
                    playerToDemote.Rank = "Member";
                }
            }
        }



        public Player[] KickPlayersByClass(string classssToRemoves)
        {
            
            Player[] removedPlayers = (new List<Player>(roster.Where(x=>x.Class == classssToRemoves))).ToArray();
            roster = roster.Where(x => x.Class != classssToRemoves).ToList();
            return removedPlayers.ToArray();

        }


        public string Report()
        {
            if(roster.Count > 0)
            {
                StringBuilder reportResult = new StringBuilder();
                reportResult.AppendLine($"Players in the guild: {Name}");

                foreach (Player element in roster)
                {
                    reportResult.AppendLine($"Player {element.Name}: {element.Class}");
                    reportResult.AppendLine($"Rank: {element.Rank}");
                    reportResult.AppendLine($"Description: {element.Description}");
                }

                return reportResult.ToString();
            }

            return null;

        }
    }
}
