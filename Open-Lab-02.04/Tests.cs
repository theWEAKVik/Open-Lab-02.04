using System;
using NUnit.Framework;
using System.Collections;

namespace Open_Lab_02._04
{
    [TestFixture]
    class Tests
    {

        private Farm farm;

        private const int RandMaxNum = 1000;
        private const int RandSeed = 1000789;
        private const int RandTestCasesCount = 98;

        [OneTimeSetUp]
        public void Init() => farm = new Farm();

        [TestCase(5, 2, 3, 30)]
        [TestCase(10, 12, 13, 120)]
        [TestCaseSource(nameof(GetRandom))]
        public void GetLegsCountTest(int chickens, int cows, int pigs, int expectedOutput) =>
            Assert.That(farm.GetLegsCount(chickens, cows, pigs), Is.EqualTo(expectedOutput));

        private static IEnumerable GetRandom()
        {
            var random = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var chickens = random.Next(RandMaxNum);
                var cows = random.Next(RandMaxNum);
                var pigs = random.Next(RandMaxNum);

                yield return new TestCaseData(chickens, cows, pigs, chickens * 2 + (cows + pigs) * 4);
            }
        }

    }
}
