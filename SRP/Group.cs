using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP
{
    class Group
    {
        List<Student> Students;

        public Group()
        {
            Students = new List<Student>();
            Students.Add(new Student() { Name = "John", AverageMark = 5 });
            //Students.Add(new StudentZF() { Name = "Jack", AverageMark = 3 });
        }
        public int CalculateMarks()
        {
            //return Students.Sum(x => x.CalculateMark());

            int result = 0;
            foreach (var student in Students)
            {
                result += student.CalculateMark();
            }
            return result;
        }
    }
}
