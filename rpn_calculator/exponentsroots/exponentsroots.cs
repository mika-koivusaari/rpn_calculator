using rpn_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exponentsroots
{
    public class Exponent : IOperator
    {
        public decimal doOperation(Stack<decimal> stack)
        {
            decimal value1 = stack.Pop();
            decimal value2 = stack.Pop();
            return (decimal)Math.Pow((double)value1,(double)value2);
        }

        public string getDescription()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "Power";
        }

        public string getOperator()
        {
            return "pow";
        }

        public int getNumberOfValues()
        {
            return 2;
        }
    }
}
