using System;

namespace Dependencies
{
    public class CustomService
    {
        /// <summary>
        /// Есть ссылка в виде свойства или поля класса
        /// При этом мы не знаем время жизни объекта
        /// Экземпляр CustomRepository можкт быть создан как в конструкторе, так и в методах. так и прийти извне
        /// </summary>
        public CustomRepository Repository { get; set; }

        public CustomRepository repository;

    }

    public class CustomRepository
    { }


    class ExampleOfUse
    {
        void Example()
        {
            CustomService service = new CustomService();
            var rep = service.Repository;
        }

    }
}
