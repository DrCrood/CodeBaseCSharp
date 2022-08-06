using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class MaxHeapTests
    {
        private MockRepository mockRepository;

        public MaxHeapTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private MaxHeap CreateMaxHeap()
        {
            return new MaxHeap(3);
        }

        [Fact]
        public void MaxHeap_PushPeekPop_ExpectedBehavior()
        {
            // Arrange
            var maxHeap = this.CreateMaxHeap();
            int[] nums = new int[] { 3, 2, 0, 6, 5, -1, 7, 11, -1, 13, 12, -1, 0, 8, 9, 10, -1, 3, 0 };
            List<int> result = new List<int>();
            // Act
            foreach (int i in nums)
            {
                if (i > 0)
                {
                    maxHeap.Push(i);
                }
                else if (i == 0)
                {
                    result.Add(maxHeap.Peek());
                }
                else
                {
                    result.Add(maxHeap.Pop());
                }
            }

            // Assert
            Assert.Equal(new int[] { 3, 6, 11, 13, 12, 12, 10 }, result);
        }
    }
}
