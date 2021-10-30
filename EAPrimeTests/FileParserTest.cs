using NUnit.Framework;
using EAPrime;
namespace EAPrimeTests
{
    public class FileParserTest
    {
        FileParser _fp;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_FileNotFound()
        {
            _fp = new FileParser("fakefile.txt");

            bool result = _fp.generateListFromFile();
            Assert.AreEqual(result, false);
        }

        [Test]
        public void Test_FileFound()
        {
            _fp = new FileParser("input.txt");

            bool result = _fp.generateListFromFile();
            Assert.AreEqual(result, true);
        }

        [Test]
        public void Test_MalformedInput()
        {
            _fp = new FileParser("fakefile.txt");

            bool result = _fp.addInputToList("a");
            Assert.AreEqual(result, false);
        }

        [Test]
        public void Test_InputTooLarge()
        {
            _fp = new FileParser("fakefile.txt");

            bool result = _fp.addInputToList("7129364912");
            Assert.AreEqual(result, false);
        }

        [Test]
        public void Test_ValidInput()
        {
            _fp = new FileParser("fakefile.txt");

            bool result = _fp.addInputToList("1");
            Assert.AreEqual(result, true);
        }

        [Test]
        public void Test_ReadWholeFile()
        {
            _fp = new FileParser("input.txt");
            _fp.generateListFromFile();

            int result = _fp.getInputCount();
            Assert.AreEqual(result, 4);
        }
    }
}
