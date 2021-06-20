using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Borimechkov.ProjectShapes.Figures;

using Shapes = Borimechkov.ProjectShapes.Figures.Shapes;
using Rectangle = Borimechkov.ProjectShapes.Figures.Rectangle;
using Triangle = Borimechkov.ProjectShapes.Figures.Triangle;
using Circle = Borimechkov.ProjectShapes.Figures.Circle;

using InvalidValueException = Borimechkov.ProjectShapes.Figures.InvalidValueException;
using InvalidTextException = Borimechkov.ProjectShapes.Figures.InvalidTextException;
using InvalidColorException = Borimechkov.ProjectShapes.Figures.InvalidColorException;

namespace Borimechkov.ProjectShapes
{
    public partial class FormShapes : Form, IGraphics
    {
        private List<Shapes> _shapes = new List<Shapes>();

        private bool _captureMouse;
        private Point _captureLocation;
        private Rectangle _frameRect;
        private Triangle _frameTriangle;
        private Circle _frameCircle;
        private Graphics _onPaintGraphics;

        //needed to move the shape around:
        private Shapes clickedOn;
        private int x, y;
        private bool isDown;

        //for overlapping purposes ;)
        private int areaOver = 0;

        public FormShapes()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        public void DrawRectangle(Color colorBorder, Color? colorFiller, int x, int y, int width, int height)
        {
            if(_onPaintGraphics != null)
            {
                if (colorFiller.HasValue)
                    using (var brush = new SolidBrush(colorFiller.Value))
                        _onPaintGraphics.FillRectangle(brush, x, y, width, height);

                using (var pen = new Pen(colorBorder, 3))
                    _onPaintGraphics.DrawRectangle(pen, x, y, width, height);
            }
        }

        public void DrawTriangle(Color colorBorder, Color? colorFiller, Point[] coordinates)
        {
            if (_onPaintGraphics != null)
            {
                if (colorFiller.HasValue)
                    using (var brush = new SolidBrush(colorFiller.Value))
                        _onPaintGraphics.FillPolygon(brush, coordinates);

                using (var pen = new Pen(colorBorder, 3))
                    _onPaintGraphics.DrawPolygon(pen, coordinates);
            }
        }

        public void DrawCircle(Color colorBorder, Color? colorFiller, int x, int y, float radius, float radius2)
        {
            if (_onPaintGraphics != null)
            {
                if (colorFiller.HasValue)
                    using (var brush = new SolidBrush(colorFiller.Value))
                        _onPaintGraphics.FillEllipse(brush, x, y, radius, radius);

                using (var pen = new Pen(colorBorder, 3))
                    _onPaintGraphics.DrawEllipse(pen, x, y, radius, radius);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _onPaintGraphics = e.Graphics;

            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                _shapes[i].Paint(this);
            }

            if (_captureMouse)
            {
                if (_frameRect != null)
                    _frameRect.Paint(this);

                else if (_frameTriangle != null)
                    _frameTriangle.Paint(this);

                else if (_frameCircle != null)
                    _frameCircle.Paint(this);
            }

            _onPaintGraphics = null;
        }

        private Rectangle CreateFrameRectangle(Point location)
        {
            var frame = new Rectangle
            {
                Location = new Point(
                  Math.Min(_captureLocation.X, location.X),
                  Math.Min(_captureLocation.Y, location.Y)),
                Width = Math.Abs(_captureLocation.X - location.X),
                Height = Math.Abs(_captureLocation.Y - location.Y)
            };

            return frame;
        }
        private Circle CreateFrameCircle(Point location)
        {
            var frameCircle = new Circle
            {
                Location = new Point(
                  Math.Min(_captureLocation.X, location.X),
                  Math.Min(_captureLocation.Y, location.Y)),
                Radius = Math.Abs(_captureLocation.Y - location.Y)
            };

            return frameCircle;
        }
        private Triangle CreateFrameTriangle(Point location)
        {
            var frameTriangle = new Triangle
            {
                Location = new Point(
                    _captureLocation.X,
                    _captureLocation.Y),
                PointB = new Point(
                    location.X,
                    location.Y),
                PointC = new Point(
                    _captureLocation.X,
                    location.Y),
            };

            return frameTriangle;
        }

        private void FormShapes_MouseDown(object sender, MouseEventArgs e)
        {
            _captureMouse = true;
            _captureLocation = e.Location;
            _frameRect = null;
            _frameTriangle = null;
            _frameCircle = null;

            foreach (var shape in _shapes)
                shape.Selected = false;

            var selectedShape = _shapes
                .FirstOrDefault(s => s.Contains(e.Location)); //1

            if (selectedShape != null)
            {
                selectedShape.Selected = true;
                clickedOn = selectedShape;
                isDown = true;
            }

            Invalidate();
        }

        private void FormShapes_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_captureMouse)
                return;

            if (isDown && e.Button == MouseButtons.Left)
            {
                try
                {
                    DragShape(clickedOn, e);
                }
                catch (InvalidValueException m)
                {
                    DeleteSelected();
                    MessageBox.Show(m.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Refresh();
                }
            }

            if (rdbRectangle.Checked && !isDown)
            {
                _frameRect = CreateFrameRectangle(e.Location);
                _frameRect.Fill = false;
                _frameRect.Color = Color.LightGray;
            }
            if (rdbTriangle.Checked && e.Button == MouseButtons.Right)
            {
                _frameTriangle = CreateFrameTriangle(e.Location);
                _frameTriangle.Fill = false;
                _frameTriangle.Color = Color.LightGray;
            }
            if (rdbCircle.Checked && e.Button == MouseButtons.Right)
            {
                _frameCircle = CreateFrameCircle(e.Location);
                _frameCircle.Fill = false;
                _frameCircle.Color = Color.LightGray;
            }

            ShapeIntersecting(_shapes);

            Invalidate();
            RefreshArea();
        }

        private void FormShapes_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_captureMouse)
                return;

            if (isDown && e.Button == MouseButtons.Left)
            {
                MovingShapeOverlap();
                DeleteShapes();
            }

            if (e.Button == MouseButtons.Right)
            {
                if (rdbRectangle.Checked)
                {
                    if (_frameRect == null)
                        return;

                    _frameRect.Fill = true;
                    _frameRect.Selected = true;
                    _frameRect.Color = Color.Blue;

                    _shapes.Insert(0, _frameRect);
                }
                else if (rdbTriangle.Checked)
                {
                    if (_frameTriangle == null)
                        return;

                    _frameTriangle.Fill = true;
                    _frameTriangle.Selected = true;
                    _frameTriangle.Color = Color.DarkOrange;

                    _shapes.Insert(0, _frameTriangle);
                }
                else
                {
                    if (_frameCircle == null)
                        return;

                    _frameCircle.Fill = true;
                    _frameCircle.Selected = true;
                    _frameCircle.Color = Color.Green;

                    _shapes.Insert(0, _frameCircle);
                }

                for (int i = _shapes.Count - 1; i > 0; i--)
                {
                    int resOfOverlap = OverlappingAreas(_shapes[0], _shapes[i]);
                    _shapes[0].Overlap += resOfOverlap;
                }
            }

            _captureMouse = false;

            RefreshArea();
            Invalidate();
        }

        private void FormShapes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            DeleteSelected();
        }

        private int OverlappingAreas(Shapes shape1, Shapes shape2)
        {
            int res = 0;
            if (shape1 is Rectangle rect)
            {
                int width = 0, height = 0;
                if (shape2 is Rectangle rect2 && rect2.Intersects(rect))
                {
                    width = Math.Min((rect.Width + rect.Location.X),(rect2.Width + rect2.Location.X)) - Math.Max(rect.Location.X, rect2.Location.X);
                    height = Math.Min((rect.Height + rect.Location.Y), (rect2.Height + rect2.Location.Y)) - Math.Max(rect.Location.Y, rect2.Location.Y);
                }
                if (shape2 is Triangle tri && tri.Intersects(rect))
                {
                    int triX = Math.Abs(tri.Location.X - tri.PointB.X);
                    int triY = Math.Abs(tri.Location.Y - tri.PointB.Y);

                    width = Math.Min((rect.Width + rect.Location.X), (triX + tri.Location.X)) - Math.Max(rect.Location.X, tri.Location.X);
                    height = Math.Min((rect.Height + rect.Location.Y), (triY + tri.Location.Y)) - Math.Max(rect.Location.Y, tri.Location.Y);
                }
                if (shape2 is Circle cir && cir.Intersects(rect))
                {
                    width = Math.Min((rect.Width + rect.Location.X), ((int)cir.Radius + cir.Location.X)) - Math.Max(rect.Location.X, cir.Location.X);
                    height = Math.Min((rect.Width + rect.Location.Y), ((int)cir.Radius + cir.Location.Y)) - Math.Max(rect.Location.Y, cir.Location.Y);
                }

                res += (width * height);
            }
            return res;
        }

        private void MovingShapeOverlap()
        {
            clickedOn.Overlap = 0;
            foreach (var shape in _shapes)
            {
                if (clickedOn.Equals(shape))
                    continue;

                int resOfOverlap = OverlappingAreas(clickedOn, shape);
                clickedOn.Overlap += resOfOverlap;
            }
        }

        private void FormShapes_DoubleClick(object sender, EventArgs e)
        {
            ShapeProperties();
        }

        // Refreshes the area tab with proper area info
        private void RefreshArea()
        {
            var area = _shapes
                .Select(s => s.Area)
                .Sum(); //2

            var overlap = _shapes
                .Sum(s => s.Overlap);

            if (_shapes.Count > 0)
                area -= overlap;

            toolStripStatusLabelArea.Text = area.ToString();
        }

        //Deleting one or many selected shapes:
        private void DeleteSelected()
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
                if (_shapes[i].Selected)
                {
                    _shapes.RemoveAt(i);
                }

            RefreshArea();
            Invalidate();
        }

        // Deletes the shapes which are out of bounds
        private void DeleteShapes()
        {
            clickedOn.Selected = true;
            if (clickedOn.Location.X > 1024
                   || clickedOn.Location.X < 0
                   || clickedOn.Location.Y < 0
                   || clickedOn.Location.Y > 640)
                DeleteSelected();
            isDown = false;
        }

        // Opens a new form and shares info about the shape
        private void ShapeProperties()
        {
            var shape = _shapes
               .FirstOrDefault(s => s.Selected); //3
            try
            {
                if (shape is Rectangle rectangle)
                {
                    var changeRect = new FrmChangeRect();
                    changeRect.MyWidth = rectangle.Width;
                    changeRect.MyHeight = rectangle.Height;
                    changeRect.MyParameter = rectangle.Parameter;
                    changeRect.MyArea = rectangle.Area;
                    changeRect.MyColor = rectangle.Color;
                    
                    if (changeRect.ShowDialog() == DialogResult.OK)
                    {
                        rectangle.Width = changeRect.MyWidth;
                        rectangle.Height = changeRect.MyHeight;
                        rectangle.Color = (changeRect.MyColor != Color.White)
                             ? changeRect.MyColor
                             : throw new InvalidColorException();
                    }
                }


                if (shape is Triangle triangle)
                {
                    var changeTriangle = new FrmChangeTriangle();
                    changeTriangle.PointB = triangle.PointB;
                    changeTriangle.PointC = triangle.PointC;
                    changeTriangle.MyColor = triangle.Color;
                    changeTriangle.MyParameter = triangle.Parameter;
                    changeTriangle.MyArea = triangle.Area;

                    if (changeTriangle.ShowDialog() == DialogResult.OK)
                    {
                        triangle.PointB = changeTriangle.PointB;
                        triangle.PointC = changeTriangle.PointC;
                        triangle.Color = (changeTriangle.MyColor != Color.White)
                             ? changeTriangle.MyColor
                             : throw new InvalidColorException();
                    }

                }

                if (shape is Circle circle)
                {
                    var changeCircle = new FrmChangeCircle();
                    changeCircle.MyRadius = circle.Radius;
                    changeCircle.MyColor = circle.Color;
                    changeCircle.MyParameter = circle.Parameter;
                    changeCircle.MyArea = circle.Area;

                    if (changeCircle.ShowDialog() == DialogResult.OK)
                    {
                        circle.Radius = changeCircle.MyRadius.Value;
                        circle.Color = (changeCircle.MyColor != Color.White)
                             ? changeCircle.MyColor
                             : throw new InvalidColorException();
                    }
                }
            }
            catch (InvalidValueException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidTextException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(InvalidColorException)
            {
                MessageBox.Show("The color cannot be white!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshArea();
            Invalidate();
        }

        // Tells us whether the rectangle frame intersects with a drawn shape
        private void ShapeIntersecting(List<Shapes> shapes)
        {
            foreach (var shape in shapes)
            {
                if (shape is Rectangle rectangle)
                {
                    rectangle.Selected = rectangle.Intersects(_frameRect);
                }
                else if (shape is Triangle triangle)
                {
                    triangle.Selected = triangle.Intersects(_frameRect);
                }
                else if (shape is Circle circle)
                {
                    circle.Selected = circle.Intersects(_frameRect);
                }
            }
        }

        // Makes the shape draggable
        private void DragShape(Shapes shape, MouseEventArgs e)
        {
            shape.Selected = true;
            if (shape is Rectangle rect)
            {
                x = e.Location.X - (rect.Width / 2);
                y = e.Location.Y - (rect.Height / 2);

                rect.Location = new Point(x, y);

            }
            else if (shape is Triangle tri)
            {
                x = Math.Abs(tri.Location.X - tri.PointB.X);
                y = Math.Abs(tri.Location.Y - tri.PointB.Y);

                tri.Location = e.Location;

                if (tri.PointB.X < tri.Location.X && tri.PointB.Y > tri.Location.Y)
                {
                    tri.PointB = new Point(
                        tri.Location.X - x,
                        tri.Location.Y + y);
                }
                if (tri.PointB.X < tri.Location.X && tri.PointB.Y < tri.Location.Y)
                {
                    tri.PointB = new Point(
                        tri.Location.X - x,
                        tri.Location.Y - y);
                }
                if (tri.PointB.X > tri.Location.X && tri.PointB.Y < tri.Location.Y)
                {
                    tri.PointB = new Point(
                        tri.Location.X + x,
                        tri.Location.Y - y);

                }
                if (tri.PointB.X > tri.Location.X && tri.PointB.Y > tri.Location.Y)
                {
                    tri.PointB = new Point(
                        tri.Location.X + x,
                        tri.Location.Y + y);
                }

                tri.PointC = new Point(tri.Location.X, tri.PointB.Y);

            }
            else if (shape is Circle cir)
            {
                x = e.Location.X - (int)(cir.Radius / 2);
                y = e.Location.Y - (int)(cir.Radius / 2);

                cir.Location = new Point(x, y);
            }
        }

        // Tool Strip editing:
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var selectedCount = _shapes
                .Count(s => s.Selected); //4

            deleteToolStripMenuItem.Enabled = selectedCount > 0;
            propertiesToolStripMenuItem.Enabled = selectedCount == 1;
            selectToolStripMenuItem.Enabled = _shapes.Count() > 0; //5
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cc = new FrmSearchColor();
            
            if (cc.ShowDialog() == DialogResult.OK)
            {
                Color search = cc.MyColor;
                foreach (var shape in _shapes)
                {
                    shape.Selected = false;
                    if (shape is Rectangle rect)
                    {
                        if (search == rect.Color)
                            rect.Selected = true;
                    }
                    if (shape is Triangle tri)
                    {
                        if (search == tri.Color)
                            tri.Selected = true;
                    }
                    if (shape is Circle cir)
                    {
                        if (search == cir.Color)
                            cir.Selected = true;
                    }
                }
            }
            Refresh();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShapeProperties();
        }

        private void FormShapes_FormClosing(object sender, FormClosingEventArgs e)
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("shapes", FileMode.Create))
            {
                formatter.Serialize(stream, _shapes);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            save.FilterIndex = 2;
            save.RestoreDirectory = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
               var formatter = new BinaryFormatter();
               using (var myStream = new FileStream(save.FileName, FileMode.Create))
               {
                   formatter.Serialize(myStream, _shapes);
               }
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                var openPath = open.FileName;
                try
                {
                    var formatter = new BinaryFormatter();
                    using (var stream = new FileStream(openPath, FileMode.Open))
                    {
                        _shapes = (List<Shapes>)formatter.Deserialize(stream);
                        Invalidate();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("This path isn't valid! Please open a suitable file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
