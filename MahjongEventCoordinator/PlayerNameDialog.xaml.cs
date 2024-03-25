// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using System.Windows;
using System.Windows.Controls;

namespace MahjongEventCoordinator
{
    public partial class PlayerNameDialog : Window
    {
        public string PlayerName { get; private set; }

        public PlayerNameDialog()                                                    => InitializeComponent();
        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs args) => OkButton.IsEnabled = !string.IsNullOrEmpty(NameTextBox.Text);

        public PlayerNameDialog(string existingName)
        {
            InitializeComponent();
            NameTextBox.Text = existingName;
        }

        public void OnOKClicked(object sender, RoutedEventArgs args)
        {
            PlayerName = NameTextBox.Text;
            DialogResult = true;
            Close();
        }

        public void OnCancelClicked(object sender, RoutedEventArgs args)
        {
            DialogResult = false;
            Close();
        }
    }
}
