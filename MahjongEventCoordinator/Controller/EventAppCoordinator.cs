// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using MahjongEventCoordinator.Model;
using MahjongEventCoordinator.ViewModel;

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
        public static readonly string ENV_TEST_AUTOLOAD_DEBATE = @"C:\Users\char4\Desktop\Test.xml";
        public static readonly bool   ENV_TEST_USE_AUTOLOAD = false;

        public static AppModel     Model         { get; private set; }
        public static AppViewModel ViewModel     { get; private set; }
    }
}
