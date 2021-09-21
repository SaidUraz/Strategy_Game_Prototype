using System.IO;
using UnityEngine;

namespace Framework.Data
{
    public static class Load
    {
        #region Functions

        public static GameData LoadGameData(string filePath, string fileName)
        {
            if (File.Exists(filePath + fileName))
                return JsonUtility.FromJson<GameData>(File.ReadAllText(filePath + fileName));
            else
                return new GameData(0, 1, 1, false);
        }

        #endregion Functions
    }
}