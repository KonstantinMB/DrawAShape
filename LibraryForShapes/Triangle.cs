using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borimechkov.ProjectShapes.Figures
{
    [Serializable]
    public class Triangle : Shapes
    {
        private Point _pointTri, _pointB, _pointC;
        private Color _color;
        private int _overlap;

        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
            }
        }


        public override Point Location
        {
            get => _pointTri;
            set
            {
                _pointTri = value;
            }
        }

        public Point PointB
        {
            get => _pointB;

            set
            {
                if (value.X < 0 || value.Y < 0)
                    throw new InvalidValueException("Negative numbers are not allowed!");

                _pointB = value;
            }
        }

        public Point PointC
        {
            get => _pointC;

            set
            {
                if (value.X < 0 || value.Y < 0 || value.X > 1024 || value.Y > 640)
                    throw new InvalidValueException("Negative numbers are not allowed!");

                _pointC = value;
            }
        }

        public override int Area
        {
            get
            {
                return (Math.Abs(PointC.X - _pointB.X) * Math.Abs(_pointTri.Y - PointC.Y)) / 2;
            }
        }

        public override int Parameter
        {
            get
            {
                double sideC = Math.Sqrt(
                    Math.Pow(_pointC.X - _pointB.X, 2)
                    + Math.Pow(_pointTri.Y - _pointC.Y, 2)
                    );

                return Math.Abs(_pointC.X - _pointB.X)
                    + Math.Abs(_pointTri.Y - _pointC.Y)
                    + (int)sideC;
            }
        }

        public override int Overlap
        {
            get => _overlap;
            set
            {
                _overlap = value;
            }
        }

        public override void Paint(IGraphics g)
        {
            var borderColor = Selected
                   ? Color.Red
                   : Color;

            Point[] coordinates =
                   {
                        new Point(
                            _pointTri.X,
                            _pointTri.Y),

                        PointB,

                        PointC
                    };

            g.DrawTriangle(
                borderColor,
                Fill
                ? Color
                : (Color?)null,
                coordinates);

        }

        public override bool Intersects(Rectangle rect)
        {
            if (rect is null)
                return false;

            return
                (rect.Location.X < _pointB.X && _pointB.X < rect.Location.X + rect.Width
                && rect.Location.Y < _pointB.Y && _pointB.Y < rect.Location.Y + rect.Height) ||

                (rect.Location.X < _pointC.X && _pointC.X < rect.Location.X + rect.Width
                && rect.Location.Y < _pointC.Y && _pointC.Y < rect.Location.Y + rect.Height) ||

                (rect.Location.X < _pointTri.X && _pointTri.X < rect.Location.X + rect.Width
                && rect.Location.Y < _pointTri.Y && _pointTri.Y < rect.Location.Y + rect.Height) ||

                (_pointC.X < rect.Location.X + rect.Width && rect.Location.X + rect.Width < _pointB.X
                && _pointTri.Y < rect.Location.Y + rect.Height && rect.Location.Y + rect.Height < _pointC.Y) ||

                (_pointC.X < rect.Location.X && rect.Location.X < _pointB.X
                && _pointTri.Y < rect.Location.Y && rect.Location.Y < _pointC.Y) ||

                (_pointC.X < rect.Location.X && rect.Location.X < _pointB.X
                && _pointTri.Y < rect.Location.Y + rect.Height && rect.Location.Y + rect.Height < _pointC.Y) ||
               
                (_pointB.X < rect.Location.X + rect.Width && rect.Location.X + rect.Width < _pointC.X
                && _pointTri.Y < rect.Location.Y + rect.Height && rect.Location.Y + rect.Height < _pointB.Y) ||

                (_pointB.X < rect.Location.X && rect.Location.X < _pointC.X
                && _pointTri.Y < rect.Location.Y && rect.Location.Y < _pointB.Y) ||

                (_pointB.X < rect.Location.X && rect.Location.X < _pointC.X
                && _pointTri.Y < rect.Location.Y + rect.Height && rect.Location.Y + rect.Height < _pointB.Y) ||

                (_pointB.X < rect.Location.X + rect.Width && rect.Location.X + rect.Width < _pointC.X
                && _pointC.Y < rect.Location.Y && rect.Location.Y < _pointTri.Y) ||

                (_pointB.X < rect.Location.X && rect.Location.X < _pointC.X
                && _pointB.Y < rect.Location.Y + rect.Height && rect.Location.Y + rect.Height < _pointTri.Y) ||

                (_pointB.X < rect.Location.X && rect.Location.X < _pointC.X
                && _pointC.Y < rect.Location.Y && rect.Location.Y < _pointTri.Y) ||

                (_pointC.X < rect.Location.X + rect.Width && rect.Location.X + rect.Width < _pointB.X
                  && _pointB.Y < rect.Location.Y && rect.Location.Y < _pointTri.Y) ||

                (_pointC.X < rect.Location.X && rect.Location.X < _pointB.X
                && _pointC.Y < rect.Location.Y + rect.Height && rect.Location.Y + rect.Height < _pointTri.Y) ||

                (_pointC.X < rect.Location.X && rect.Location.X < _pointB.X
                && _pointB.Y < rect.Location.Y && rect.Location.Y < _pointTri.Y);
        }

        public override bool Contains(Point p)
        {
            return
                (_pointB.X < p.X && p.X < _pointC.X && _pointB.Y < p.Y && p.Y < _pointTri.Y) ||
                (_pointC.X < p.X && p.X < _pointB.X && _pointTri.Y < p.Y && p.Y < _pointC.Y) ||
                (_pointB.X < p.X && p.X < _pointC.X && _pointTri.Y < p.Y && p.Y < _pointC.Y) ||
                (_pointC.X < p.X && p.X < _pointB.X && _pointC.Y < p.Y && p.Y < _pointTri.Y);
        }
        
    }
}
