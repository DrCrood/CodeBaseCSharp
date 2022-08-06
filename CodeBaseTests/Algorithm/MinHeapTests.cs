using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class MinHeapTests
    {
        private MockRepository mockRepository;

        public MinHeapTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private MinHeap CreateMinHeap()
        {
            return new MinHeap(3);
        }

        [Fact]
        public void MinHeap_PushPopPeek_ShouldProductExpectedResults()
        {
            // Arrange
            var minHeap = this.CreateMinHeap();
            int[] nums = new int[] {3,2,0,6,5,-1,7,11,-1,13,12,-1,0,8,9,10,-1,3,0};
            List<int> result = new List<int>();
            // Act
            foreach(int i in nums)
            {
                if(i > 0)
                {
                    minHeap.Push(i);
                }
                else if(i == 0)
                {
                    result.Add(minHeap.Peek());
                }
                else
                {
                    result.Add(minHeap.Pop());
                }
            }

            // Assert
            Assert.Equal(new int[] {2,2,3,5,6,6,3}, result);
            this.mockRepository.VerifyAll();
        }

    }
}
