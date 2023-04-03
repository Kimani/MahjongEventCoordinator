// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using MahjongEventCoordinator.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace MahjongEventCoordinator.ViewModel
{
    public class AppViewModel : BindableBase
    {
        public int             RoundCount                { get => 4;                        set { } }
        public int             UpperDivisionModifier     { get => 4;                        set { } }
        public int             LowerDivisionModifier     { get => 2;                        set { } }
        public int             ChomboPenalty             { get => 20;                       set { } }
        public int             UpperDivisionTableCount   { get => 1;                        set { } }
        public SeatingStrategy FinalRoundSeatingStrategy { get => SeatingStrategy.HzMethod; set { } }
        public ICollectionView TournamentPages           { get;                             private set; }

        private List<BindableBase> _Pages = new List<BindableBase>();

        public AppViewModel()
        {
            // Initialize collection of pages. For now we will point to ourselves
            // as the 'base' page, which will represent the settings page in the UX.
            _Pages.Add(this);
            TournamentPages = CollectionViewSource.GetDefaultView(_Pages);
        }
    }
}
