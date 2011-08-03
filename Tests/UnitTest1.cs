using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beeper;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldDecodeAndEncode()
        {
            var simon = new Simon();
            var signal = "-- --- .-. ... .    -.-. --- -.. . ";
            var result = simon.Decode(signal);
            Assert.AreEqual("morse code", result);
            var encodedResult = simon.Encode(result);
            Assert.AreEqual(encodedResult, signal);
        }

        [TestMethod]
        public void DoobeyDoobeyDoo()
        {
            var simon = new Simon();
            var result = simon.Encode("fuzzy wuzzy was a bear");
            var reverse = simon.Decode(result);
        }
    }
}
