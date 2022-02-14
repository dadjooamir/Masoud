using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace Inputbox

{
    public partial class showinputbox : Form
    {
        public showinputbox()
        {
            InitializeComponent();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        public enum Input_Type
        {
            Text,
            Number,
        }

        public class GetInputType
        {
            public int Number_Value
            {
                get; set;
            }

            public string Text_Value
            {
                get; set;
            }
       }

        public Input_Type InputType
        {
            get; set;
        }

        private GetInputType _getInputType;
        public GetInputType Get_Input_Type
        {
            get
            {
                if (_getInputType == null)
                {
                    _getInputType =
                        new GetInputType();
                }
                return _getInputType;
            }
            set
            {
                _getInputType = value;
            }
        }

        private string GetValue(GetInputType get_Input_Type)
        {
            if (InputType == Input_Type.Text)
            {
                return get_Input_Type.Text_Value;
            }
            else
            {
                return get_Input_Type.Number_Value.ToString();
            }
        }

        private static void NumberTyping(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public static void TextTyping(System.Windows.Forms.KeyPressEventArgs e)
        {
                
        }

        public static string Showinput( String messge, Input_Type _inputType)

        {
            showinputbox inputbox = new showinputbox();
            string ret = "";
            inputbox.label2.Text = messge;
            inputbox.InputType = _inputType;
            inputbox.ShowDialog();
            try
            {
                if (inputbox.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    ret = inputbox.textBox1.Text;
                }
                inputbox.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().FullName, ex.Message);
            }

            return ret;
        }

        

       //EVENT

        private void showinputbox_Load(object sender, EventArgs e)
        {
            BtnOk.Location = new Point(267, 149);
            BtnCancell.Location = new Point(108, 149);
            label2.Location = new Point(65, 75);
            pictureBox1.Location = new Point(215, 10);
        }

        
        

        

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (InputType == Input_Type.Text)
            {
                TextTyping(e);
            }
            else
            {
                NumberTyping(e);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }
            else
            {
                if (InputType == Input_Type.Text)
                {
                    Get_Input_Type.Text_Value = textBox1.Text;
                }
                else
                {
                    try
                    {
                        Get_Input_Type.Number_Value = int.Parse(textBox1.Text);
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show($"{ex.Message}");
                    }
                }
            }
        }


        private void BtnOk_Click_1(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnCancell_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

       
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnOk.Focus();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("fa-IR"));
        }
    }
}



