// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using MahjongEventCoordinator.Controller;
using System.Windows;

namespace MahjongEventCoordinator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = EventAppCoordinator.ViewModel;
        }

        private void ExitClicked(object sender, RoutedEventArgs args)   => System.Environment.Exit(0);
        private void NewClicked(object sender, RoutedEventArgs args)    {}
        private void OpenClicked(object sender, RoutedEventArgs args)   {}
        private void SaveClicked(object sender, RoutedEventArgs args)   {}
        private void SaveAsClicked(object sender, RoutedEventArgs args) {}
    }
}
