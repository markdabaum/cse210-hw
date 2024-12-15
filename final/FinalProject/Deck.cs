using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

public class Deck
{
    private List<Pokie> _deck = [];

    public Deck()
    {
        _deck = [];
    }

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

    public Deck(Deck sourceDeck)
    {
        List<Pokie> deckList = sourceDeck._deck;

        Pokie a = deckList[deckList.Count-1];
        _deck.Add(a);
        deckList.RemoveAt(deckList.Count-1);

        Pokie b = deckList[deckList.Count-1];
        _deck.Add(b);
        deckList.RemoveAt(deckList.Count-1);
    }

    public int GetDeckCount()
    {
        int count = 0;
        foreach (Pokie pokie in _deck)
        {
            count++;
        }
        return count;
    }

    public void DisplayDeck(bool midturn)
    {

        string deckType = _deck[0].GetType();
        if (!midturn)
            Thread.Sleep(1000);
        for(int i=0; i<_deck.Count; i++)
        {
            Console.Write($"{i+1}. ");
            _deck[i].DisplayStats();
            if (!midturn)
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

    public Pokie GivePokie(int index)
    {
        Pokie pokie = _deck[index];
        _deck.RemoveAt(index);
        return pokie;
    }

    public void DisperseCourage(int index)
    {
        index--;
        _deck[index].ReceiveCourage();
    }

    public Deck MoveToDeck(Deck targetDeck, int index)
    {
        if (targetDeck == null)
        {
            targetDeck = new();
        }
        Pokie i = _deck[index];
        targetDeck._deck.Add(i);
        _deck.RemoveAt(index);
        return targetDeck;
    }
    
}