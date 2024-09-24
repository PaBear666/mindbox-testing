using Figure.Exceptions;
using Figure.Models;

namespace Figure.Tests.ModelTests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(0,0,0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(-1, 0, 1)]
        [InlineData(1, 0, -1)]
        [InlineData(1, 1, -1)]
        [InlineData(-1, 1, -1)]
        [InlineData(-1, -1, 1)]
        public void MustThrowException_When_SideLengthsAreZeroOrLess(double aSide, double bSide, double cSide)
        {
            // Assert
            Assert.Throws<FigureException>(() =>
            {
                _ = new Triangle(aSide, bSide, cSide);
            });
        }

        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(2, 5, 2)]
        [InlineData(1000, 1000, 2000)]
        [InlineData(1000.00005, 1000.00005, 2000.0001)]
        [InlineData(7, 8, 15)]
        public void MustThrowException_When_SideLengthsAreNotSuitableForTriangle(double aSide, double bSide, double cSide)
        {
            // Assert
            Assert.Throws<FigureException>(() =>
            {
                _ = new Triangle(aSide, bSide, cSide);
            });
        }


        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(1, 6, 6)]
        [InlineData(1000, 1000, 1999.99)]
        [InlineData(1000.00006, 1000.00006, 2000.0001)]
        [InlineData(8, 8, 15)]
        public void MustCreateTriangle_When_SideLengthsAreSuitable(double aSide, double bSide, double cSide)
        {
            //Action
            var triangle = new Triangle(aSide, bSide, cSide);
            
            //Assert
            Assert.NotNull(triangle);
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(1, 6, 6, 2.98956)]
        [InlineData(1000, 1000, 1999.99, 3162.25789)]
        [InlineData(8, 8, 15, 20.87911)]
        public void MustReturnRightArea_When_SetDefaultEps(double aSide, double bSide, double cSide, double res)
        {
            //Action
            var triangle = new Triangle(aSide, bSide, cSide);
            
            //Assert
            Assert.True(Math.Abs(triangle.GetArea() - res) < triangle.Epsilon);
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(5, 3, 4, true)]
        [InlineData(12, 5, 13, true)]
        [InlineData(10, 5, 13, false)]
        public void MustReturnTrue_When_TriangleIsRectangle(double aSide, double bSide, double cSide, bool res)
        {
            //Action
            var triangle = new Triangle(aSide, bSide, cSide);

            //Assert
            Assert.Equal(res, triangle.IsRectangular());
        }
    }
}