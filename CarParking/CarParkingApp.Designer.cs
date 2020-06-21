namespace CarParking
{
    partial class CarParkingApp
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btn_Exist = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblLoding = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Location = new System.Drawing.Point(117, 24);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(365, 261);
            this.Panel1.TabIndex = 0;
            this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // btn_Exist
            // 
            this.btn_Exist.Location = new System.Drawing.Point(251, 375);
            this.btn_Exist.Name = "btn_Exist";
            this.btn_Exist.Size = new System.Drawing.Size(75, 23);
            this.btn_Exist.TabIndex = 1;
            this.btn_Exist.Text = "Exit";
            this.btn_Exist.UseVisualStyleBackColor = true;
            this.btn_Exist.Click += new System.EventHandler(this.btn_Exist_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(117, 341);
            this.progressBar1.Maximum = 40;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(365, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            // 
            // lblLoding
            // 
            this.lblLoding.AutoSize = true;
            this.lblLoding.Location = new System.Drawing.Point(256, 304);
            this.lblLoding.Name = "lblLoding";
            this.lblLoding.Size = new System.Drawing.Size(70, 13);
            this.lblLoding.TabIndex = 3;
            this.lblLoding.Text = "Refreshing....";
            this.lblLoding.Visible = false;
            // 
            // CarParkingApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 410);
            this.Controls.Add(this.lblLoding);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_Exist);
            this.Controls.Add(this.Panel1);
            this.Name = "CarParkingApp";
            this.Text = "CarParkingApp";
            this.Load += new System.EventHandler(this.CarParkingApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Button btn_Exist;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblLoding;
    }
}