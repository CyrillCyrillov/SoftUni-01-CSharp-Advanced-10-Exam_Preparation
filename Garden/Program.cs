using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int columns = dimentions[1];

            int[,] garden = new int[rows, columns];

            for (int i = 0; i <= rows - 1; i++)
            {
                for (int j = 0; j <= columns - 1; j++)
                {
                    garden[i, j] = 0;
                }

            }

            string comand = null;
            while ((comand = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] newFlower = comand.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int curentRow = newFlower[0];
                int curentColumn = newFlower[1];

                if(curentRow < 0 || curentRow > rows - 1 || curentColumn < 0 || curentColumn > columns - 1)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int i = 0; i <= columns - 1; i++)
                {
                    garden[curentRow, i]++;
                }
                for (int i = 0; i <= rows - 1; i++)
                {
                    garden[i, curentColumn]++;
                }

                garden[curentRow, curentColumn] = 1;
            }


            for (int i = 0; i <= rows - 1; i++) // ********* ROWS
            {
                for (int j = 0; j <= columns -1; j++) // ****** COLUMNS
                {
                    Console.Write(garden[i, j]);
                    if(j < columns - 1)
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
