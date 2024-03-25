// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2024

using MahjongCore.Riichi.Helpers;
using MahjongCore.Riichi;
using MahjongEventCoordinator.Common;

namespace MahjongEventCoordinator.Model
{
	public class TableData
	{
		public TablePlayerData[] Seats { get; set; }
		public double[] PlayerScores(int[] rawScores, int[] chombos)
		{
			IGameState state = GameStateFactory.CreateNewGame(Helpers.GenerateInitialGameSettings());
			GameStateHelpers.InitializeToFirstDiscard(state);
			state.Player1Hand.SubmitOverride(OverrideHand.Score, rawScores[0]);
			state.Player1Hand.SubmitOverride(OverrideHand.Chombo, chombos[0]);
			state.Player2Hand.SubmitOverride(OverrideHand.Score, rawScores[1]);
			state.Player2Hand.SubmitOverride(OverrideHand.Chombo, chombos[1]);
			state.Player3Hand.SubmitOverride(OverrideHand.Score, rawScores[2]);
			state.Player3Hand.SubmitOverride(OverrideHand.Chombo, chombos[2]);
			state.Player4Hand.SubmitOverride(OverrideHand.Score, rawScores[3]);
			state.Player4Hand.SubmitOverride(OverrideHand.Chombo, chombos[3]);
			IGameResult finalScore = Helpers.GetGameResult(state);
			double[] fPlayerScores = new double[4];
			fPlayerScores[0] = finalScore.FinalScorePlayer1;
			fPlayerScores[1] = finalScore.FinalScorePlayer2;
			fPlayerScores[2] = finalScore.FinalScorePlayer3;
			fPlayerScores[3] = finalScore.FinalScorePlayer4;
			return fPlayerScores;
		}
		public void Calculate(int round)
		{
			int[] scores = new int[4];
			int[] chombo = new int[4];
			for (int i = 0; i < scores.Length; i++)
			{
				scores[i] = Seats[i].RawScore;
				chombo[i] = Seats[i].ChomboCount;
			}
			double[] fScores = PlayerScores(scores, chombo);

			for (int i = 0; i < fScores.Length; i++)
			{
				Seats[i].Player.AssignScore((int)fScores[i], round);
			}
		}
	}
}
