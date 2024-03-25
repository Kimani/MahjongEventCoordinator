// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

namespace MahjongEventCoordinator.Model
{
	public class TablePlayerData
	{
		public PlayerData Player      { get; set; }
		public string	  FirstSeat	  { get; set; }
		public int		  RawScore	  { get; set; }
		public int		  ChomboCount { get; set; }
	}
}
