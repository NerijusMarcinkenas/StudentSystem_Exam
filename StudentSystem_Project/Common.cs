using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_Project
{
    internal static class Common
    {
        public static ulong PersonalCodeParse(string input)
        {
            bool succes = false;
            ulong parsedCode;
            do
            {
                if (input.Length > 19)
                {
                    Console.WriteLine("Code is to long");                    
                }
                if (!ulong.TryParse(input, out parsedCode))
                {
                    Console.WriteLine("Wrong input");                   
                }
                else
                {
                    succes = true;
                }

            } while (!succes);
            return parsedCode;

        }
        public static int IntParse()
        {
            var input = Console.ReadLine();
            bool succes = false;
            int number;
            do
            {               
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
                Console.WriteLine($"[{j}] - {items[i]}\n");
            }
        }
    }
}
