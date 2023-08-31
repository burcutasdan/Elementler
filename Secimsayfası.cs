using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elementler
{
    public partial class Secimsayfası : Form
    {
        public Secimsayfası()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Metaller mtl=new Metaller();
            mtl.Show();
            this.Hide();
        }
    }
}
