// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using MahjongCore.Riichi;
using MahjongEventCoordinator.Common;
using MahjongEventCoordinator.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace MahjongEventCoordinator.ViewModel
{
    public class AppViewModel : BindableBase
    {
        public double          UpperDivisionModifier     { get => _Model.ActiveEvent.UpperDivisionModifier;   set => _Model.ActiveEvent.UpperDivisionModifier = value; }
        public double          LowerDivisionModifier     { get => _Model.ActiveEvent.LowerDivisionModifier;   set => _Model.ActiveEvent.LowerDivisionModifier = value; }
        public int             UpperDivisionTableCount   { get => _Model.ActiveEvent.UpperDivisionTableCount; set => _Model.ActiveEvent.UpperDivisionTableCount = value; }
        public int             QualifiersCount           { get => _Model.ActiveEvent.QualifiersCount;         set => _Model.ActiveEvent.QualifiersCount = value; }
        public int             QualifiersTime            { get => _Model.ActiveEvent.QualifiersTime;          set => _Model.ActiveEvent.QualifiersTime = value; }
        public int             FinalsCount               { get => _Model.ActiveEvent.FinalsCount;             set => _Model.ActiveEvent.FinalsCount = value; }
        public int             FinalsTime                { get => _Model.ActiveEvent.FinalsTime;              set => _Model.ActiveEvent.FinalsTime = value; }
        public ChomboPenalty   ChomboPenalty             { get => _Model.ActiveEvent.ChomboPenalty;           set => _Model.ActiveEvent.ChomboPenalty = value; }
        public SeatingStrategy FinalRoundSeatingStrategy { get => SeatingStrategy.HzMethod;                   set { } }
        public ICollectionView TournamentPages           { get;                                               private set; }
        public string          Header                    { get => "Setup"; }

        private AppModel _Model;
        private List<BindableBase> _Pages = new List<BindableBase>();

        public AppViewModel(AppModel model)
        {
            _Model = model;

            // Initialize collection of pages. We will point to ourselves as
            // the 'base' page, which will represent the settings page in the UX.
            _Pages.Add(this);
            TournamentPages = CollectionViewSource.GetDefaultView(_Pages);
        }
    }
}
