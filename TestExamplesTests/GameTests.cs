using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestExamples;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace TestExamples.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void IsGameEndedTest()
        {
            var mockBoard = new Mock<IBoard>();

            mockBoard.Setup(m => m.HasSpecialSituation()).Returns(true);

            var game = new Game();
            game.Board = mockBoard.Object;



            bool actual = game.IsGameEnded();

            Assert.IsTrue(actual);
        }
    }
}