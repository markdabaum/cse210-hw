using System.Formats.Asn1;
// By far the most complicated class.
public class Scripture
{
    private string _script;
    private string[] _scriptL;
    private List<Word> _scriptW = new();

    public Scripture()
    {
        // Preset construct.
        _script = "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man.";
    
    /* This splits the list into an array, and then 
    converts that array into a list of Word objects.*/
        _scriptL = _script.Split(" ");
        for (int i=0; i<_scriptL.Length; i+=1)
        {
           Word word = new($"{_scriptL[i]}", false);
           _scriptW.Add(word);
        }
    }

    public Scripture(string script)
    {
    // The exact same as the previous, but with user input
        _script = script;

        _scriptL = _script.Split(" ");
        for (int i=0; i<_scriptL.Length; i+=1)
        {
           Word word = new($"{_scriptL[i]}", false);
           _scriptW.Add(word);
        }
    }

    public void DisplayScripture()
    {
    /*It was necessary to display the scripture in this way
    because having each word as an object allows the program
    to check if the word has been blanked and to easily modify
    each word without needing to save the full scripture as a
    new string everytime.*/
        foreach (Word i in _scriptW)
        {
            Console.Write($"{i.DisplayWord()} ");
        }
        Console.WriteLine("\n");
    }

/*This method is part of my exceeding requirements. It no joke,
saved probably over 40 lines of code in Program.cs*/
    public string GetScript()
    {
        return _script;
    }

// Simple method to check if all the words in the scripture are blank
    public bool AllBlank()
    {
        int notblank = _scriptW.Count;

        foreach (Word word in _scriptW)
        {
            if (word.GetBlank())
                notblank -= 1;
        }

        if (notblank == 0)
            return true;
        else
            return false;
    }
    
    public void HideWords()
    {
        
        int success = 0;

/*This while loop does like 90% of the work in this program. 
And I feel like it's fairly self explanatory. We get a random index,
check to see if that index has already been blanked. If not, then we
successfully found a non-blank word. We hide it and move on. We then 
check to see how many words have been blanked. If they've all been 
blanked we know it's time to quit the program.*/
        while (!AllBlank() & success != 3)
        {
            Random random = new();
            int wordIndex = random.Next(_scriptW.Count);

            if (!_scriptW[wordIndex].GetBlank())
            {
                success += 1;
                _scriptW[wordIndex].HideWord(_scriptW[wordIndex]);  
            } 
        }   
    }
}
