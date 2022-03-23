
namespace PACS_NONAME_PLANETA
{
    partial class frmPlanetView
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lstvPlanets = new System.Windows.Forms.ListView();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(19, 98);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(58, 513);
            this.panel8.TabIndex = 11;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(1186, 98);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(59, 513);
            this.panel12.TabIndex = 12;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(77, 98);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1109, 26);
            this.panel13.TabIndex = 13;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(77, 587);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1109, 24);
            this.panel14.TabIndex = 14;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.lstvPlanets);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(77, 124);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1109, 463);
            this.panel15.TabIndex = 15;
            // 
            // lstvPlanets
            // 
            this.lstvPlanets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lstvPlanets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstvPlanets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvPlanets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvPlanets.ForeColor = System.Drawing.Color.White;
            this.lstvPlanets.HideSelection = false;
            this.lstvPlanets.Location = new System.Drawing.Point(0, 0);
            this.lstvPlanets.MultiSelect = false;
            this.lstvPlanets.Name = "lstvPlanets";
            this.lstvPlanets.Size = new System.Drawing.Size(1109, 463);
            this.lstvPlanets.TabIndex = 0;
            this.lstvPlanets.UseCompatibleStateImageBehavior = false;
            // 
            // frmPlanetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel8);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(1264, 681);
            this.Name = "frmPlanetView";
            this.Text = "PACS - NONAME";
            this.Load += new System.EventHandler(this.PlanetView_Load);
            this.Controls.SetChildIndex(this.panel8, 0);
            this.Controls.SetChildIndex(this.panel12, 0);
            this.Controls.SetChildIndex(this.panel13, 0);
            this.Controls.SetChildIndex(this.panel14, 0);
            this.Controls.SetChildIndex(this.panel15, 0);
            this.panel15.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.ListView lstvPlanets;
    }
}

