using Figure.Exceptions;
using Figure.Models.Abstract;

namespace Figure.Models
{
    public class Triangle : Polygon
    {
        private double? _area;
        private bool? _isRectangle;

        public double ASide { get; }
        public double BSide { get; }
        public double CSide { get; }

        public Triangle(double aSide, double bSide, double cSide) : base(new[] { aSide, bSide, cSide })
        {
            ASide = aSide;
            BSide = bSide;
            CSide = cSide;


            if (!AreCorrectedRelationSides())
            {
                throw new FigureException("It isn't possible to construct a triangle with the specified lengths");
            }
        }

        public override double GetArea()
        {
            if (_area == null)
            {
                var semiP = (ASide + BSide + CSide) / 2;
                var area = Math.Sqrt(semiP * (semiP - ASide) * (semiP - BSide) * (semiP - CSide));
                _area = area;
            }

            return _area.Value;
        }

        public bool IsRectangular()
        {
            if (_isRectangle != null)
            {
                return _isRectangle.Value;
            }

            var maxSide = Math.Max(ASide, Math.Max(BSide, CSide));

            if (SidesEqual(maxSide, ASide))
            {
                _isRectangle = SidesEqual(ASide * ASide, BSide * BSide + CSide * CSide);
                return _isRectangle.Value;
            }

            if (SidesEqual(maxSide, BSide))
            {
                _isRectangle = SidesEqual(BSide * BSide, ASide * ASide + CSide * CSide);
                return _isRectangle.Value;
            }

            _isRectangle = SidesEqual(CSide * CSide, ASide * ASide + BSide * BSide);
            return _isRectangle.Value;
        }


        private bool AreCorrectedRelationSides()
        {
            return ASide + BSide > CSide
                   && ASide + CSide > BSide
                   && BSide + CSide > ASide;
        }
    }
}
