using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace ConsoleApplicationTest01
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            a = 3;
            int b = (int)a;

            // ctl + F5 to hold the window before exit
            System.Console.WriteLine(b);

            test01();

            IntHolder y = new IntHolder();
            y.i = 5;
            Foo(y);
            Console.WriteLine("struct " + y.i);

            //
            string myStr = "";
            PropertyInfo[] pi = new System.Text.StringBuilder().GetType().GetProperties();

            //
            Console.WriteLine("TestClass --- ");
            TestClass tester = new TestClass();
            tester.test01();
        }


        public static void test01()
        {
            List<Object> MyList = new List<Object>();

            MyList.Add("AAA");
            MyList.Add("BBB");
            MyList.Add("CCC");
            MyList.Add("DDD");

            //String temp = MyList[2];  // wont compile
            String temp = (String)MyList[2];  // wont compile

            System.Console.WriteLine(temp);

            Program test = new Program();
            test.testInheritance();

            test.testA();


            StringBuilder y = new StringBuilder();
            y.Append("hello");
            Foo(y);
            Console.WriteLine(y == null);
            Console.WriteLine( y );


            

        }


        

        public void testInheritance()
        {
            DwuBase parent = new DwuBase();
            DwuTest child = new DwuTest();

            parent.doIt();

            child.doIt();

            DwuBase mybase = new DwuTest();
            mybase.doIt();   //from base
            

            DwuBase base2 = (DwuBase)child;
            base2.doIt();

        }

        public void testA()
        {
            int[] Data = {1,2,3 };
            var results = from X in Data select X;

            foreach( var z in results)
            {
                Console.WriteLine("z is {0}" , z  );
            }

            Console.WriteLine( "type is " +  results.GetType().FullName );


            string s = "\\My Test\\\\";
            int i = s.LastIndexOf(@"\\");

            Console.WriteLine(s);
            Console.WriteLine("i is " + i);



        }

        private void testB()
        {
            long bigNum = 1234567890;
            System.Int32 smallNum;

            //smallNum = bigNum; //wrong

            

            smallNum = (int)bigNum;
            //smallNum = int.Parse(bigNum); //wrong  take string parameter
            //smallNum = bigNum as System.Int32; // wrong, must be reference type of nullable type

            //(long) smallNum = bigNum; //
        }

        static void Foo(IntHolder x)
        {
            x.i = 10;
        }

        static void Foo(StringBuilder x)
        {
            //x = null;
            x.Append(" world");
        }

    }

    struct IntHolder
    {
        public int i;
    }

    




    class testNobody
    {

    }

    class testSameName
    {
        //String testSameName;  // error compile, can not be same as enclosing type

        //public string testSameName() { }; // error compile, can not be same name as enclosing type
    }

    class DwuBase
    {
        public virtual string name { get; set; }

        public virtual void doIt()
        {
            System.Console.WriteLine("from Base");
        }
    }

    class DwuTest : DwuBase
    {
        public override void doIt()
        {
            System.Console.WriteLine("from Child");
        }
    }


}
