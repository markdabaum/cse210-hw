public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }
    
    public void SetColor(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public virtual double GetArea()
    {
        double _area = 0;
        return _area;
    }
}