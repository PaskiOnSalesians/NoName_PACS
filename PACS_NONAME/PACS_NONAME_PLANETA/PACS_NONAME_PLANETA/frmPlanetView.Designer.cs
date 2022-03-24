
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
            this.panel15 = new System.Windows.Forms.Panel();
            this.lstvPlanets = new System.Windows.Forms.ListView();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.lstvPlanets);
            this.panel15.Controls.Add(this.panel14);
            this.panel15.Controls.Add(this.panel13);
            this.panel15.Controls.Add(this.panel8);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(19, 98);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1226, 513);
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
            this.lstvPlanets.Location = new System.Drawing.Point(27, 27);
            this.lstvPlanets.Margin = new System.Windows.Forms.Padding(50);
            this.lstvPlanets.MultiSelect = false;
            this.lstvPlanets.Name = "lstvPlanets";
            this.lstvPlanets.Size = new System.Drawing.Size(1199, 459);
            this.lstvPlanets.TabIndex = 19;
            this.lstvPlanets.UseCompatibleStateImageBehavior = false;
            this.lstvPlanets.SelectedIndexChanged += new System.EventHandler(this.lstvPlanets_SelectedIndexChanged);
            this.lstvPlanets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstvPlanets_KeyPress);
            this.lstvPlanets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstvPlanets_MouseDoubleClick);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(27, 486);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1199, 27);
            this.panel14.TabIndex = 18;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(27, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1199, 27);
            this.panel13.TabIndex = 17;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(27, 513);
            this.panel8.TabIndex = 15;
            // 
            // frmPlanetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel15);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(1264, 681);
            this.Name = "frmPlanetView";
            this.Text = "PACS - NONAME";
            this.Load += new System.EventHandler(this.PlanetView_Load);
            this.Controls.SetChildIndex(this.panel15, 0);
            this.panel15.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.ListView lstvPlanets;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel8;
    }
}

