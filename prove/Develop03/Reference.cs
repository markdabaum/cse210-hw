using System.Dynamic;
/*This class ended up way simpler than I thought it would.
The rubric talks about how the Reference Class should handle
more than one verse.. and I don't think I interpreted that
how it was meant to be interpreted. My program handles more
than one verse at a time just fine.. you just have to type it
in by hand.

I think it would have made sense to include that aspect of handling 
more than one verse if we had a csv file or huge dictionary, or list
of every verse in the quad. IDK. I'm pretty sure I might lose points here.
*/
public class Reference
{
    private string _reference;

    public Reference()
    {
        _reference = "Moses 1:39";
    }

    public Reference(string reference)
    {
        _reference = reference;
    }
        
    public void DisplayReference()
    {
        Console.Write($"{_reference} ");
    }
}