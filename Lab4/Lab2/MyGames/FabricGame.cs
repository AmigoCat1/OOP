using Lab2.MyGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MyGames
{
    public class FabricGame
    {
        public Game GetClassic()
        {
            return new ClassicGame();
        }
        
        public Game GetTraining()
        {
            return new TrainingGame();
        }

        public Game GetGameForOne()
        {
            return new GameForOne();
        }
    }
}