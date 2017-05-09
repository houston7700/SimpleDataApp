using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest01
{
    class Class1
    {
        // can only have 1 main mehtod, other wise needs to compile with /main option to specify main entry point 

    }

    class TestClass
    {

        internal void test01()
        {
            // The Three Parts of a LINQ Query:
            //  1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);   // 0 2 4 6

                Console.WriteLine("new1");
                Console.Write("{0} ", num);

                Console.WriteLine("new2");
                Console.Write("{0}, xx {1} ", num, num    );

            }
        }
    }


    public class MyClass
    {
        private MyClass() { }
        //

        /*
          A private constructor is a special instance constructor. It is generally used in classes that
          contain static members only. If a class has one or more private constructors and no public 
          constructors, other classes (except nested classes) cannot create instances of this class.
         */

        //public string MyClass; //wrong




    }

    public interface MyInterface
    {
        //public MyInterface();  //wrong, must be abstract / partial /extern ..


    }

    public class BClass
    {
        public BClass() { }

        public BClass(String newValue) : this() { }
    }


}
