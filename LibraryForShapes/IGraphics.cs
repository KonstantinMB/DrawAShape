using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borimechkov.ProjectShapes.Figures
{
    public interface IGraphics
    {
        void DrawRectangle(Color colorBorder, Color? colorFiller, int x, int y, int width, int height);
        void DrawTriangle (Color colorBorder, Color? colorFiller, Point[] coordinates);
        void DrawCircle(Color colorBorder, Color? colorFiller, int x, int y, float radius, float radius2);
    }
}
