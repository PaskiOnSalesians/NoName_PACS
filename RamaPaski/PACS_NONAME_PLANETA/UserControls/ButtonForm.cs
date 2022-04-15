using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class ButtonControl : UserControl
    {
        public ButtonControl()
        {
            InitializeComponent();
        }

        private String _buttonName;

        public String ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

        private string _FormName;

        public string FormName
        {
            get { return _FormName; }
            set { _FormName = value; }
        }

        private bool _Enabled;

        public bool ButtonEnabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }
    }
}
