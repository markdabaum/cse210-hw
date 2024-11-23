using System;
using System.Collections;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

class Program
{
    static void CreateNewGoal(List<string> goalTypes, Goal goals)
    {
        // Switches make a lot of this coding assignment pretty simple.
        Console.WriteLine("The types of Goals are:");
        for (int i=0; i<goalTypes.Count; i++)
            Console.WriteLine($"\t{i+1}. {goalTypes[i]}");

        Console.Write("Which type of goal would you like to create? ");
        int menuChoice = int.Parse(Console.ReadLine());

        switch (menuChoice){
            case 1:
                Simple simple = new();
                simple.CreateGoal();
                goals.AddToList(simple);
                break;
            case 2:
                Eternal eternal = new();
                eternal.CreateGoal();
                goals.AddToList(eternal);
                break;
            case 3:
                Checklist checklist = new();
                checklist.CreateGoal();
                goals.AddToList(checklist);
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }

    static void ListGoals(Goal goals)
    {
        Console.WriteLine("The goals are:");
        List<Goal> goalList = goals.GetList();

        for (int i=0; i<goalList.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {goalList[i].DisplayGoal()}");
        }
        Console.WriteLine();
    }

    static void SaveGoals(int points, Goal goals)
    {
        string fileName = "goals.txt";
        List<Goal> goalList = goals.GetList();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"{points}");
            for (int i=0; i<goalList.Count; i++)
            {
                outputFile.WriteLine(goalList[i].SaveGoal());
            }
            
        }
    }

    static void LoadGoals(ref int points, Goal goals)
    {
        string fileName = "goals.txt";
        string[] lines = System.IO.File.ReadAllLines(fileName);

        points = int.Parse(lines[0]);

        for (int i=1; i<lines.Length; i++)
        {   
            string line = lines[i];
            string[] objects = line.Split(":");

            string type = objects[0];
            string[] attributes = objects[1].Split("|");

            switch (type)
            {
                case "Simple":
                    Simple simple = new();
                    simple.LoadGoal(attributes);
                    goals.AddToList(simple);
                    break;
                case "Eternal":
                    Eternal eternal = new();
                    eternal.LoadGoal(attributes);
                    goals.AddToList(eternal);
                    break;
                case "Checklist":
                    Checklist checklist = new();
                    checklist.LoadGoal(attributes);
                    goals.AddToList(checklist);
                    break;
                default:
                    Console.WriteLine($"Unknown Goal Type: {type}");
                    break;
            }
            
        }

    }

    static void RecordGoals(ref int points, Goal goals)
    {
        int earnedPoints;
        ListGoals(goals);
        int record;
        Console.Write($"Which goal did you accomplish? (1-{goals.GetList().Count}) ");
        record = int.Parse(Console.ReadLine());
        
        earnedPoints = goals.GetList()[record-1].RecordGoal();
        points = points + earnedPoints;

        Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");
        Console.WriteLine($"You now have {points} points.");
    }

    static void Main(string[] args)
    {
        // Setting up variables
        Console.Clear();

        Goal goals = new();
        int points = 0;
        int menuChoice;

        List<string> menu = [
            "Create New Goal",
            "List Goals",
            "Save Goals",
            "Load Goals",
            "Record Event",
            "Quit"
        ];

        List<string> goalTypes = [
            "Simple Goal",
            "Eternal Goal",
            "Checklist Goal"
        ];
        
        // menu implementation
        do{

            Console.WriteLine($"You have {points} points\n");
            Console.WriteLine("Menu Options:");
            for (int i=0; i<menu.Count; i++)
            {
                Console.WriteLine($"\t{i+1}. {menu[i]}");
            }
            Console.Write("Select a choice from the menu: ");
            menuChoice = int.Parse(Console.ReadLine());

            switch (menuChoice){
                case 1:
                    CreateNewGoal(goalTypes, goals);
                    break;
                case 2:
                    ListGoals(goals);
                    break;
                case 3:
                    SaveGoals(points, goals);
                    break;
                case 4:
                    LoadGoals(ref points, goals);
                    break;
                case 5:
                    RecordGoals(ref points, goals);
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }while (menuChoice != menu.Count);
    }
}