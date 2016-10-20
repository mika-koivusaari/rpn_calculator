using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace rpn_calculator
{
    class Program
    {
        public Hashtable initOperators()
        {
            Hashtable operatortable = new Hashtable();

            //get all Operators that are built-in(in this exe)
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && typeof(Operator).IsAssignableFrom(t)
                    select t;
            //and add them to operator table
            foreach (Type t in q)
            {
                Operator op = (Operator)Activator.CreateInstance(t);
                operatortable.Add(op.getOperator(), op);
                Console.WriteLine("Added operator " + op.getName());
            }

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
                string line = Console.ReadLine();
                string[] inputs = line.Split(' ');
                foreach (string input in inputs)
                {
                    if (input == "exit")
                    {
                        exit = true;
                    }
                    else if (input == "peek")
                    {
                        Console.WriteLine(stack.Peek());
                    }
                    else if (operatortable.ContainsKey(input))
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
