using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class MedianStreamFWTests
    {
        private MockRepository mockRepository;



        public MedianStreamFWTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private MedianStreamFW CreateMedianStreamFW()
        {
            return new MedianStreamFW(10);
        }

        [Fact]
        public void AddGet_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medianStreamFW = this.CreateMedianStreamFW();
            int n = 0;

            int[] nums = new int[] { 3, 0, 3, 6, 15, 4, 0, 11, 5, 13, 0, 18, 20, 12, 0, 10, 6, 6, 0, 3, 6, 9, 1, 2, 10, 8, 6, 12, 0, 5, 6, 7, 8, 12, 0, 14, 0, 15, 0, 16, 0 };
            List<double> result = new List<double>();

            // Act
            foreach (int i in nums)
            {
                if (i > 0)
                {
                    medianStreamFW.Add(i);
                }
                else
                {
                    result.Add(medianStreamFW.Get());
                }
            }

            // Assert
            Assert.Equal(new double[] { 3, 4, 5.5, 11.5, 10.5, 6, 7.5, 8, 8, 10}, result);
        }
    }
}
