using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.TemplateMethod
{
    internal class IntQuickSort : QuickSort<int>
    {
        protected override int Compare(int item, int first)
        {
            if (item < first ) return -1;
            if (item == first ) return 0;
            //(item > first )
            return 1;
            
        }
    }
}
