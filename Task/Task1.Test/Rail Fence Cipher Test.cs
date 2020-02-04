using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TASK_1._Rail_Fence_Cipher;

namespace Task1.Test
{
    [TestClass]
    public class Rail_Fence_Cipher_Test
    {
        [TestMethod]
        public void Encode_with_two_rails()
        {
            var sentence = "HELLO WORLD";
            var rail = new RailFenceCipher(2);
            var expected = "HLOWRDEL OL";
            Assert.AreEqual(expected, rail.Encode(sentence));
        }

        [TestMethod]
        public void Encode_with_three_rails()
        {
            var sentence = "WEAREDISCOVEREDFLEEATONCE";
            var rail = new RailFenceCipher(3);
            var expected = "WECRLTEERDSOEEFEAOCAIVDEN";
            Assert.AreEqual(expected, rail.Encode(sentence));
        }

        [TestMethod]
        public void Decode_with_three_rails()
        {
            var sentence = "WECRLTEERDSOEEFEAOCAIVDEN";
            var rail = new RailFenceCipher(3);
            var expected = "WEAREDISCOVEREDFLEEATONCE";
            Assert.AreEqual(expected, rail.Decode(sentence));
        }
    }
}
