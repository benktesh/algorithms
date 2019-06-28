using System;
using Algorithms.BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTest
{
    [TestClass]
    public class BitRepresentationIPV4Test
    {
        [TestMethod]
        public void IPV4_Test_Parses()
        {
            var br = new BitRepresentationIPV4();
            string input = "192.168.10.10";
            string output = br.Get32Bit(input);
            Assert.IsTrue(output.Equals("11000000101010000000101000001010"));
        }

        [TestMethod]
        public void IPV4_Test_InvalidIP_ThrowsException()
        {
            Exception expectedExcetpion = null;
            try
            {
                var br = new BitRepresentationIPV4();
                string input = "192.168.10";
                string output = br.Get32Bit(input);
                input = "192.168.10.10.10";
                output = br.Get32Bit(input);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }
            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IPV4_Test_InvalidOct_ThrowsException()
        {
            var br = new BitRepresentationIPV4();
            string input = "192.168.10.abc";
            string output = br.Get32Bit(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IPV4_Test_Null_ThrowsException()
        {
            var br = new BitRepresentationIPV4();
            string input = "null";
            string output = br.Get32Bit(input);
        }

    }
}
