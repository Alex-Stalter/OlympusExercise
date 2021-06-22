using System;
using System.IO;
using System.Linq;
using System.Threading;


namespace OlympusExercise
{
    public class Program
    {
        public static Mutex sharedResource = new Mutex();
        public static void threadWrite()
        {
            
            for(int i = 0; i < 10; i++)
            {
                sharedResource.WaitOne();
                var lastInput = File.ReadLines("/log/out.txt").Last();
                string[] splitInput = lastInput.Split(',');
                int count = Int32.Parse(splitInput[0]);
                count++;
                using StreamWriter file = new("/log/out.txt", append: true);
                int threadid = Thread.CurrentThread.ManagedThreadId;
                file.WriteLine(count+", "+ threadid + ", " + DateTime.Now.ToString("HH:mm:ss.fff"));
                file.Close();
                sharedResource.ReleaseMutex();

            }
            
        }
    }

    public class driver {

        static void Main(string[] args) {
            if (!Directory.Exists("/log")) {

                Directory.CreateDirectory("/log");
            }

            if (File.Exists("/log/out.txt"))
            {
                File.Delete("/log/out.txt");
            }
            using StreamWriter file = new("/log/out.txt", append: true);
            file.WriteLine(0 + ", " + 0+", " + DateTime.Now.ToString("HH:mm:ss.fff"));
            file.Close();
          

            Thread trd0 = new Thread(Program.threadWrite);
            Thread trd1 = new Thread(Program.threadWrite);
            Thread trd2 = new Thread(Program.threadWrite);
            Thread trd3 = new Thread(Program.threadWrite);
            Thread trd4 = new Thread(Program.threadWrite);
            Thread trd5 = new Thread(Program.threadWrite);
            Thread trd6 = new Thread(Program.threadWrite);
            Thread trd7 = new Thread(Program.threadWrite);
            Thread trd8 = new Thread(Program.threadWrite);
            Thread trd9 = new Thread(Program.threadWrite);
            trd0.Start();
            trd1.Start();
            trd2.Start();
            trd3.Start();
            trd4.Start();
            trd5.Start();
            trd6.Start();
            trd7.Start();
            trd8.Start();
            trd9.Start();

            Console.WriteLine("All threads have finished proccessing...");
        }


    }
}
