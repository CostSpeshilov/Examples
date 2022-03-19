using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.Aggregation
{
    public class CustomService
    {
        /// <summary>
        /// Есть ссылка в виде свойства или поля класса
        /// При этом мы не знаем время жизни объекта
        /// Экземпляр CustomRepository можкт быть создан как в конструкторе, так и в методах. так и прийти извне
        /// </summary>
        public CustomRepository Repository { get; set; }

        /// <summary>
        /// Репозиторий клиентов
        /// </summary>
        public CustomRepository repository;


        public CustomService(CustomRepository repository)
        {
            this.repository = repository;
        }


        public CustomService()
        {

        }
    }

    public class CustomRepository
    { }

    class ExampleOfUse
    {
        void Example()
        {
            // Экземпляр CustomRepository должен быть создан до того, как создается CustomSersive
            CustomRepository repository = new CustomRepository();
            CustomService service = new CustomService(repository);

            //Экземпляр CustomRepository может быть создан и после того, как создается CustomSersive, 
            //но обязательно вне CustomSersive
            CustomService service1 = new CustomService();

            CustomRepository repository2 = new CustomRepository();
            service1.Repository = repository2;
        }

    }
}
