
namespace Borimechkov.ProjectShapes
{
    partial class FrmChangeRect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWidth = new System.Windows.Forms.Label();
            this.tboxWidth = new System.Windows.Forms.TextBox();
            this.tboxHeight = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnColorRect = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtRectArea = new System.Windows.Forms.TextBox();
            this.lblAreaOfRect = new System.Windows.Forms.Label();
            this.txtRectParam = new System.Windows.Forms.TextBox();
            this.lblParameterOfRect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(89, 22);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width";
            // 
            // tboxWidth
            // 
            this.tboxWidth.Location = new System.Drawing.Point(28, 38);
            this.tboxWidth.Name = "tboxWidth";
            this.tboxWidth.Size = new System.Drawing.Size(156, 20);
            this.tboxWidth.TabIndex = 1;
            // 
            // tboxHeight
            // 
            this.tboxHeight.Location = new System.Drawing.Point(28, 85);
            this.tboxHeight.Name = "tboxHeight";
            this.tboxHeight.Size = new System.Drawing.Size(156, 20);
            this.tboxHeight.TabIndex = 3;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(87, 69);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(213, 136);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(65, 27);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(284, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnColorRect
            // 
            this.btnColorRect.Location = new System.Drawing.Point(80, 136);
            this.btnColorRect.Name = "btnColorRect";
            this.btnColorRect.Size = new System.Drawing.Size(55, 27);
            this.btnColorRect.TabIndex = 6;
            this.btnColorRect.UseVisualStyleBackColor = true;
            this.btnColorRect.Click += new System.EventHandler(this.btnColorRect_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(92, 120);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "Color";
            // 
            // txtRectArea
            // 
            this.txtRectArea.Location = new System.Drawing.Point(230, 38);
            this.txtRectArea.Name = "txtRectArea";
            this.txtRectArea.Size = new System.Drawing.Size(119, 20);
            this.txtRectArea.TabIndex = 9;
            this.txtRectArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAreaOfRect
            // 
            this.lblAreaOfRect.AutoSize = true;
            this.lblAreaOfRect.Location = new System.Drawing.Point(241, 22);
            this.lblAreaOfRect.Name = "lblAreaOfRect";
            this.lblAreaOfRect.Size = new System.Drawing.Size(96, 13);
            this.lblAreaOfRect.TabIndex = 8;
            this.lblAreaOfRect.Text = "Area of Rectangle:";
            // 
            // txtRectParam
            // 
            this.txtRectParam.Location = new System.Drawing.Point(230, 85);
            this.txtRectParam.Name = "txtRectParam";
            this.txtRectParam.Size = new System.Drawing.Size(119, 20);
            this.txtRectParam.TabIndex = 11;
            this.txtRectParam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblParameterOfRect
            // 
            this.lblParameterOfRect.AutoSize = true;
            this.lblParameterOfRect.Location = new System.Drawing.Point(228, 69);
            this.lblParameterOfRect.Name = "lblParameterOfRect";
            this.lblParameterOfRect.Size = new System.Drawing.Size(122, 13);
            this.lblParameterOfRect.TabIndex = 10;
            this.lblParameterOfRect.Text = "Parameter of Rectangle:";
            // 
            // FrmChangeRect
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.txtRectParam);
            this.Controls.Add(this.lblParameterOfRect);
            this.Controls.Add(this.txtRectArea);
            this.Controls.Add(this.lblAreaOfRect);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.btnColorRect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tboxHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.tboxWidth);
            this.Controls.Add(this.lblWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangeRect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rectangle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox tboxWidth;
        private System.Windows.Forms.TextBox tboxHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnColorRect;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtRectArea;
        private System.Windows.Forms.Label lblAreaOfRect;
        private System.Windows.Forms.TextBox txtRectParam;
        private System.Windows.Forms.Label lblParameterOfRect;
    }
}