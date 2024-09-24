using Figure.Exceptions;

namespace Figure.Models
{
    public class Circle : Figure
    {
        public double Radius { get; }
        private double? _area;

        public Circle(double radius) : base(1e-2)
        {
            if (radius <= 0)
            {
                throw new FigureException($"Radius can't be less than or equal to zero. Current value: {Radius}");
            }

            Radius = radius;
        }

        public override double GetArea()
        {
            _area ??= Math.Round(Math.PI, 2) * Radius * Radius;
            return _area.Value;
        }
    }
}
