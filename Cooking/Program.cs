using System;
using System.Linq;
using System.Collections.Generic;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>();
            int[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (int element in data)
            {
                liquids.Enqueue(element);
            }
            
            Stack<int> ingredient = new Stack<int>();
            data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (int element in data)
            {
                ingredient.Push(element);
            }

            /*

            Bread	25
            Cake	50
            Pastry	75
            Fruit Pie	100


            */

            Dictionary<string, int> productsPlane = new Dictionary<string, int>();
            productsPlane.Add("Bread", 0);
            productsPlane.Add("Cake", 0);
            productsPlane.Add("Pastry", 0);
            productsPlane.Add("Fruit Pie", 0);

            while (liquids.Count > 0 && ingredient.Count > 0)
            {
                int curentLiquids = liquids.Dequeue();
                int curentIngredients = ingredient.Pop();

                int mix = curentIngredients + curentLiquids;

                switch (mix)
                {
                    case 25:
                        productsPlane["Bread"]++;
                        break;

                    case 50:
                        productsPlane["Cake"]++;
                        break;

                    case 75:
                        productsPlane["Pastry"]++;
                        break;

                    case 100:
                        productsPlane["Fruit Pie"]++;
                        break;

                    default:
                        ingredient.Push(curentIngredients + 3);
                        break;
                }
            }

            int productsTypeCount = 0;
            foreach (var element in productsPlane)
            {
                if(element.Value > 0)
                {
                    productsTypeCount++;
                }
            }

            if (productsTypeCount == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            Console.Write("Liquids left: ");
            if (liquids.Count == 0)
            {
                Console.WriteLine("none");
            }
            else
            {
                Console.WriteLine(string.Join(',', liquids));
                Console.WriteLine();
            }

            Console.Write("Ingredients left: ");
            if (ingredient.Count == 0)
            {
                Console.WriteLine("none");
            }
            else
            {
                Console.WriteLine(string.Join(", ", ingredient));
            }

            foreach (var element in productsPlane.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
