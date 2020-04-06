using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OctopusV3.Builder.EntityFrm
{
    public partial class CreateControllerForm : Form
    {
        protected MainForm main { get; set; }

        public CreateControllerForm(MainForm _main)
        {
            InitializeComponent();
            this.main = _main;
        }
    }
}
