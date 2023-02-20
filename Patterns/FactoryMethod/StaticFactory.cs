using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod
{
    internal static class StaticFactory
    {

        #region Именованные конструкторы

        // Применяются для того ,чтобы обойти ограничения конструктора
        // второй параметр и в том, и в другом случае целое число
        // разница лишь в семантике - в одном случае граммы, в другом килограммы

        public static Product FromKgs(string name, double weightInkg)
        {
            return new Product(name, weightInkg * 1000);
        }
        public static Product FromGramms(string name, double weightInGramms)
        {
            return new Product(name, weightInGramms);
        } 
        #endregion


        // при небольшой или стабильной иерархии мы можем скрыть всю иерархию за одним 
        // фабричным методом. Клиент не будет даже знать о существовании иерархии
        public static Product CreateProduct(string type, string name, double weightInGramms)
        {
            if (type == "product1")
            {
                return new Product1 (name, weightInGramms);
            }
            if (type == "product2") 
            {
                return new Product2 (name, weightInGramms);
            }
            else
            {
                throw new ArgumentException(nameof(type));
            }
        }
    }
}
