using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm.Test
{
    public class UtilityTests
    {
        private MockRepository mockRepository;

        public UtilityTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [Fact]
        public void Sqrt_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            double n = 10;

            // Act
            var result = Utility.Sqrt( n);
            double diff = Math.Abs(result-Math.Sqrt(n));

            // Assert
            Assert.True(diff < 1E-12);
        }

    }
}
