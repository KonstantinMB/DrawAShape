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
    public partial class FrmChangeCircle : Form
    {
        public FrmChangeCircle()
        {
            InitializeComponent();
        }

        private double? _Radius;
        private Color _Color;
        private int _Parameter, _Area;

        public double? MyRadius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
                txtRadius.Text = _Radius.ToString();
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
                txtCircleParam.Text = _Parameter.ToString();
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
                txtCircleArea.Text = _Area.ToString();
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
                btnColorCircle.BackColor = _Color;
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            _Radius = int.TryParse(txtRadius.Text, out int radius)
                ? radius
                : throw new InvalidTextException("The value must be a number!");

            DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnColorCircle_Click(object sender, EventArgs e)
        {
            var changeColor = new ColorDialog();
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                MyColor = changeColor.Color;
            }
        }
    }
}
