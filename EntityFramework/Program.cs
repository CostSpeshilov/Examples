using System;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (Context db = new Context())
            {
                Student st1 = new Student() { Age = 18, Name = "Иван", Surname = "Иванов" };
                Student st2 = new Student() { Age = 18, Name = "Пётр", Surname = "Петров" , Patronymic = "Сергеевич"};

                Group gr = new Group() { Name = "первая" };
                st1.Group = gr;
                st2.Group = gr;
                db.Students.Add(st1);
                db.Students.Add(st2);
                db.SaveChanges();


                var students = db.Students.Where(x => x.Name == "Иван").ToList();

                foreach (var st in students)
                {
                    Console.WriteLine($"Name = {st.Name}, Surname = {st.Surname}, Age = {st.Age}");
                }
            }
        }
    }
}
