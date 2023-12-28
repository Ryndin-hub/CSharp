using NUnit.Framework;
using Cards;
using Strategy;
using ColosseumFight;

namespace Tests
{
    public class StrategyTest
    {
        private Card FirstOutput;
        private Deck Deck;
        private List<Card> HalfDeck;
        private IStrategy Strategy;

        [SetUp]
        public void SetUp()
        {
            Deck = new Deck();
            DeckShuffler deckShufller = new DeckShuffler();

            deckShufller.Shuffle(Deck.Cards);
            HalfDeck = Deck.Cards.Take(Deck.Cards.Count / 2).ToList();

            Strategy = new FirstCardStrategy();
            FirstOutput = Strategy.Choose(HalfDeck);
        }

        [Test]
        [Repeat(100)]
        public void SameOutputTest()
        {
            Assert.That(FirstOutput, Is.EqualTo(Strategy.Choose(HalfDeck)));
        }
    }
}
