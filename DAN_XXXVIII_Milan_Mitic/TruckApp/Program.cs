using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static EventWaitHandle waitHandle = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread t = new Thread(() => Go());
            Thread t2 = new Thread(() => Go2());
            t.Start();
            t2.Start();

            Console.ReadLine();
        }

        public static void Go()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("   " + i);
            }
            waitHandle.Set();
        }

        public static void Go2()
        {
            waitHandle.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("aaa " + i);
            }
        }
    }
}
