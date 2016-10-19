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
    public class PeekTests
    {
        [TestMethod()]
        public void doOperationTest()
        {
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(10);
            Peek peek = new Peek();
            Assert.AreEqual(10, peek.doOperation(stack));
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
            Peek peek = new Peek();
            Assert.AreEqual("Peek", peek.getName());
        }

        [TestMethod()]
        public void getOperatorTest()
        {
            Peek peek = new Peek();
            Assert.AreEqual("peek", peek.getOperator());
        }

        [TestMethod()]
        public void getNumberOfValuesTest()
        {
            Peek peek = new Peek();
            Assert.AreEqual(1, peek.getNumberOfValues());
        }
    }
}