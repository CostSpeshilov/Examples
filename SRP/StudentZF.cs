using System;
using System.Collections.Generic;
using System.Text;

namespace SRP
{
    class StudentZF: IStudent
    {
        public string Name { get; set; }
        public int AverageMark { get; set; }

        public int CalculateMark()
        {
            return AverageMark * 9; 
        }
    }
}
