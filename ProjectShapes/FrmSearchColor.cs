using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borimechkov.ProjectShapes
{
    public partial class FrmSearchColor : Form
    {
        public FrmSearchColor()
        {
            InitializeComponent();
        }
        private Color _Color;
        public Color MyColor
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                btnColorSearch.BackColor = _Color;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnColorSearch_Click(object sender, EventArgs e)
        {
            var changeColor = new ColorDialog();
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                MyColor = changeColor.Color;
            }
        }
    }
}
