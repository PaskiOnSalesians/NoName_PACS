
namespace Criptografia
{
    partial class frmValidacio
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
            this.btnKeyPair = new System.Windows.Forms.Button();
            this.btnPublicKey = new System.Windows.Forms.Button();
            this.btnGenerarXifrat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKeyPair
            // 
            this.btnKeyPair.Location = new System.Drawing.Point(34, 49);
            this.btnKeyPair.Name = "btnKeyPair";
            this.btnKeyPair.Size = new System.Drawing.Size(175, 84);
            this.btnKeyPair.TabIndex = 0;
            this.btnKeyPair.Text = "Generar KeyPair";
            this.btnKeyPair.UseVisualStyleBackColor = true;
            this.btnKeyPair.Click += new System.EventHandler(this.btnKeyPair_Click);
            // 
            // btnPublicKey
            // 
            this.btnPublicKey.Location = new System.Drawing.Point(34, 160);
            this.btnPublicKey.Name = "btnPublicKey";
            this.btnPublicKey.Size = new System.Drawing.Size(175, 89);
            this.btnPublicKey.TabIndex = 1;
            this.btnPublicKey.Text = "Conseguir PubicKey";
            this.btnPublicKey.UseVisualStyleBackColor = true;
            this.btnPublicKey.Click += new System.EventHandler(this.btnPublicKey_Click);
            // 
            // btnGenerarXifrat
            // 
            this.btnGenerarXifrat.Location = new System.Drawing.Point(34, 285);
            this.btnGenerarXifrat.Name = "btnGenerarXifrat";
            this.btnGenerarXifrat.Size = new System.Drawing.Size(175, 84);
            this.btnGenerarXifrat.TabIndex = 3;
            this.btnGenerarXifrat.Text = "Generar xifrat";
            this.btnGenerarXifrat.UseVisualStyleBackColor = true;
            this.btnGenerarXifrat.Click += new System.EventHandler(this.btnGenerarXifrat_Click);
            // 
            // frmValidacio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerarXifrat);
            this.Controls.Add(this.btnPublicKey);
            this.Controls.Add(this.btnKeyPair);
            this.Name = "frmValidacio";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmValidacio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKeyPair;
        private System.Windows.Forms.Button btnPublicKey;
        private System.Windows.Forms.Button btnGenerarXifrat;
    }
}

