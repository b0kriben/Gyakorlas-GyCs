using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas_Konzol_model_reteg.Models
{
    public class Player
    {
        public string Name { get; set; }
    public string Email { get; }
    public int Score { get; private set; }
    public int Won { get; private set; }
    public int Lost { get; private set; }

    // Konstruktor
    public Player(string name, string email, int starterScore)
    {
        if (starterScore < 0)
        {
            throw new ArgumentException("A kezdő pontszám nem lehet negatív.");
        }
        Name = name;
        Email = email;
        Score = starterScore;
        Won = 0;
        Lost = 0;
    }

    public void Win(int pont)
    {
        if (Score < 0)
        {
            throw new InvalidOperationException($"{Name} kiesett a játékból. Nem játszhat tovább.");
        }
        Score += pont;
        Won++;
    }

    public void Lose(int pont)
    {
        if (Score < 0)
        {
            throw new InvalidOperationException($"{Name} kiesett a játékból. Nem játszhat tovább.");
        }
        Score -= pont;
        if (Score < 0)
        {
            throw new InvalidOperationException($"{Name} kiesett a játékból. Pontszáma negatív.");
        }
        Lost++;
    }

    public bool Winner()
    {
        return Won > Lost;
    }

    public override string ToString()
    {
        return $"{Name} ({Email}) -> {Score} pont";
    }
    }
}
