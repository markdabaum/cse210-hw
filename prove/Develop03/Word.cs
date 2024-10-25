public class Word
{
    private string _word;
    private bool _blank;

/*This very conviniently only needed one construct because
it's only called in one place for one reason.*/
    public Word(string word, bool blank)
    {
        _word = word;
        _blank = blank;
    }

    public string DisplayWord()
    {
        return _word;
    }

    public bool GetBlank()
    {
        return _blank;
    }


    public Word HideWord(Word word)
    {
        word._blank = true;
    //Such simplicity. It's really quite beautiful.    
        int wordLength = word._word.Length;
        word._word = new string('_', wordLength);
        return word;
    }
}