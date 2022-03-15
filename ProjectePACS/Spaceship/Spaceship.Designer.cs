
namespace Spaceship
{
    partial class Spaceship
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
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.btn_GetValidationCode = new System.Windows.Forms.Button();
            this.btn_GetPublicKeyPlanet = new System.Windows.Forms.Button();
            this.lsx_DestinationPlanet = new System.Windows.Forms.ListBox();
            this.lbl_PlanetDestination = new System.Windows.Forms.Label();
            this.lbl_UrNewDestination = new System.Windows.Forms.Label();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.Controls.Add(this.lblExit);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(800, 41);
            this.pnlTopBar.TabIndex = 4;
            this.pnlTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseDown);
            this.pnlTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseMove);
            this.pnlTopBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseUp);
            // 
            // lblExit
            // 
            this.lblExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblExit.ForeColor = System.Drawing.Color.LightCoral;
            this.lblExit.Location = new System.Drawing.Point(766, 5);
            this.lblExit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(31, 26);
            this.lblExit.TabIndex = 0;
            this.lblExit.Text = "l";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // btn_GetValidationCode
            // 
            this.btn_GetValidationCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_GetValidationCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btn_GetValidationCode.FlatAppearance.BorderSize = 0;
            this.btn_GetValidationCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GetValidationCode.ForeColor = System.Drawing.Color.White;
            this.btn_GetValidationCode.Location = new System.Drawing.Point(258, 169);
            this.btn_GetValidationCode.Name = "btn_GetValidationCode";
            this.btn_GetValidationCode.Size = new System.Drawing.Size(115, 45);
            this.btn_GetValidationCode.TabIndex = 5;
            this.btn_GetValidationCode.Text = "Obtenir Codi de Validació";
            this.btn_GetValidationCode.UseVisualStyleBackColor = false;
            this.btn_GetValidationCode.Click += new System.EventHandler(this.btn_GetValidationCode_Click);
            // 
            // btn_GetPublicKeyPlanet
            // 
            this.btn_GetPublicKeyPlanet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_GetPublicKeyPlanet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btn_GetPublicKeyPlanet.FlatAppearance.BorderSize = 0;
            this.btn_GetPublicKeyPlanet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GetPublicKeyPlanet.ForeColor = System.Drawing.Color.White;
            this.btn_GetPublicKeyPlanet.Location = new System.Drawing.Point(258, 245);
            this.btn_GetPublicKeyPlanet.Name = "btn_GetPublicKeyPlanet";
            this.btn_GetPublicKeyPlanet.Size = new System.Drawing.Size(115, 45);
            this.btn_GetPublicKeyPlanet.TabIndex = 6;
            this.btn_GetPublicKeyPlanet.Text = "Obtenir Clau Pública del Planeta";
            this.btn_GetPublicKeyPlanet.UseVisualStyleBackColor = false;
            this.btn_GetPublicKeyPlanet.Click += new System.EventHandler(this.btn_GetPublicKeyPlanet_Click);
            // 
            // lsx_DestinationPlanet
            // 
            this.lsx_DestinationPlanet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lsx_DestinationPlanet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lsx_DestinationPlanet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsx_DestinationPlanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsx_DestinationPlanet.ForeColor = System.Drawing.Color.White;
            this.lsx_DestinationPlanet.FormattingEnabled = true;
            this.lsx_DestinationPlanet.ItemHeight = 20;
            this.lsx_DestinationPlanet.Location = new System.Drawing.Point(36, 91);
            this.lsx_DestinationPlanet.Name = "lsx_DestinationPlanet";
            this.lsx_DestinationPlanet.Size = new System.Drawing.Size(180, 300);
            this.lsx_DestinationPlanet.TabIndex = 7;
            this.lsx_DestinationPlanet.SelectedIndexChanged += new System.EventHandler(this.lsx_DestinationPlanet_SelectedIndexChanged);
            // 
            // lbl_PlanetDestination
            // 
            this.lbl_PlanetDestination.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PlanetDestination.AutoSize = true;
            this.lbl_PlanetDestination.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PlanetDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PlanetDestination.ForeColor = System.Drawing.Color.White;
            this.lbl_PlanetDestination.Location = new System.Drawing.Point(33, 56);
            this.lbl_PlanetDestination.Name = "lbl_PlanetDestination";
            this.lbl_PlanetDestination.Size = new System.Drawing.Size(183, 25);
            this.lbl_PlanetDestination.TabIndex = 8;
            this.lbl_PlanetDestination.Text = "New Destination";
            // 
            // lbl_UrNewDestination
            // 
            this.lbl_UrNewDestination.AutoSize = true;
            this.lbl_UrNewDestination.BackColor = System.Drawing.Color.Transparent;
            this.lbl_UrNewDestination.ForeColor = System.Drawing.Color.White;
            this.lbl_UrNewDestination.Location = new System.Drawing.Point(255, 65);
            this.lbl_UrNewDestination.Name = "lbl_UrNewDestination";
            this.lbl_UrNewDestination.Size = new System.Drawing.Size(0, 13);
            this.lbl_UrNewDestination.TabIndex = 9;
            // 
            // Spaceship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_UrNewDestination);
            this.Controls.Add(this.lbl_PlanetDestination);
            this.Controls.Add(this.lsx_DestinationPlanet);
            this.Controls.Add(this.btn_GetPublicKeyPlanet);
            this.Controls.Add(this.btn_GetValidationCode);
            this.Controls.Add(this.pnlTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Spaceship";
            this.Text = "frmSpaceship";
            this.Load += new System.EventHandler(this.Spaceship_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Button btn_GetValidationCode;
        private System.Windows.Forms.Button btn_GetPublicKeyPlanet;
        private System.Windows.Forms.ListBox lsx_DestinationPlanet;
        private System.Windows.Forms.Label lbl_PlanetDestination;
        private System.Windows.Forms.Label lbl_UrNewDestination;
    }
}

