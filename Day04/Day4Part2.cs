using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day04;

public class Day4Part2
{
    public void Main(string path)
    {
        string data = new StreamReader(path).ReadToEnd();
        var cardData = data.Split('\n');
        List<Card> cards = new List<Card>();

        int count = 1;
        foreach (var card in cardData)
        {
            cards.Add(new Card()
            {
                ID = count++,
                WinningNumbers = card.Split(':')[1].Trim().Split('|')[0].Trim().Replace("  ", " ").Split(' ').Select(s => int.Parse(s.Trim())).ToList(),
                SelectedNumbers = card.Split(':')[1].Trim().Split('|')[1].Trim().Replace("  ", " ").Split(' ').Select(s => int.Parse(s.Trim())).ToList(),
                Count = 1
            });
        }

        var initCardCount = cards.Count;
        for (int i = 1; i <= initCardCount; i++)
        {
            Console.WriteLine($"Processing Card ID: [{i}]");
            Card.ProcessCardByID(i, cards);
        }

        Console.WriteLine($"Result: [{cards.Aggregate(0, (total, card) => total + card.Count)}]");
    }

    public class Card
    {
        public int ID { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> SelectedNumbers { get; set; }
        public int Count { get; set; }

        public static void ProcessCardByID(int id, List<Card> cards)
        {
            var card = cards.Where(c => c.ID == id).FirstOrDefault();

            int numNewCards = card.SelectedNumbers.Where(number => card.WinningNumbers.Contains(number)).Count();

            for (int j = id + 1; j <= id + numNewCards; j++)
                cards.Where(card => card.ID == j).First().Count += card.Count;
        }
    }
}
