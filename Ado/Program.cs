using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           
            DataAccess db= new DataAccess();

            var addedCount = db.InsertStudent(
                new Student() 
                { Age = 18, 
                    Name = "Иван", Surname = "Иванов" });
            addedCount = db.InsertStudentWithParameters(new Student() { Age = 18, Name = "Иван', 'Иванов', 18); delete from Students where name='Иван'; insert into Students (Name, Surname, Age) values ('Вася", Surname = "Иванов" });

            // addedCount = db.InsertStudentWithParameters(new Student() { Age = 18, Name = "Пётр", Surname = "Петров" });

            Console.WriteLine($"added {addedCount}");
            var students = db.GetStudents();
            
     

            foreach (var st in students)
            {
                Console.WriteLine($"Name = {st.Name}, Surname = {st.Surname}, Age = {st.Age}");
            }
        }


        
    }
}


//   var studentTask = db.GetStudentsAsync();
// var students = studentTask.Result;




//var addedCount = db.InsertStudent(new Student() { Age = 18, Name = "Иван', 'Иванов', 18); delete from Students where name='Иван'; insert into Students (Name, Surname, Age) values ('Вася", Surname = "Иванов" });
//addedCount = db.InsertStudentWithParameters(new Student() { Age = 18, Name = "Иван', 'Иванов', 18); delete from Students where name='Иван'; insert into Students (Name, Surname, Age) values ('Вася", Surname = "Иванов" });
// addedCount = db.InsertStudentWithParameters(new Student() { Age = 18, Name = "Пётр", Surname = "Петров" });