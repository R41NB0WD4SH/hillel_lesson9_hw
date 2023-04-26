

namespace Hillel_Lesson9_HW
{
    class Programm
    {
        static void Main(string[] args)
        {
            
            
            Random rnd = new Random();

            object lockObject = new object();
            
            

            int[] numbers = new int[100000];

            int sumArrayNumbers = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(0, 21);
                Console.WriteLine("{0}", numbers[i]);
            }



            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            
            

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 25000; i++)
                {
                    lock (lockObject)
                    {
                        sumArrayNumbers += numbers[i];
                    }
                }
            });
            
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 25000; i++)
                {
                    lock (lockObject)
                    {
                        sumArrayNumbers += numbers[i];
                    }
                }
            });
            
            Thread t3 = new Thread(() =>
            {
                for (int i = 0; i < 25000; i++)
                {
                    lock (lockObject)
                    {
                        sumArrayNumbers += numbers[i];
                    }
                }
            });

            Thread t4 = new Thread(() =>
            {
                for (int i = 0; i < 25000; i++)
                {
                    lock (lockObject)
                    {
                        sumArrayNumbers += numbers[i];
                    }
                }
            });
            
            Thread checkThread = new Thread(() =>
            {
                
            });



            Console.ReadKey();


        }
    }
}