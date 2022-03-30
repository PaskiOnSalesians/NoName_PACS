using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBase
{
    public partial class frmBaseMain : Form
    {
        public frmBaseMain()
        {
            InitializeComponent();
        }

        #region Variables

        //Variables base de dades

        #region Variables de customització de programa
        // Variables de tamany pantalla
        int MaximitzarPantalla = 0;

        // Dragging Variables
        bool dragging = false; // Per a comprovar si podem moure la finestra
        Point startPoint = new Point(0, 0); // Posicio inicial de la finestra
        #endregion

        #endregion

        #region Dragging window
        public void pnl_topbar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        public void pnl_topbar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        public void pnl_topbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }



        #endregion

        #region Minimize - Maximize - Exit

        // Botó Sortir
        public void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msgbuttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show("Segur que vols sortir?", "PACS - NONAME", msgbuttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Botó Minimitzar
        public void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Botó Maximitzar
        public void btn_maximize_Click(object sender, EventArgs e)
        {
            if (MaximitzarPantalla == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                MaximitzarPantalla++;

            }
            else if (MaximitzarPantalla == 1)
            {
                this.WindowState = FormWindowState.Normal;
                MaximitzarPantalla--;
            }
        }

        // Maximitzar/Normal amb la barra superior
        public void pnl_topbar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MaximitzarPantalla == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                MaximitzarPantalla++;

            }
            else if (MaximitzarPantalla == 1)
            {
                this.WindowState = FormWindowState.Normal;
                MaximitzarPantalla--;
            }
        }
        #endregion
     
       

       
    }
}
