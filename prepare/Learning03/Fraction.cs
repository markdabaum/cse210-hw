using System.Diagnostics.Contracts;

public class Fraction
{
    private float _top;
    private float _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(float top)
    {
        _top = top;
        _bottom = 1;
    }

    public Fraction(float top, float bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string _fractionstring = $"{_top}/{_bottom}";
        return _fractionstring;
    }

    public double GetDecimalValue()
    {
        double _decimalValue = _top / _bottom;
        return _decimalValue;
    }
}