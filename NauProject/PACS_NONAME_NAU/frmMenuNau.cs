using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormBase;

namespace PACS_NONAME_NAU
{
    public partial class frmMenuNau : frmBaseMain
    {
        public frmMenuNau()
        {
            InitializeComponent();
            label1.Text = VariablesGlobals.RefVariables.ShipName;
            label2.Text = VariablesGlobals.RefVariables.ShipId.ToString();
            label3.Text = VariablesGlobals.RefVariables.ShipFilePort.ToString();
            label4.Text = VariablesGlobals.RefVariables.ShipMessagePort.ToString();
            pictureBox1.Image = Image.FromFile(VariablesGlobals.RefVariables.ShipImage);

        }

        
    }
}
