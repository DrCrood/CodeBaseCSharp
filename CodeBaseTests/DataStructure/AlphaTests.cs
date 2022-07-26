using CodeBase.DataStructure;
using Moq;
using System;
using System.Diagnostics;
using Xunit;

namespace CodeBaseTests.DataStructure
{
    public class AlphaTests
    {
        private MockRepository mockRepository;



        public AlphaTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Alpha CreateAlpha()
        {
            return new Alpha();
        }

        [Fact]
        public void testenum_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();

            // Act
            alpha.testenum();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TestEnumerable_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();

            // Act
            alpha.TestEnumerable();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void InfoService_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            string ssn = null;

            // Act
            var result = alpha.InfoService(
                ssn);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void InfoService2_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            string ssn = null;

            // Act
            var result = alpha.InfoService2(
                ssn);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Double_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            int n = 0;

            // Act
            var result = alpha.Double(
                n);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Test_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();

            // Act
            alpha.Test();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }



        [Fact]
        public void AverageOrder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            int n = 0;

            // Act
            alpha.AverageOrder(
                n);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public void MaxProfitWithDayRange_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            int days = 0;

            // Act
            alpha.MaxProfitWithDayRange(
                days);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void randomSample_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            int n = 0;

            // Act
            alpha.randomSample(
                n);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void converter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            string sinput = null;
            int iinput = 0;

            // Act
            alpha.converter(
                sinput,
                iinput);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void WinningProbability_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            int previousWon = 0;
            int previousLoss = 0;
            int gameLeft = 0;
            int MustWin = 0;

            // Act
            var result = alpha.WinningProbability(
                previousWon,
                previousLoss,
                gameLeft,
                MustWin);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void permu_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            int t = 0;
            int p = 0;

            // Act
            var result = alpha.permu(
                t,
                p);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void lookandsay_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            string input = null;
            int num = 0;

            // Act
            alpha.lookandsay(
                input,
                num);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void substringSearch_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var alpha = this.CreateAlpha();
            string sstring = null;
            string sub = null;

            // Act
            alpha.substringSearch(
                sstring,
                sub);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
