namespace Cards
{
    public class Card
    {
        public enum CardColor
        {
            Black,
            Red,
        }

        public enum CardSuit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades,
        }

        public enum CardRank
        {
            _6,
            _7,
            _8,
            _9,
            _10,
            J,
            Q,
            K,
            A,
        }

        public CardRank Rank { get; }

        public CardSuit Suit { get; }

        public CardColor Color { get; }

        public Card(CardSuit suit, CardRank rank)
        {
            Rank = rank;
            Suit = suit;
            Color = suitToColor(suit);
        }

        private CardColor suitToColor(CardSuit suit)
        {
            if (suit == CardSuit.Hearts || suit == CardSuit.Diamonds)
                return CardColor.Red;

            return CardColor.Black;
        }
    }
}
