namespace PACS_Ship
{
    partial class frmSelectShip
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
            this.ButtonsContainer = new System.Windows.Forms.Panel();
            this.Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectShip = new System.Windows.Forms.Button();
            this.btnConnectPlanet = new System.Windows.Forms.Button();
            this.btnSelectPlanet = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnFileProcessing = new System.Windows.Forms.Button();
            this.btnEncryptCodes = new System.Windows.Forms.Button();
            this.RightSeparatorButtons = new System.Windows.Forms.Panel();
            this.LeftSeparatorButtons = new System.Windows.Forms.Panel();
            this.BotSeparator = new System.Windows.Forms.Panel();
            this.LeftBar = new System.Windows.Forms.Panel();
            this.RightBar = new System.Windows.Forms.Panel();
            this.RightSeparator = new System.Windows.Forms.Panel();
            this.LeftSeparator = new System.Windows.Forms.Panel();
            this.lstvTopBorder = new System.Windows.Forms.Panel();
            this.lstvBotBorder = new System.Windows.Forms.Panel();
            this.lstvLeftBorder = new System.Windows.Forms.Panel();
            this.lstvRightBorder = new System.Windows.Forms.Panel();
            this.lstvSpaceship = new System.Windows.Forms.ListView();
            this.ButtonsContainer.SuspendLayout();
            this.Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsContainer
            // 
            this.ButtonsContainer.Controls.Add(this.Buttons);
            this.ButtonsContainer.Controls.Add(this.RightSeparatorButtons);
            this.ButtonsContainer.Controls.Add(this.LeftSeparatorButtons);
            this.ButtonsContainer.Controls.Add(this.BotSeparator);
            this.ButtonsContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsContainer.Location = new System.Drawing.Point(0, 558);
            this.ButtonsContainer.Name = "ButtonsContainer";
            this.ButtonsContainer.Size = new System.Drawing.Size(1366, 125);
            this.ButtonsContainer.TabIndex = 40;
            // 
            // Buttons
            // 
            this.Buttons.ColumnCount = 6;
            this.Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Buttons.Controls.Add(this.btnSelectShip, 0, 0);
            this.Buttons.Controls.Add(this.btnConnectPlanet, 2, 0);
            this.Buttons.Controls.Add(this.btnSelectPlanet, 1, 0);
            this.Buttons.Controls.Add(this.btnEnd, 5, 0);
            this.Buttons.Controls.Add(this.btnFileProcessing, 4, 0);
            this.Buttons.Controls.Add(this.btnEncryptCodes, 3, 0);
            this.Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Buttons.Location = new System.Drawing.Point(90, 25);
            this.Buttons.Name = "Buttons";
            this.Buttons.RowCount = 1;
            this.Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Buttons.Size = new System.Drawing.Size(1186, 100);
            this.Buttons.TabIndex = 27;
            // 
            // btnSelectShip
            // 
            this.btnSelectShip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectShip.FlatAppearance.BorderSize = 5;
            this.btnSelectShip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSelectShip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.btnSelectShip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSelectShip.ForeColor = System.Drawing.Color.White;
            this.btnSelectShip.Location = new System.Drawing.Point(3, 3);
            this.btnSelectShip.Name = "btnSelectShip";
            this.btnSelectShip.Size = new System.Drawing.Size(191, 94);
            this.btnSelectShip.TabIndex = 8;
            this.btnSelectShip.Text = "Select Spaceship";
            this.btnSelectShip.UseVisualStyleBackColor = true;
            this.btnSelectShip.Click += new System.EventHandler(this.btnSelectSpaceship_Click);
            // 
            // btnConnectPlanet
            // 
            this.btnConnectPlanet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnectPlanet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectPlanet.Enabled = false;
            this.btnConnectPlanet.FlatAppearance.BorderSize = 5;
            this.btnConnectPlanet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnConnectPlanet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.btnConnectPlanet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectPlanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnConnectPlanet.ForeColor = System.Drawing.Color.White;
            this.btnConnectPlanet.Location = new System.Drawing.Point(397, 3);
            this.btnConnectPlanet.Name = "btnConnectPlanet";
            this.btnConnectPlanet.Size = new System.Drawing.Size(191, 94);
            this.btnConnectPlanet.TabIndex = 9;
            this.btnConnectPlanet.Text = "Connect Planet";
            this.btnConnectPlanet.UseVisualStyleBackColor = true;
            this.btnConnectPlanet.Click += new System.EventHandler(this.btnConnectPlanet_Click);
            // 
            // btnSelectPlanet
            // 
            this.btnSelectPlanet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectPlanet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectPlanet.Enabled = false;
            this.btnSelectPlanet.FlatAppearance.BorderSize = 5;
            this.btnSelectPlanet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSelectPlanet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.btnSelectPlanet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectPlanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPlanet.ForeColor = System.Drawing.Color.White;
            this.btnSelectPlanet.Location = new System.Drawing.Point(200, 3);
            this.btnSelectPlanet.Name = "btnSelectPlanet";
            this.btnSelectPlanet.Size = new System.Drawing.Size(191, 94);
            this.btnSelectPlanet.TabIndex = 2;
            this.btnSelectPlanet.Text = "Select Planet";
            this.btnSelectPlanet.UseVisualStyleBackColor = true;
            this.btnSelectPlanet.Click += new System.EventHandler(this.btnSelectPlanet_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnd.Enabled = false;
            this.btnEnd.FlatAppearance.BorderSize = 5;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnEnd.ForeColor = System.Drawing.Color.White;
            this.btnEnd.Location = new System.Drawing.Point(988, 3);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(195, 94);
            this.btnEnd.TabIndex = 6;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnFileProcessing
            // 
            this.btnFileProcessing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFileProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFileProcessing.Enabled = false;
            this.btnFileProcessing.FlatAppearance.BorderSize = 5;
            this.btnFileProcessing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnFileProcessing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.btnFileProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnFileProcessing.ForeColor = System.Drawing.Color.White;
            this.btnFileProcessing.Location = new System.Drawing.Point(791, 3);
            this.btnFileProcessing.Name = "btnFileProcessing";
            this.btnFileProcessing.Size = new System.Drawing.Size(191, 94);
            this.btnFileProcessing.TabIndex = 5;
            this.btnFileProcessing.Text = "File Processing";
            this.btnFileProcessing.UseVisualStyleBackColor = true;
            this.btnFileProcessing.Click += new System.EventHandler(this.btnFileProcessing_Click);
            // 
            // btnEncryptCodes
            // 
            this.btnEncryptCodes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncryptCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEncryptCodes.Enabled = false;
            this.btnEncryptCodes.FlatAppearance.BorderSize = 5;
            this.btnEncryptCodes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnEncryptCodes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.btnEncryptCodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncryptCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnEncryptCodes.ForeColor = System.Drawing.Color.White;
            this.btnEncryptCodes.Location = new System.Drawing.Point(594, 3);
            this.btnEncryptCodes.Name = "btnEncryptCodes";
            this.btnEncryptCodes.Size = new System.Drawing.Size(191, 94);
            this.btnEncryptCodes.TabIndex = 4;
            this.btnEncryptCodes.Text = "Encrypt Codes";
            this.btnEncryptCodes.UseVisualStyleBackColor = true;
            this.btnEncryptCodes.Click += new System.EventHandler(this.btnEncryptCodes_Click);
            // 
            // RightSeparatorButtons
            // 
            this.RightSeparatorButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightSeparatorButtons.Location = new System.Drawing.Point(1276, 25);
            this.RightSeparatorButtons.Name = "RightSeparatorButtons";
            this.RightSeparatorButtons.Size = new System.Drawing.Size(90, 100);
            this.RightSeparatorButtons.TabIndex = 17;
            // 
            // LeftSeparatorButtons
            // 
            this.LeftSeparatorButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSeparatorButtons.Location = new System.Drawing.Point(0, 25);
            this.LeftSeparatorButtons.Name = "LeftSeparatorButtons";
            this.LeftSeparatorButtons.Size = new System.Drawing.Size(90, 100);
            this.LeftSeparatorButtons.TabIndex = 16;
            // 
            // BotSeparator
            // 
            this.BotSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.BotSeparator.Location = new System.Drawing.Point(0, 0);
            this.BotSeparator.Name = "BotSeparator";
            this.BotSeparator.Size = new System.Drawing.Size(1366, 25);
            this.BotSeparator.TabIndex = 5;
            // 
            // LeftBar
            // 
            this.LeftBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftBar.Location = new System.Drawing.Point(0, 100);
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.Size = new System.Drawing.Size(65, 458);
            this.LeftBar.TabIndex = 41;
            // 
            // RightBar
            // 
            this.RightBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightBar.Location = new System.Drawing.Point(1301, 100);
            this.RightBar.Name = "RightBar";
            this.RightBar.Size = new System.Drawing.Size(65, 458);
            this.RightBar.TabIndex = 42;
            // 
            // RightSeparator
            // 
            this.RightSeparator.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightSeparator.Location = new System.Drawing.Point(1276, 100);
            this.RightSeparator.Name = "RightSeparator";
            this.RightSeparator.Size = new System.Drawing.Size(25, 458);
            this.RightSeparator.TabIndex = 43;
            // 
            // LeftSeparator
            // 
            this.LeftSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSeparator.Location = new System.Drawing.Point(65, 100);
            this.LeftSeparator.Name = "LeftSeparator";
            this.LeftSeparator.Size = new System.Drawing.Size(25, 458);
            this.LeftSeparator.TabIndex = 44;
            // 
            // lstvTopBorder
            // 
            this.lstvTopBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lstvTopBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstvTopBorder.Location = new System.Drawing.Point(90, 100);
            this.lstvTopBorder.Name = "lstvTopBorder";
            this.lstvTopBorder.Size = new System.Drawing.Size(1186, 10);
            this.lstvTopBorder.TabIndex = 45;
            // 
            // lstvBotBorder
            // 
            this.lstvBotBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lstvBotBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstvBotBorder.Location = new System.Drawing.Point(90, 548);
            this.lstvBotBorder.Name = "lstvBotBorder";
            this.lstvBotBorder.Size = new System.Drawing.Size(1186, 10);
            this.lstvBotBorder.TabIndex = 46;
            // 
            // lstvLeftBorder
            // 
            this.lstvLeftBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lstvLeftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstvLeftBorder.Location = new System.Drawing.Point(90, 110);
            this.lstvLeftBorder.Name = "lstvLeftBorder";
            this.lstvLeftBorder.Size = new System.Drawing.Size(10, 438);
            this.lstvLeftBorder.TabIndex = 48;
            // 
            // lstvRightBorder
            // 
            this.lstvRightBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lstvRightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstvRightBorder.Location = new System.Drawing.Point(1266, 110);
            this.lstvRightBorder.Name = "lstvRightBorder";
            this.lstvRightBorder.Size = new System.Drawing.Size(10, 438);
            this.lstvRightBorder.TabIndex = 49;
            // 
            // lstvSpaceship
            // 
            this.lstvSpaceship.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lstvSpaceship.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstvSpaceship.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstvSpaceship.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvSpaceship.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvSpaceship.ForeColor = System.Drawing.Color.White;
            this.lstvSpaceship.HideSelection = false;
            this.lstvSpaceship.Location = new System.Drawing.Point(100, 110);
            this.lstvSpaceship.Name = "lstvSpaceship";
            this.lstvSpaceship.Size = new System.Drawing.Size(1166, 438);
            this.lstvSpaceship.TabIndex = 50;
            this.lstvSpaceship.UseCompatibleStateImageBehavior = false;
            this.lstvSpaceship.SelectedIndexChanged += new System.EventHandler(this.lstvSpaceship_SelectedIndexChanged);
            this.lstvSpaceship.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstvSpaceship_KeyPress);
            this.lstvSpaceship.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstvSpaceship_MouseDoubleClick);
            // 
            // frmSelectShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.lstvSpaceship);
            this.Controls.Add(this.lstvRightBorder);
            this.Controls.Add(this.lstvLeftBorder);
            this.Controls.Add(this.lstvBotBorder);
            this.Controls.Add(this.lstvTopBorder);
            this.Controls.Add(this.LeftSeparator);
            this.Controls.Add(this.RightSeparator);
            this.Controls.Add(this.RightBar);
            this.Controls.Add(this.LeftBar);
            this.Controls.Add(this.ButtonsContainer);
            this.Name = "frmSelectShip";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSelectShip_Load);
            this.Controls.SetChildIndex(this.ButtonsContainer, 0);
            this.Controls.SetChildIndex(this.LeftBar, 0);
            this.Controls.SetChildIndex(this.RightBar, 0);
            this.Controls.SetChildIndex(this.RightSeparator, 0);
            this.Controls.SetChildIndex(this.LeftSeparator, 0);
            this.Controls.SetChildIndex(this.lstvTopBorder, 0);
            this.Controls.SetChildIndex(this.lstvBotBorder, 0);
            this.Controls.SetChildIndex(this.lstvLeftBorder, 0);
            this.Controls.SetChildIndex(this.lstvRightBorder, 0);
            this.Controls.SetChildIndex(this.lstvSpaceship, 0);
            this.ButtonsContainer.ResumeLayout(false);
            this.Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsContainer;
        private System.Windows.Forms.Panel RightSeparatorButtons;
        private System.Windows.Forms.Panel LeftSeparatorButtons;
        private System.Windows.Forms.Panel BotSeparator;
        private System.Windows.Forms.Panel LeftBar;
        private System.Windows.Forms.Panel RightBar;
        private System.Windows.Forms.Panel RightSeparator;
        private System.Windows.Forms.Panel LeftSeparator;
        private System.Windows.Forms.Panel lstvTopBorder;
        private System.Windows.Forms.Panel lstvBotBorder;
        private System.Windows.Forms.Panel lstvLeftBorder;
        private System.Windows.Forms.Panel lstvRightBorder;
        private System.Windows.Forms.ListView lstvSpaceship;
        private System.Windows.Forms.TableLayoutPanel Buttons;
        private System.Windows.Forms.Button btnSelectShip;
        private System.Windows.Forms.Button btnConnectPlanet;
        private System.Windows.Forms.Button btnSelectPlanet;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnFileProcessing;
        private System.Windows.Forms.Button btnEncryptCodes;
    }
}

