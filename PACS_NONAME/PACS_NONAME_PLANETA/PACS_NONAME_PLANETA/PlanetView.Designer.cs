
namespace PACS_NONAME_PLANETA
{
    partial class PlanetView
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
            this.pnl_topbar = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlBottomBar = new System.Windows.Forms.Panel();
            this.lblDevs = new System.Windows.Forms.Label();
            this.lblCopy = new System.Windows.Forms.Label();
            this.lstvPlanets = new System.Windows.Forms.ListView();
            this.pnl_topbar.SuspendLayout();
            this.pnlBottomBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_topbar
            // 
            this.pnl_topbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.pnl_topbar.Controls.Add(this.lblName);
            this.pnl_topbar.Controls.Add(this.btnExit);
            this.pnl_topbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_topbar.Location = new System.Drawing.Point(0, 0);
            this.pnl_topbar.Name = "pnl_topbar";
            this.pnl_topbar.Size = new System.Drawing.Size(1264, 77);
            this.pnl_topbar.TabIndex = 0;
            this.pnl_topbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_topbar_MouseDown);
            this.pnl_topbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_topbar_MouseMove);
            this.pnl_topbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_topbar_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1209, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(43, 36);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(31, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(261, 25);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "PACS - Planet Interface";
            // 
            // pnlBottomBar
            // 
            this.pnlBottomBar.Controls.Add(this.lblCopy);
            this.pnlBottomBar.Controls.Add(this.lblDevs);
            this.pnlBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomBar.Location = new System.Drawing.Point(0, 644);
            this.pnlBottomBar.Name = "pnlBottomBar";
            this.pnlBottomBar.Size = new System.Drawing.Size(1264, 37);
            this.pnlBottomBar.TabIndex = 1;
            // 
            // lblDevs
            // 
            this.lblDevs.AutoSize = true;
            this.lblDevs.Location = new System.Drawing.Point(1082, 15);
            this.lblDevs.Name = "lblDevs";
            this.lblDevs.Size = new System.Drawing.Size(150, 13);
            this.lblDevs.TabIndex = 0;
            this.lblDevs.Text = "Developed by NoName Group";
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.Location = new System.Drawing.Point(33, 15);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(90, 13);
            this.lblCopy.TabIndex = 1;
            this.lblCopy.Text = "Copyright © 2022";
            // 
            // lstvPlanets
            // 
            this.lstvPlanets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lstvPlanets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstvPlanets.ForeColor = System.Drawing.Color.White;
            this.lstvPlanets.FullRowSelect = true;
            this.lstvPlanets.HideSelection = false;
            this.lstvPlanets.Location = new System.Drawing.Point(37, 104);
            this.lstvPlanets.MultiSelect = false;
            this.lstvPlanets.Name = "lstvPlanets";
            this.lstvPlanets.Size = new System.Drawing.Size(255, 507);
            this.lstvPlanets.TabIndex = 2;
            this.lstvPlanets.UseCompatibleStateImageBehavior = false;
            // 
            // PlanetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lstvPlanets);
            this.Controls.Add(this.pnlBottomBar);
            this.Controls.Add(this.pnl_topbar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlanetView";
            this.Text = "PACS - NONAME";
            this.Load += new System.EventHandler(this.PlanetView_Load);
            this.pnl_topbar.ResumeLayout(false);
            this.pnl_topbar.PerformLayout();
            this.pnlBottomBar.ResumeLayout(false);
            this.pnlBottomBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_topbar;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlBottomBar;
        private System.Windows.Forms.Label lblCopy;
        private System.Windows.Forms.Label lblDevs;
        private System.Windows.Forms.ListView lstvPlanets;
    }
}

