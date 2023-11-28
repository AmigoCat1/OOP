using System;
using System.Collections.Generic;
using Lab2.MyAccounts;
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
            var a = new PremiumAccount("Andre");
            var b = new PremiumMiddleAccount("Julia");
            var c = new Account("Alex");

            var fabric = new FabricGame();
            var listGames = new List<Game> { fabric.GetClassic(), fabric.GetTraining(), fabric.GetGameForOne() };


            for (var i = 0; i < 5; i++)
            {
                listGames[0].PlayingGame(a, b, rnd.Next(2, 8));
                listGames[0].PlayingGame(c, b, rnd.Next(2, 8));
            }

            listGames[0].Information();

            for (var i = 0; i < 5; i++)
            {
                listGames[1].PlayingGame(c, a, 0);
                listGames[1].PlayingGame(b, a, 0);
            }

            listGames[1].Information();

            for (var i = 0; i < 5; i++)
            {
                listGames[2].PlayingGame(a, c, rnd.Next(2, 8));
                listGames[2].PlayingGame(b, c, rnd.Next(2, 8));
            }
            listGames[2].Information();

            a.InformationForPlayer();
            a.GetStats();
            b.InformationForPlayer();
            b.GetStats();
            c.InformationForPlayer();
            c.GetStats();


        }


    }
}