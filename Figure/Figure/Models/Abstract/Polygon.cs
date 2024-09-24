using Figure.Exceptions;
using System.Drawing;

namespace Figure.Models.Abstract
{
    public abstract class Polygon : Figure
    {
        public IEnumerable<double> Sides { get; }
        public Polygon(IEnumerable<double> sides)
        {
            if (sides == null)
            {
                throw new ArgumentNullException(nameof(sides));
            }

            foreach (var side in sides)
            {
                if (side <= 0)
                {
                    throw new FigureException($"Side can't be less than or equal to zero, current value: {side}");
                }
            }

            Sides = sides;
        }

        protected bool SidesEqual(double aSide, double bSide)
        {
            return Math.Abs(aSide - bSide) < Epsilon;
        }
    }
}
