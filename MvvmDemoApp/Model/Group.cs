using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemoApp.Model
{
    public class Group
    {
        public string Name { get; set; }
        public List<Student> Students
        { get; set; } = new List<Student>();

        public void AddStudent(Student student)
        {
            student.Group = this;
            Students.Add(student);            
        }
    }
}
