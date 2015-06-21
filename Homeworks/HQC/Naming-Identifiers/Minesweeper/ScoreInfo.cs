namespace Minesweeper
{
    using System;

    public class ScoreInfo
    {
        private string playerName;
        private int playerPoints;

        public ScoreInfo() { }

        public ScoreInfo(string player, int points)
        {
            this.PlayerName = player;
            this.PlayerPoints = points;
        }

        public string PlayerName
        {
            get { return this.playerName; }
            set { this.playerName = value; }
        }

        public int PlayerPoints
        {
            get { return this.playerPoints; }
            set { this.playerPoints = value; }
        }
    }
}
