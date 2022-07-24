using CodeBase.Algorithm;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class SchedulingTests
    {
        private MockRepository mockRepository;

        public SchedulingTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Scheduling CreateScheduling()
        {
            return new Scheduling();
        }

        [Fact]
        public void MinMeetingRooms_ValidInputArray_ShouldReturnCorrectNumberOfMinimumRooms()
        {
            // Arrange
            var scheduling = this.CreateScheduling();
            int[][] meetings = new int[][] { new int[] { 30, 40 }, new int[] { 6, 16 }, new int[] { 8, 33 }, new int[] { 0, 30 }, new int[] { 5, 10 }, new int[] { 15, 20 } };

            // Act
            var result = scheduling.MinMeetingRooms( meetings);
            // Assert
            Assert.Equal(4,result);
        }

    }
}
