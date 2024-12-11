using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

public class Deck
{
    private List<Pokie> _deck = [];

    public Deck(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        for (int i=1; i<lines.Length; i++)
        {
            string line = lines[i];
            string[] atb = line.Split(",");

            string type = atb[0];
            string name = atb[1];
            int health = int.Parse(atb[2]);
            int attack = int.Parse(atb[3]);
            int secondary = int.Parse(atb[4]);
            int courage = int.Parse(atb[5]);
            int secondaryCourage = int.Parse(atb[6]);

            switch (type)
            {
                case "Fire":
                    Fire firePokie = new(type, name, health, attack, secondary, courage, secondaryCourage);
                    _deck.Add(firePokie);
                    break;
                
                case "Water":
                    Water waterPokie = new(type, name, health, attack, secondary, courage, secondaryCourage);
                    _deck.Add(waterPokie);
                    break;
                
                case "Earth":
                    Earth EarthPokie = new(type, name, health, attack, secondary, courage, secondaryCourage);
                    _deck.Add(EarthPokie);
                    break;
            }
        }
    }

    public Deck(Pokie pokie1, Pokie pokie2, Pokie pokie3)
    {
        _deck.Add(pokie1);
        _deck.Add(pokie2);
        _deck.Add(pokie3);
    }

    public void DisplayDeck()
    {
        string deckType = _deck[0].GetType();
        Console.WriteLine($"{deckType} Deck:\n");
        Thread.Sleep(1000);
        foreach(Pokie pokie in _deck)
        {
            pokie.DisplayStats();
            Thread.Sleep(500);
        }
        Console.Write("\n");
    }

    public void ShuffleDeck()
    {
        Random rng = new Random();

        for (int i = _deck.Count - 1; i>0; i--)
        {
            int j = rng.Next(i+1);
            Pokie pokie = _deck[j];
            _deck[j] = _deck[i];
            _deck[i] = pokie;
        }
    }
    
}