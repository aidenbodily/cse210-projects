using System;

class Program
{
    static void Main(string[] args)
    {
        // computational thinking:
        // the 3 steps of computational thinking:
        // 1. break the problem into smaller parts
        // 2. look for repeated or similar steps
        // 3. make a list of steps
        //
        // example for this mindfulness app:
        // 1. break the problem into smaller parts
        //    - i need to show a menu so the user can choose an activity.
        //    - once they choose one, i need to run that activity for the time they enter.
        //
        // 2. look for repeated or similar steps
        //    - every activity starts with the same intro and ends with the same outro.
        //    - each activity also uses a timer/animation while the user is thinking or breathing.
        //
        // 3. make a list of steps
        //    - show menu options.
        //    - read the user's choice.
        //    - create the matching activity object.
        //    - run the activity.
        //    - update and show the session log.
        //    - repeat until user chooses quit.

        // just keeping a simple count for each activity this run
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        bool running = true;
        while (running)
        {
            // basic menu loop
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            if (choice == null)
            {
                choice = "";
            }

            Activity activity = null;

            // choose which activity thingy class to run
            if (choice == "1")
            {
                activity = new BreathingActivity();
            }
            else if (choice == "2")
            {
                activity = new ReflectionActivity();
            }
            else if (choice == "3")
            {
                activity = new ListingActivity();
            }
            else if (choice == "4")
            {
                running = false;
                continue;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Press enter to try again.");
                Console.ReadLine();
                continue;
            }

            // run the selected activity
            activity.Run();

            // update counts after each run
            if (choice == "1")
            {
                breathingCount++;
            }
            else if (choice == "2")
            {
                reflectionCount++;
            }
            else if (choice == "3")
            {
                listingCount++;
            }

            Console.WriteLine("\nSession activity log:");
            Console.WriteLine("- Breathing Activity: " + breathingCount);
            Console.WriteLine("- Reflection Activity: " + reflectionCount);
            Console.WriteLine("- Listing Activity: " + listingCount);

            Console.WriteLine("\nPress enter to return to the menu.");
            Console.ReadLine();
        }
    }
}