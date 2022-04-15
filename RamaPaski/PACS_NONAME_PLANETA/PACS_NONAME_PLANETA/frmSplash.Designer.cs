
namespace PACS_NONAME_NAU
{
    partial class frmSplash
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbTieFighter = new System.Windows.Forms.PictureBox();
            this.prbBarra = new System.Windows.Forms.ProgressBar();
            this.lblCarga = new System.Windows.Forms.Label();
            this.timerProgressBar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTieFighter)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(170, 44);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pbTieFighter
            // 
            this.pbTieFighter.Image = ((System.Drawing.Image)(resources.GetObject("pbTieFighter.Image")));
            this.pbTieFighter.Location = new System.Drawing.Point(111, 206);
            this.pbTieFighter.Margin = new System.Windows.Forms.Padding(2);
            this.pbTieFighter.Name = "pbTieFighter";
            this.pbTieFighter.Size = new System.Drawing.Size(82, 82);
            this.pbTieFighter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTieFighter.TabIndex = 6;
            this.pbTieFighter.TabStop = false;
            // 
            // prbBarra
            // 
            this.prbBarra.Location = new System.Drawing.Point(111, 240);
            this.prbBarra.Margin = new System.Windows.Forms.Padding(2);
            this.prbBarra.Maximum = 101;
            this.prbBarra.Name = "prbBarra";
            this.prbBarra.Size = new System.Drawing.Size(378, 19);
            this.prbBarra.TabIndex = 5;
            // 
            // lblCarga
            // 
            this.lblCarga.AutoSize = true;
            this.lblCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarga.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblCarga.Location = new System.Drawing.Point(286, 297);
            this.lblCarga.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarga.Name = "lblCarga";
            this.lblCarga.Size = new System.Drawing.Size(46, 26);
            this.lblCarga.TabIndex = 4;
            this.lblCarga.Text = "0%";
            // 
            // timerProgressBar
            // 
            this.timerProgressBar.Enabled = true;
            this.timerProgressBar.Interval = 30;
            this.timerProgressBar.Tick += new System.EventHandler(this.timerProgressBar_Tick);
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbTieFighter);
            this.Controls.Add(this.prbBarra);
            this.Controls.Add(this.lblCarga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTieFighter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbTieFighter;
        private System.Windows.Forms.ProgressBar prbBarra;
        private System.Windows.Forms.Label lblCarga;
        private System.Windows.Forms.Timer timerProgressBar;
    }
}

