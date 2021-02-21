using System;
using System.Collections.Generic;
using System.Linq;


namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            char[,] bakeryField = new char[dimentions, dimentions];
            
            List<int> oPositions = new List<int>(); // O1 -> [0],[1]  O2 -> [2],[3]
            
            int[] sPosition = new int[2]; // ROW -> [0]   COLUMN -> [1]

            for (int i = 0; i <= dimentions - 1; i++) // ********* ROWS
            {
                string dataLines = Console.ReadLine();
                for (int j = 0; j <= dimentions - 1; j++) // ****** COLUMNS
                {
                    bakeryField[i, j] = dataLines[j];
                    if(dataLines[j] == 'O')
                    {
                        oPositions.Add(i);
                        oPositions.Add(j);
                    }

                    if (dataLines[j] == 'S')
                    {
                        sPosition[0] = i;
                        sPosition[1] = j;
                    }
                }
            }

            int totalMoney = 0;
            bool isOut = false;
            while (true)
            {
                
                string moveDirection = Console.ReadLine();

                bakeryField[sPosition[0], sPosition[1]] = '-';

                switch (moveDirection)
                {
                    case "left":
                        sPosition[1]--;
                        if (sPosition[1] < 0) isOut = true;
                        break;

                    case "right":
                        sPosition[1]++;
                        if (sPosition[1] > dimentions - 1) isOut = true;
                        break;

                    case "up":
                        sPosition[0]--;
                        if (sPosition[0] < 0) isOut = true;
                        break;
                   
                    case "down":
                        sPosition[0]++;
                        if (sPosition[0] > dimentions - 1) isOut = true;
                        break;
                    
                    default:
                        break;
                }

                if (isOut)  // ************************************************** OUT of Bakery 
                {
                    Console.WriteLine("Bad news, you are out of the bakery."); //  OUT of Bakery 
                    break; 
                }
                    
                    

                char target = bakeryField[sPosition[0], sPosition[1]];

                switch (target)
                {
                    case 'O':
                        bakeryField[sPosition[0], sPosition[1]] = '-';
                        oPositions.Remove(sPosition[0]);
                        oPositions.Remove(sPosition[1]);
                        sPosition[0] = oPositions[0]; 
                        sPosition[1] = oPositions[1];
                        bakeryField[sPosition[0], sPosition[1]] = 'S';
                        break;

                    case '-':
                        bakeryField[sPosition[0], sPosition[1]] = 'S';
                        break;
                    
                    default:
                        int toAdd = int.Parse(target.ToString());
                        totalMoney += toAdd;
                        bakeryField[sPosition[0], sPosition[1]] = 'S';
                        break;
                }

                if (totalMoney >= 50) // ************************************************** GOT the Money
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }

            Console.WriteLine($"Money: {totalMoney}");


            // ************* PRINT the Bakery

            for (int i = 0; i <= dimentions - 1; i++) // ********* ROWS
            {
                for (int j = 0; j <= dimentions - 1; j++) // ****** COLUMNS
                {
                    Console.Write(bakeryField[i, j]);
                }
                Console.WriteLine();
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
