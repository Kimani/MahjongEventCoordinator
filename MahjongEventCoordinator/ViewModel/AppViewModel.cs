// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using MahjongEventCoordinator.Common;

namespace MahjongEventCoordinator.ViewModel
{
    public class AppViewModel
    {
        public int             RoundCount                { get => 4;                        set { } }
        public int             UpperDivisionModifier     { get => 4;                        set { } }
        public int             LowerDivisionModifier     { get => 2;                        set { } }
        public int             ChomboPenalty             { get => 20;                       set { } }
        public int             UpperDivisionTableCount   { get => 1;                        set { } }
        public SeatingStrategy FinalRoundSeatingStrategy { get => SeatingStrategy.HzMethod; set { } }

    }
}
