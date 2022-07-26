using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class MiscTests
    {
        private MockRepository mockRepository;
        public MiscTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Misc CreateMisc()
        {
            return new Misc();
        }

        [Fact]
        public void IntToRoman_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var misc = this.CreateMisc();
            int num = 1994;

            // Act
            var result = misc.IntToRoman(num);

            // Assert
            Assert.Equal("MCMXCIV", result);
            this.mockRepository.VerifyAll();
        }
    }
}
