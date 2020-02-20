using NUnit.Framework;
using StokvelNamespace;

namespace StokvelNamespace.Tests
{
    public class Tests
    {
        [Test]
        public void PayoutPeriodAndContributionAmountAreSetCorrectly()
        {
            // ARRANGE -- empty, nothing needed
            // ACT
            IStokvel s = new Stokvel(4, 1000);
            // ASSERT
            Assert.That(s.PayoutPeriod, Is.EqualTo(4));
            Assert.That(s.ContributionAmount, Is.EqualTo(1000));
        }

        [Test]
        public void CheckThatPayoutsOccurCorrectly() {
            // ARRANGE
            IStokvel s = new Stokvel(4, 1000);
            IMember a = new Member("Adam", s);
            IMember b = new Member("Bob", s);
            IMember c = new Member("Chloe", s);
            // ACT
            s.NextMeeting();
            s.NextMeeting();
            s.NextMeeting();
            s.NextMeeting();
            // ASSERT
            Assert.That(a.Withdrawn, Is.EqualTo(9000));
            Assert.That(b.Withdrawn, Is.EqualTo(0));
            Assert.That(c.Withdrawn, Is.EqualTo(0));
        }

        [Test]
        public void CheckThatPayoutsDoNotOccurPrematurely() {
            // ARRANGE
            IStokvel s = new Stokvel(4, 1000);
            IMember a = new Member("Adam", s);
            IMember b = new Member("Bob", s);
            IMember c = new Member("Chloe", s);
            // ACT
            s.NextMeeting();
            s.NextMeeting();
            s.NextMeeting();
            // ASSERT
            Assert.That(a.Withdrawn, Is.EqualTo(0));
            Assert.That(b.Withdrawn, Is.EqualTo(0));
            Assert.That(c.Withdrawn, Is.EqualTo(0));
        }
    }
}