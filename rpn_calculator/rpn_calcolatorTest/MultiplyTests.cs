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
    public class MultiplyTests
    {
        [TestMethod()]
        public void doOperationTest()
        {
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(10);
            stack.Push(4);
            Multiply mul = new Multiply();
            Assert.AreEqual(40, mul.doOperation(stack));
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
            Multiply mul = new Multiply();
            Assert.AreEqual("Multiply", mul.getName());
        }

        [TestMethod()]
        public void getOperatorTest()
        {
            Multiply mul = new Multiply();
            Assert.AreEqual("*", mul.getOperator());
        }

        [TestMethod()]
        public void getNumberOfValuesTest()
        {
            Multiply mul = new Multiply();
            Assert.AreEqual(2, mul.getNumberOfValues());
        }
    }
}