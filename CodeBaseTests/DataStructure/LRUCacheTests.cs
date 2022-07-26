using CodeBase.DataStructure;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.DataStructure
{
    public class LRUCacheTests
    {
        private MockRepository mockRepository;

        public LRUCacheTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private LRUCache CreateLRUCache(int capacity)
        {
            return new LRUCache(capacity);
        }

        [Fact]
        public void Get_ProvideKeys_ShouldReturnValue()
        {
            // Arrange
            var lRUCache = this.CreateLRUCache(3);
            int[] result = new int[5];

            // Act
            lRUCache.Put(1, 1);
            lRUCache.Put(2, 2);
            lRUCache.Put(3, 3);
            result[0] = lRUCache.Get(2);
            result[1] = lRUCache.Get(4);
            lRUCache.Put(4, 4);
            lRUCache.Put(2, 8);
            result[2] = lRUCache.Get(4);
            result[3] = lRUCache.Get(2);
            lRUCache.Put(5, 5);
            lRUCache.Put(5, 25);
            result[4] = lRUCache.Get(5);

            // Assert
            Assert.Equal(new int[] {2,-1,4,8,25}, result);
            this.mockRepository.VerifyAll();
        }
    }
}
