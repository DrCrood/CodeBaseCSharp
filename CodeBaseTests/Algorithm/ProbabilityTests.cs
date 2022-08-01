using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class ProbabilityTests
    {
        private MockRepository mockRepository;

        public ProbabilityTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Probability CreateProbability()
        {
            return new Probability();
        }

        [Fact]
        public void HeadTailProbCheck_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var probability = this.CreateProbability();

            // Act
            ((string cond1, int prob1),(string cond2, int prob2)) = probability.HeadTailProbCheck();

            // Assert
            Assert.True(prob2 > prob1);
            this.mockRepository.VerifyAll();
        }
    }
}
