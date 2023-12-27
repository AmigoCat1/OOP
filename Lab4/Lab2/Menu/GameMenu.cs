using System;

namespace Lab2.Menu
{
    public class GameMenu
    {
        private readonly ICommandController _commandController;
        private bool _isWork = true;
        public GameMenu(ICommandController commandController)
        {
            _commandController = commandController;
        }

        public void Show()
        {
            ShowTitle();
            while (_isWork)
            {
                ShowStartAction();
                ReadAction();
            }
        }

        private void ShowStartAction()
        {
            Console.WriteLine("1) Додати гравця");
            Console.WriteLine("2) Показати гравців");
            Console.WriteLine("3) Знайти гравця");
            Console.WriteLine("4) Зіграти у гру");
            Console.WriteLine("5) Вихід");
        }

        private void ReadAction()
        {
            switch (GetUserAction(1, 5))
            {
                case 1:
                    Console.Clear();
                    AddPlayer();
                    break;
                case 2:
                    Console.Clear();
                    ShowPlayers();
                    break;
                case 3:
                    Console.Clear();
                    FindPlayer();
                    break;
                case 4:
                    Console.Clear();
                    PlayGame();
                    break;
                case 5:
                    Console.Clear();
                    _isWork = false;
                    break;
            }
        }

        private void PlayGame()
        {
            Console.WriteLine("1) Класичний");
            Console.WriteLine("2) Тренувальний");
            Console.WriteLine("3) Для одного");
            Console.WriteLine("Оберіть тип гри: ");
            var answerUser = GetUserAction(1, 3);
            switch (answerUser)
            {
                case 1:
                    Console.Write("Введіть ім'я гравця 1: ");
                    var userName = Console.ReadLine();
                    Console.Write("Введіть ім'я гравця 2: ");
                    var userName2 = Console.ReadLine();
                    _commandController.PlayGame("ClassicGame", userName, userName2);
                    break;
                case 2:
                    Console.Write("Введіть ім'я гравця 1: ");
                    var userNameTraining1 = Console.ReadLine();
                    Console.Write("Введіть ім'я гравця 2: ");
                    var userNameTraining2 = Console.ReadLine();
                    _commandController.PlayGame("TrainingGame",userNameTraining1, userNameTraining2);
                    break;
                case 3:
                    Console.Write("Введіть ім'я гравця: ");
                    var userNameFoeOne = Console.ReadLine();
                    _commandController.PlayGame("GameForOne",userNameFoeOne);
                    break;
            }
            
        }

        private void FindPlayer()
        {
            Console.Write("Введіть ім'я: ");
            var userName = Console.ReadLine();
            _commandController.ShowStatsForPlayer(userName);
        }

        private void ShowPlayers()
        {
            _commandController.ShowPLayers();
        }

        private void AddPlayer()
        {
            Console.Write("Введіть ім'я: ");
            var userName = Console.ReadLine();
            Console.WriteLine("1) Звичайний");
            Console.WriteLine("2) Середній");
            Console.WriteLine("3) Преміум");
            Console.WriteLine("Оберіть тип аккаунту: ");
            var answerUser = GetUserAction(1, 3);
            switch (answerUser)
            {
                case 1:
                    _commandController.AddPLayer(userName, "Simple");
                    break;
                case 2:
                    _commandController.AddPLayer(userName, "PremiumMiddle");
                    break;
                case 3:
                    _commandController.AddPLayer(userName, "Premium");
                    break;
            }

            Console.WriteLine("Гравець додан!");
        }

        private int GetUserAction(int minValue, int maxValue)
        {
            while (true)
            {
                Console.WriteLine("Оберіть дію: ");
                try
                {
                    int result = Convert.ToInt32(Console.ReadLine());
                    if (CheckAction(result, minValue, maxValue))
                        return result;
                    
                    Console.WriteLine("Введіть число від 1 до 4");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введіть цифру!");
                }
            }
        }

        private bool CheckAction(int result, int minValue, int maxValue)
        {
            return result >= minValue && result <= maxValue;
        }

        private void ShowTitle()
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
        }
    }
}