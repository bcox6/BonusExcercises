using System;
using System.Text.RegularExpressions;

namespace CustomExceptionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string doAnother;
            do
            {
                //try
                //{
                //    Console.Write("Please enter num1: ");
                //    string num1str = Console.ReadLine();
                //    int num1 = int.Parse(num1str);

                //    Console.Write("Please enter num2: ");
                //    string num2str = Console.ReadLine();
                //    int num2 = int.Parse(num2str);

                //    Console.WriteLine("Num1/Num2: {0}", num1 / num2);
                //}
                //catch (FormatException exc)
                //{
                //    Console.WriteLine("Not a number!");
                //}
                //catch (OverflowException exc)
                //{
                //    Console.WriteLine("Number is too large or small!");
                //}


                try
                {
                    Console.Write("Please enter a social security number: ");
                    String userInput = Console.ReadLine();
                    SocialSecurityNumber ssn = new SocialSecurityNumber();
                    ssn.SSN = userInput;
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Error! " + exc.Message + "\nException type: " + exc.GetType());
                }
                finally
                {
                    Console.WriteLine("This section always excecutes!");
                }

                Console.Write("Do another (y/n): ");
                doAnother = Console.ReadLine();

            } while (doAnother == "y");
        }
    }
    class SocialSecurityNumber
    {
        private string ssn;

        public string SSN
        {
            get { return ssn; }
            set
            {
                string pattern = @"^\d{3}-\d{2}-\d{4}$";

                if (Regex.IsMatch(value, pattern))
                {
                    ssn = value;
                }
                else
                {
                    //throw new Exception();
                    //throw new FormatException("Not a valid Social Social Security Number");
                    throw new SSNFormatException();
                }
            }
        }
    }
    class SSNFormatException : Exception
    {
        public SSNFormatException() : base("Not a valid Social Social Security Number.")
        {
        }
    }
}
