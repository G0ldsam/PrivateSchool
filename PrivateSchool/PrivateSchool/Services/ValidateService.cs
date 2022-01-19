using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB.Services
{
    class ValidateService
    {

        public string GetOnlyString(string String, int minLength)
        {

            string userInput;
            bool isValid = false;
            int error = 0;
            do
            {

                Console.WriteLine($"Please enter {String} " + ((error > 0) ? $"\n(Input can be only Letters and Length must be larger than {minLength} characters)" : " :"));
                userInput = Console.ReadLine();
                error++;
                isValid = String.Length >= minLength;

            } while (!isValid || !userInput.All(Char.IsLetter));
            return userInput;
        }

        public DateTime CheckDate(string Type)
        {
            Console.WriteLine($"Enter {Type} (dd/mm/yyyy)");
            string userInput = Console.ReadLine();
            CultureInfo culture = new CultureInfo("el-EL");
            while (!(DateTime.TryParse(userInput,out _)))
            {
                Console.WriteLine("Invalid input. Try again (dd/mm/yyyy)");
                userInput = Console.ReadLine();
            }
            DateTime result = DateTime.Parse(userInput, culture);
            return result;
        }

        public int GetInt(string String, int min, int max)
        {
            int userInput;
            bool isValid = false;
            do
            {
                Console.WriteLine($"Please enter {String}({min}-{max}): ");
                isValid = int.TryParse(Console.ReadLine(), out userInput);
            } while (!isValid || userInput < min || userInput > max);    //Set acceptable tuition costs range
            return userInput;
        }

        public string GetString(string String, int minLength)
        {

            string userInput;
            bool isValid = false;
            int error = 0;
            do
            {

                Console.WriteLine($"Please enter {String} " + ((error > 0) ? $"\n(Length must be larger than {minLength} characters)" : " :"));
                userInput = Console.ReadLine();
                error++;
                isValid = String.Length >= minLength;

            } while (!isValid);
            return userInput;
        }

        public string CheckStream()
        {
            List<string> stream = new List<string> {"CSHARP", "JAVA","JAVASCRIPT","PYTHON"};
            string userInput;
            bool isValid = false;
            int error = 0;
            do
            {

                Console.WriteLine($"Please enter Stream " + ((error > 0) ? $"\n(CSHARP , JAVA, JAVASCRIPT , PYTHON)" : " :"));
                userInput = Console.ReadLine();
                error++;
                isValid = stream.Contains(userInput.ToUpper());

            } while (!isValid);

            return userInput;
        }

        public string CheckType()
        {
            List<string> stream = new List<string> { "FULLTIME", "PARTTIME"};
            string userInput;
            bool isValid = false;
            int error = 0;
            do
            {

                Console.WriteLine($"Please enter Type " + ((error > 0) ? $"\n(FULLTIME or PARTTIME)" : " :"));
                userInput = Console.ReadLine();
                error++;
                isValid = stream.Contains(userInput.ToUpper());

            } while (!isValid);

            return userInput;
        }

        public int CheckIntInList()
        {
            using(School schoolDb = new School())
            {

                List<int> validIDs = schoolDb.courses.Select(c => c.course_id).ToList();
                bool isValid;
                int userInput;
                int error = 0;
                do
                {
                        Console.WriteLine("Please choose course Id "+ ((error > 0) ? $"\nInvalid input.Please enter a valid Course": ":"));
                        isValid = int.TryParse(Console.ReadLine(), out  userInput);
                        error++;


                } while (!isValid || !validIDs.Contains(userInput));


            return userInput;
            }
        }

        //public DateTime GetDate(string Type)
        //{
        //    Console.WriteLine($"Enter {Type} (dd/mm/yyyy)");
        //    string userInput = Console.ReadLine();
        //    CultureInfo culture = new CultureInfo("el-GR");
        //    while (!(DateTime.TryParse(userInput, out _)))
        //    {
        //        Console.WriteLine("Invalid input. Try again (dd/mm/yyyy)");
        //        userInput = Console.ReadLine();
        //    }
        //    DateTime result = DateTime.Parse(userInput, culture);
        //    return result;
        //}
    }
}
