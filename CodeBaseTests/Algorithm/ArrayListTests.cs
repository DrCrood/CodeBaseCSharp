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

        [Fact]
        public void MergeKSortedLists_ValidInputWithKLists_ShouldRetuenSortedList()
        {
            // Arrange
            ListNode[] nodes = new ListNode[3];
            ListNode node1 = new() { val = 1 };
            ListNode node2 = new() { val = 2 };
            ListNode node3 = new() { val = 1 };

            nodes[0] = node1;
            nodes[1] = node2;
            nodes[2] = node3;

            for (int i = 0; i < 4; i++)
            {
                node1.next = new ListNode() { val = i + 3 };
                node2.next = new ListNode() { val = i + 5 };
                node3.next = new ListNode() { val = i*i + 5 };
                node1 = node1.next;
                node2 = node2.next;
                node3 = node3.next;
            }

            // Act
            ListNode result = ArrayList.MergeKSortedLists(nodes);
            List<int> valuelist = new List<int>();
            while(result is not null)
            {
                valuelist.Add(result.val);
                result = result.next;
            }
            // Assert
            Assert.Equal(new List<int> {1,1,2,3,4,5,5,5,6,6,6,7,8,9,14 }, valuelist);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void MergeKSortedLists_EmptyInput_ShouldRetuenNull()
        {
            // Arrange
            ListNode[] nodes = new ListNode[0];

            // Act
            ListNode result = ArrayList.MergeKSortedLists(nodes);
            List<int> valuelist = new List<int>();
            while (result is not null)
            {
                valuelist.Add(result.val);
                result = result.next;
            }
            // Assert
            Assert.Equal(new List<int> { }, valuelist);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void getPermutation_MultipleStringSortMethods_ShouldRetuenCorrect()
        {
            // Arrange

            // Act
            string result = ArrayList.getKthPermutation("123456789ABCDEFGHIJK",3991680);

            result.Equals("123456789KJIHGFEDCBA");
        }

        [Fact]
        public void StringSort_MultipleStringSortMethods_ShouldRetuenCorrect()
        {
            // Arrange
            List<string> list1 = new List<string>() { "qwert", "asdfgh", "abc", "ASDFGH", "ABC", "QWER", "CHEN" };
            List<string> list2 = new List<string>() { "qwert", "asdfgh", "abc", "ASDFGH", "ABC", "QWER", "CHEN" };
            // Act
            ArrayList.StringSort(list1, list2);

            this.mockRepository.VerifyAll();
        }
    }
}
