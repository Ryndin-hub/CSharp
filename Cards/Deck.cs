namespace Cards
{
    public class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = CreateDeck();
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
    }
}
