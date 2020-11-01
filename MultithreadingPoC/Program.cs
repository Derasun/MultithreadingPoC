using System;
using System.Threading;

namespace MultithreadingPoC
{
    class Program
    {
        static object left = new object();
        static object right = new object();
        static object noLeft = new object();
        static object noRight = new object();
        public static void DeadLockLeftRight()
        {
            lock (left)
            {
                Console.WriteLine("DeadLockLeftRight left");
                Thread.Sleep(1000);
                lock (right)
                {
                    Console.WriteLine("DeadLockLeftRight right");
                }
            }
        }

        public static void DeadLockRightLeft()
        {
            lock (right)
            {
                Console.WriteLine("DeadLockRightLeft right");
                Thread.Sleep(1000);
                lock (left)
                {
                    Console.WriteLine("DeadLockRightLeft left");
                }
            }
        }

        public static void NoDeadLockLeftRight()
        {
            lock (noLeft)
            {
                Console.WriteLine("NoDeadLockLeftRight left");
                Thread.Sleep(1000);
                lock (noRight)
                {
                    Console.WriteLine("NoDeadLockLeftRight right");
                }
            }
        }

        public static void NoDeadLockRightLeft()
        {
            lock (noLeft)
            {
                Console.WriteLine("NoDeadLockRightLeft left");
                Thread.Sleep(1000);
                lock (noRight)
                {
                    Console.WriteLine("NoDeadLockRightLeft right");
                }
            }
        }
        static void Main()
        {
            Thread thread1 = new Thread((ThreadStart)DeadLockLeftRight);
            Thread thread2 = new Thread((ThreadStart)DeadLockRightLeft);
            Thread thread3 = new Thread((ThreadStart)NoDeadLockLeftRight);
            Thread thread4 = new Thread((ThreadStart)NoDeadLockRightLeft);

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        } 
    }

}