using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training
{
    public static class ThreadingTest
    {

        public static void MonitorTest()
        {
            object _lock = new object();
            string x = "";
            for (int i = 0; i < 3; i++)
            {

                var thread = new Thread(() =>
                {
                    Monitor.Enter(_lock);
                    Console.WriteLine(Thread.CurrentThread.Name + " entered");
                    for (int y = 0; y < 10; y++)
                    {
                        x += "*";
                        Console.WriteLine(x);
                    }

                    Monitor.Exit(_lock);
                });
                thread.Name = i.ToString();
                thread.Start();

            }
        }


        public static void SignalingTest()
        {
            Thread parent = new Thread(() =>
            {

                for (int i = 0; i <= 200; i++)
                {
                    if (i == 10)
                    {
                        var child = new Thread(() =>
                        {
                            for (int y = 0; y <= 100; y++)
                                Console.WriteLine("{0} child working ..", y);

                        });
                        child.Start();
                        child.Join();

                    }
                    else
                    {
                        Console.WriteLine("{0} parent working ..", i);
                    }
                }
            });
            parent.Start();
        }

        public static void SemaphoreTest()
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(2, 2);
            for (int i = 1; i < 6; i++)
            {
                new Thread(o =>
                {
                    Console.WriteLine(o + " wants to enter");
                    semaphore.Wait();
                    Console.WriteLine("{0} entered ", o);
                    Thread.Sleep(1000 * (int)o);
                    Console.WriteLine("{0} leaving ", o);
                    semaphore.Release();

                }).Start(i);
            }
        }


        public static void MutexTest()
        {
             
            using (Mutex mutex = new Mutex(true, "myapp"))
            {
                if (!mutex.WaitOne(TimeSpan.FromSeconds(10), false))
                {
                    Console.WriteLine("another instance is running .");
                    return;
                }
                Console.WriteLine("app is running..");
                Console.ReadLine();
            }
        }


        public static void TaskCreation()
        {
            TaskFactory taskFactory = new TaskFactory();
            var task = taskFactory.StartNew(()=>{
                Console.WriteLine("Task Factory..");
                throw new Exception("error");
            });

            Console.ReadLine();
            Console.WriteLine(task.Status);

        }
    }
}
