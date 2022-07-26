using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class ComputeTests
    {
        private MockRepository mockRepository;

        public ComputeTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }



        [Fact]
        public void GroupAnagrams_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string[] strings = new string[] { "eat", "tea", "tan", "ate", "nat", "bat", "wo", "test", "estt", "tset"};

            // Act
            var result = Compute.GroupAnagrams( strings);

            // Assert
            Assert.True(result.Count == 5);
        }

    }
}
