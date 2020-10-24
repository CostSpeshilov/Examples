using TestExamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestExamples.Tests
{
    [TestClass()]
    public class TestedClassTests
    {
        [TestMethod()]
        public void SumTest()
        {
            TestedClass tested = new TestedClass();
            int a = 1;
            int b = 2;

            int expected = 3;

            int actual = tested.Sum(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivTest()
        {
            TestedClass tested = new TestedClass();
            int a = 1;
            int b = 0;

            Assert.ThrowsException<DivideByZeroException>(() => tested.Div(a, b));
        }
        #region Несколько методов для ожного теста

        [TestMethod()]
        public void MaxElementWhenElemenstAreDifferentTest()
        {
            TestedClass tested = new TestedClass();
            List<int> elements = new List<int> { 1, 2, 3 };

            int expected = 3;

            int actual = tested.MaxElement(elements);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MaxElementWhenElemenstAreSameTest()
        {
            TestedClass tested = new TestedClass();
            List<int> elements = new List<int> { 3, 3, 3 };

            int expected = 3;

            int actual = tested.MaxElement(elements);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Один метод с параметрами
        [TestMethod()]
        [DynamicData(nameof(ElementsDataSet), DynamicDataSourceType.Method)]
        public void MaxElementTest(List<int> elements, int expected)
        {
            TestedClass tested = new TestedClass();

            int actual = tested.MaxElement(elements);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> ElementsDataSet()
        {
            yield return new object[] { new List<int> { 1, 2, 3 }, 3 };
            yield return new object[] { new List<int> { 3, 3, 3 }, 3 };
            yield return new object[] { new List<int> { 3, 2, 1 }, 3 };
            yield return new object[] { new List<int> { 1, 3, 2 }, 3 };
            yield return new object[] { new List<int> { -1, 3, 2 }, 3 };
            yield return new object[] { new List<int> { 1 }, 1 };
        }

        [TestMethod()]
        public void MaxElementExceptionTest()
        {
            TestedClass tested = new TestedClass();

            Assert.ThrowsException<ArgumentNullException>(() =>  tested.MaxElement(null));
        }

        [TestMethod()]
        public void MaxElementEmptyExceptionTest()
        {
            TestedClass tested = new TestedClass();

            Assert.ThrowsException<EmptyListException>(() => tested.MaxElement(new List<int>()));
        }
        #endregion



    }
}