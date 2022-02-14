using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersianMessagebox
{
    public partial class ShowMessage : Form
    {
        public ShowMessage()
        {
          
            InitializeComponent();

        }
        private enum PersianDialogResult
        {
            Yes, No, Ok, Cancel
        }
        public enum PersianMessageBoxButton
        {
            Ok, OkCancel, YesNo, YesNoCancel
        }
        public enum PersianMessageBoxType
        {
            Error, Warning,Qustion,Information
        }
        public enum PersianMessageBoxIcon
        {
            Warning, Information, Error, Qustion, None
        }
        DialogResult _persianDialogResult;
        private DialogResult PersianResult
        {
            get { return _persianDialogResult; }
            set { _persianDialogResult = value; }
        }

        private Image GetIcon(PersianMessageBoxIcon MessageIcon)
        {
            switch (MessageIcon)
            {
                case PersianMessageBoxIcon.Information:
                    return Properties.Resources.information;
                case PersianMessageBoxIcon.Warning:
                    return Properties.Resources.warning;
                case PersianMessageBoxIcon.Error:
                    return Properties.Resources.Error;
                case PersianMessageBoxIcon.Qustion:
                    return Properties.Resources.question;
                default:
                    return Properties.Resources.information;
            }
         
        }


        private void SetButton(PersianMessageBoxButton MessageButton)
        {


            switch (MessageButton)
            {

                case PersianMessageBoxButton.Ok:
                    btnOk.Visible = true;
                    btnCancel.Visible = false;
                    btnYes.Visible = false;
                    btnNo.Visible = false;
                    btnOk.Location = new Point(204, 153);
                    btnOk.Top = lblText.Bottom + 5;
                    break;

                case PersianMessageBoxButton.OkCancel:
                    btnOk.Visible = true;
                    btnCancel.Visible = true;
                    btnYes.Visible = false;
                    btnNo.Visible = false;


                    btnOk.Location = new Point(118, 153);
                    btnCancel.Location = new Point(268, 153);
                    btnOk.Top = lblText.Bottom + 5;
                    btnCancel.Top = lblText.Bottom + 5;
                    break;



                case PersianMessageBoxButton.YesNo:
                    btnOk.Visible = false;
                    btnCancel.Visible = false;
                    btnYes.Visible = true;
                    btnNo.Visible = true;


                    btnYes.Location = new Point(118, 153);
                    btnNo.Location = new Point(268, 153);
                    btnYes.Top = lblText.Bottom + 5;
                    btnNo.Top = lblText.Bottom + 5;
                    break;

                case PersianMessageBoxButton.YesNoCancel:
                    btnOk.Visible = false;
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    btnCancel.Visible = true;


                    btnYes.Location = new Point(347, 153);
                    btnNo.Location = new Point(204, 153);
                    btnCancel.Location = new Point(61, 153);
                    btnYes.Top = lblText.Bottom + 5;
                    btnNo.Top = lblText.Bottom + 5;
                    btnCancel.Top = lblText.Bottom + 5;
                    
                    break;

            }
        }
       

        private void SetTheme(PersianMessageBoxType Types)
        {

            switch (Types)
            {

                
                case PersianMessageBoxType.Error:
                    this.BackColor = System.Drawing.Color.FromArgb(247, 176, 176);
                    break;
                case PersianMessageBoxType.Warning:
                    this.BackColor = System.Drawing.Color.FromArgb(241, 255, 148);
                    break;
                case PersianMessageBoxType.Information:
                    this.BackColor = System.Drawing.Color.FromArgb(178, 247, 176);
                    break;
                case PersianMessageBoxType.Qustion:
                    this.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
                    break;
            }
        }

        private void GetSound(PersianMessageBoxIcon MessageIcon)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            switch (MessageIcon)
            {
                case PersianMessageBoxIcon.Error:
                    player.Stream = Properties.Resources.sound_Error;
                    player.Play();
                    break;
                case PersianMessageBoxIcon.Information:
                    player.Stream = Properties.Resources.sound_information;
                    player.Play();
                    break;
                case PersianMessageBoxIcon.Qustion:
                    player.Stream = Properties.Resources.sound_question;
                    player.Play();
                    break;
                case PersianMessageBoxIcon.Warning:
                    player.Stream = Properties.Resources.sound_warning;
                    player.Play();
                    break;
            }
        }

        public static DialogResult Show(string Message)
        {
            ShowMessage Bax = new ShowMessage();
            Bax.Text = " ";
            Bax.lblText.Text = Message;
            Bax.pbxIcon.Image = Bax.GetIcon(PersianMessageBoxIcon.Information);
            Bax.GetSound(PersianMessageBoxIcon.Information);
            Bax.SetButton(PersianMessageBoxButton.Ok);
            Bax.ShowDialog();
            return Bax._persianDialogResult;
        }

        public static DialogResult Show(
            string Message, 
            string Title)
        {
            ShowMessage Bax = new ShowMessage();
            Bax.lbl2.Text = Title;
            Bax.lblText.Text = Message;
            Bax.pbxIcon.Image = Bax.GetIcon(PersianMessageBoxIcon.Information);
            Bax.GetSound(PersianMessageBoxIcon.Information);
            Bax.SetButton(PersianMessageBoxButton.Ok);
            Bax.ShowDialog();
            return Bax._persianDialogResult;
        }
        public static DialogResult Show(
            string Message,
            string Title,
            PersianMessageBoxButton MessageButton)
        {
            ShowMessage Bax = new ShowMessage();
            Bax.lbl2.Text = Title;
            Bax.lblText.Text = Message;
            Bax.SetButton(MessageButton);
            Bax.pbxIcon.Image = Bax.GetIcon(PersianMessageBoxIcon.Information);
            Bax.ShowDialog();
            return Bax._persianDialogResult;
        }
        public static DialogResult Show(
            string Message,
            string Title, 
            PersianMessageBoxButton MessageButton,
            PersianMessageBoxIcon MessageIcon)
        {
            ShowMessage Bax = new ShowMessage();
            Bax.lbl2.Text = Title;
            Bax.lblText.Text = Message;
            Bax.SetButton(MessageButton);
            Bax.pbxIcon.Image = Bax.GetIcon(MessageIcon);
            Bax.GetSound(MessageIcon);
            Bax.ShowDialog();
            return Bax._persianDialogResult;
        }
        public static DialogResult Show(
            string Message,
            string Title,
            PersianMessageBoxButton MessageButton,
            PersianMessageBoxIcon MessageIcon,
            PersianMessageBoxType Types)

        {
            ShowMessage Bax = new ShowMessage();
            Bax.lbl2.Text = Title;
            Bax.lblText.Text = Message;
            Bax.SetButton(MessageButton);
            Bax.pbxIcon.Image = Bax.GetIcon(MessageIcon);
            Bax.GetSound(MessageIcon);
            Bax.SetTheme(Types);
            global::System.Object p = Bax.ShowDialog();
            return Bax._persianDialogResult;
        }

       

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            PersianResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            PersianResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_Click_1(object sender, EventArgs e)
        {
            PersianResult = DialogResult.No;
            this.Close();
        }

        private void btnYes_Click_1(object sender, EventArgs e)
        {
            PersianResult = DialogResult.Yes;
            this.Close();
        }
    }
}
