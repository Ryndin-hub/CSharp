using NUnit.Framework;
using Cards;

namespace Tests
{
    public class DeckTest
    {
        [Test]
        public void ColorsTest()
        {
            var deck = new Deck();
            int blackCards = 0;
            int redCards = 0;

            foreach (Card card in deck.Cards)
                if (card.Color == Card.CardColor.Black)
                    blackCards++;
                else if (card.Color == Card.CardColor.Red)
                    redCards++;

            Assert.That(blackCards, Is.EqualTo(redCards));
        }
    }
}