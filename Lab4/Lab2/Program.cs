using System;
using System.Collections.Generic;
using Lab2.Data;
using Lab2.Data.Repository;
using Lab2.Data.Service;
using Lab2.Menu;
using Lab2.MyGames;


namespace Lab2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            GameMenu gameMenu = new GameMenu(new CommandController());
            gameMenu.Show();
        }
    }
}