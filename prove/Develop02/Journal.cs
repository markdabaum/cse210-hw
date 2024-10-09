public class Journal
{
    public List<Entry> _entries = new();
    
    public void DisplayEntries()
    {
        foreach (Entry i in _entries)
            Console.WriteLine($"{i._fullEntry}\n");
    }
}