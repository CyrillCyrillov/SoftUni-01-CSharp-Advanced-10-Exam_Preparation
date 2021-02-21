using System;
using System.Linq;
using System.Collections.Generic;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>();
            
            int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (int element in data)
            {
                tasks.Push(element);
            }


            Queue<int> threads = new Queue<int>();
            
            data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (int element in data)
            {
                threads.Enqueue(element);
            }

            int cpuTask = int.Parse(Console.ReadLine());

            int curentTask = 0;
            int curentThread = 0;
            while (true)
            {
                curentTask = tasks.Pop();
                curentThread = threads.Peek();

                if(curentTask == cpuTask)
                {
                    break;
                }

                if(curentThread >= curentTask)
                {
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                    tasks.Push(curentTask);
                }
            }

            Console.WriteLine($"Thread with value {curentThread} killed task {cpuTask}");

            Console.WriteLine(string.Join(' ', threads));

            //Console.WriteLine("Hello World!");
        }
    }
}
