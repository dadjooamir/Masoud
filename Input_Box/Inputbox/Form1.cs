using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inputbox
{
    public partial class TEST : Form
    {
        public TEST()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = Inputbox.showinputbox.Showinput("لطفا مقادير مورد نظر را وارد كنيد ", showinputbox.Input_Type.Text);
            MessageBox.Show(name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = Inputbox.showinputbox.Showinput("لطفا مقادير مورد نظر را وارد كنيد ", showinputbox.Input_Type.Number);
            MessageBox.Show(name);

        }
    }
}
