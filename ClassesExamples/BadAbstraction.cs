using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples
{
    class BadStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public string GetBirthYear()
        {
            throw new NotImplementedException();
        }

        public void SetStringFormatForStudentName()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Не согласованный уровень абстракции.
        /// Этот метод принажлежит классу String (и он там есть), а не классу Student
        /// </summary>
        /// <returns></returns>
        public bool StringIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
