using Figure.Exceptions;

namespace Figure.Models
{
    public abstract class Figure
    {
        private double _eps;
        public double Epsilon
        {
            get => _eps;

            private set
            {
                if (value <= 0)
                {
                    throw new FigureException($"Epsilon can't be less than or equal to zero, current value: {value}");
                }

                _eps = value;
            }
        }


        public Figure(double eps = 1e-5)
        {
            Epsilon = eps;
        }
        
        public abstract double GetArea();
    }
}
