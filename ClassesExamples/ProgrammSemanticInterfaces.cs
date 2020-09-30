using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples
{
    abstract class SemanticInterface
    {
        public abstract int FirstMethod();
        public abstract string SecondMethod();
        public abstract double ThirdMethod();

        int res;
        string res2;
        double Example()
        {
            res = FirstMethod();
            res2 = SecondMethod();
            return ThirdMethod();
        }


        double InvertedMethodCalls()
        {
            //Спокойно меняются местами
            //Ошибка времени выполнения, которую может быть тяжело найти
            res2 = SecondMethod();
            res = FirstMethod();
            return ThirdMethod();
        }
    }

    abstract class ProgrammInterface
    {
        public abstract int FirstMethod();
        public abstract string SecondMethod(int resultFromFirstMethod);
        public abstract double ThirdMethod(string resultFromSecondMethod);

        double Example()
        {
            int res = FirstMethod();
            string res2 = SecondMethod(res);
            return ThirdMethod(res2);
        }


        double InvertedMethodCalls()
        {
            //Не могу поменять местами, потому как не определена переменная
            //Ошибка времени компиляции
            string res2 = SecondMethod(res); 
            int res = FirstMethod();
            return ThirdMethod(res2);
        }
    }
}
