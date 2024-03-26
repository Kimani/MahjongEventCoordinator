// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using MahjongEventCoordinator.Model;
using System.Text;

namespace MahjongEventCoordinator.ViewModel
{
    public class RoundViewModel : BindableBase
    {
        public string Header { get => GetHeader(); }

        private RoundData _Parent;

        public RoundViewModel(RoundData parent)
        {
            _Parent = parent;
        }

        private string GetHeader()
        {
            var sb = new StringBuilder();
            sb.Append(_Parent.IsFinalRound ? "Finals " : "Qualifier ");
            sb.Append(_Parent.GroupIndex + 1);
            return sb.ToString();
        }
    }
}
