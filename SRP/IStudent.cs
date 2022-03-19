using System;
using System.Collections.Generic;
using System.Text;

namespace SRP
{
    interface IStudent
    {
        public int AverageMark { get; set; }
        public string Name { get; set; }
        public int CalculateMark();
    }
}
