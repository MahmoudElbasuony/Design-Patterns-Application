using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Training
{
    class Program
    {

        static void Main(string[] args)
        {
            #region MultiThreading
            // ThreadingTest.MonitorTest();
            // ThreadingTest.SignalingTest();
            // ThreadingTest.SemaphoreTest();
            // ThreadingTest.MutexTest();
            // ThreadingTest.TaskCreation();
            #endregion

            #region Singleton
            var x = DatabaseConnection.Instance;

            Console.WriteLine(x.ConnectionString);

            x = DatabaseConnection.Instance;


            Console.WriteLine(x.ConnectionString); 
            #endregion



        }
    }


}
