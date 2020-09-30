using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples
{
    class WrongStudentAbstraction
    {
        #region Эти свойства относятся к классу студент
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Group Group { get; set; }
        #endregion

        #region А эти уже к классу человек, и для определения студента они излишни
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BloodType { get; set; } 
        #endregion

        public double GetAverageMark()
        {
            throw new NotImplementedException();
        }
    }
}
