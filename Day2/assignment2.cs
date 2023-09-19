using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo1
{
    public delegate void Mydelegate();

    internal class Program
    {

     
        static void Main(string[] args)
        { 
            
            TestClass obj=new TestClass();
            Mydelegate delobj = new Mydelegate(obj.Hello);
            delobj();
            Console.WriteLine();
        }

    }
    internal class TestClass()
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }

}
