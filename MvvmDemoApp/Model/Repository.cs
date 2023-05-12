using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemoApp.Model
{
    internal class Repository
    {
        public Group GetGroup()
        {
            var student1 = new Student()
            {
                Name = "Иван",
                Surname = "Иванов",
                Birthday = DateTime.Now
            };
            var student2 = new Student()
            {
                Name = "Петр",
                Surname = "Петров",
                Birthday = DateTime.Now
            };
            var group = new Group()
            {
                Name = "BPI-311"
            };
            group.AddStudent(student1);
            group.AddStudent(student2);
            return group;
        }
    }
}
