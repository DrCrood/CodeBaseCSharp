using CodeBase.DataStructure;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class FrequencyStatckTests
    {
        private FrequencyStatck CreateFrequencyStatck()
        {
            return new FrequencyStatck();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 5, 1, 2, 2, 4, 1, 5, 2, 4, 3, 3, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 5, 5, 4, 4, 3, 3, 2, 2, 1, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 5, 5, 5, 5, 5, 4, 4, 4,4, 3, 3,3, 2, 2, 1 }, new int[] { 5, 4, 5, 3, 4 })]
        public void PushPop_StateUnderTest_ExpectedBehavior(int[] nums, int[] result)
        {
            // Arrange
            var frequencyStatck = this.CreateFrequencyStatck();
            List<int> list = new List<int>();
            // Act
            foreach(int num in nums)
            {
                frequencyStatck.Push(num);
            }

            for(int i = 0; i < 5; i++)
            {
                list.Add(frequencyStatck.Pop());
            }

            // Assert
            Assert.Equal(result, list);
        }
    }
}
