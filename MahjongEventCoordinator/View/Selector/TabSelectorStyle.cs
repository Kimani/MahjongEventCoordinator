// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System.Windows;
using System.Windows.Controls;

namespace MahjongEventCoordinator.View.Selector
{
    public class TabSelectorStyle : DataTemplateSelector
    {
        public DataTemplate SetupTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return (item != null) ? SetupTemplate : null;
        }

    }
}
