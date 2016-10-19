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
    public class DivisionTests
    {
        [TestMethod()]
        public void doOperationTest()
        {
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(10);
            stack.Push(2);
            Division div = new Division();
            Assert.AreEqual(5, div.doOperation(stack));
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
            Division div = new Division();
            Assert.AreEqual("Division", div.getName());
        }

        [TestMethod()]
        public void getOperatorTest()
        {
            Division div = new Division();
            Assert.AreEqual("/", div.getOperator());
        }

        [TestMethod()]
        public void getNumberOfValuesTest()
        {
            Division div = new Division();
            Assert.AreEqual(2, div.getNumberOfValues());
        }
    }
}