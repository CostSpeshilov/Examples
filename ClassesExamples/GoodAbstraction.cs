using System;

namespace ClassesExamples
{
    /// <summary>
    /// Имя данного класса не совпадает с именем файла, в котором он определен.
    /// Это сделано только для целей обучения. Не делайте так в реальных проектах
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Group Group { get; set; }

        public double GetAverageMark()
        {
            throw new NotImplementedException();
        }
    }

    #region Вспомогательные классы

    /// <summary>
    /// В одном файле следует всегда размещать только одно поределение класса, интерфейса, перечисления
    /// Добавление сюда класса Group сделано только для демонстрации. Не делайте так. 
    /// </summary>
    public class Group
    {
    } 
    #endregion
}
