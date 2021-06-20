using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borimechkov.ProjectShapes.Figures
{
    [Serializable]
    public abstract class Shapes
    {
        public bool Fill { get; set; } = true;

        public abstract Point Location { get; set; }
        public abstract void Paint(IGraphics g);
        public abstract bool Contains(Point p);

        public virtual bool Selected { get; set; }
        public virtual int Area { get; set; }
        public virtual int Parameter { get; }
        public virtual bool Intersects(Rectangle rectangle)
        {
            return true;
        }

        public virtual int Overlap { get; set; }

        public static implicit operator double(Shapes shape)
        {
            return shape.Area;
        }

    }
}
