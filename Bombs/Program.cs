using System;
using System.Linq;
using System.Collections.Generic;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>();
            int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (int number in data)
            {
                effects.Enqueue(number);
            }

            Stack<int> casings = new Stack<int>();
            data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (int number in data)
            {
                casings.Push(number);
            }

            Dictionary<string, int> bombPouches = new Dictionary<string, int>();
            bombPouches.Add("Datura Bombs", 0);
            bombPouches.Add("Cherry Bombs", 0);
            bombPouches.Add("Smoke Decoy Bombs", 0);

            bool isBbombPouchesFull = false;
            int curentEffect = 0;
            int curentCasing = 0;

            while (effects.Count > 0 && casings.Count > 0)
            {
                if(curentEffect == 0)
                {
                    curentEffect = effects.Dequeue();
                    curentCasing = casings.Pop();
                }

                int curentCombination = curentCasing + curentEffect;

                switch (curentCombination)
                {
                    /*
                    
                    •	Datura Bombs: 40
                    •	Cherry Bombs: 60
                    •	Smoke Decoy Bombs: 120


                    */

                    case 40:
                        bombPouches["Datura Bombs"]++;
                        curentEffect = 0;
                        curentCasing = 0;
                        break;

                    case 60:
                        bombPouches["Cherry Bombs"]++;
                        curentEffect = 0;
                        curentCasing = 0;
                        break;

                    case 120:
                        bombPouches["Smoke Decoy Bombs"]++;
                        curentEffect = 0;
                        curentCasing = 0;
                        break;

                    default:
                        curentCasing -= 5;
                        break;
                }

                if (bombPouches["Datura Bombs"] >= 3 && bombPouches["Cherry Bombs"] >= 3 && bombPouches["Smoke Decoy Bombs"] >= 3)
                {
                    isBbombPouchesFull = true;
                    break;
                }
            }

            if(isBbombPouchesFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if(effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.Write("Bomb Effects: ");
                Console.WriteLine(string.Join(", ", effects));
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.Write("Bomb Casings: ");
                Console.WriteLine(string.Join(", ", casings));
            }

            foreach (var element in bombPouches.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }



            //Console.WriteLine("Hello World!");
        }
    }
}
