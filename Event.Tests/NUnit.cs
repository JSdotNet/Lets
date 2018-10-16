using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Event.Tests
{
    [TestFixture]
    public class NUnit
    {
#region Setup / Teardown
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
            // Runs once before ALL tests in this class
            // Can be put in a base class
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Runs once after ALL tests in this class
            // Can be put in a base class
        }

        [SetUp]
        public void BaseSetUp()
        {
            // Run before EVERY test
            // Not allowed in base class
        }

        [TearDown]
        public void BaseTearDown()
        {
            // Run after EVERY test
            // Not allowed in base class
        }

#endregion



#region SimpleTest
        [Test]
        public void SimpleTest()
        {
            // Arrange
            var expected = 4;

            // Act
            var result = 4;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task SimpleTestAsync()
        {
            // Arrange
            var expected = await Task.FromResult(4);

            // Act
            var result = await Task.FromResult(4);

            // Assert
            Assert.AreEqual(expected, result);
        }
#endregion




#region TestCase
        // Use TestC

        [TestCase(4, 5)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(5, 6)]
        public void TestCase(int expected, int result)
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(expected, result);
        }
#endregion




#region TestCaseSource
        public class TestCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                for (var i = 0; i < 10; i++)
                {
                    yield return new TestCaseData(i, i)
                    {
                        TestName = $"Test {i}"
                    };
                }
            }
        }
        [TestCaseSource(typeof(TestCases))]
        public void TestCaseSource(int expected, int result)
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
#endregion
}
