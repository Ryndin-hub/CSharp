using Cards;

namespace Strategy
{
    public interface IStrategy
    {
        public Card Choose(List<Card> cards);
    }
}
