using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace custom_notification
{
    public partial class CustomNotification : UserControl
    {
        public CustomNotification(string message)
        {
            InitializeComponent();
            labelMessage.Text = message;
            buttonDelete.Click += (sender, e) =>
            {
                Dispose();
            };
        }
        public new void Dispose()
        {
            CurrentNotifications.Remove(this);
            RecalcLocations();
            base.Dispose();
        }

        private static void RecalcLocations()
        {
            for (int i = 0; i < CurrentNotifications.Count; i++)
            {
                var notification = CurrentNotifications[i];
                notification.Location = new Point(0, (notification.Height + 10) * i);
            }
        }

        static List<CustomNotification> CurrentNotifications { get; } = new List<CustomNotification>();
        public static void Show(IWin32Window owner, string message)
        {
            var notification = new CustomNotification(message);
            if (owner is Control control)
            {
                control.Controls.Add(notification);
                notification.Width = control.ClientRectangle.Width;
                CurrentNotifications.Add(notification);
                RecalcLocations();
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseDownLocation = Location;
            _mouseDownX = PointToScreen(e.Location).X;            
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            var delta = Math.Max(0, PointToScreen(e.Location).X - _mouseDownX);
            if(delta > (3 * Width) / 4)
            {
                Dispose();
            }
            else
            {
                Location = _mouseDownLocation;
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            buttonDelete.Visible = true;
            labelMessage.ForeColor = Color.LightYellow;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if(null == GetChildAtPoint(PointToClient(MousePosition)))
            {
                buttonDelete.Visible = false;
                labelMessage.ForeColor = Color.White;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (MouseButtons == MouseButtons.Left)
            {
                var delta = Math.Max(0, PointToScreen(e.Location).X - _mouseDownX);
                Location = new Point(delta, Location.Y);
            }
        }
        private Point _mouseDownLocation;
        private int _mouseDownX;
    }
}
