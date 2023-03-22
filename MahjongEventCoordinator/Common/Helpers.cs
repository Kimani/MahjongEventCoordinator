using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongEventCoordinator.Common
{
    class Helpers
    {
        /*
               public static IGameSettings GenerateInitialGameSettings()
        {
            // Set common settings factored into app functionality.
            IGameSettings settings = GameSettingsFactory.BuildGameSettings();
            settings.SetSetting(GameOption.UmaOption, Uma.Uma_15_5);
            settings.SetSetting(GameOption.OkaOption, Oka.Oka_None);
            settings.SetSetting(GameOption.RedDoraOption, RedDora.RedDora_0);
            settings.SetSetting(GameOption.StartingPoints, 30000);
            settings.SetSetting(GameOption.ChomboPenaltyOption, ChomboPenalty.Penalty8000);
            settings.SetSetting(GameOption.ChomboTypeOption, ChomboType.AfterRanking);
            settings.SetSetting(GameOption.WinnerGetsPool, false);
            settings.SetSetting(GameOption.NagashiBonusOnEastTempaiOnly, false);
            settings.SetSetting(GameOption.NagashiConsumesPool, true);
            settings.SetSetting(GameOption.NagashiUsesBonus, true);
            settings.SetSetting(GameOption.SplitTieUma, true);
            settings.SetSetting(GameOption.IntFinalScores, false);
            settings.SetSetting(GameOption.KiriageMangan, true);
            settings.SetSetting(GameOption.EndgameDealerFinish, false);
            return settings;
        }

        public static IGameState GenerateInitialGameState(IGameSettings settings)
        {
            // Create a game state based on the settings, and advance past pregame.
            IGameState state = GameStateFactory.CreateNewGame(settings);
            GameStateHelpers.InitializeToFirstDiscard(state);
            state.SubmitOverride(OverrideState.DoraCount, 0);
            return state;
        }


              public static IGameResult GetGameResult(IGameState state)
        {
            IGameResult result = null;
            void gameCompleteHandler(IGameResult r) { result = r; }
            state.GameComplete += gameCompleteHandler;
            state.SubmitResultCommand(ResultFactory.BuildFireGameResultCommand());
            state.GameComplete -= gameCompleteHandler;
            CommonHelpers.Check((result != null), "Didn't fire game result!!");
            return result;
        }


          public void SetHandOverride(Player player, OverrideHand hand, object value)
        {
            GameStateHelpers.GetHand(State, player).SubmitOverride(hand, value);
            StateChanged?.Invoke();
        }
         */



    }
}
