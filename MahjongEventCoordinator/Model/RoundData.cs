// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool IsFinalRound { get; set; }
        public int  RoundIndex { get; private set; }
        public int  GroupIndex { get; private set; }

        private EventData _Parent;

        public RoundData(EventData parent, int index)
        {
            _Parent = parent;
            RoundIndex = index;

            GroupIndex = index;
            if (GroupIndex >= parent.QualifiersCount)
            {
                GroupIndex -= parent.QualifiersCount;
                IsFinalRound = true;
            }
        }

        public void BeginRound()
        {

        }

        public void loadPlayers(IReadOnlyList<PlayerData> Players)
        {
            Tables = new TableData[Players.Count/4];
            if (IsFinalRound)
            {
                List<PlayerData> finalRanking = new List<PlayerData>(Players);
                finalRanking.Sort();
                for (int i = 0; i < 4; i++)
                {
                    if (finalRanking[i].SubstituteForRound.HasValue)
                    {
                        int findNonSub = 4;
                        bool foundNonSub = false;
                        while (!foundNonSub && findNonSub < finalRanking.Count)
                        {
                            if (!finalRanking[findNonSub].SubstituteForRound.HasValue)
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
                Random rng = new Random();
                List<PlayerData> tableUp = new List<PlayerData>(Players);
                for (int i = 0; i < Tables.Length; i++)
                {
                    PlayerData p1 = tableUp.ElementAtOrDefault(rng.Next(tableUp.Count - 1));
                    tableUp.Remove(p1);
					PlayerData p2 = tableUp.ElementAtOrDefault(rng.Next(tableUp.Count - 1));
					tableUp.Remove(p2);
					PlayerData p3 = tableUp.ElementAtOrDefault(rng.Next(tableUp.Count - 1));
					tableUp.Remove(p3);
					PlayerData p4 = tableUp.ElementAtOrDefault(rng.Next(tableUp.Count - 1));
					tableUp.Remove(p4);

                    bool validTable = false;
                    while (!validTable)
                    {
                        bool[] checkvalidity = checkTableValidity(p1, p2, p3, p4);
                        PlayerData swap;
                        validTable = true;
                        if (checkvalidity[1] == false)
                        {
                            validTable = false;
                            swap = tableUp.ElementAtOrDefault(rng.Next(tableUp.Count - 1));
                            tableUp.Add(p2);
                            p2 = swap;
                            tableUp.Remove(p2);
                        }
                        if (checkvalidity[2] == false)
                        {
                            validTable = false;
                            swap = tableUp.ElementAtOrDefault(rng.Next(tableUp.Count - 1));
                            tableUp.Add(p3);
                            p3 = swap;
                            tableUp.Remove(p3);
                        }
                        if (checkvalidity[3] == false)
                        {
                            validTable = false;
                            swap = tableUp.ElementAtOrDefault(rng.Next(tableUp.Count - 1));
                            tableUp.Add(p4);
                            p4 = swap;
                            tableUp.Remove(p4);
                        }
                    }
					Tables[i].Seats[0].Player = p1;
                    Tables[i].Seats[1].Player = p2;
					Tables[i].Seats[2].Player = p3;
					Tables[i].Seats[3].Player = p4;
				}
            }
        }
        public bool[] checkTableValidity(PlayerData p1, PlayerData p2, PlayerData p3, PlayerData p4)
        {
            bool[] triplecheck = new bool[4];
            triplecheck[0] = true;
            triplecheck[1] = p1.newOpponent(p2);
            triplecheck[2] = p1.newOpponent(p3) && (!triplecheck[1] || p2.newOpponent(p3));
			triplecheck[3] = p1.newOpponent(p4) && (!triplecheck[1] || p2.newOpponent(p4)) && (!triplecheck[2] || p3.newOpponent(p4));

            return triplecheck;
		}
    }
}
