namespace Framework.Data
{
    public class GameData
    {
        #region Variables

        public float coin;
        public int levelText;
        public int lastLevelPlayed;

        public bool didLastLevelReached;

        #endregion

        #region Functions
        public GameData(float coin, int levelText, int lastLevelPlayed, bool didLastLevelReached)
        {
            this.coin = coin;
            this.levelText = levelText;
            this.lastLevelPlayed = lastLevelPlayed;

            this.didLastLevelReached = didLastLevelReached;
        }

        public override string ToString()
        {
            return
                "{" +
                "\"" + "coin" + "\"" + ":" + coin + "," +
                "\"" + "levelText" + "\"" + ":" + levelText + "," +
                "\"" + "lastLevelPlayed" + "\"" + ":" + lastLevelPlayed + "," +
                "\"" + "didLastLevelReached" + "\"" + ":" + didLastLevelReached +
                "}";
        }

        #endregion
    }
}