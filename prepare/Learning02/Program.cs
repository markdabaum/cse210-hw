using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Micron";
        job1._jobTitle = "Test Engineer Intern";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new();
        job2._company = "Broulims";
        job2._jobTitle = "Nighttime Supervisor";
        job2._startYear = 2023;
        job2._endYear = 2024;
        
        Resume myResume = new();
        myResume._name = "Mark";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.DisplayResume();
        
    }
}