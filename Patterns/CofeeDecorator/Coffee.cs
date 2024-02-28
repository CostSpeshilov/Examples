using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.CofeeDecorator
{
    public class Coffee
    {
        public string Name { get; init; }
        public virtual int Price { get; init; }

        public virtual string GetDescription()
        {
            return $"Кофе - {Name}";
        }
    }
}
