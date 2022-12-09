namespace SmartCortana
{
    partial class frmCortana
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCortana));
            this.picCortana = new System.Windows.Forms.PictureBox();
            this.tm1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.picCortana)).BeginInit();
            this.SuspendLayout();
            // 
            // picCortana
            // 
            this.picCortana.BackColor = System.Drawing.Color.Transparent;
            this.picCortana.Location = new System.Drawing.Point(-3, 0);
            this.picCortana.Name = "picCortana";
            this.picCortana.Size = new System.Drawing.Size(340, 324);
            this.picCortana.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCortana.TabIndex = 0;
            this.picCortana.TabStop = false;
            // 
            // tm1
            // 
            this.tm1.Interval = 200;
            this.tm1.Tick += new System.EventHandler(this.tm1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-3, 321);
            this.progressBar1.Maximum = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(340, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // frmCortana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(335, 336);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.picCortana);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCortana";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCortana";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCortana_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCortana)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCortana;
        private System.Windows.Forms.Timer tm1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}