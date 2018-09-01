using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnowCSharpTest.Services;

namespace SnowCSharpTest.Tests
{
    [TestClass]
    public class ParserTests
    {
        private IParser _parser;

        [TestInitialize]
        public void Setup()
        {
            _parser = new ParserService();
        }

        [TestMethod]
        public void Empty_String_Should_Return_Empty_IEnumerable_Of_Bar()
        {
            var input = String.Empty;

            var result = _parser.Parse(input);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Line_Without_Hash_Sign_Should_Throw_Exception()
        {
            var input = @"A:Blue:5";

            _parser.Parse(input);
            Assert.ThrowsException<InvalidDataException>(() => _parser.Parse(input));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Line_Without_Bar_Code_Should_Throw_Exception()
        {
            var input = @"#:Blue:5";

            _parser.Parse(input);
            Assert.ThrowsException<InvalidDataException>(() => _parser.Parse(input));

        }




        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Line_Without_Bar_Size_Should_Throw_Exception()
        {
            var input = @"#A:Red:";

            _parser.Parse(input);
            Assert.ThrowsException<InvalidDataException>(() => _parser.Parse(input));

            //Assert.AreEqual("Red", result.FirstOrDefault().Color);
        }



        [TestMethod]

        public void Line_With_Proper_Data_Should_Proper_Data()
        {
            var input = @"#A:Red:5";

            var result = _parser.Parse(input);
            //Assert.ThrowsException<InvalidDataException>(() => _parser.Parse(input));

            Assert.AreEqual("Red", result.FirstOrDefault().Color);
            Assert.AreEqual("A", result.FirstOrDefault().BarCode);
            Assert.AreEqual(5, result.FirstOrDefault().Size);

        }





    }
}
