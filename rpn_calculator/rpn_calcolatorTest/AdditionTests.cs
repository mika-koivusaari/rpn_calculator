using Microsoft.VisualStudio.TestTools.UnitTesting;
using rpn_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpn_calculator.Tests
{
    [TestClass()]
    public class AdditionTests
    {
        [TestMethod()]
        public void doOperationTest()
        {
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(10);
            stack.Push(10);
            Addition add = new Addition();
            Assert.AreEqual(20, add.doOperation(stack));
        }

        //        [TestMethod()]
        public void doOperationTest1()
        {
            throw new NotImplementedException();
        }

        //        [TestMethod()]
        public void getDescriptionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void getNameTest()
        {
            Addition add = new Addition();
            Assert.AreEqual("Addition", add.getName());
        }

        [TestMethod()]
        public void getOperatorTest()
        {
            Addition add = new Addition();
            Assert.AreEqual("+", add.getOperator());
        }

        [TestMethod()]
        public void getNumberOfValuesTest()
        {
            Addition add = new Addition();
            Assert.AreEqual(2, add.getNumberOfValues());
        }
    }
}