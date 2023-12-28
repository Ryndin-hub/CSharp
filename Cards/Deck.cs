namespace Cards
{
    public class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = CreateDeck();
        }

        public void ShuffleDeck()
        {
            ShuffleCards(Cards);
        }

        private List<Card> CreateDeck()
        {
            var cards = new List<Card>();

            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit)))
            {
                foreach (Card.CardRank rank in Enum.GetValues(typeof(Card.CardRank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }

            return cards;
        }

        private static Random rng = new Random();

        private void ShuffleCards(List<Card> cards)
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
