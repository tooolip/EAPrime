using NUnit.Framework;
using EAPrime;
namespace EAPrimeTests
{
    public class ArgumentsTests
    {
        Arguments _arguments;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_ReadAllArguments()
        {
            string[] args = { "-a", "-b", "-c" };
            _arguments = new Arguments(args);

            int result = _arguments.getArgumentCount();
            Assert.AreEqual(result, 5);
        }

        [Test]
        public void Test_NoFilepath()
        {
            string[] args = { "-a", "-b", "-c" };
            _arguments = new Arguments(args);

            string result = _arguments.getFilepath();
            Assert.AreEqual(result, "empty");
        }

        [Test]
        public void Test_EmptyFilepath()
        {
            string[] args = { "-d", "-a" };
            _arguments = new Arguments(args);

            string result = _arguments.getFilepath();
            Assert.AreEqual(result, "empty");
        }

        [Test]
        public void Test_EmptyFilepathAtEnd()
        {
            string[] args = { "-a", "-d" };
            _arguments = new Arguments(args);

            string result = _arguments.getFilepath();
            Assert.AreEqual(result, "empty");
        }

        [Test]
        public void Test_PrintoutEnabled()
        {
            string[] args = { "-p" };
            _arguments = new Arguments(args);

            bool result = _arguments.printoutEnabled();
            Assert.AreEqual(result, true);
        }
    }
}