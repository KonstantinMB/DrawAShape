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
    public partial class FrmChangeRect : Form
    {
        public FrmChangeRect()
        {
            InitializeComponent();
        }

        private int _Width, _Height;
        private int _Parameter, _Area;
        private Color _Color;

        public int MyWidth
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
                tboxWidth.Text = _Width.ToString();
            }
        }

        public int MyHeight
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
                tboxHeight.Text = _Height.ToString();
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
                txtRectParam.Text = _Parameter.ToString();
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
                txtRectArea.Text = _Area.ToString();
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
                btnColorRect.BackColor = _Color;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _Width = int.TryParse(tboxWidth.Text, out int width)
                ? width
                : throw new InvalidTextException("The value must be a number!");
            _Height = int.TryParse(tboxHeight.Text, out int height)
                ? height
                : throw new InvalidTextException("The value must be a number!");
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnColorRect_Click(object sender, EventArgs e)
        {
            var changeColor = new ColorDialog();
            if(changeColor.ShowDialog() == DialogResult.OK)
            {
                MyColor = changeColor.Color;
            }
        }
    }
}
