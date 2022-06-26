using System;

namespace Time_Calculator
{
    class Program
    {
        const int HOUR = 60;
        const int HALFDAY = 12;
        static void Main(string[] args)
        {
            int mins, custom_hour, custom_mins;
            
            Console.Write("Enter the minutes you want to calculate: ");
            mins = Int32.Parse(Console.ReadLine());
            do
            {
                Console.Write("Enter your custom hour (12-hour time): ");
                custom_hour = Int32.Parse(Console.ReadLine());
            } while(custom_hour < 0 || custom_hour > 12);

            do
            {
                Console.Write("Enter your custom minutes: ");
                custom_mins = Int32.Parse(Console.ReadLine());
            } while(custom_mins < 0 || custom_mins > 60);
            
            Console.WriteLine("\nWhat operation do you wish to perform?");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            int operation = Int32.Parse(Console.ReadLine());
            while (operation <= 0 || operation > 2)
            {
                Console.WriteLine("Invalid operation! What operation do you wish to perform?");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
            }

            switch (operation)
            {
                case 1: 
                    AddMinutes(mins, custom_hour, custom_mins);
                    break;
                case 2:
                    SubtractMinutes(mins, custom_hour, custom_mins);
                    break;
                default:
                    break;
            }
        }

        static void AddMinutes(int mins, int custom_hour, int custom_mins) 
        {
            custom_hour += (int)mins / HOUR;
            custom_mins += mins % HOUR;
            if (custom_mins >= HOUR) 
            { // minutes cannot be greater than 60 so convert again to hours and get the remainder
                custom_hour += (int)custom_mins / HOUR;
                custom_mins = custom_mins % HOUR;
            }
            Console.WriteLine("Time will be: " + custom_hour + ":" + (custom_mins < 10 ? "0" + custom_mins : custom_mins));
        }

        static void SubtractMinutes(int mins, int custom_hour, int custom_mins) 
        {
            custom_mins -= mins % HOUR;
            if (custom_mins < 0)
            { // minutes cannot be less than 0 so add 60 to normalize
                custom_mins += HOUR;
                custom_hour--; // decrement because minutes just became less than 0
            }

            custom_hour -= (int)mins / HOUR;
            if (custom_hour < 0)
            { // hour cannot be less than zero
                custom_hour += HALFDAY;
            }
            Console.WriteLine("Time will be: " + custom_hour + ":" + (custom_mins < 10 ? "0" + custom_mins : custom_mins));
        }
    }
}
