using System;
using System.Collections.Generic;
using System.Text;

namespace MethodsExamples
{
    class Parameters
    {
        void Method(in int input, ref int mutable, out int output) { throw new NotImplementedException(); }

        void Method1(int x, int y, int weight) { }
        void WrongMethod2(int y, int x, int weight) { }
        void GoodMethod2(int x, int y, int weight) { }

        void ProcedureWithOut(int i, out int p) { throw new NotImplementedException(); }
        void ProcedureWithOut2(List<int> ints)
        {
            ints = new List<int>();
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
        }

        void ProcedureWithOut3(Player player)
        {
            player = new Player();
        }

        int FunctionWithManyOutputs(int i, ref int secondOutput)
        {
            secondOutput = 2;
            return i;
        }
        int FunctionWithManyOutputs2(int i, out int secondOutput)
        {
            secondOutput = 2;
            return i;
        }

        int GetNewLifeSideEffects(Effects effects)
        {
            effects.Life -= 10;
            return effects.Life;
        }

        int GetNewLifeSideEffects2(Effects effects)
        {
            int newLife = effects.Life - 10;
            if (newLife < 50)
            {
                effects.Armor += 5;
            }
            return newLife;
        }
    }
}
