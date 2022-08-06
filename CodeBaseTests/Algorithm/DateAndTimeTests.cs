using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class DateAndTimeTests
    {
        private MockRepository mockRepository;

        public DateAndTimeTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private DateAndTime CreateDateAndTime()
        {
            return new DateAndTime();
        }

        [Fact]
        public void Convert_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dateAndTime = this.CreateDateAndTime();

            // Act
            dateAndTime.Convert();

            // Assert
            Assert.True(true);
        }
    }
}
