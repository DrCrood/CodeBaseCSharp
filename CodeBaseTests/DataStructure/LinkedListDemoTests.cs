using CodeBase.DataStructure;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.DataStructure
{
    public class LinkedListDemoTests
    {
        private MockRepository mockRepository;



        public LinkedListDemoTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private LinkedListDemo CreateLinkedListDemo()
        {
            return new LinkedListDemo();
        }

        [Fact]
        public void LinkedList_ValidCall_ShouldPrint()
        {
            // Arrange
            var linkedListDemo = this.CreateLinkedListDemo();

            // Act
            int result = linkedListDemo.LinkedListSum();

            // Assert
            Assert.Equal(45, result);
            this.mockRepository.VerifyAll();
        }
    }
}
