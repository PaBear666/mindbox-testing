using Figure.Exceptions;
using Figure.Models;

namespace Figure.Tests.ModelTests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MustThrowException_When_SideLengthsAreZeroOrLess(double radius)
        {
            // Assert
            Assert.Throws<FigureException>(() =>
            {
                _ = new Circle(radius);
            });
        }

        [Theory]
        [InlineData(1, 3.14)]
        [InlineData(123, 47505.06)]
        [InlineData(1.5123, 7.18)]
        public void MustReturnRightArea_When_SetDefaultEps(double radius, double res)
        {
            //Action
            var circle = new Circle(radius);

            //Assert
            Assert.True(Math.Abs(circle.GetArea() - res) < circle.Epsilon);
        }
    }
}
