using System;

namespace SRP
{
    internal class Student
    {
        public string Name { get; set; }
        public int AverageMark { get; set; }
        internal int CalculateMark()
        {
            return AverageMark;
        }
    }
}