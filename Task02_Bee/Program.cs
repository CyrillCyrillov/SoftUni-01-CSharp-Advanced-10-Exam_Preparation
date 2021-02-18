using System;
using System.Linq;

namespace Task02_Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());

            char[,] field = new char[dimension, dimension];
            int[] beePosition = new int[2] { -1, -1 };

            for (int i = 0; i <= dimension - 1; i++)
            {
                string nextLine = Console.ReadLine();
                for (int j = 0; j <= dimension - 1; j++)
                {
                    field[i, j] = nextLine[j];
                    if(nextLine[j] == 'B')
                    {
                        beePosition[0] = i;
                        beePosition[1] = j;
                    }
                }
            }

            int polinationedFlowers = 0;
            bool isOut = false;
            
            string comand;
            while ((comand = Console.ReadLine().ToUpper()) != "END")
            {

                
                /*
                 (beePosition[0] > 0)
                     && (beePosition[0] < dimension)
                     && (beePosition[1] > 0)
                     && (beePosition[1] < dimension)
                     && 
                 */

                switch (comand.ToUpper())
                {
                    case "UP":
                        if((beePosition[0] - 1) < 0)
                        {
                            isOut = true;
                        }
                        else
                        {
                            field[beePosition[0], beePosition[1]] = '.';
                            beePosition[0]--;
                        }
                        break;

                    case "DOWN":
                        
                        if((beePosition[0] + 1 == dimension))
                        {
                            isOut = true;
                        }
                        else
                        {
                            field[beePosition[0], beePosition[1]] = '.';
                            beePosition[0]++;
                        }
                        break;

                    case "LEFT":
                        if ((beePosition[1] - 1) < 0)
                        {
                            isOut = true;
                        }
                        else
                        {
                            field[beePosition[0], beePosition[1]] = '.';
                            beePosition[1]--;
                        }
                        break;

                    case "RIGHT":
                        if ((beePosition[1] + 1) == dimension)
                        {
                            isOut = true;
                        }
                        else
                        {
                            field[beePosition[0], beePosition[1]] = '.';
                            beePosition[1]++;
                        }
                        break;

                    default:
                        break;
                }

                if(isOut == true)
                {
                    break;
                }
                //else
                //{
                //    field[beePosition[0], beePosition[1]] = 'B';
                //}

                
                
                char type = field[beePosition[0], beePosition[1]];

                switch (type)
                {
                    case 'f':
                        polinationedFlowers++;
                        field[beePosition[0], beePosition[1]] = 'B';
                        break;

                    case 'O':

                        switch (comand.ToUpper())
                        {
                            case "UP":
                                if (field[(beePosition[0] - 1), beePosition[1]] == 'f')
                                {
                                    polinationedFlowers++;
                                }
                                
                                    field[beePosition[0], beePosition[1]] = '.';
                                    beePosition[0]--;
                                
                                break;

                            case "DOWN":

                                if (field[(beePosition[0] + 1), beePosition[1]] == 'f')
                                {
                                    polinationedFlowers++;
                                }
                                
                                    field[beePosition[0], beePosition[1]] = '.';
                                    beePosition[0]++;
                                
                                break;

                            case "LEFT":
                                if (field[(beePosition[1] - 1), beePosition[1]] == 'f')
                                {
                                    polinationedFlowers++;
                                }
                                
                                    field[beePosition[0], beePosition[1]] = '.';
                                    beePosition[1]--;
                                
                                break;

                            case "RIGHT":
                                if (field[(beePosition[1] + 1), beePosition[1]] == 'f')
                                {
                                    polinationedFlowers++;
                                }
                                
                                    field[beePosition[0], beePosition[1]] = '.';
                                    beePosition[1]++;
                                
                                break;

                            default:
                                break;
                        }

                        break;

                    case '.':
                        field[beePosition[0], beePosition[1]] = 'B';
                        break;

                    default:
                        break;
                }

                /*
                Console.WriteLine();
                Console.WriteLine("********************************************");
                Console.WriteLine();

                for (int i = 0; i <= dimension - 1; i++)
                {
                    for (int j = 0; j <= dimension - 1; j++)
                    {
                        Console.Write(field[i, j]);
                    }
                    Console.WriteLine();
                }

                */


            }

            field[beePosition[0], beePosition[1]] = 'B';
            if (isOut == true)
            {
                field[beePosition[0], beePosition[1]] = '.';
                Console.WriteLine("The bee got lost!");
            }
            if(polinationedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinationedFlowers} flowers more");
            }

            for (int i = 0; i <= dimension - 1; i++)
            {
                for (int j = 0; j <= dimension - 1; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
