using CodeBase.Algorithm.Graph;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.Algorithm.Test
{
    public class GraphTests
    {
        private MockRepository mockRepository;

        public GraphTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Graph CreateGraph()
        {
            return new Graph();
        }

        [Fact]
        public void ShortestPathInGrid_ValidGrid_ShouldFindTheShortestPath()
        {
            // Arrange
            var graph = this.CreateGraph();
            char[][] grid = new char[][] { new char[] { 'O', 'O', 'O' }, new char[] { 'O', '#', '#' }, new char[] { 'O', 'O', 'X' }, new char[] { 'O', 'O', 'O' }, new char[] { '#', 'O', '*' } };

            // Act
            var result = Graph.ShortestPathInGrid(grid);

            // Assert
            Assert.Equal(2, result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void NumberOfIslands_ValidGrid_ShouldFindCorrectNumberOfIslands()
        {
            // Arrange
            var graph = this.CreateGraph();
            char[][] grid = new char[][] { new char[] { '1', '1', '0','0','0','1' }, new char[] { '1', '1', '0','1','0','1' }, new char[] { '0', '0', '1','0','0','0' }, new char[] { '0', '0', '0','1','1','1'} };

            // Act
            var result = Graph.NumberOfIslands(grid);

            // Assert
            Assert.Equal(5, result);
            this.mockRepository.VerifyAll();
        }

    }
}
