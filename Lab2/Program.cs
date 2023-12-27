using System;
using System.Collections.Generic;
using Lab2.Data;
using Lab2.Data.Repository;
using Lab2.Data.Service;
using Lab2.MyGames;


namespace Lab2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t   .___________________________________________________________. \n" +
                              "\t\t\t\t\t\t   |    _______      ________     .________.         ___       | \n" +
                              "\t\t\t\t\t\t   |   |  __   \\    /  ____  \\    |__    __|        /   \\      |  \n" +
                              "\t\t\t\t\t\t   |   |  |  | |    |  |  |  |       |  |          /  ^  \\     |  \n" +
                              "\t\t\t\t\t\t   |   |  |  | |    |  |  |  |       |  |         /  /_\\  \\    |  \n" +
                              "\t\t\t\t\t\t   |   |  |__| |    |  |__|  |       |  |        /  _____  \\   |      \n" +
                              "\t\t\t\t\t\t   |   |_______/    \\________/       |__|       /__/     \\__\\  |           \n" +
                              "\t\t\t\t\t\t   |___________________________________________________________|             \n");

            Console.ResetColor();
            var rnd = new Random();
            
            var dbContext = new DbContext();
            IPlayerRepository playerRepository = new PlayerRepository(dbContext);
            IPlayerService playerService = new PlayerService(playerRepository);
            IGameRepository gameRepository = new GameRepository(dbContext);
            IGameService gameService = new GameService(gameRepository);
            
            playerService.CreateAccount("Andre");
            playerService.CreateAccount("Julia");
            playerService.CreateAccount("Alex");
            
            var a = playerService.ReadAccountBytId("Andre");
            var b = playerService.ReadAccountBytId("Julia");
            var c = playerService.ReadAccountBytId("Alex");
            
            gameService.CreateGame("Classic");
            gameService.CreateGame("Training");
            gameService.CreateGame("ForOne");

            var listGames = gameService.ReadGames();

            for (var i = 0; i < 5; i++)
            {
                listGames[0].PlayingGame(a, b, rnd.Next(2, 8));
                listGames[0].PlayingGame(c, b, rnd.Next(2, 8));
            }


            for (var i = 0; i < 5; i++)
            {
                listGames[1].PlayingGame(c, a, 0);
                listGames[1].PlayingGame(b, a, 0);
            }

            for (var i = 0; i < 5; i++)
            {
                listGames[2].PlayingGame(a, c, rnd.Next(2, 8));
                listGames[2].PlayingGame(b, c, rnd.Next(2, 8));
            }
            
            foreach (var readGame in gameService.ReadGames())
            {
                readGame.Information();
            }

            foreach (var readAccount in playerService.ReadAccounts())
            {
                readAccount.InformationForPlayer();
                readAccount.GetStats();
            }
        }
    }
}