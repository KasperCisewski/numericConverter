using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zamianaSystemówLiczbowych
{
    class Program
    {
        public static readonly char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'w', 'x', 'y', 'z' };
        static void Main(string[] args)
        {
            startProgram();

        }
        static void startProgram()
        {


            int numberIn=0, number;
            string numbersWithChars;
            Console.WriteLine("enter number system which you want to change (2-31)");
            int systerIn = Int32.Parse(Console.ReadLine());
            if (systerIn > 9)
            {
                Console.WriteLine("enter number in system of {0}", systerIn);
                numbersWithChars = Console.ReadLine();
                var chars = numbersWithChars.ToCharArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    int ASCIChar = chars[i] - '0';
                    if(ASCIChar>=0 && ASCIChar<=9)
                    {
                        numberIn = numberIn + ASCIChar * (int)Math.Pow(systerIn, chars.Length-1-i);
                    }
                    else
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if(chars[i].ToString().ToUpper()==alphabet[j].ToString().ToUpper())
                            {
                                numberIn = numberIn + (j+10) * (int)Math.Pow(systerIn, chars.Length-1-i);
                                break;
                            }
                        }
                    }
                }
                number = numberIn;
            }
            else
            {
                Console.WriteLine("enter number in system {0}",systerIn);
                numberIn = Int32.Parse(Console.ReadLine());
                List<int> tabDigitsInput = new List<int>();
                while(numberIn>0)
                {
                    tabDigitsInput.Add(numberIn % 10);
                    numberIn = numberIn / 10;
                }

                for (int i = 0; i < tabDigitsInput.Count(); i++)
                    numberIn = numberIn + tabDigitsInput[i] * (int)Math.Pow(systerIn, i);


                number = numberIn;

                
            }

         
            
            Console.WriteLine("enter number system which you want to change(2-31)");
            int system = Int32.Parse(Console.ReadLine());

            int lengthArray = (int)(numbersOfDigits(number) * Math.Log(10) / Math.Log(system));
            List<int> tabOfDigits = new List<int>();
            conversionSystems(tabOfDigits, system, number);
            showAfterConversion(tabOfDigits,system);


            
        }
        static int numbersOfDigits(int n)
        {
            int i = 0;
            while (n > 0)
            {
                n = n / 10;
                i++;
            }
            return i;
        }

        static void conversionSystems(List<int> tabOfDigits, int system, int number)
        {
            
            while(number>0)
            {
                tabOfDigits.Add(number % system);
                number = number / system;
                
            }
        }
        static void showAfterConversion(List<int> tabOfDigits,int system)
        {
            for(int i=tabOfDigits.Count()-1;i>=0;i--)
            {
                if(tabOfDigits[i]>9)
                {
                    Console.Write(charOtherNumbers(tabOfDigits, i).ToString().ToUpper());
                }
                else
                {
                    Console.Write(tabOfDigits[i]);
                }
            }
        }

        static char charOtherNumbers(List<int> tabOfDigits, int count)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if(tabOfDigits[count]==i)
                return alphabet[i-10];
            }
            return 'a';

            
           
        }

    }
}
