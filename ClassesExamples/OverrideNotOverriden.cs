using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples
{
    abstract class Parent
    {
        public virtual double CanBeOverriden()
        {
            throw new NotImplementedException();
        }

        public abstract double MustBeOverriden();

        public double CanNotBeOverriden()
        {
            return 0;
        }
    }


    class Child : Parent
    {
        public override double MustBeOverriden()
        {
            throw new NotImplementedException();
        }

        public override double CanBeOverriden()
        {
            return base.CanBeOverriden();
        }

        public double CanNotBeOverriden()
        {
            return 1000;
        }
    }

}
