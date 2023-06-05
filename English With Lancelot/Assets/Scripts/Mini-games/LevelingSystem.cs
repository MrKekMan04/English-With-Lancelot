using System.Collections.Generic;
using UnityEngine;

namespace Mini_games
{
    public static class LevelingSystem
    {
        public static void AddExp(int exp)
        {
            var currentExp = PlayerPrefs.GetInt(GameConstants.PlayerExpKey, 0);

            PlayerPrefs.SetInt(GameConstants.PlayerExpKey, currentExp + exp);
            
            CheckForLevelDestination();
        }

        public static Dictionary<string, int> GetPlayerStats()
        {
            var currentLevel = PlayerPrefs.GetInt(GameConstants.PlayerLevelKey, 0);
            var currentExp = PlayerPrefs.GetInt(GameConstants.PlayerExpKey, 0);

            return new Dictionary<string, int>
            {
                [GameConstants.PlayerLevelKey] = currentLevel,
                [GameConstants.PlayerExpKey] = currentExp
            };
        }

        private static void CheckForLevelDestination()
        {
            var playerStats = GetPlayerStats();

            while (playerStats[GameConstants.PlayerExpKey] >=
                   (playerStats[GameConstants.PlayerLevelKey] + 1) * GameConstants.LevelExpIncrease)
            {
                playerStats[GameConstants.PlayerExpKey] -=
                    (playerStats[GameConstants.PlayerLevelKey] + 1) * GameConstants.LevelExpIncrease;
                playerStats[GameConstants.PlayerLevelKey]++;
            }
            
            SavePlayerStatsFromDict(playerStats);
        }

        private static void SavePlayerStatsFromDict(Dictionary<string, int> stats)
        {
            PlayerPrefs.SetInt(GameConstants.PlayerExpKey, stats[GameConstants.PlayerExpKey]);
            PlayerPrefs.SetInt(GameConstants.PlayerLevelKey, stats[GameConstants.PlayerLevelKey]);
        }
    }
}