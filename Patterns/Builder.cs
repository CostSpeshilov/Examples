using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    /// <summary>
    /// Сам продукт, который создаёт строитель
    /// </summary>
    public class Product
    {
        // Параметры продукта нельзя задать извне
        // присвоить им значения может только  строитель
        public string Name { get; private set; }
        public decimal Price { get; set; }
        public int OptionalProperty { get; private set; }
        public string OptionalStringProperty { get; private set; }
        /// <summary>
        /// конструктор для использования в строителе. 
        /// публичного конструктора, а значит и возможности создать продукт без строителя нет
        /// </summary>
        private Product()
        {

        }
        /// <summary>
        /// Статическое свойство предоставляющее клиенту экземпляр строителя
        /// </summary>
        public static ProductBuilder Builder => new ProductBuilder();
        public static SimpleBuilder SBuilder => new();
        /// <summary>
        /// непостедственно сам строитель
        /// реализован как вложенный класс, чтобы был доступ к установке приватных полей продукта
        /// </summary>
        public class ProductBuilder
        {
            /// <summary>
            /// текущее состояние конструируемого продукта
            /// </summary>
            Product product;

            public ProductBuilder()
            {
                product = new Product();
            }

            /// <summary>
            /// метод добавления имени. такие методы нужны для всех полей продукта
            /// </summary>
            /// <param name="name"></param>
            /// <returns>возвращается экземпляр класса наследника, чтобы реализовать обязательное добавление имени</returns>
            public FinalProductBuilder AddName(string name)
            {
                product.Name = name;
                return new FinalProductBuilder(product);
            }

        }

        /// <summary>
        /// финальное состояние строителя, в которм есть метод Build
        /// </summary>
        public class FinalProductBuilder
        {
            Product product;

            public FinalProductBuilder(Product product)
            {
                this.product = product;
            }

            public FinalProductBuilder AddOptionalProperty(int value)
            {
                product.OptionalProperty = value;
                return this;
            }

            public FinalProductBuilder AddOptionalStringProperty(string value)
            {
                product.OptionalStringProperty = value;
                return this;
            }

            /// <summary>
            /// Возвращает продукт. получить продукт можно только через этот метод
            /// </summary>
            /// <returns></returns>
            public Product Build()
            {
                return product;
            }
        }

        public class SimpleBuilder
        {
            private bool _nameAdded = false;
            private bool _priceAdded = false;
            private readonly Product _product;
            public SimpleBuilder()
            {
                _product = new Product();
            }

            public SimpleBuilder WithName(string name)
            {
                _product.Name = name;
                _nameAdded = true;
                return this;
            }

            public SimpleBuilder WithPrice(decimal price)
            {
                _product.Price = price;
                _priceAdded = true;
                return this;
            }
            public SimpleBuilder WithOptionalProperty(int quantity)
            {
                _product.OptionalProperty = quantity;
                return this;
            }
            public SimpleBuilder WithOptionalStringProperty(string str)
            {
                _product.OptionalStringProperty = str;
                return this;
            }

            public Product Build()
            {
                if (_nameAdded && _priceAdded)
                    return _product;
                throw new InvalidOperationException(
                    "name and price are required");
            }
        }


    }
}
