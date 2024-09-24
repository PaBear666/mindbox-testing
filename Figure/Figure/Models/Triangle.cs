using Figure.Exceptions;
using Figure.Models.Abstract;

namespace Figure.Models
{
    public class Triangle : Polygon
    {
        private double? _area;
        private bool? isRectangle;

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
            if (isRectangle != null)
            {
                return isRectangle.Value;
            }

            var maxSide = Math.Max(ASide, Math.Max(BSide, CSide));
            isRectangle = false;

            if (SidesEqual(maxSide, ASide))
            {
                isRectangle = SidesEqual(ASide * ASide, BSide * BSide + CSide * CSide);
                return isRectangle.Value;
            }

            if (SidesEqual(maxSide, BSide))
            {
                isRectangle = SidesEqual(BSide * BSide, ASide * ASide + CSide * CSide);
                return isRectangle.Value;
            }

            isRectangle = SidesEqual(CSide * CSide, ASide * ASide + BSide * BSide);
            return isRectangle.Value;
        }


        private bool AreCorrectedRelationSides()
        {
            return ASide + BSide > CSide
                   && ASide + CSide > BSide
                   && BSide + CSide > ASide;
        }
    }
}
