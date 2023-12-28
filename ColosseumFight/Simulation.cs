using Strategy;
using Cards;

namespace ColosseumFight
{
    public class Simulation
    {
        private const int NumberOfSimulations = 1000000;

        public void Simulate()
        {
            int numberOfSucceses = 0;

            for (int i = 0; i < NumberOfSimulations; i++)
            {
                bool result = SimulateOnce();

                if (result)
                    numberOfSucceses++;
            }

            Console.WriteLine((float)numberOfSucceses / NumberOfSimulations);
        }

        private bool SimulateOnce()
        {
            Deck deck = new Deck();
            deck.ShuffleDeck();

            Player elon = new Player("Elon Musk", new FirstCardStrategy());
            Player mark = new Player("Mark Zuckerberg", new FirstCardStrategy());

            List<Card> deckFirstHalf = deck.Cards.Take(deck.Cards.Count / 2).ToList();
            List<Card> deckSecondHalf = deck.Cards.Skip(deck.Cards.Count / 2).ToList();

            elon.GiveCards(deckFirstHalf);
            mark.GiveCards(deckSecondHalf);

            if (elon.PickCard().Color == mark.PickCard().Color)
                return true;

            return false;
        }
    }
}
