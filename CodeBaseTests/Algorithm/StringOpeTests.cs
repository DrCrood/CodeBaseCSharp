using CodeBase.Algorithm;
using Moq;
using System;
using System.Collections;
using Xunit;

namespace CodeBaseTests.Algorithm
{
    public class StringOpeTests
    {
        private MockRepository mockRepository;

        public StringOpeTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private StringOpe CreateStringOpe()
        {
            return new StringOpe();
        }

        [Fact]
        public void LargestVariance_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s = null;

            // Act
            var result = stringOpe.LargestVariance(
                s);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetStringPermutation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s = "ABCDE";

            // Act
            var result = stringOpe.GetStringPermutationInOrder(s);

            // Assert
            Assert.True(result.Count == 120);
        }

        [Fact]
        public void StringPermutation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s = "ABCDE";

            // Act
            var result = StringOpe.StringPermutation(s);

            // Assert
            Assert.True(result.Count == 120);
        }

        [Fact]
        public void LongestSubStringWithKTimes_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s = "abcdeabcdfabcabcgabchxxyzxyzxyzzabcdfg";

            // Act
            var result = stringOpe.LongestSubStringWithKTimes(s, 2);

            // Assert
            Assert.True(result == "xxyzxyzxyzz");
        }

        [Fact]
        public void CountStringSequenceinAnotherString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string a = "abcchhjxxyzzggiabcxyyz";
            string b = "abcxyz";

            // Act
            var result = stringOpe.CountStringSequenceinAnotherString(a,b);

            // Assert
            Assert.True(result == 30);
        }

        [Fact]
        public void longestCommonSequenceLength_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string a = "abcchhjxxyzzggiabcxyyz";
            string b = "aaabcopjjjqxyz";
            //a = "acx";
            //b = "ajqx";

            // Act
            var result = stringOpe.longestCommonSequenceLength(a, b);

            // Assert
            Assert.True(result == 7);
        }

        [Fact]
        public void longestCommonSequence_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string a = "abcchhjxxyzzggiabcxyyz";
            string b = "aaabcopjjjqxyz";

            // Act
            var result = stringOpe.longestCommonSequence(a, b);

            // Assert
            Assert.True(result == "abcjxyz");
        }

        [Fact]
        public void CountOccurencesIfStringRepeatKTimes_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s = "ABABBC";

            // Act
            var result = stringOpe.CountOccurencesIfStringRepeatKTimes(s, 3);

            // Assert
            Assert.True(result == 33);
        }

        [Fact]
        public void CountOccurencesOfSubsequenceWithABCPattern_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s = "CBACBCBABBCAB";
            string s2 = "ABC";

            // Act
            var result = stringOpe.CountOccurencesOfSubsequenceWithABCPattern(s, s2);

            // Assert
            Assert.True(result == 7);
        }

        [Fact]
        public void countDistinctSubSequences_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s = "aabcba";

            // Act
            var result = stringOpe.countDistinctSubSequences(s);

            // Assert
            Assert.True(result == 40);
        }

        [Fact]
        public void AllLongestCommonSequence_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s1 = "AKATGATGSHT";
            string s2 = "AGKTTAGSSTH";

            // Act
            var result = stringOpe.AllLongestCommonSequence(s1,s2);

            // Assert
            Assert.True(result.Count == 4);
        }

        [Fact]
        public void WordBreak_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stringOpe = this.CreateStringOpe();
            string s = "pineapplepenapple";
            IList<string> wordDict = new List<string> { "apple", "pen", "applepen", "pine", "pineapple" }; ;

            // Act
            var result = stringOpe.WordBreak(s, wordDict);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
