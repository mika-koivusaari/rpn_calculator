using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpn_calculator
{
    class Program
    {
        public Hashtable initOperators()
        {
            Hashtable operatortable = new Hashtable();
            Operator addition = new Addition();
            operatortable.Add(addition.getOperator(), addition);

            return operatortable;
        }

        public void loop()
        {
            Stack<decimal> stack = new Stack<decimal>();
            Hashtable operatortable = initOperators();
            Boolean exit = false;

            while (!exit)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    exit = true;
                } else if (input == "peek")
                {
                    Console.WriteLine(stack.Peek());
                } else if (operatortable.ContainsKey(input))
                {
                    Operator op = (Operator)operatortable[input];
                    decimal value=op.doOperation(stack);
                    Console.WriteLine(value);
                    stack.Push(value);
                }
                else
                {
                    stack.Push(Decimal.Parse(input));
                }
            }
        }

        static void Main(string[] args)
        {
            Program rpn_calc = new Program();
            rpn_calc.loop();
        }
    }

    public interface Operator
    {
        string getName();
        string getOperator();
        decimal doOperation(Stack<decimal> stack);
        string getDescription();
    }

    public class Addition : Operator
    {
        public decimal doOperation(Stack<decimal> stack)
        {
            decimal value1 = stack.Pop();
            decimal value2 = stack.Pop();
            return value1 + value2;
        }

        public string getDescription()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "Addition";
        }

        public string getOperator()
        {
            return "+";
        }
    }
}
