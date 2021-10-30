using NUnit.Framework;
using System.Collections;
using EAPrime;
namespace EAPrimeTests
{
    public class PrimeFactorCalculatorTests
    {
        PrimeFactorCalculator _pfc;

        [SetUp]
        public void Setup()
        {
            _pfc = new PrimeFactorCalculator();
        }

        [Test]
        public void Test_PrimeGenerator()
        {
            ArrayList result1 = _pfc.getPrimesUpTo(1);
            ArrayList result2 = _pfc.getPrimesUpTo(2);
            ArrayList result3 = _pfc.getPrimesUpTo(5);
            ArrayList result4 = _pfc.getPrimesUpTo(10);

            ArrayList answer1 = new ArrayList();
            ArrayList answer2 = new ArrayList() { 2 };
            ArrayList answer3 = new ArrayList() { 2, 3, 5 };
            ArrayList answer4 = new ArrayList() { 2, 3, 5, 7 };

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EquivalentTo(answer1));
                Assert.That(result2, Is.EquivalentTo(answer2));
                Assert.That(result3, Is.EquivalentTo(answer3));
                Assert.That(result4, Is.EquivalentTo(answer4));
            });
        }

        [Test]
        public void Test_FactorGenerator()
        {
            ArrayList result1 = _pfc.getPrimeFactors(1);
            ArrayList result2 = _pfc.getPrimeFactors(2);
            ArrayList result3 = _pfc.getPrimeFactors(6);
            ArrayList result4 = _pfc.getPrimeFactors(42);
            ArrayList result5 = _pfc.getPrimeFactors(43);

            ArrayList answer1 = new ArrayList();
            ArrayList answer2 = new ArrayList() { 2 };
            ArrayList answer3 = new ArrayList() { 2, 3 };
            ArrayList answer4 = new ArrayList() { 2, 3, 7 };
            ArrayList answer5 = new ArrayList() { 43 };

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EquivalentTo(answer1));
                Assert.That(result2, Is.EquivalentTo(answer2));
                Assert.That(result3, Is.EquivalentTo(answer3));
                Assert.That(result4, Is.EquivalentTo(answer4));
                Assert.That(result5, Is.EquivalentTo(answer5));
            });
        }

        [Test]
        public void Test_RepeatFactor()
        {
            ArrayList result = _pfc.getPrimeFactors(12);
            ArrayList answer = new ArrayList() { 2, 2, 3 };

            Assert.That(result, Is.EquivalentTo(answer));
        }

        [Test]
        public void Test_NegativePrime()
        {
            ArrayList result = _pfc.getPrimesUpTo(-1);

            Assert.That(result, Is.EquivalentTo(new ArrayList()));
        }

        [Test]
        public void Test_NegativeFactor()
        {
            ArrayList result = _pfc.getPrimeFactors(-1);

            Assert.That(result, Is.EquivalentTo(new ArrayList()));
        }
    }
}