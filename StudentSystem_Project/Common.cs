using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_Project
{
    internal static class Common
    {
        public static string PersonalCodeParse()
        {
           
            bool succes = false;
            string input;
            do
            {
                Console.Write("Enter Personal Code: ");
                input = Console.ReadLine();
                if (input.Length > 20)
                {
                    Console.WriteLine("Code is to long");                    
                }               
                else
                {
                    succes = true;
                }

            } while (!succes);
            return input;

        }
        public static int IntParse()
        {
            bool succes = false;
            int number;
            do
            {
                var input = Console.ReadLine();
               
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Wrong input");
                }
                else
                {
                    succes = true;
                }

            } while (!succes);
            return number;

        }
        public static void ShowItems<T>(List<T> items)
        {
            int j = 1;
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"[{j++}] - {items[i]}");
            }
        }
        public static T TryGetItem<T>(List<T> values, int index)
        {
            index -= 1;
            T value = default;
            try
            {
                value = values[index];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Selection was out of range");
            }
            return value;
        }
        public static bool Disclaimer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Disclaimer! Changing student department, will couse all student's lectures to be assigned to a department lectures by default");
            Console.ResetColor();
            Console.WriteLine("Press enter to continue or any key to cancel");
            return Console.ReadKey().Key == ConsoleKey.Enter;
        }
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
