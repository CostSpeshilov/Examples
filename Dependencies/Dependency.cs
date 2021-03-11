using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.Dependencies
{
    class SalaryCalculator
    {        

        public decimal CalculateSalary(Worker worker)
        {
            return 0;
        }

        public void DoSomething()
        {
            Worker worker = new Worker();
            worker.DoSomething();
        }
    }

    class Worker
    {
        public void DoSomething()
        {
        }
    }


}
