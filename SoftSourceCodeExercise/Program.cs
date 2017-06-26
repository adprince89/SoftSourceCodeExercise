using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace SoftSourceCodeExercise
{
    class Program
    {
        private static Timer primeTimer;
        private static int currentPrime;
        private static List<int> primeList;
        private static int elapsedSeconds = 0;
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Press any key to start prime number generation.");

            Console.ReadKey();

           
            primeTimer = new Timer();
            primeTimer.Interval = 1000;
            primeTimer.Elapsed += TimerElapsed;
            //first prime is 2
            currentPrime = 2;
            primeList = new List<int>();
            primeList.Add(currentPrime);
            primeTimer.Start();
            while (true)
            {
                if(elapsedSeconds == 60)
                {
                    break;
                }
                currentPrime = GenerateNextPrime(currentPrime);
               
            }
         
            Console.ReadKey();
        }

        private static void TimerElapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.Out.Write("\r The current largest prime is: " + currentPrime);
            if (elapsedSeconds == 60)
            {
               
                Console.Out.WriteLine("\r\n Completed. Press any key to exit.");
                primeTimer.Stop();
                return;
            }
            elapsedSeconds++;
            
        }

        private static int GenerateNextPrime(int previousPrime)
        {

            bool foundPrime = false;
            int nextPrime = currentPrime;
            while (foundPrime == false)
            {
                //seed the next prime by checking the next odd number
                nextPrime = nextPrime + 2;
                //if we started with 2 we need to go down to 3
                if (nextPrime % 2 == 0)
                {
                    nextPrime = nextPrime - 1;
                }
                //get the square root of the number we want to check
                int sqRoot = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; primeList[i] <= sqRoot; i++)
                {
                    if (nextPrime % primeList[i] == 0)
                    {
                        //not a prime if it's divisible by another number
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeList.Add(nextPrime);
                    foundPrime = true;
                     
                }
            }
            return nextPrime;
        }
       
    }

}
