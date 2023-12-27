namespace Lab2.Menu
{
    public interface ICommandController
    {
        void ShowPLayers();
        void AddPLayer(string account, string accountType);
        void ShowStatsForPlayer(string userName);
        void PlayGame(string gameType, string player1, string player2);
        void PlayGame(string gameType, string player1);
    }
}