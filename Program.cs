using System;

namespace Time_Calculator
{
    class Program
    {
        const int HOUR = 60;
        const int HALFDAY = 12;
        static void Main(string[] args)
        {
            int choice, mins, custom_hour, custom_mins;
            DateTime dt = DateTime.Now;
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1. Calculate using current time.");
            Console.WriteLine("2. Calculate using custom time.");
            choice = Int32.Parse(Console.ReadLine());
            while(choice <= 0 || choice > 2)
            {
                Console.WriteLine("Select an option: ");
                Console.WriteLine("1. Calculate using current time.");
                Console.WriteLine("2. Calculate using custom time.");
                choice = Int32.Parse(Console.ReadLine());
            }
            Console.Write("Enter the minutes you want to calculate: ");
            mins = Int32.Parse(Console.ReadLine());
            // AddMinutes(150, 1, 20);
            // SubtractMinutes(150, 3, 0);
            
            switch (choice)
            {
                case 1:
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

                    if(operation == 1)
                    {
                        var result = dt.AddMinutes(mins);
                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("lol! I haven't got the time figured out how to" +
                        "subtract minutes from a DateTime object");
                    }
                    break;
                case 2:
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
                    operation = Int32.Parse(Console.ReadLine());
                    while (operation <= 0 || operation > 2)
                    {
                        Console.WriteLine("Invalid operation! What operation do you wish to perform?");
                        Console.WriteLine("1. Add");
                        Console.WriteLine("2. Subtract");
                    }

                    if (operation == 1)
                    {
                        AddMinutes(mins, custom_hour, custom_mins);
                    }
                    else 
                    {
                        SubtractMinutes(mins, custom_hour, custom_mins);
                    }
                    break;
                default:
                    Console.WriteLine("Wrong operation! Restart the program to calculate.");
                    break;
            }
        }

        static void AddMinutes(int mins, int custom_hour, int custom_mins) 
        {
            custom_hour += (int)mins / HOUR;
            custom_mins += mins % HOUR;
            if (custom_mins >= HOUR) 
            {
                custom_hour += (int)custom_mins / HOUR;
                custom_mins = custom_mins % HOUR;
            }
            Console.WriteLine("Time will be: " + custom_hour + ":" + (custom_mins < 10 ? "0" + custom_mins : custom_mins));
        }

        static void SubtractMinutes(int mins, int custom_hour, int custom_mins) 
        {
            custom_mins -= mins % HOUR;
            if (custom_mins < 0)
            {
                custom_mins += HOUR;
                custom_hour--;
            }

            custom_hour -= (int)mins / HOUR;
            if (custom_hour < 0)
            {
                custom_hour += HALFDAY;
            }
            Console.WriteLine("Time will be: " + custom_hour + ":" + (custom_mins < 10 ? "0" + custom_mins : custom_mins));
        }
    }
}
