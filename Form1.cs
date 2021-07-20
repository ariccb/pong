using pong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_pong
{
    public partial class Form1 : Form
    {
        private Canvas window;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // the sender is the button itself in this case
                                                               // e is the event argument
        {
            window = new Canvas();
            window.Text = "Pong Game Screen";
            window.Show();

        }
    }
}
