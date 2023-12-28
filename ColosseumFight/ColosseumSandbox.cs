using Cards;

namespace ColosseumFight
{
    public class ColosseumSandbox
    {
        private Player FirstPlayer;
        private Player SecondPlayer;
        private IDeckShufller DeckShufller;
        private Deck Deck;

        public ColosseumSandbox(
            IDeckShufller deckShufller,
            IEnumerable<Player> players)
        {
            FirstPlayer = players.ElementAt(0);
            SecondPlayer = players.ElementAt(1);
            DeckShufller = deckShufller;
        }

        public bool Simulate()
        {
            Deck = new Deck();
            DeckShufller.Shuffle(Deck.Cards);

            List<Card> deckFirstHalf = Deck.Cards.Take(Deck.Cards.Count / 2).ToList();
            List<Card> deckSecondHalf = Deck.Cards.Skip(Deck.Cards.Count / 2).ToList();

            FirstPlayer.GiveCards(deckFirstHalf);
            SecondPlayer.GiveCards(deckSecondHalf);

            if (FirstPlayer.PickCard().Color == SecondPlayer.PickCard().Color)
                return true;

            return false;
        }
    }
}
