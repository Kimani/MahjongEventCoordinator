// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongEventCoordinator.Model
{
    public class PlayerData
    {
        public Guid   Id         { get; set; }
        public string Name       { get; set; }
        public string Substitute { get; set; }
    }
}
