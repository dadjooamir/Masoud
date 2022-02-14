using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersianMessagebox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = ShowMessage.Show("تنظیمات صخیخ است", "اطلاع رساني");


        }

               

        private void button3_Click_1(object sender, EventArgs e)
        {
        DialogResult result = ShowMessage.Show(
               "ايا از انجام اين عمليات مطمين هستيد", "هشدار",
               ShowMessage.PersianMessageBoxButton.YesNoCancel,
               ShowMessage.PersianMessageBoxIcon.Warning
               );

    }

    private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = ShowMessage.Show(
               "شما در حال اعمال تنظيمات زير هستيد ايا از انجام اين عمليات مطمين هستيد؟",
               "هشدار",
               ShowMessage.PersianMessageBoxButton.YesNo);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult result = ShowMessage.Show(
               "عمليات با خطا مواجه شد", "خطا",
               ShowMessage.PersianMessageBoxButton.OkCancel,
               ShowMessage.PersianMessageBoxIcon.Error
               );

        }
    }
}
