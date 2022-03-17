using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACS_NONAME_PLANETA
{
    public partial class PlanetView : Form
    {
        #region Variables
        // Dragging Variables
        bool dragging = false; // Per a comprovar si podem moure la finestra
        Point startPoint = new Point(0, 0); // Posicio inicial de la finestra
        #endregion

        public PlanetView()
        {
            InitializeComponent();
        }

        #region Dragging window
        private void pnl_topbar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnl_topbar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pnl_topbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        #endregion

        private void lblExit_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Segur que vols sortir?");

        }
    }
}
