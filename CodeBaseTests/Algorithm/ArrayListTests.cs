using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class ArrayListTests
    {
        private MockRepository mockRepository;



        public ArrayListTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ArrayList CreateArrayList()
        {
            return new ArrayList();
        }

        [Fact]
        public void MergeOverlapIntervals_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            int[][] intervals = new int[][] {new int[] {1,4}, new int[] { 4, 8 } , new int[] { 10, 25 } , new int[] { 40, 50 } , new int[] { 11, 14 } , new int[] { 2, 9 } };

            // Act
            var result = ArrayList.MergeOverlapIntervals(intervals);

            // Assert
            Assert.True(result.Length == 3);
            this.mockRepository.VerifyAll();
        }
    }
}
