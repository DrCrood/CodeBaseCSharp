using CodeBase.DataStructure;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class MedianStreamTests
    {
        private MockRepository mockRepository;

        public MedianStreamTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private MedianStream CreateMedianStream()
        {
            return new MedianStream();
        }

        [Fact]
        public void MedianStream_AddGet_ShouldReturnExpected()
        {
            // Arrange
            var medianStream = this.CreateMedianStream();

            int[] nums = new int[] { 3, 0, 3, 6, 15, 4, 0, 11, 5, 13, 0, 18, 20, 12, 0, 10, 6, 6, 0 };
            List<double> result = new List<double>();

            // Act
            foreach (int i in nums)
            {
                if (i > 0)
                {
                    medianStream.Add(i);
                }
                else
                {
                    result.Add(medianStream.Get());
                }
            }

            // Assert
            Assert.Equal(new double[] { 3, 4, 5.5, 11, 8 }, result);
        }
    }
}
