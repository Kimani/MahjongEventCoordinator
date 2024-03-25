// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using MahjongEventCoordinator.Model;
using MahjongEventCoordinator.ViewModel;
using System;

namespace MahjongEventCoordinator.Controller
{
    public static class EventAppCoordinator
    {
        private static readonly bool ENV_DEBUG =
#if DEBUG
            true;
#else
            false;
#endif

        public static readonly string ENV_TEST_AUTOLOAD_EVENT = @"C:\Users\char4\Desktop\Test.xml";
        public static readonly bool   ENV_TEST_USE_AUTOLOAD = false;

        public static AppModel     Model         { get; private set; }
        public static AppViewModel ViewModel     { get; private set; }

        public static event Action PlayerListChanged;

        public static void NotifyPlayersChanged() => PlayerListChanged?.Invoke();

        public static void Initialize()
        {
            Model = new AppModel();
            ViewModel = new AppViewModel(Model);

            // TODO: Create AppModel here, using ViewModel properties.
            // NOTE: Later this will be refactored so that we build the model
            // first, and it will determine defaults. But for now we'll do it
            // this way so that the ViewModel is supplying them. And for now they
            // are hardcoded.
        }
    }
}
