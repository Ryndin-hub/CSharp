using Cards;

namespace Strategy
{
    public class FirstCardStrategy : IStrategy
    {
        public Card Choose(List<Card> cards)
        {
            return cards[0];
        }
    }
}
