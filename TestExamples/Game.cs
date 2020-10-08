using System;
using System.Collections.Generic;
using System.Text;

namespace TestExamples
{
    public class Game
    {
        public IBoard Board { get; set; }
        public bool IsGameEnded()
        {
            return Board.HasSpecialSituation();
        }
    }
}
