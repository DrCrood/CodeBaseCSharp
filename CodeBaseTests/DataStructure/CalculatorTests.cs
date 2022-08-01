using CodeBase.DataStructure;
using Moq;
using System;
using Xunit;

namespace CodeBaseTests.DataStructure
{
    public class CalculatorTests
    {
        private MockRepository mockRepository;
        public CalculatorTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Calculator CreateCalculator()
        {
            return new Calculator();
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("+2", 2)]
        [InlineData("-3", -3)]
        [InlineData("(2) ", 2)]
        [InlineData(" ( + 2)/ ", 2)]
        [InlineData(" -3 / ", -3)]
        [InlineData(" 4*( 2+ 3)/(10*10 - 2*40) ", 1)]
        [InlineData(" 6*8 /4*3 -5-30+10 ", 11)]
        [InlineData(" ((2) + ( 3 ) )", 5)]
        [InlineData(" 10 + ( ((3+3 * 1)) 7) - 50", 9)]
        [InlineData("2*3/3-4*5/10- 22+2*2 + 17", -1)]
        [InlineData("(2*4+5)*3-11*2-16", 1)]
        [InlineData("    ", Double.NaN)]
        [InlineData("/ * ", Double.NaN)]
        [InlineData(" + -", Double.NaN)]
        [InlineData("(()())", Double.NaN)]
        public void Evaluate_StateUnderTest_ExpectedBehavior(string input, double expect)
        {
            // Arrange
            var Cal = this.CreateCalculator();

            // Act
            var result = Cal.Evaluate(input);

            // Assert
            Assert.Equal(expect,result);
            
            this.mockRepository.VerifyAll();
        }
    }
}
