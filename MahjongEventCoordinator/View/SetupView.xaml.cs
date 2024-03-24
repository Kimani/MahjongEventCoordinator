// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MahjongEventCoordinator.View
{
    public partial class SetupView : UserControl
    {
        private static readonly Regex _IntegerRegex = new Regex("[^0-9]+"); //regex that matches disallowed text

        private static bool IsIntegerText(string text)
        {
            return !_IntegerRegex.IsMatch(text);
        }

        public SetupView()
        {
            InitializeComponent();
        }
    }
}
