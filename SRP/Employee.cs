using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.SRP
{
    public class Employee
    {
        /// <summary>
        /// Расчитывает зарплату. Определяется бухгалтерией
        /// </summary>
        /// <returns></returns>
        public double CalcucatePay()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Расчитывает рабочие часы, определяется кадрами
        /// </summary>
        /// <returns></returns>
        public double Reportshours()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Сохранение в БД. Определяется администраторами БД
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
