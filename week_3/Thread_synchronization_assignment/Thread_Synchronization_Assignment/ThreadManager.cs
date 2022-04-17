using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_Synchronization_Assignment
{
    internal class ThreadManager
    {
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        private static object _locker = new object();


        //static WaitHandle[] waitHandlesAuto = new WaitHandle[]
        //{
        //    new AutoResetEvent(false),
        //    new AutoResetEvent(false)
        //};

        //static WaitHandle[] waitHandlesManual = new WaitHandle[]
        //{
        //    new ManualResetEvent(false),
        //    new ManualResetEvent(false)
        //};

        //public static void PerformFirstThreadTask()
        //{
        //    Console.WriteLine("Thread 1 started");
        //    ThreadPool.QueueUserWorkItem(new WaitCallback(FirstThreadWaitingTask), waitHandlesManual[0]);
        //    ThreadPool.QueueUserWorkItem(new WaitCallback(FirstThreadWaitingTask), waitHandlesManual[1]);
        //    WaitHandle.WaitAll(waitHandlesManual);
        //    Console.WriteLine("Thread 1 set signal");
        //    ThreadPool.QueueUserWorkItem(new WaitCallback(FirstThreadSignalTask), waitHandlesManual[1]);
        //    ThreadPool.QueueUserWorkItem(new WaitCallback(FirstThreadSignalTask), waitHandlesManual[1]);

        //}

        //static void FirstThreadWaitingTask(object state)
        //{
        //    ManualResetEvent manual = (ManualResetEvent)state;
        //    Console.WriteLine("Thread {0} is waiting for a manual signal from Thread 1", Thread.CurrentThread.ManagedThreadId);
        //    manual.Set();
        //}

        //static void FirstThreadSignalTask(object state)
        //{
        //    ManualResetEvent manual = (ManualResetEvent)state;
        //    Console.WriteLine("Thread {0} received a manual signal, continue working", Thread.CurrentThread.ManagedThreadId);
        //    manual.Set();
        //}



        public static void StartManaging()
        {
            new Thread(FirstThreadSignal) { Name = "Thread 1" }.Start();

            Thread.Sleep(100);

            new Thread(SecondThreadSignal) { Name = "Thread 2" }.Start();

            Thread.Sleep(100);

            for (int i = 0; i < 2; i++)
            {
                new Thread(ThirdAndFourthThreadsWaiting) { Name = "Thread " + (i + 3) }.Start();
            }

            Thread.Sleep(100);

            for (int i = 0; i < 2; i++)
            {
                new Thread(FifthAndSixthThreadsWaiting) { Name = "Thread " + (i + 5) }.Start();
            }
        }

        static void FirstThreadSignal()
        {
            Console.WriteLine("{0} started", Thread.CurrentThread.Name);

            Thread.Sleep(2000);        
            manualResetEvent.Set();
            Console.WriteLine("{0} set signal", Thread.CurrentThread.Name);

            Thread.Sleep(1000);
            manualResetEvent.Reset();
            Console.WriteLine("{0} reset signal", Thread.CurrentThread.Name);
        }

        static void SecondThreadSignal()
        {
            Console.WriteLine("{0} started", Thread.CurrentThread.Name);

            Thread.Sleep(1000);
            Console.WriteLine("{0} set signal", Thread.CurrentThread.Name);
            autoResetEvent.Set();

            Thread.Sleep(2000);
            Console.WriteLine("{0} set signal", Thread.CurrentThread.Name);
            autoResetEvent.Set();
        }

        static void ThirdAndFourthThreadsWaiting()
        {
            Console.WriteLine("{0} is waiting for a manual signal from Thread 1", Thread.CurrentThread.Name);
            lock (_locker)
            {
                manualResetEvent.WaitOne();
                Console.WriteLine("{0} received a manual signal, continue working ", Thread.CurrentThread.Name);
            }
        }

        static void FifthAndSixthThreadsWaiting()
        {
            Console.WriteLine("{0} is waiting for a auto signal from Thread 2", Thread.CurrentThread.Name);

            autoResetEvent.WaitOne();

            Console.WriteLine("{0} received a auto signal, continue working ", Thread.CurrentThread.Name);
        }
    }
}
