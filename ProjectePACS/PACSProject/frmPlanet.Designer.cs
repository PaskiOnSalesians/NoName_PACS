
namespace PACSProject
{
    partial class frmPlanet
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
            this.lblExit = new System.Windows.Forms.Label();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblMaximize = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblPlanet = new System.Windows.Forms.Label();
            this.lsxPlanets = new System.Windows.Forms.ListBox();
            this.btnEncriptar = new System.Windows.Forms.Button();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblExit
            // 
            this.lblExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblExit.ForeColor = System.Drawing.Color.LightCoral;
            this.lblExit.Location = new System.Drawing.Point(1632, 9);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(60, 53);
            this.lblExit.TabIndex = 0;
            this.lblExit.Text = "l";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblMinimize
            // 
            this.lblMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblMinimize.ForeColor = System.Drawing.Color.Khaki;
            this.lblMinimize.Location = new System.Drawing.Point(1500, 9);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(60, 53);
            this.lblMinimize.TabIndex = 1;
            this.lblMinimize.Text = "l";
            // 
            // lblMaximize
            // 
            this.lblMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaximize.AutoSize = true;
            this.lblMaximize.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblMaximize.ForeColor = System.Drawing.Color.LightGreen;
            this.lblMaximize.Location = new System.Drawing.Point(1566, 9);
            this.lblMaximize.Name = "lblMaximize";
            this.lblMaximize.Size = new System.Drawing.Size(60, 53);
            this.lblMaximize.TabIndex = 2;
            this.lblMaximize.Text = "l";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.Controls.Add(this.lblMaximize);
            this.pnlTopBar.Controls.Add(this.lblExit);
            this.pnlTopBar.Controls.Add(this.lblMinimize);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1700, 78);
            this.pnlTopBar.TabIndex = 3;
            // 
            // lblPlanet
            // 
            this.lblPlanet.AutoSize = true;
            this.lblPlanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPlanet.Location = new System.Drawing.Point(87, 147);
            this.lblPlanet.Name = "lblPlanet";
            this.lblPlanet.Size = new System.Drawing.Size(99, 31);
            this.lblPlanet.TabIndex = 6;
            this.lblPlanet.Text = "Planet:";
            // 
            // lsxPlanets
            // 
            this.lsxPlanets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lsxPlanets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsxPlanets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lsxPlanets.ForeColor = System.Drawing.Color.White;
            this.lsxPlanets.FormattingEnabled = true;
            this.lsxPlanets.ItemHeight = 31;
            this.lsxPlanets.Location = new System.Drawing.Point(93, 228);
            this.lsxPlanets.Name = "lsxPlanets";
            this.lsxPlanets.Size = new System.Drawing.Size(336, 372);
            this.lsxPlanets.TabIndex = 5;
            this.lsxPlanets.SelectedIndexChanged += new System.EventHandler(this.lsxPlanets_SelectedIndexChanged);
            // 
            // btnEncriptar
            // 
            this.btnEncriptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnEncriptar.FlatAppearance.BorderSize = 0;
            this.btnEncriptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncriptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEncriptar.Location = new System.Drawing.Point(439, 134);
            this.btnEncriptar.Name = "btnEncriptar";
            this.btnEncriptar.Size = new System.Drawing.Size(214, 56);
            this.btnEncriptar.TabIndex = 4;
            this.btnEncriptar.Text = "Generar Clau";
            this.btnEncriptar.UseVisualStyleBackColor = false;
            this.btnEncriptar.Click += new System.EventHandler(this.btnEncriptar_Click);
            // 
            // frmPlanet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(1700, 1000);
            this.Controls.Add(this.lblPlanet);
            this.Controls.Add(this.lsxPlanets);
            this.Controls.Add(this.btnEncriptar);
            this.Controls.Add(this.pnlTopBar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPlanet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.SecondForm_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblMaximize;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblPlanet;
        private System.Windows.Forms.ListBox lsxPlanets;
        private System.Windows.Forms.Button btnEncriptar;
    }
}