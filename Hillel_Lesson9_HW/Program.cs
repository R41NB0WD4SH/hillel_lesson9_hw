namespace Hillel_Lesson9_HW
{
    class Programm
    {
        static void Main(string[] args)
        {
            
            
            Random rnd = new Random();

            object lockObject = new object();

            bool condition = true;
            
            

            int[] numbers = new int[100000];

            int sumArrayNumbers = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(0, 21);
                // Console.WriteLine("{0}", numbers[i]);

            }
            




            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            
            

            Thread t1 = new Thread(() =>
            {
                manualResetEvent.WaitOne();
                
                Console.WriteLine("Thread 1 Started...");
                
                if (condition)
                {
                    for (int i = 0; i < 25000; i++)
                    {
                        lock (lockObject)
                        {
                            sumArrayNumbers += numbers[i];
                        }
                    }
                    Console.WriteLine("Thread 1 Finished...");
                }
            });
            
            Thread t2 = new Thread(() =>
            {
                manualResetEvent.WaitOne();
                
                Console.WriteLine("Thread 2 Started...");
                
                
                if (condition)
                {
                    for (int i = 25001; i < 50000; i++)
                    {
                        lock (lockObject)
                        {
                            sumArrayNumbers += numbers[i];
                        }
                    }
                    Console.WriteLine("Thread 2 Finished...");
                }
            });
            
            Thread t3 = new Thread(() =>
            {
                manualResetEvent.WaitOne();
                
                Console.WriteLine("Thread 3 Started...");
                
                if (condition)
                {
                    for (int i = 50001; i < 75000; i++)
                    {
                        lock (lockObject)
                        {
                            sumArrayNumbers += numbers[i];
                        }
                    }
                    Console.WriteLine("Thread 3 Finished...");
                }
            });

            Thread t4 = new Thread(() =>
            {
                manualResetEvent.WaitOne();
                
                Console.WriteLine("Thread 4 Started...");
                
                if (condition)
                {
                    for (int i = 75001; i < 100000; i++)
                    {
                        lock (lockObject)
                        {
                            sumArrayNumbers += numbers[i];
                        }
                    }
                    Console.WriteLine("Thread 4 Calculated...");
                }

            });
            
            Thread checkingThread = new Thread(() =>
            {
                
                Console.WriteLine("Cheking Thread Started...");
                
                
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] < 1)
                    {
                        condition = false;
                    }
                }

                manualResetEvent.Set();

            });
            
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            checkingThread.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            checkingThread.Join();


            Console.WriteLine("Sum: {0}", sumArrayNumbers);


            Console.ReadKey();


        }
    }
}