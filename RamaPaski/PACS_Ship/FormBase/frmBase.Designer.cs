
namespace FormBase
{
    partial class frmBase
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
            this.TopSeparator = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BotBar = new System.Windows.Forms.Panel();
            this.DevelopersGroup = new System.Windows.Forms.Label();
            this.CopyRight = new System.Windows.Forms.Label();
            this.SeparatorBotLine = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ActionButtons = new System.Windows.Forms.Panel();
            this.CloseApp = new System.Windows.Forms.Button();
            this.MinimizeApp = new System.Windows.Forms.Button();
            this.TopSeparator.SuspendLayout();
            this.BotBar.SuspendLayout();
            this.TopBar.SuspendLayout();
            this.ActionButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopSeparator
            // 
            this.TopSeparator.Controls.Add(this.panel3);
            this.TopSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopSeparator.Location = new System.Drawing.Point(0, 65);
            this.TopSeparator.Name = "TopSeparator";
            this.TopSeparator.Size = new System.Drawing.Size(1366, 35);
            this.TopSeparator.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1366, 10);
            this.panel3.TabIndex = 8;
            // 
            // BotBar
            // 
            this.BotBar.Controls.Add(this.DevelopersGroup);
            this.BotBar.Controls.Add(this.CopyRight);
            this.BotBar.Controls.Add(this.SeparatorBotLine);
            this.BotBar.Controls.Add(this.panel1);
            this.BotBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BotBar.Location = new System.Drawing.Point(0, 683);
            this.BotBar.Name = "BotBar";
            this.BotBar.Size = new System.Drawing.Size(1366, 85);
            this.BotBar.TabIndex = 9;
            // 
            // DevelopersGroup
            // 
            this.DevelopersGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DevelopersGroup.AutoSize = true;
            this.DevelopersGroup.ForeColor = System.Drawing.Color.White;
            this.DevelopersGroup.Location = new System.Drawing.Point(1126, 54);
            this.DevelopersGroup.Name = "DevelopersGroup";
            this.DevelopersGroup.Size = new System.Drawing.Size(150, 13);
            this.DevelopersGroup.TabIndex = 11;
            this.DevelopersGroup.Text = "Developed by NoName Group";
            // 
            // CopyRight
            // 
            this.CopyRight.AutoSize = true;
            this.CopyRight.ForeColor = System.Drawing.Color.White;
            this.CopyRight.Location = new System.Drawing.Point(90, 54);
            this.CopyRight.Name = "CopyRight";
            this.CopyRight.Size = new System.Drawing.Size(90, 13);
            this.CopyRight.TabIndex = 10;
            this.CopyRight.Text = "Copyright © 2022";
            // 
            // SeparatorBotLine
            // 
            this.SeparatorBotLine.BackColor = System.Drawing.Color.White;
            this.SeparatorBotLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.SeparatorBotLine.Location = new System.Drawing.Point(0, 25);
            this.SeparatorBotLine.Name = "SeparatorBotLine";
            this.SeparatorBotLine.Size = new System.Drawing.Size(1366, 10);
            this.SeparatorBotLine.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 25);
            this.panel1.TabIndex = 8;
            // 
            // TopBar
            // 
            this.TopBar.Controls.Add(this.lblTitle);
            this.TopBar.Controls.Add(this.ActionButtons);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(1366, 65);
            this.TopBar.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(58, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(473, 39);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "PACS - Spaceship Interface";
            // 
            // ActionButtons
            // 
            this.ActionButtons.Controls.Add(this.CloseApp);
            this.ActionButtons.Controls.Add(this.MinimizeApp);
            this.ActionButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.ActionButtons.Location = new System.Drawing.Point(1216, 0);
            this.ActionButtons.Name = "ActionButtons";
            this.ActionButtons.Size = new System.Drawing.Size(150, 65);
            this.ActionButtons.TabIndex = 0;
            // 
            // CloseApp
            // 
            this.CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloseApp.FlatAppearance.BorderSize = 0;
            this.CloseApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.CloseApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.CloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseApp.ForeColor = System.Drawing.Color.White;
            this.CloseApp.Location = new System.Drawing.Point(75, 0);
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(75, 65);
            this.CloseApp.TabIndex = 1;
            this.CloseApp.Text = "×";
            this.CloseApp.UseVisualStyleBackColor = true;
            this.CloseApp.Click += new System.EventHandler(this.CloseApp_Click);
            // 
            // MinimizeApp
            // 
            this.MinimizeApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeApp.Dock = System.Windows.Forms.DockStyle.Left;
            this.MinimizeApp.FlatAppearance.BorderSize = 0;
            this.MinimizeApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.MinimizeApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.MinimizeApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeApp.ForeColor = System.Drawing.Color.White;
            this.MinimizeApp.Location = new System.Drawing.Point(0, 0);
            this.MinimizeApp.Name = "MinimizeApp";
            this.MinimizeApp.Size = new System.Drawing.Size(75, 65);
            this.MinimizeApp.TabIndex = 0;
            this.MinimizeApp.Text = "─";
            this.MinimizeApp.UseVisualStyleBackColor = true;
            this.MinimizeApp.Click += new System.EventHandler(this.MinimizeApp_Click);
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.TopSeparator);
            this.Controls.Add(this.BotBar);
            this.Controls.Add(this.TopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBase";
            this.TopSeparator.ResumeLayout(false);
            this.BotBar.ResumeLayout(false);
            this.BotBar.PerformLayout();
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.ActionButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopSeparator;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel BotBar;
        private System.Windows.Forms.Label DevelopersGroup;
        private System.Windows.Forms.Label CopyRight;
        private System.Windows.Forms.Panel SeparatorBotLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TopBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel ActionButtons;
        private System.Windows.Forms.Button CloseApp;
        private System.Windows.Forms.Button MinimizeApp;
    }
}

