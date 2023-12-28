using Strategy;
using Cards;

namespace ColiseumFight
{
    public class Player
    {
        public string Name { get; }

        private List<Card>? Cards;

        private IStrategy Strategy;

        public Player(string name, IStrategy strategy)
        {
            Name = name;
            Strategy = strategy;
        }

        public void GiveCards(List<Card> cards)
        {
            Cards = cards;
        }

        public Card PickCard()
        {
            return Strategy.Choose(Cards);
        }
    }
}
