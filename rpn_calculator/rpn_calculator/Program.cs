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

        //Get all operators from current assembly and
        //from specified ddl's
        public Hashtable initOperators()
        {
            Hashtable operatortable = new Hashtable();

            //get all Operators that are built-in(in this exe)
            Assembly asm = Assembly.GetExecutingAssembly();
            getOperatorsFromAssembly(operatortable, asm);

            //get all operators from external dll
            asm = Assembly.LoadFrom("exponentsroots.dll");
            getOperatorsFromAssembly(operatortable, asm);

            return operatortable;
        }

        private void getOperatorsFromAssembly(Hashtable operatortable,Assembly ass)
        {
            //get types from given assembly
            IEnumerable<Type> q = from t in ass.GetTypes()
                                  where t.IsClass && typeof(IOperator).IsAssignableFrom(t)
                                  select t;
            //and add them to operator table
            foreach (Type t in q)
            {
                IOperator op = (IOperator)Activator.CreateInstance(t);
                try
                {
                    operatortable.Add(op.getOperator(), op);
                    Console.WriteLine("Added operator " + op.getName());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Error: Operator " + op.getName()+" allready exists.");
                }
            }
        }

        //main loop
        public void loop()
        {
            Stack<decimal> stack = new Stack<decimal>();
            Hashtable operatortable = initOperators();
            Boolean exit = false;

            //loop until user gives exit command
            while (!exit)
            {
                Console.Write("> ");
                string line = Console.ReadLine();
                string[] inputs = line.Split(' ');
                foreach (string input in inputs)
                {
                    //exit is hardcoded
                    if (input == "exit")
                    {
                        exit = true;
                    }
                    //all other operators are loaded classes
                    else if (operatortable.ContainsKey(input))
                    {
                        IOperator op = (IOperator)operatortable[input];
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
                    else //not an operator, must be number
                    {
                        try
                        {
                            //maybe add parsing of hex etc?
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

    //Interface that all operators must implement
    public interface IOperator
    {
        string getName();
        string getOperator();
        decimal doOperation(Stack<decimal> stack);
        string getDescription();
        int getNumberOfValues();
    }

    public class Addition : IOperator
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

    public class Peek : IOperator
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

    public class Minus : IOperator
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

    public class Multiply : IOperator
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

    public class Division : IOperator
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
