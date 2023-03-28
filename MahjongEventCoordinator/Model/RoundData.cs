// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongEventCoordinator.Model
{
    public static class ListExtensionMethods
    {
		public static void swap(this List<PlayerData> p, int a, int b)
		{
			PlayerData s = p[a];
			p[a] = p[b];
			p[b] = s;
		}
	}
    public class RoundData
    {
        public TableData[] Tables { get; set; }
        public int roundNumber { get; set; }
        public bool finalRound { get; set; }
        public void loadPlayers(IReadOnlyList<PlayerData> Players)
        {
            Tables = new TableData[Players.Count/4];
            if (finalRound)
            {
                List<PlayerData> finalRanking = new List<PlayerData>(Players);
                finalRanking.Sort();
                for (int i = 0; i < 4; i++)
                {
                    if (finalRanking[i].Substitute)
                    {
                        int findNonSub = 4;
                        bool foundNonSub = false;
                        while (!foundNonSub && findNonSub < finalRanking.Count)
                        {
                            if (!finalRanking[findNonSub].Substitute)
                            {
                                finalRanking.swap(i, findNonSub);
                            }
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
					Tables[0].Seats[i].Player = finalRanking[i];
				}
                for (int j = 4; j < finalRanking.Count; j++)
                {
                    Tables[(j-4)%(Tables.Length-1)].Seats[(j-4)/(Tables.Length - 1)].Player = finalRanking[j];
                }
                
                //sort by finalscores, check top 4, move down list if any are substitutes.
            }
            else
            {
                //insert randomizing method here.
            }
        }
    }
}
