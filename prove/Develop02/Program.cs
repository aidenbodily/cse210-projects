using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;
        
        while (running)
        {
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                
                // Add mood tracking
                Console.Write("How would you rate your mood today? (1-10): ");
                int mood = int.Parse(Console.ReadLine());
                
                string date = DateTime.Now.ToShortDateString();
                Entry entry = new Entry(prompt, response, date, mood);
                journal.AddEntry(entry);
                Console.WriteLine("Entry added!\n");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("Journal saved!");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded!");
            }
            else if (choice == "5")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
        }
    }
}