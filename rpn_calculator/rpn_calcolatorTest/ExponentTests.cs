using Microsoft.VisualStudio.TestTools.UnitTesting;
using exponentsroots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exponentsroots.Tests
{
    [TestClass()]
    public class ExponentTests
    {
        [TestMethod()]
        public void doOperationTest()
        {
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(2);
            stack.Push(4);
            Exponent pow = new Exponent();
            Assert.AreEqual(16, pow.doOperation(stack));
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
            Exponent pow = new Exponent();
            Assert.AreEqual("Power", pow.getName());
        }

        [TestMethod()]
        public void getOperatorTest()
        {
            Exponent pow = new Exponent();
            Assert.AreEqual("pow", pow.getOperator());
        }

        [TestMethod()]
        public void getNumberOfValuesTest()
        {
            Exponent pow = new Exponent();
            Assert.AreEqual(2, pow.getNumberOfValues());
        }
    }
}