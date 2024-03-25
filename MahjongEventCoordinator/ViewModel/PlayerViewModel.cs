// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using MahjongEventCoordinator.Model;
using System;

namespace MahjongEventCoordinator.ViewModel
{
    public class PlayerViewModel : BindableBase
    {
        public Guid   Id   { get => _Model.Id; }
        public string Name { get => _Model.Name; set => _Model.Name = value; }

        private readonly PlayerData _Model;

        public PlayerViewModel(PlayerData model)
        {
            _Model = model;
            _Model.NameChanged += () => Notify("Name");
        }
    }
}
