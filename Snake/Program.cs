using System;
using System.Linq;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            char[,] field = new char[dimention, dimention];
            int[] snakePosition = new int[2]; // { -1, -1 }; ROW -> [0]  COLUMN -> [1]
            List<int> bPositions = new List<int>(); //  B1 -> [0, 1]  B2 -> [2, 3]

            for (int i = 0; i <= dimention - 1; i++)
            {
                string nextLine = Console.ReadLine();
                for (int j = 0; j <= dimention - 1; j++)
                {
                    field[i, j] = nextLine[j];
                    if(field[i, j] == 'S')
                    {
                        snakePosition[0] = i;
                        snakePosition[1] = j;
                    }
                    if(field[i, j] == 'B')
                    {
                        bPositions.Add(i);
                        bPositions.Add(j);
                    }
                }
            }

            int food = 0;
            bool isOut = false;
           
            while (food < 10)
            {
                string comand = Console.ReadLine();

                field[snakePosition[0], snakePosition[1]] = '.';

                switch (comand.ToUpper())
                {
                    case "LEFT":
                        snakePosition[1]--;
                        if (snakePosition[1] < 0)
                        { 
                            isOut = true;
                        }
                        break;

                    case "RIGHT":
                        snakePosition[1]++;
                        if (snakePosition[1] > dimention - 1)
                        {
                            isOut = true;
                        }
                        break;

                    case "UP":
                        snakePosition[0]--;
                        if (snakePosition[0] < 0)
                        {
                            isOut = true;
                        }
                        break;

                    case "DOWN":
                        snakePosition[0]++;
                        if (snakePosition[0] > dimention - 1)
                        {
                            isOut = true;
                        }
                        break;

                    default:
                        break;
                }

                if(isOut)
                {
                    break;
                }

                char newPosition = field[snakePosition[0], snakePosition[1]];

                switch (newPosition)
                {
                    case '*':
                        food++;
                        field[snakePosition[0], snakePosition[1]] = 'S';
                        break;

                    case 'B':
                        field[snakePosition[0], snakePosition[1]] = '.';
                        bPositions.Remove(snakePosition[0]);
                        bPositions.Remove(snakePosition[1]);
                        snakePosition[0] = bPositions[0];
                        snakePosition[1] = bPositions[1];
                        field[snakePosition[0], snakePosition[1]] = 'S';
                        break;
                    
                    default:
                        field[snakePosition[0], snakePosition[1]] = 'S';
                        break;
                }
            }

            if(isOut)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {food}");

            // *************** PRINT the FIELD

            for (int i = 0; i <= dimention - 1; i++)
            {
                
                for (int j = 0; j <= dimention - 1; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
