using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace custom_notification
{
    public partial class CustomNotificationContainer : Form
    {
        public CustomNotificationContainer()
        {
            InitializeComponent();
            checkBoxDocked.CheckedChanged += (sender, e) =>
            {
                if(checkBoxDocked.Checked)
                {
                    var x =
                        Screen.PrimaryScreen.WorkingArea.X +
                        Screen.PrimaryScreen.WorkingArea.Width -
                        Width;

                    Location = new Point(x, Screen.PrimaryScreen.WorkingArea.Y);
                    Height = Screen.PrimaryScreen.WorkingArea.Height;
                }
                else
                {
                    Location = _defaultPos;
                    Size = _defaultSize;
                }
            };
            textBoxNewMessage.KeyDown += (sender, e) =>
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        e.SuppressKeyPress = true;
                        CustomNotification.Show(this, textBoxNewMessage.Text);
                        textBoxNewMessage.Clear();
                        break;
                }
            };
        }
        private Point _defaultPos;
        private Size _defaultSize;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _defaultPos = Location;
            _defaultSize = Size;
            CustomNotification.Show(this, "StackOverflow sent you a message");
            CustomNotification.Show(this, "IVSoftware wants your vote");
        }
    }
}
