using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACS_NONAME_NAU
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            prbBarra.ForeColor = Color.FromArgb(255, 51, 51);
            prbBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        }


        private void timerProgressBar_Tick(object sender, EventArgs e)
        {
            prbBarra.Increment(3);
            lblCarga.Text = prbBarra.Value.ToString() + "%";

            int x = pbTieFighter.Location.X;
            int y = pbTieFighter.Location.Y;

            x += 9;

            Point punto = new Point(x, y);
            pbTieFighter.Location = punto;



            if (prbBarra.Value == prbBarra.Maximum)
            {
                timerProgressBar.Stop();
                this.Hide();
                frmShipView frm = new frmShipView();
                frm.ShowDialog();
            }
        }
    }
}
