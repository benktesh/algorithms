using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoirthmsTest
{
    [TestClass]
    public class CountWordTest
    {
        [TestMethod]
        public void CountWord()
        {
            var cw = new CountWords();
            var s = new[]
            {
                "hate", "love", "peace", "love",
                "peace", "hate", "love", "peace",
                "love", "peace"
            };

            var result = cw.CountTwice(s);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] == "hate");


            s = new[]
            {
                "Om", "Om", "Shankar", "Tripathi",
                "Tom", "Jerry", "Jerry"
            };

            result = cw.CountTwice(s);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains("Om"));
            Assert.IsTrue(result.Contains("Jerry"));

        }
    }
}
