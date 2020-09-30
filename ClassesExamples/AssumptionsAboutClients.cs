using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples
{
    class AssumptionsAboutClients
    {

        public double Method(double i, double j)
        {
            //Можно не проверять на 0, потому что в вызывающем коде 0 не может появиться
            return i / j;
        }
    }
}
