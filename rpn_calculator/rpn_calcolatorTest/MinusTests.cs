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
    public class MinusTests
    {
        [TestMethod()]
        public void doOperationTest()
        {
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(10);
            stack.Push(3);
            Minus minus = new Minus();
            Assert.AreEqual(7, minus.doOperation(stack));
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
            Minus minus = new Minus();
            Assert.AreEqual("Minus", minus.getName());
        }

        [TestMethod()]
        public void getOperatorTest()
        {
            Minus minus = new Minus();
            Assert.AreEqual("-", minus.getOperator());
        }

        [TestMethod()]
        public void getNumberOfValuesTest()
        {
            Minus minus = new Minus();
            Assert.AreEqual(2, minus.getNumberOfValues());
        }
    }
}