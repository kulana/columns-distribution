using NUnit.Framework;
using System.Collections.Generic;

namespace Kulana.Common.Columns.Tests.Methods
{
    [TestFixture]
    class LeftToRightTopToBottomTests
    {
        private LeftToRightTopToBottom _out;

        [SetUp]
        public void Setup()
        {
            _out = new LeftToRightTopToBottom();
        }

        [TestCase(1, 1, 1, 1)]
        [TestCase(1, 3, 1, 1)]
        [TestCase(1, 3, 2, 1)]
        [TestCase(1, 3, 3, 1)]
        public void Test_1_Column(int totalColumns, int totalItems, int currentItemIndex, int testResult)
        {
            // act
            var result = _out.GetColumnIndex(totalColumns, totalItems, currentItemIndex);

            // assert
            Assert.AreEqual(testResult, result);
        }

        [TestCase(2, 2, 1, 1)]
        [TestCase(2, 2, 2, 2)]
        [TestCase(2, 2, 3, 1)]
        [TestCase(2, 2, 4, 2)]
        [TestCase(2, 2, 5, 1)]
        public void Test_2_Columns(int totalColumns, int totalItems, int currentItemIndex, int testResult)
        {
            // act
            var result = _out.GetColumnIndex(totalColumns, totalItems, currentItemIndex);

            // assert
            Assert.AreEqual(testResult, result);
        }


    }
}
