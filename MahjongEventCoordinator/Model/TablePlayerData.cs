using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongEventCoordinator.Model
{
	public class TablePlayerData
	{
		public PlayerData Player { get; set; }
		public string FirstSeat { get; set; }
		public int RawScore { get; set; }
		public int ChomboCount { get; set; }
	}
}
