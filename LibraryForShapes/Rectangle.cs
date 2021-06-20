using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borimechkov.ProjectShapes.Figures
{
    [Serializable]
    public class Rectangle : Shapes
    {
        private Point _pointRect;
        private int _width, _height;
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
            get => _pointRect;
            set 
            {
                _pointRect = value;
            }
        }

        public int Width
        {
            get => _width;
            set
            {
                if (value < 0)
                    throw new InvalidValueException("Negative numbers are not allowed!");
                _width = value;
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                if (value < 0)
                    throw new InvalidValueException("Negative numbers are not allowed!");
                _height = value;
            }
        }

        public override int Area
        {
            get
            {
                return _width * _height;
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
        
        public override int Parameter
        {
            get
            {
                return 2*_width + 2*_height;
            }
        }

        public override void Paint(IGraphics g)
        {
            var borderColor = Selected
                    ? Color.Red
                    : Color;

            g.DrawRectangle(
                borderColor,
                Fill
                ? Color
                : (Color?)null,
                _pointRect.X,
                _pointRect.Y,
                Width,
                Height);
            
        }

        public override bool Intersects(Rectangle rectangle)
        {
            if (rectangle is null)
                return false;
    
            return
              _pointRect.X < rectangle._pointRect.X + rectangle.Width &&
              rectangle._pointRect.X < _pointRect.X + Width &&
              _pointRect.Y < rectangle._pointRect.Y + rectangle.Height &&
              rectangle._pointRect.Y < _pointRect.Y + Height;
        }

        public override bool Contains(Point p)
        {
            return
                _pointRect.X < p.X && p.X < _pointRect.X + Width &&
                _pointRect.Y < p.Y && p.Y < _pointRect.Y + Height;
        }
    }
}
