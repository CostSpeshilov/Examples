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

        public bool ChangeValue(string attributeName, string newValue)
        {

        }

        public bool Exists(string attributeName)
        {
            return true;
        }
    }

    class Worker
    {
        public void DoSomething()
        {
            try
            {
                DoSomethingImplementation();
            }
            catch (Exception exp)
            {

                Console.WriteLine(exp.Message);
            }
        }

        private void DoSomethingImplementation()
        {
            throw new NotImplementedException();
        }
    }


}
