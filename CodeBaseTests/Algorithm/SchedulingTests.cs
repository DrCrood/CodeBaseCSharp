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

        [Fact]
        public void TaskScheduleWithPreRequirements_ValidInputArray_ShouldReturnCorrectTaskOrder()
        {
            // Arrange
            int[][] tasks = new int[][] { new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 3, 1 }, new int[] { 3, 2 }, new int[] { 3, 4 } };

            // Act
            int[] result = Scheduling.TaskScheduleWithPreRequirements(5,tasks);
            // Assert
            Assert.Equal(new int[] { 0, 2, 1, 4, 3 }, result);
        }

        [Fact]
        public void TaskScheduleWithPreRequirements_LoopedRequirement_ShouldReturnEmptyArray()
        {
            // Arrange
            int[][] tasks = new int[][] { new int[] { 1, 0 }, new int[] { 2, 1 }, new int[] { 3, 2 }, new int[] { 0, 3 } };

            // Act
            int[] result = Scheduling.TaskScheduleWithPreRequirements(4, tasks);
            // Assert
            Assert.Equal(new int[] { }, result);
        }
    }
}
