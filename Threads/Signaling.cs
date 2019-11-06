using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public static class Signaling
    {
        static CountdownEvent CountdownEvent = new CountdownEvent(2);
        static int result = 0;
        static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        static ManualResetEvent autoResetEvent = new ManualResetEvent(false);

        public static void SingalingTest()
        {
            //CountDownTest();
            ManualResetEvent();

        }


        #region Count Down

        public static void CountDownTest()
        {
            Task.Run(Increment);
            Task.Run(Increment2);
            CountdownEvent.Wait();
            Console.WriteLine($"All tasks finished and the result is {result}");
        }
        public static void Increment()
        {
            Thread.Sleep(1000);
            result++;
            Console.WriteLine($"Task {Task.CurrentId} : {CountdownEvent.CurrentCount}");
            CountdownEvent.Signal();
            Console.WriteLine($"Task {Task.CurrentId} After Signaling : {CountdownEvent.CurrentCount}");
        }

        public static void Increment2()
        {
            Thread.Sleep(1000);
            result++;
            Console.WriteLine($"Task {Task.CurrentId} : {CountdownEvent.CurrentCount}");
            CountdownEvent.Signal();
            Console.WriteLine($"Task {Task.CurrentId} After Signaling : {CountdownEvent.CurrentCount}");
        }


        #endregion

        public static void ManualResetEvent()
        {
            var task = Task.Run(ThreadProc);
            for (int i = 0; i <= 6; i++)
            {
                 Task.Run(ThreadProc);
            }

            Thread.Sleep(500);
            Console.WriteLine("Press Enter to signal the waiting threads");
            Console.ReadLine();

            autoResetEvent.Set();

            Thread.Sleep(500);
            Console.ReadLine();
        }

        private static void ThreadProc()
        {
      

            Console.WriteLine(Task.CurrentId + " starts and calls WaitOne()");

            autoResetEvent.WaitOne();

            Console.WriteLine(Task.CurrentId + " Realeased.");
            Thread.Sleep(500);
        }

    }
}
