// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System;
using System.Collections.Generic;

namespace MahjongEventCoordinator.Model
{
    public class PlayerData : BaseModel, IComparable<PlayerData>, IEquatable<PlayerData>
    {
        public Guid             Id                 { get; private set; }
        public string           Name               { get => _Name;               set => AssignToProp(NameChanged, out _Name, _Name, value); }
        public int?             SubstituteForRound { get => _SubstituteForRound; set => SetSubstituteForRound(value); }
        public List<ScoreModel> RoundScores        { get; private set; }
        public List<PlayerData> PastPlayers        { get; private set; }
        public double           TotalScore         { get => GetTotalScore(); }

        public event Action NameChanged;
        public event Action SubstituteForRoundChanged;
        public event Action RoundScoresChanged;
        public event Action PastPlayersChanged;
        public event Action TotalScoreChanged;

        private EventData _Parent;
        private string _Name;
        private int? _SubstituteForRound = null;

        public bool Equals(PlayerData other)   => Id.Equals(other.Id);
        public int CompareTo(PlayerData other) => TotalScore.CompareTo(other.TotalScore);

        public PlayerData(EventData parent, string name)
        {
            _Parent = parent;
            _Name = name;
        }

        public void InitializeEvent()
        {

        }

        public void AssignScore(int score, int round)
        {
            RoundScores[round].RawScore = score;
            RoundScoresChanged?.Invoke();
            TotalScoreChanged?.Invoke();
        }

        private void SetSubstituteForRound(int? value)
        {
            if (_SubstituteForRound != value)
            {
                _SubstituteForRound = value;
                SubstituteForRoundChanged?.Invoke();
            }
        }

        private double GetTotalScore()
        {
            double total = 0;
            foreach (ScoreModel score in RoundScores)
            {
                total += score.Total;
            }
            return total;
        }

        public void registerRepeats(PlayerData p, PlayerData q, PlayerData r)
        {
            PastPlayers.Add(p);
            PastPlayers.Add(q);
            PastPlayers.Add(r);
            PastPlayersChanged?.Invoke();
        }

        public bool newOpponent(PlayerData other)
        {
            string p = other.Id.ToString();
            foreach (PlayerData r in PastPlayers)
            {
                if (r.Equals(p))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
