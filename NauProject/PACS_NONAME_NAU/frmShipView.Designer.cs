
namespace PACS_NONAME_NAU
{
    partial class frmShipView
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
            this.lstvShips = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lstvShips
            // 
            this.lstvShips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.lstvShips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvShips.HideSelection = false;
            this.lstvShips.Location = new System.Drawing.Point(25, 121);
            this.lstvShips.Name = "lstvShips";
            this.lstvShips.Size = new System.Drawing.Size(1214, 473);
            this.lstvShips.TabIndex = 11;
            this.lstvShips.UseCompatibleStateImageBehavior = false;
            this.lstvShips.SelectedIndexChanged += new System.EventHandler(this.lstvShips_SelectedIndexChanged);
            // 
            // frmShipView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lstvShips);
            this.Name = "frmShipView";
            this.Text = "frmShipView";
            this.Load += new System.EventHandler(this.frmShipView_Load);
            this.Controls.SetChildIndex(this.lstvShips, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvShips;
    }
}