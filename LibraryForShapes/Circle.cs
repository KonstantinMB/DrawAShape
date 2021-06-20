using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borimechkov.ProjectShapes.Figures
{
    [Serializable]
    public class Circle : Shapes
    {
        private Point _pointCir;
        private double _radius;
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
            get => _pointCir;
            set
            {
                _pointCir = value;
            }
        }

        public double Radius
        {
            get => _radius;

            set
            {
                if (value < 0)
                    throw new InvalidValueException("Negative numbers are not allowed!");
               
                _radius = value;
            }
        }

        public override int Area
        {
            get
            {
                return (int)(Math.PI * (_radius/2) * (_radius/2));
            }
        }
        public override int Parameter
        {
            get
            {
                return (int)(2 * Math.PI * _radius);
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

            g.DrawCircle(
                borderColor,
                Fill
                ? Color
                : (Color?)null,
                _pointCir.X,
                _pointCir.Y,
                (float)Radius,
                (float)Radius);

        }

        public override bool Intersects(Rectangle rect)
        {
            if (rect is null)
                return false;

            return
              _pointCir.X < rect.Location.X + rect.Width &&
              rect.Location.X < _pointCir.X + _radius &&
              Location.Y < rect.Location.Y + rect.Height &&
              rect.Location.Y < _pointCir.Y + _radius;
        }
 
        public override bool Contains(Point p)
        {
            return
                _pointCir.X < p.X && p.X < _pointCir.X + _radius &&
                _pointCir.Y < p.Y && p.Y < _pointCir.Y + _radius;
        }
    }
}
