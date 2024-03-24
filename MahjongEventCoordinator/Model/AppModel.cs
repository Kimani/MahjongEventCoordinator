// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using MahjongEventCoordinator.Common;
using System;
using System.Collections.Generic;

namespace MahjongEventCoordinator.Model
{
    public class AppModel
    {
        public EventData ActiveEvent { get; set; }

        public AppModel()
        {
            ActiveEvent = new EventData();
        }
    }
}
