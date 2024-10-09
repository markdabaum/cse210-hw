public class Entry
{
    public string _fullEntry;
    public string _entrydate;
    public string _entryPrompt;
    public string _entryResponse;

    public void GetInput()
    {
        _fullEntry = $"{_entrydate} {_entryPrompt}:\n{_entryResponse}";
    }

}