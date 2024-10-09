using System;
using System.Security.Cryptography;

public class Prompt
{
    List<string> _promptList = new()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today",
            "Whats was the strongest emotion I felt today",
            "If I had one thing I could do over today, what would it be?",
            "What is one act of service I did today?"
        };
    
    public string RandomPrompt()
    {
        Random randomGenerator = new();
        int promptIndex = randomGenerator.Next(_promptList.Count);

        return _promptList[promptIndex];
    }
}