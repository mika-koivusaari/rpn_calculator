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
            Operator minus = new Minus();
            operatortable.Add(minus.getOperator(), minus);
            Operator multiply = new Multiply();
            operatortable.Add(multiply.getOperator(), multiply);
            Operator div = new Division();
            operatortable.Add(div.getOperator(), div);
            Operator peek = new Peek();
            operatortable.Add(peek.getOperator(), peek);

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
                    if (stack.Count() >= op.getNumberOfValues())
                    {
                        decimal value = op.doOperation(stack);
                        Console.WriteLine(value);
                        stack.Push(value);
                    }
                    else
                    {
                        Console.WriteLine("Not enought values in stack. " + op.getNumberOfValues() + " needed.");
                    }
                }
                else
                {
                    try
                    {
                        stack.Push(decimal.Parse(input));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Format error, not a number or an operator.");
                    }
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
        int getNumberOfValues();
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

        public int getNumberOfValues()
        {
            return 2;
        }

        public string getOperator()
        {
            return "+";
        }

    }

    public class Peek : Operator
    {
        public decimal doOperation(Stack<decimal> stack)
        {
            decimal value1 = stack.Pop();
            return value1;
        }

        public string getDescription()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "Peek";
        }

        public string getOperator()
        {
            return "peek";
        }

        public int getNumberOfValues()
        {
            return 1;
        }
    }

    public class Minus : Operator
    {
        public decimal doOperation(Stack<decimal> stack)
        {
            decimal value1 = stack.Pop();
            decimal value2 = stack.Pop();
            return value2 - value1;
        }

        public string getDescription()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "Minus";
        }

        public int getNumberOfValues()
        {
            return 2;
        }

        public string getOperator()
        {
            return "-";
        }

    }

    public class Multiply : Operator
    {
        public decimal doOperation(Stack<decimal> stack)
        {
            decimal value1 = stack.Pop();
            decimal value2 = stack.Pop();
            return value1 * value2;
        }

        public string getDescription()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "Multiply";
        }

        public int getNumberOfValues()
        {
            return 2;
        }

        public string getOperator()
        {
            return "*";
        }

    }

    public class Division : Operator
    {
        public decimal doOperation(Stack<decimal> stack)
        {
            decimal value1 = stack.Pop();
            decimal value2 = stack.Pop();
            return value2 / value1;
        }

        public string getDescription()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "Division";
        }

        public int getNumberOfValues()
        {
            return 2;
        }

        public string getOperator()
        {
            return "/";
        }

    }
}
