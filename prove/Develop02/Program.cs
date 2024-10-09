using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.IO;
using System.IO.Enumeration;

class Program
{

// This is where the user does most of their writing.
    static void Write(Prompt prompt, Journal journal)
    {
        Entry entry = new();

// Gives the user a prompt from the prompt class
        string userPrompt = prompt.RandomPrompt();
        Console.WriteLine($"{userPrompt}");
        Console.Write("> ");

// Adding info to the entry class.
        entry._entrydate = DateTime.Now.ToString("M/d/yyyy");
        entry._entryPrompt = userPrompt;
        entry._entryResponse = Console.ReadLine();

// Records the user input and adds it to a list in the journal class
        entry.GetInput();
        journal._entries.Add(entry);
    }

// Displayes the loaded file(if hasLoaded) along with the users current entries
    static void Display(Journal journal)
    {
        journal.DisplayEntries();
    }

// Loads the user given file
    static void Load(Journal journal, bool hasLoaded, string filename)
    {
        if (hasLoaded)
        {
            bool overwrite;
            Console.Write("This will overwrite any additions from this session\nWould you like to continue? (y/n) ");
            overwrite = Console.ReadLine() == "y";

            if (overwrite)
            {
                journal._entries = [];
                Console.WriteLine("What is the name of the file?");
                filename = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Load cancelled");
                return;
            }
        }

        string[] lines = System.IO.File.ReadAllLines(filename);
        
        for (int i = 0; i < lines.Length; i += 3)
        {
// Assuming the user loads a file with the correct format, this will properly separate each line
            Entry entry = new();
            string output = lines[i];
            string input = lines[i+1];
            string blank = (i + 2 < lines.Length) ? lines[i+2] : "";
// Adds each entry from the user file to the journal class to be added onto.
            entry._fullEntry = $"{output}\n{input}";
            journal._entries.Add(entry);
        }

    }

    static void Save(Journal journal, bool hasLoaded, string filename)
    {
// If the user has not yet loaded a file, this will load the file to save the new information to it
// instead of simply overwriting the file.
        if (!hasLoaded)
            {
                Console.WriteLine("What is the name of the file?");
                filename = Console.ReadLine();
                if (System.IO.File.Exists(filename))
                    Load(journal, hasLoaded, filename);    
            }

// Saves the file
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry i in journal._entries)
                outputFile.WriteLine($"{i._fullEntry}\n");
        }
        Console.WriteLine($"{filename} has been saved");
    }

    static void Main(string[] args)
    {

// Setting up Variables, Classes and the such.
        Prompt prompt1 = new();
        Journal journal1 = new();

        bool hasLoaded = false;
        string filename = "";

        List<string> menuOptions = new()
            {"1. Write", 
            "2. Display", 
            "3. Load",
            "3. Save", 
            "4. Quit"};
        int input;

        Console.Write("Would you like to load from a preexisting file? (y/n) ");
        string toLoad = Console.ReadLine();

// If the user decides to load a file, they will be sent here
        if (toLoad == "y")
        {
            do{
                Console.WriteLine("What is the name of the file?");
                filename = Console.ReadLine();

                if (File.Exists(filename))
                {
                Load(journal1, hasLoaded, filename);
                hasLoaded = true;
                }

                else
                    Console.WriteLine("Invalid file name");
                    
            } while (!File.Exists(filename));
        }

// This is the menu selection dowhile loop. The user will spend the rest of their time
// With this application here.
        do{
            Console.WriteLine("Please select on of the following choices:");

// Displays the options
            foreach (string str in menuOptions)
            {
                Console.WriteLine($"{str}");
            }    
            Console.Write($"What would you like to do? (1-{menuOptions.Count}) ");
            string i = Console.ReadLine();
            input = int.Parse(i);

// Sends them on their way.
            if (input == 1)
                Write(prompt1, journal1);
            else if (input == 2)
                Display(journal1);
            else if (input == 3)
                Load(journal1, hasLoaded, filename);
            else if (input == 4)
                Save(journal1, hasLoaded, filename);
            else
                Console.WriteLine("GoodBye");
        }while (input != menuOptions.Count);
    }
}