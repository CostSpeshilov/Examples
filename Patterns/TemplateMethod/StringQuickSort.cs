using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.TemplateMethod
{
    internal class StringQuickSort : QuickSort<string>
    {
        protected override int Compare(string item, string first)
        {
            return string.Compare(item, first);
        }
    }

}
