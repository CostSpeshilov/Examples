using System;
using System.Collections.Generic;
using System.Text;

namespace TestExamples
{
    public class Board : IBoard
    {
        public bool HasSpecialSituation()
        {
            throw new NotImplementedException();
            //логика определения ситуации на доске
        }
    }
}
