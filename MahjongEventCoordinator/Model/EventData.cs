// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using MahjongCore.Riichi;
using MahjongEventCoordinator.Common;
using System;
using System.Collections.Generic;

namespace MahjongEventCoordinator.Model
{
    public class EventData : BaseModel
    {
        public static EventData Load(string path)
        {
            return null;
        }

        public double                    UpperDivisionModifier   { get => _UpperDivisionModifier;   set => AssignToProp(UpperDivisionModifierChanged,   out _UpperDivisionModifier,   _UpperDivisionModifier,   value); }
        public double                    LowerDivisionModifier   { get => _LowerDivisionModifier;   set => AssignToProp(LowerDivisionModifierChanged,   out _LowerDivisionModifier,   _LowerDivisionModifier,   value); }
        public int                       UpperDivisionTableCount { get => _UpperDivisionTableCount; set => AssignToProp(UpperDivisionTableCountChanged, out _UpperDivisionTableCount, _UpperDivisionTableCount, value); }
        public int                       QualifiersCount         { get => _QualifiersCount;         set => AssignToProp(QualifiersCountChanged,         out _QualifiersCount,         _QualifiersCount,         value); }
        public int                       QualifiersTime          { get => _QualifiersTime;          set => AssignToProp(QualifiersTimeChanged,          out _QualifiersTime,          _QualifiersTime,          value); }
        public int                       FinalsCount             { get => _FinalsCount;             set => AssignToProp(FinalsCountChanged,             out _FinalsCount,             _FinalsCount,          value); }
        public int                       FinalsTime              { get => _FinalsTime;              set => AssignToProp(FinalsTimeChanged,              out _FinalsTime,              _FinalsTime,          value); }
        public bool                      Started                 { get => _Started;                 set => AssignToProp(StartedChanged,                 out _Started,                 _Started,                 value); }
        public ChomboPenalty             ChomboPenalty           { get => _ChomboPenalty;           set => AssignToProp(ChomboPenaltyChanged,           out _ChomboPenalty,           _ChomboPenalty,           value); }
        public SeatingStrategy           SeatingStrategy         { get => _SeatingStrategy;         set => AssignToProp(SeatingStrategyChanged,         out _SeatingStrategy,         _SeatingStrategy,         value); }
        public IReadOnlyList<PlayerData> Players                 { get => _Players.AsReadOnly(); }
        public IReadOnlyList<RoundData>  Rounds                  { get => _Rounds.AsReadOnly(); }
        public int                       CurrentRoundIndex       { get => _CurrentRoundIndex;       set => AssignToProp(CurrentRoundIndexChanged, out _CurrentRoundIndex, _CurrentRoundIndex, value); }

        public event Action UpperDivisionModifierChanged;
        public event Action LowerDivisionModifierChanged;
        public event Action ChomboPenaltyChanged;
        public event Action UpperDivisionTableCountChanged;
        public event Action QualifiersCountChanged;
        public event Action QualifiersTimeChanged;
        public event Action FinalsCountChanged;
        public event Action FinalsTimeChanged;
        public event Action SeatingStrategyChanged;
        public event Action PlayersChanged;
        public event Action RoundsChanged;
        public event Action StartedChanged;
        public event Action CurrentRoundIndexChanged;

        private bool _Started = false;
        private double _UpperDivisionModifier = 4;
        private double _LowerDivisionModifier = 2;
        private ChomboPenalty _ChomboPenalty = MahjongCore.Riichi.ChomboPenalty.Penalty20000;
        private int _UpperDivisionTableCount = 1;
        private int _QualifiersCount = 4;
        private int _QualifiersTime = 45;
        private int _FinalsCount = 1;
        private int _FinalsTime = 60;
        private int _CurrentRoundIndex = 0;
        private SeatingStrategy _SeatingStrategy = SeatingStrategy.HzMethod;
        private readonly List<PlayerData> _Players = new List<PlayerData>();
        private readonly List<RoundData> _Rounds = new List<RoundData>();

        public EventData() { }

        public void BeginTournament()
        {
            if (!Started)
            {
                Started = true;

                int totalRoundCount = _QualifiersCount + _FinalsCount;
                for (int i = 0; i < totalRoundCount; ++i)
                {
                    _Rounds.Add(new RoundData(this, i));
                }
                RoundsChanged?.Invoke();

                _Rounds[0].BeginRound();
            }
        }

        public void AddPlayer(string name)
        {
            _Players.Add(new PlayerData(this, name));
            PlayersChanged?.Invoke();
        }

        public void DeletePlayer(Guid id)
        {
            for (int i = _Players.Count - 1; i >= 0; --i)
            {
                if (_Players[i].Id.Equals(id))
                {
                    _Players.RemoveAt(i);
                    PlayersChanged?.Invoke();
                    break;
                }
            }
        }
    }
}
