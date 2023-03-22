// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MahjongEventCoordinator.Model
{
    public class PlayerData
    {
        public Guid   Id         { get; set; }
        public string Name       { get; set; }
        public bool Substitute { get; set; }
        public double[] RoundScores { get; set; }
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
    }
}
