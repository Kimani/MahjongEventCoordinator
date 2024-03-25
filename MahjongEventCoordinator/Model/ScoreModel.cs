// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

namespace MahjongEventCoordinator.Model
{
    public class ScoreModel : BaseModel
    {
        public int    RawScore { get; set; }
        public double Total    { get => GetTotal(); }

        private readonly TableData _Parent;

        public ScoreModel(TableData parent) => _Parent = parent;
        private double GetTotal()           => 0.0;
    }
}
