using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sekiro40v
{
    public partial class Form1 : Form
    {
        private App app;

        public Form1(App app)
        {
            this.app = app;

            InitializeComponent();

            textBox1.Text = app.memoryHook.processName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var hp = app.memoryHook.ReadMemory();
            label1.Text = hp.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            app.memoryHook.processName = textBox1.Text;
        }
    }
}