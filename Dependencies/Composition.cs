using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.Composition
{
    public class CustomService
    {
        /// <summary>
        /// Есть ссылка в виде свойства или поля класса
        /// При этом мы знаем время жизни объекта
        /// Экземпляр CustomRepository создается внутри класса
        /// </summary>
        public CustomRepository Repository { get; }

        public CustomRepository repository;


        public CustomService()
        {
            repository = new CustomRepository();
        }

    }

    public class CustomRepository
    {
    }

    class ExampleOfUse
    {
        void Example()
        {


            CustomService service1 = new CustomService();

        }

    }
}
