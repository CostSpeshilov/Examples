using System;
using System.Collections.Generic;
using System.Text;

namespace MethodsExamples
{
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
            Action1();
            Action2();
            Action3();
        }

        private void Action3()
        {
            throw new NotImplementedException();
        }

        private void Action2()
        {
            throw new NotImplementedException();
        }

        private void Action1()
        {
            throw new NotImplementedException();
        }
    }
}
