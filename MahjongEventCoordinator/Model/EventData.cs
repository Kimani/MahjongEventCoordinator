// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongEventCoordinator.Model
{
    public class EventData
    {
        public int                       RoundCount              { get; set; }
        public double                    UpperDivisionModifier   { get; set; }
        public double                    LowerDivisionModifier   { get; set; }
        public int                       ChomboPenalty           { get; set; }
        public int                       UpperDivisionTableCount { get; set; }
        public IReadOnlyList<PlayerData> Players                 { get; set; }
        public IReadOnlyList<RoundData>  Rounds                  { get; set; }
    }
}
