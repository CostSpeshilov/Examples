using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
