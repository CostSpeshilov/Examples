using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado
{
    class DataAccess
    {
       // private string connectionString = $@"Data Source=;Initial Catalog=adoExamples;Integrated Security=True";
        private string connectionString = $@"
Data Source=.\SQLEXPRESS;Initial Catalog=adoExamples;User ID=sa;Password=fcnfkfdbcnf12345;";


        public int InsertStudent(Student student)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                string command = $"Insert into Students (Name, Surname, Age) values ('{student.Name}', '{student.Surname}', {student.Age});";

                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(command, connection);


                number = sqlCommand.ExecuteNonQuery();
            }
            return number;
        }


        public int InsertStudentWithParameters(Student student)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"Insert into Students (Name, surname, age) values (@Naqme, @Surname, @Age)";

                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@Naqme", student.Name);
                sqlCommand.Parameters.AddWithValue("@Surname", student.Surname);
                sqlCommand.Parameters.AddWithValue("@Age", student.Age);
                number = sqlCommand.ExecuteNonQuery();
            }
            return number;
        }


        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "Select * from Students";

                SqlCommand sqlCommand = new SqlCommand(command, connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.Name = (String)reader["Name"];
                        student.Surname = (String)reader["Surname"];
                        student.Age = (int)reader["Age"];

                         student.Name = (String)reader[1];
                        //student.Name = reader.GetString(1);
                        students.Add(student);
                    }
                }
            }

            return students;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string command = "Select * from Students";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader reader = await  sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        Student student = new Student();
                        student.Name = (String)reader["Name"];
                        student.Surname = (String)reader["Surname"];
                        student.Age = (int)reader["Age"];

                        // student.Name = (String)reader[0];
                        //student.Name = reader.GetString(1);
                        students.Add(student);
                    }
                }
            }

            return students;
        }
    }
}
