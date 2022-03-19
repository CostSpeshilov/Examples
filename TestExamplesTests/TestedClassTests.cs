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

        [TestMethod]
        public void Div2Test()
        {
            TestedClass tested = new TestedClass();
            int a = 10;
            int b = 2;

            int expected = 5;

            int actual = tested.Div(a, b);

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

        [TestMethod]
        public void PowerTest()
        {
            //Arrange

            var sut = new TestedClass();

            var expected = 4;
            //Act

            var actual = sut.Power(2, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Power2Test()
        {
            //Arrange

            var sut = new TestedClass();

            var expected = 8;
            //Act

            var actual = sut.Power(2, 3);

            //Assert
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

            Assert.ThrowsException<ArgumentNullException>(() => tested.MaxElement(null));
        }

        [TestMethod()]
        public void MaxElementEmptyExceptionTest()
        {
            TestedClass tested = new TestedClass();

            Assert.ThrowsException<EmptyListException>(() => tested.MaxElement(new List<int>()));
        }


        #endregion

        [TestMethod]
        public void MaxTest()
        {
            // Arrange
            TestedClass sut = new TestedClass();
            int a = 3;
            int b = 2;

            int expected = 3;
            //Act
            var actual = sut.Max(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Max1Test()
        {
            // Arrange
            TestedClass sut = new TestedClass();
            int a = 1;
            int b = 2;

            int expected = 2;
            //Act
            var actual = sut.Max(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFirstGreaterTest()
        {
            // Arrange
            TestedClass sut = new TestedClass();
            int a = 1;
            int b = 2;

            var expected = false;
            //Act
            var actual = sut.IsFirstGreater(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}