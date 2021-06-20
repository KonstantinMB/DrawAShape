using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvalidTextException = Borimechkov.ProjectShapes.Figures.InvalidTextException;


namespace Borimechkov.ProjectShapes
{
    public partial class FrmChangeTriangle : Form
    {
        public FrmChangeTriangle()
        {
            InitializeComponent();
        }

        private Point _PointB, _PointC;
        private Color _Color;
        private int _Parameter, _Area;

        public Point PointB
        {
            get
            {
                return _PointB;
            }
            set
            {
                _PointB = value;
                txtBX.Text = _PointB.X.ToString();
                txtBY.Text = _PointB.Y.ToString();
            }
        }

        public Point PointC
        {
            get
            {
                return _PointC;
            }
            set
            {
                _PointC = value;
                txtCX.Text = _PointC.X.ToString();
                txtCY.Text = _PointC.Y.ToString();
            }
        }
     
     
        public Color MyColor
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                btnColorTriangle.BackColor = _Color;
            }
        }

        public int MyParameter
        {
            get
            {
                return _Parameter;
            }
            set
            {
                _Parameter = value;
                txtTriParam.Text = _Parameter.ToString();
            }
        }

        public int MyArea
        {
            get
            {
                return _Area;
            }
            set
            {
                _Area = value;
                txtTriArea.Text = _Area.ToString();
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            _PointB.X = int.TryParse(txtBX.Text, out int pointBx)
                ? pointBx
                : throw new InvalidTextException("The value must be a number!");
            _PointB.Y = int.TryParse(txtBY.Text, out int pointBy)
                ? pointBy
                : throw new InvalidTextException("The value must be a number!"); ;
            _PointC.X = int.TryParse(txtCX.Text, out int pointCx)
                ? pointCx
                : throw new InvalidTextException("The value must be a number!"); ;
            _PointC.Y = int.TryParse(txtCY.Text, out int pointCy)
                ? pointCy
                : throw new InvalidTextException("The value must be a number!"); ;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnColorTriangle_Click(object sender, EventArgs e)
        {
            var changeColor = new ColorDialog();
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                MyColor = changeColor.Color;
            }
        }
    }
}
