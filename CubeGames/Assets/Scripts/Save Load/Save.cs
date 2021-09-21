using System.IO;
using UnityEngine;

namespace Framework.Data
{
    public static class Save
    {
        #region Events



        #endregion Events

        #region Variables



        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public static void SaveGame(float coin, int levelText, int lastLevelPlayed, bool didLastLevelReached, string filePath, string fileName)
        {
            GameData gameData = new GameData(coin, levelText, lastLevelPlayed, didLastLevelReached);

            if (gameData != null)
            {
                string jsonData = JsonUtility.ToJson(gameData, false);
                File.WriteAllText(filePath + fileName, jsonData);
            }
            else
                Debug.Log("GameData is null. Could not be saved game data!");
        }

        #endregion Functions
    }
}