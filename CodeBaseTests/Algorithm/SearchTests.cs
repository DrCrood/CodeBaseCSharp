using CodeBase.Algoriths;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class SearchTests
    {
        private MockRepository mockRepository;

        public SearchTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

        }

        private Search CreateSearch()
        {
            return new Search();
        }

        [Fact]
        public void SearchWordInGrid_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var search = this.CreateSearch();
            char[][] board = new char[][] { new char[] { 'A', 'B', 'C', 'E' }, new char[] { 'S', 'F', 'C', 'S' }, new char[] { 'A', 'D', 'E', 'E' } };
            string[] words = new string[] { "ABCB", "ABC", "DEE", "FCF" };

            // Act
            var result = Search.SearchWordsInGrid( board, words);

            // Assert
            Assert.Equal(new string[] { "ABC", "DEE" },result);
            this.mockRepository.VerifyAll();
        }

  
    }
}
