using System;

namespace Numbers
{
    class Program
    {
        static void Main()
        {
          //  unsafe
           // {
            //    int n = 10;
            //    int* p = &n;

             //   Console.WriteLine("value:{0}", n);
               // Console.WriteLine("address :{0}", (int));
                //
                //}
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------Activity 1---------------------------------------------");
            Console.WriteLine();
            ExploringNumbers();
            Console.WriteLine("---------------------------------------------------Activity 2----------------------------------------------");
            Console.WriteLine();
            AssignLocalVariables();
            Console.WriteLine("---------------------------------------------------Activity 3----------------------------------------------");
            Console.WriteLine();
            Ass();
            Console.WriteLine("---------------------------------------------------Activity 4----------------------------------------------");
            Console.WriteLine();
            //  unsafe
            // {
            //    int n = 10;
            //    int* p = &n;

            //   Console.WriteLine("value:{0}", n);
            // Console.WriteLine("address :{0}", (int));
            //
            //}
            Console.WriteLine("this section is cooment in code");


            Console.WriteLine("---------------------------------------------------Activity 5----------------------------------------------");
            Console.WriteLine();
            castintanddouble();
            Console.WriteLine("---------------------------------------------------Activity 6----------------------------------------------");
            Console.WriteLine();

            converttostring();
            Console.WriteLine("---------------------------------------------------Activity 7----------------------------------------------");
            Console.WriteLine();
            parsenumberanddate();
            Console.ReadLine();
        }
        private static void parsenumberanddate()
        {
            int age = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 july 1980");
            Console.WriteLine($"i was born {age} years ago");
            Console.WriteLine($"my birthady is {birthday}.");
            Console.WriteLine($"my birthday is {birthday:D}.");

        }
        private static void converttostring()
        {
            int number =12;
            Console.WriteLine(number.ToString());
            bool boolean = true;
            Console.WriteLine(boolean.ToString());
            DateTime now =DateTime.Now;
            Console.WriteLine(now.ToString());
            Object me=new Object();
            Console.WriteLine(me.ToString());



        }
        private static void castintanddouble()
        {
            int a=10;
            double b = a;
            Console.WriteLine(b);
            double c = 9.8;
            int d = (int)c;
            long e = 10;
            int f = (int)e;
            Console.WriteLine($" e is {e} and f is {f}");
            e=long.MaxValue;
            f = (int)e;
            Console.WriteLine($"e is {e} and f is {f}");
        }

        private static void AssignLocalVariables()
        {
            int population = 66_000_000; 
            double weight = 1.88; 
            decimal price = 4.99M; 
            string fruit = "Apples";
            char letter = 'Z'; 
            bool happy = true;
            Console.WriteLine("the weight is " + weight);
            Console.WriteLine("the price is " + price);
            Console.WriteLine();
            Console.WriteLine();

        }
        private static void Ass()
        {
            string a = "slam";
            a += "for";
            a = a + "ali";
            Console.WriteLine(a);
            Object obj;
            obj = 20;
            Console.WriteLine(obj);
            Console.WriteLine(obj.GetType());
            Console.WriteLine();
            Console.WriteLine();
        }



            private static void ExploringNumbers()
        {
            Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range:\n" +
                              $"{int.MinValue:N0} to {int.MaxValue:N0}.\n");

            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range:\n" +
                              $"{double.MinValue:N0} to {double.MaxValue:N0}.\n");

            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range:\n" +
                              $"{decimal.MinValue:N0} to {decimal.MaxValue:N0}.\n");

            Console.WriteLine();
            Console.WriteLine();


        }
    }
}
