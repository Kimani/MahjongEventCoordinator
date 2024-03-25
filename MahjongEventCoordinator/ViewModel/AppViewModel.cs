// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using MahjongCore.Riichi;
using MahjongEventCoordinator.Common;
using MahjongEventCoordinator.Controller;
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
        public bool            Started                   { get => _Model.ActiveEvent.Started;                 set => _Model.ActiveEvent.Started = value; }
        public int             UpperDivisionTableCount   { get => _Model.ActiveEvent.UpperDivisionTableCount; set => _Model.ActiveEvent.UpperDivisionTableCount = value; }
        public int             QualifiersCount           { get => _Model.ActiveEvent.QualifiersCount;         set => _Model.ActiveEvent.QualifiersCount = value; }
        public int             QualifiersTime            { get => _Model.ActiveEvent.QualifiersTime;          set => _Model.ActiveEvent.QualifiersTime = value; }
        public int             FinalsCount               { get => _Model.ActiveEvent.FinalsCount;             set => _Model.ActiveEvent.FinalsCount = value; }
        public int             FinalsTime                { get => _Model.ActiveEvent.FinalsTime;              set => _Model.ActiveEvent.FinalsTime = value; }
        public ChomboPenalty   ChomboPenalty             { get => _Model.ActiveEvent.ChomboPenalty;           set => _Model.ActiveEvent.ChomboPenalty = value; }
        public SeatingStrategy SeatingStrategy           { get => SeatingStrategy.HzMethod;                   set => _Model.ActiveEvent.SeatingStrategy = value; }
        public ICollectionView TournamentPages           { get;                                               private set; }
        public ICollectionView Players                   { get;                                               private set; }
        public string          Header                    { get => "Setup"; }

        private readonly AppModel _Model;
        private readonly List<BindableBase> _Pages = new List<BindableBase>();
        private readonly List<PlayerViewModel> _Players = new List<PlayerViewModel>();

        public void AddPlayer(string name) => _Model.ActiveEvent.AddPlayer(name);

        public AppViewModel(AppModel model)
        {
            _Model = model;
            _Model.ActiveEvent.UpperDivisionModifierChanged   += () => Notify("UpperDivisionModifier");
            _Model.ActiveEvent.LowerDivisionModifierChanged   += () => Notify("LowerDivisionModifier");
            _Model.ActiveEvent.ChomboPenaltyChanged           += () => Notify("ChomboPenalty");
            _Model.ActiveEvent.UpperDivisionTableCountChanged += () => Notify("UpperDivisionTableCount");
            _Model.ActiveEvent.QualifiersCountChanged         += () => Notify("QualifiersCount");
            _Model.ActiveEvent.QualifiersTimeChanged          += () => Notify("QualifiersTime");
            _Model.ActiveEvent.FinalsCountChanged             += () => Notify("FinalsCount");
            _Model.ActiveEvent.FinalsTimeChanged              += () => Notify("FinalsTime");
            _Model.ActiveEvent.SeatingStrategyChanged         += () => Notify("SeatingStrategy");
            _Model.ActiveEvent.StartedChanged                 += () => Notify("UpperDivisionModifier");
            _Model.ActiveEvent.PlayersChanged                 += OnPlayersChanged;

            //_Model.ActiveEvent.RoundsChanged                  += () => Notify("UpperDivisionModifier");

            // Initialize collection of pages. We will point to ourselves as
            // the 'base' page, which will represent the settings page in the UX.
            _Pages.Add(this);
            TournamentPages = CollectionViewSource.GetDefaultView(_Pages);
            Players = CollectionViewSource.GetDefaultView(_Players);
        }

        private void OnPlayersChanged()
        {
            // Add missing players to the view model.
            foreach (PlayerData playerModel in _Model.ActiveEvent.Players)
            {
                bool found = false;
                foreach (PlayerViewModel playerViewModel in _Players)
                {
                    if (playerModel.Id.Equals(playerViewModel.Id))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    _Players.Add(new PlayerViewModel(playerModel));
                }
            }

            // Remove deleted players from the view model.
            for (int i = _Players.Count - 1; i >= 0; --i)
            {
                PlayerViewModel playerViewModel = _Players[i];
                bool found = false;
                foreach (PlayerData playerModel in _Model.ActiveEvent.Players)
                {
                    if (playerModel.Id.Equals(playerViewModel.Id))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    _Players.RemoveAt(i);
                }
            }

            Notify("Players");
            Players.Refresh();
            EventAppCoordinator.NotifyPlayersChanged();
        }

        //
        //() => OnPlayersChanged; Notify("Players");
    }
}
