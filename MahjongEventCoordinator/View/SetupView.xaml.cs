// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using MahjongEventCoordinator.Controller;
using MahjongEventCoordinator.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MahjongEventCoordinator.View
{
    public partial class SetupView : UserControl
    {
        private readonly AppViewModel _ViewModel;

        public SetupView()
        {
            _ViewModel = EventAppCoordinator.ViewModel;
            DataContext = _ViewModel;
            InitializeComponent();

            // EventAppCoordinator.PlayerListChanged += OnPlayerListChanged;
        }

        private void OnAddPlayerClicked(object sender, RoutedEventArgs args)
        {
            var appPlayerDialog = new PlayerNameDialog();
            if (appPlayerDialog.ShowDialog().GetValueOrDefault(false))
            {
                _ViewModel.AddPlayer(appPlayerDialog.PlayerName);
            }
        }

        private void OnEditPlayerClicked(object sender, RoutedEventArgs args)
        {
            if ((sender is Button editPlayerButton) && (editPlayerButton.DataContext is PlayerViewModel playerViewModel))
            {
                var appPlayerDialog = new PlayerNameDialog(playerViewModel.Name);
                if (appPlayerDialog.ShowDialog().GetValueOrDefault(false))
                {
                    playerViewModel.Name = appPlayerDialog.PlayerName;
                }
            }
        }

        private void OnDeletePlayerClicked(object sender, RoutedEventArgs args)
        {
            if ((sender is Button deletePlayerButton) && (deletePlayerButton.DataContext is PlayerViewModel playerViewModel))
            {
                if (MessageBox.Show(Application.Current.MainWindow, "Really delete player?", "Delete player", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _ViewModel.DeletePlayer(playerViewModel.Id);
                }
            }
        }
    }
}
