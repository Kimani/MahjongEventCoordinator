// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MahjongEventCoordinator.Model
{
    public class PlayerData : IComparable<PlayerData>
    {
        public Guid   Id         { get; set; }
        public string Name       { get; set; }
        public bool Substitute { get; set; }
        public double[] RoundScores { get; set; }
        public List<string> pastPlayers { get; set; }
        public double TotalScore 
        {
            get
            {
                double total = 0;
                foreach (double score in RoundScores)
                {
                    total += score;
                }
                return total;
            }
        }
        public void AssignScore(double score, int round)
        {
            RoundScores[round] = score;
        }

		public int CompareTo(PlayerData other)
		{
			if (TotalScore > other.TotalScore)
            {
                return -1;
            }
            else if (TotalScore < other.TotalScore)
            {
                return 1;
            }
            else
            { 
                return 0; 
            }
		}
        public void registerRepeats(string p, string q, string r)
        {
            this.pastPlayers.Add(p);
            this.pastPlayers.Add(q);
            this.pastPlayers.Add(r);
        }
        public bool newOpponent(PlayerData other)
        {
            string p = other.Id.ToString();
            foreach (string r in pastPlayers)
            {
                if (r == p)
                {
                    return false;
                }
            }
            return true;
        }
	}
}
