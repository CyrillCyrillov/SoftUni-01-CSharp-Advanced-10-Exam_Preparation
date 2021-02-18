using System;
using System.Collections.Generic;
using System.Linq;

namespace Task01_Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>();
            foreach (int number in Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
            {
                lilies.Push(number);
            }

            Queue<int> roses = new Queue<int>();
            foreach (int number in Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
            {
                roses.Enqueue(number);
            }

            int wreathsCount = 0;
            int storedFlowers = 0;
            while (roses.Count > 0 && lilies.Count > 0)
            {
                int curentLilie = lilies.Pop();
                int curentRose = roses.Dequeue();

                int curentSum = curentLilie + curentRose;

                if (curentSum == 15)
                {
                    wreathsCount++;
                    continue;
                }

                if (curentSum < 15)
                {
                    storedFlowers = storedFlowers + curentSum;
                    continue;
                }
                
                while (curentSum > 15)
                {
                    curentLilie -= 2;
                    curentSum = curentLilie + curentRose;

                    if (curentSum == 15)
                    {
                        wreathsCount++;
                        continue;
                    }
                    
                    if(curentSum < 15)
                    {
                        storedFlowers += curentSum;
                        continue;
                    } 
                }

                //storedFlowers = storedFlowers + curentSum;
            }


            wreathsCount += storedFlowers / 15;

            if(wreathsCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCount} wreaths more!");
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
