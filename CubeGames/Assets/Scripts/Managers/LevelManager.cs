using UnityEngine;
using Framework.Data;
using UnityEngine.SceneManagement;

namespace Framework.Managers
{
	public class LevelManager : MonoBehaviour
    {
        #region Events



        #endregion Events

        #region Variables

        private string _filePath;
        private const string GAME_DATA_FILE = "/GameData.json";

        private int _currentLevel;
        private int _levelText;
        private int _lastLevelPlayed;
        private int _lastSceneBuildIndex;

        private bool _didLastLevelReached;

        #endregion Variables

        #region Properties

		public string FilePath { get => _filePath; set => _filePath = value; }
        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
        public int LevelText { get => _levelText; set => _levelText = value; }
        public int LastLevelPlayed { get => _lastLevelPlayed; set => _lastLevelPlayed = value; }
        public int LastSceneBuildIndex { get => _lastSceneBuildIndex; set => _lastSceneBuildIndex = value; }
        public bool DidLastLevelReached { get => _didLastLevelReached; set => _didLastLevelReached = value; }

		#endregion Properties

		#region Start

		void Start()
        {
            Initialize();
        }

        #endregion Start

        #region Functions
        
        private void Initialize()
        {
            FilePath = Application.persistentDataPath;
            LastSceneBuildIndex = SceneManager.sceneCountInBuildSettings - 1;

            LoadGame();
            SkipMainScene();
        }

        public void SaveGame()
		{
            OnBeforeSaving();
            //Save.SaveGame(CoinManager.Instance.CoinAmount, LevelText, LastLevelPlayed, DidLastLevelReached, FilePath, GAME_DATA_FILE);
		}

        private void LoadGame()
		{
            GameData gameData = Load.LoadGameData(FilePath, GAME_DATA_FILE);

			if (gameData != null)
			{
                //if (CoinManager.Instance)
                //    CoinManager.Instance.CoinAmount = gameData.coin;

                LevelText = gameData.levelText;
                LastLevelPlayed = gameData.lastLevelPlayed;
                CurrentLevel = LastLevelPlayed;
                DidLastLevelReached = gameData.didLastLevelReached;
            }
        }

        private void CheckIfLastLevelHasBeenReached()
		{
            if (!DidLastLevelReached && LastSceneBuildIndex + 1 == SceneManager.GetActiveScene().buildIndex + 1)
                DidLastLevelReached = true;
        }

        private void OnBeforeSaving()
		{
            CheckIfLastLevelHasBeenReached();

            if (DidLastLevelReached)
            {
                int randomLevel = UnityEngine.Random.Range(2, LastSceneBuildIndex + 1);
                CurrentLevel = randomLevel;
            }
            else
            {
                CurrentLevel++;
            }

            LastLevelPlayed = CurrentLevel;
            LevelText++;
        }

        public void LoadNextScene()
        {
            //CoinManagerInstance.ResetCurrentCoin();
            SceneManager.LoadScene(CurrentLevel);
        }

        public void LoadCurrentScene()
		{
            //CoinManagerInstance.DeleteCurrentCoin();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void SkipMainScene()
		{
            SceneManager.LoadScene(LastLevelPlayed);
		}

        #endregion Functions
    }
}