using MvvmDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemoApp.ViewModel
{
    public class StudentShortViewModel
    {
        private Student student;

        public StudentShortViewModel(Student student)
        {
            this.student = student;
        }

        public string FIO
        {
            get => student.Surname + student.Name[0];
        }
    }
}
