using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_1._3_Godtycklig_lönerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                // Anropar metoden ReadInt() som läser in antalet löner man vill mata in
                int numberOffPay = ReadInt("Skriv in antal löner: ");

                // Om antalet löner är större än två så anropas metoden ProcessSalaries och antal löner skickas med som argument
                if (numberOffPay >= 2) 
                {
                    ProcessSalaries(numberOffPay);
                }
                else 
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning.");
                    Console.ResetColor();
                }

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck vilken tangent som helst för ny beräkning, escape för att avsluta.");
                Console.ResetColor();
             } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        
        static int ReadInt(string message) // Skriver ut ett meddelande, läser in värden och retunerar dem till andra metoder
        {
            int tempNumber = 0;
            while (true) 
            {
                try 
                { 
                   Console.Write(message);
                    tempNumber = int.Parse(Console.ReadLine());
                    return tempNumber;                                    
                 }
                catch  // Felmeddlande om det inte är ett heltal, och möjlighet att mata in nytt värde
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(String.Format("FEL! {0} kan inte tolkas som ett heltal.", tempNumber));
                    Console.ResetColor();
                }
            }
        }



        static void ProcessSalaries(int numberOffPay)
        {
            int[] payList = new int[numberOffPay];  // Skapar en array med lika många värden som numberOffPay

            while (true)
            {
                try
                {
                    for (int i = 0, y = 1; i < payList.Length; i++, y++)
                    {
                        payList[i] = ReadInt(String.Format("Ange lön nr {0}: ", y));                                       
                    }
                    break;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Du måste ange ett heltal.");
                    Console.ResetColor();
                }
            }
            
            Console.WriteLine("--------------------------------");

            // Beräkna medellön
            double averagePay = payList.Average();
            
            // Beräkna lönespridning - skillnaden mellan den högsta och lägsta lönen?
            double lowestPay = payList.Min();
            double highestPay = payList.Max();
            double differenceInPay = highestPay - lowestPay;
            
            // Beräkna medianlön
            int[] copyPayList = new int[numberOffPay]; // Skapar en array med lika många värden som payList

            Array.Copy(payList, copyPayList, numberOffPay); // Kopierar värdena hos payList till copyPayList

            Array.Sort(payList); // Sorterar paylist

            
            // Sedan hittar man positionen för det mittersta värdet
            int middlePay = numberOffPay / 2;

            if (numberOffPay % 2 == 0) // Om antal löner är jämnt, slå ihop de två mittvärdena, dela med 2 och skriv ut värdet 
            {
                int otherValue = (numberOffPay / 2) - 1;
                int value1 = payList[middlePay];
                int value2 = payList[otherValue];
                middlePay = (value1 + value2) / 2;
                Console.WriteLine("Medianlön: {0, 10:C0}", middlePay);
            }
            else // Annars, om antal löner är ojämnt, skriv ut det mittersta värdet
            {
                middlePay = payList[middlePay];
                Console.WriteLine("Medianlön:    {0, 10:C0}", middlePay);
            }

            // Avrundar till heltal
            averagePay = (int)Math.Round(averagePay, 0);
            differenceInPay = (int)Math.Round(differenceInPay, 0);

            // Presentera medellönen
            Console.WriteLine("Medellön:     {0, 10:C0}", averagePay);

            // Presentera lönespridningen
            Console.WriteLine("Lönespridning: {0, 10:C0}", differenceInPay);

            Console.WriteLine("--------------------------------");
                    
            // Presentera den ursprungliga osorterade lönelistan

            for (int i = 0, y = 1; i < copyPayList.Length; i++, y++)
            {
                Console.Write(" {0, 10}", copyPayList[i]);

                if (y % 3 == 0) 
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }


        
    }
}
