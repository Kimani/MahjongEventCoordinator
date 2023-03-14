// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using MahjongEventCoordinator.Controller;
using System.Windows;

namespace MahjongEventCoordinator
{
    public partial class App : Application
    {
        public static App CurrentInstance;

        private void DebateApplicationStartup(object sender, StartupEventArgs args)
        {
            CurrentInstance = this;
            EventAppCoordinator.Initialize();
        }
    }
}
