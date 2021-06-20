
namespace Borimechkov.ProjectShapes
{
    partial class FrmChangeCircle
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.lblRadius = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnColorCircle = new System.Windows.Forms.Button();
            this.txtCircleParam = new System.Windows.Forms.TextBox();
            this.lblParameterOfCircle = new System.Windows.Forms.Label();
            this.txtCircleArea = new System.Windows.Forms.TextBox();
            this.lblAreaOfCircle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(266, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(190, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 27);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(25, 47);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(148, 20);
            this.txtRadius.TabIndex = 7;
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(70, 31);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(40, 13);
            this.lblRadius.TabIndex = 6;
            this.lblRadius.Text = "Radius";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(75, 104);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 13;
            this.lblColor.Text = "Color";
            // 
            // btnColorCircle
            // 
            this.btnColorCircle.Location = new System.Drawing.Point(55, 120);
            this.btnColorCircle.Name = "btnColorCircle";
            this.btnColorCircle.Size = new System.Drawing.Size(71, 32);
            this.btnColorCircle.TabIndex = 12;
            this.btnColorCircle.UseVisualStyleBackColor = true;
            this.btnColorCircle.Click += new System.EventHandler(this.btnColorCircle_Click);
            // 
            // txtCircleParam
            // 
            this.txtCircleParam.Location = new System.Drawing.Point(217, 72);
            this.txtCircleParam.Name = "txtCircleParam";
            this.txtCircleParam.Size = new System.Drawing.Size(119, 20);
            this.txtCircleParam.TabIndex = 17;
            this.txtCircleParam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblParameterOfCircle
            // 
            this.lblParameterOfCircle.AutoSize = true;
            this.lblParameterOfCircle.Location = new System.Drawing.Point(227, 56);
            this.lblParameterOfCircle.Name = "lblParameterOfCircle";
            this.lblParameterOfCircle.Size = new System.Drawing.Size(99, 13);
            this.lblParameterOfCircle.TabIndex = 16;
            this.lblParameterOfCircle.Text = "Parameter of Circle:";
            // 
            // txtCircleArea
            // 
            this.txtCircleArea.Location = new System.Drawing.Point(217, 29);
            this.txtCircleArea.Name = "txtCircleArea";
            this.txtCircleArea.Size = new System.Drawing.Size(119, 20);
            this.txtCircleArea.TabIndex = 15;
            this.txtCircleArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAreaOfCircle
            // 
            this.lblAreaOfCircle.AutoSize = true;
            this.lblAreaOfCircle.Location = new System.Drawing.Point(240, 13);
            this.lblAreaOfCircle.Name = "lblAreaOfCircle";
            this.lblAreaOfCircle.Size = new System.Drawing.Size(73, 13);
            this.lblAreaOfCircle.TabIndex = 14;
            this.lblAreaOfCircle.Text = "Area of Circle:";
            // 
            // FrmChangeCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 191);
            this.Controls.Add(this.txtCircleParam);
            this.Controls.Add(this.lblParameterOfCircle);
            this.Controls.Add(this.txtCircleArea);
            this.Controls.Add(this.lblAreaOfCircle);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.btnColorCircle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.lblRadius);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangeCircle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Circle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnColorCircle;
        private System.Windows.Forms.TextBox txtCircleParam;
        private System.Windows.Forms.Label lblParameterOfCircle;
        private System.Windows.Forms.TextBox txtCircleArea;
        private System.Windows.Forms.Label lblAreaOfCircle;
    }
}