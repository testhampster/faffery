using System;

namespace DemoCsharp
{
    class BaseClass
    {
        public virtual int Add(int num1, int num2)
        {
            return (num1 + num2);
        }

        public class Adder
        {
            public delegate void dgEventRaiser();
            public delegate void TitRaiser(string titmessage);
            public delegate void gobtart();

            public event dgEventRaiser OnMultipleOfFiveReached;
            public event TitRaiser OnTit;
            public event gobtart OnGob;

            public int Add(int x, int y)
            {
                int iSum = x + y;

                if ((iSum % 5 == 0) && (OnMultipleOfFiveReached != null))
                {
                    OnMultipleOfFiveReached();
                }

                if (y == 6)
                {
                    OnTit("splinge");
                    OnGob();
                };

                return iSum;
            }
        }

        public delegate int dgPointer(int a, int b);

    }
    class ChildClass : BaseClass
    {
        public override int Add(int num1, int num2)
        {
            if (num1 <= 0 || num2 <= 0)
            {
                Console.WriteLine("Values could not be less than zero or equals to zero");
                Console.WriteLine("Enter First value : ");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second value : ");
                num2 = Convert.ToInt32(Console.ReadLine());
            }
            return (num1 + num2);
        }
    }
    class Program
    {
        //working example of Events and delegates 

        static void Main()
        {
            BaseClass.Adder a = new BaseClass.Adder();

            a.OnMultipleOfFiveReached += new BaseClass.Adder.dgEventRaiser(a_MultipleOfFiveReached);
            a.OnTit += new BaseClass.Adder.TitRaiser(TitAction);
            a.OnGob += new BaseClass.Adder.gobtart(Gobaction);

            BaseClass.dgPointer pAdder = new BaseClass.dgPointer(a.Add);

            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("start the faffery"); // a change - a second change a third change to twiglet

            int iAnswer = pAdder(num1, num2);
            Console.WriteLine("iAnswer = {0}", iAnswer);

            iAnswer = pAdder(num1, num2);
            Console.WriteLine("iAnswer = {0}", iAnswer);

            Console.ReadLine();

        }

        private static void Gobaction()
        {
            Console.WriteLine("Tit Gobbing");
        }

        private static void TitAction(string titmessage)
        {
            Console.WriteLine("Tit " + titmessage);
        }

        static void a_MultipleOfFiveReached()
        {
            Console.WriteLine("Multiple of five reached watty!");
        }


    }
}