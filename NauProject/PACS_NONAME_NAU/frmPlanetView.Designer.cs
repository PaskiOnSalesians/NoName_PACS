
namespace PACS_NONAME_NAU
{
    partial class frmPlanetView
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
            this.lstvPlanets = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lstvPlanets
            // 
            this.lstvPlanets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lstvPlanets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstvPlanets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvPlanets.ForeColor = System.Drawing.Color.White;
            this.lstvPlanets.HideSelection = false;
            this.lstvPlanets.Location = new System.Drawing.Point(25, 148);
            this.lstvPlanets.Name = "lstvPlanets";
            this.lstvPlanets.Size = new System.Drawing.Size(1214, 432);
            this.lstvPlanets.TabIndex = 13;
            this.lstvPlanets.UseCompatibleStateImageBehavior = false;
            this.lstvPlanets.SelectedIndexChanged += new System.EventHandler(this.lstvPlanets_SelectedIndexChanged);
            this.lstvPlanets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstvPlanets_KeyPress);
            this.lstvPlanets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstvPlanets_MouseDoubleClick);
            // 
            // frmPlanetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lstvPlanets);
            this.Name = "frmPlanetView";
            this.Text = "frmPlanetView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPlanetView_Load);
            this.Controls.SetChildIndex(this.lstvPlanets, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvPlanets;
    }
}