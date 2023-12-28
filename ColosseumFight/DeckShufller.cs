using Cards;

namespace ColosseumFight
{
    public class DeckShufller : IDeckShufller
    {
        private static Random rng = new Random();

        public void Shuffle(List<Card> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
