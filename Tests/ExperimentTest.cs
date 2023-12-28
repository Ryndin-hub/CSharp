using NUnit.Framework;
using ColosseumFight;
using Strategy;
using Cards;
using Moq;

namespace Tests
{
    public class ExperimentTest
    {
        private Mock<IDeckShuffler> ShufflerMock;
        private Player FirstPlayer;
        private Player SecondPlayer;
        private IEnumerable<Player> Players;

        [SetUp]
        public void SetUp()
        {
            ShufflerMock = new Mock<IDeckShuffler>();
            FirstPlayer = new Player("Elon Musk", new FirstCardStrategy());
            SecondPlayer = new Player("Mark Zuckerberg", new FirstCardStrategy());
            var players = new List<Player>
            {
                FirstPlayer,
                SecondPlayer
            };
            Players = players;
        }

        [Test]
        public void ShuffleOnceTest()
        {
            var colosseumSandbox = new ColosseumSandbox(
                ShufflerMock.Object,
                Players);

            colosseumSandbox.Simulate();

            Assert.DoesNotThrow(() =>
            {
                ShufflerMock.Verify(x => x.Shuffle(It.IsAny<List<Card>>()), Times.Once);
            });
        }

        [Test]
        [Repeat(100)]
        public void SameOutputTest()
        {
            var deck = new Deck();

            var colosseumSandbox = new ColosseumSandbox(
                ShufflerMock.Object,
                Players);

            bool firstOutput = colosseumSandbox.Simulate(deck);

            colosseumSandbox = new ColosseumSandbox(
                ShufflerMock.Object,
                Players);

            bool secondOutput = colosseumSandbox.Simulate(deck);

            Assert.That(firstOutput, Is.EqualTo(secondOutput));
        }
    }
}
