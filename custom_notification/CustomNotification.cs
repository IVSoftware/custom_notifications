using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace custom_notification
{
    public partial class CustomNotification : UserControl
    {
        static List<CustomNotification> CurrentNotifications { get; } = new List<CustomNotification>();
        private CustomNotification(string message)
        {
            InitializeComponent();
            labelMessage.Text = message;
            buttonDelete.Click += (sender, e) =>
            {
                Dispose();
            };
        }

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

        // Called when the number of messages changes
        private static void RecalcLocations()
        {
            for (int i = 0; i < CurrentNotifications.Count; i++)
            {
                var notification = CurrentNotifications[i];
                notification.Location = new Point(0, (notification.Height + 10) * i);
            }
        }
        // Capture mouse down X position IN SCREEN COORDINATES
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseDownLocation = Location;
            _mouseDownX = PointToScreen(e.Location).X;
        }
        // Most of the issues are solved by using screen coordinates.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (MouseButtons == MouseButtons.Left)
            {
                var delta = Math.Max(0, PointToScreen(e.Location).X - _mouseDownX);
                Location = new Point(delta, Location.Y);
            }
        }
        // Snap back or delete
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            var delta = Math.Max(0, PointToScreen(e.Location).X - _mouseDownX);
            if(delta > (3 * Width) / 4)
            {
                // Delete the message if hard swipe right.
                Dispose();
            }
            else
            {
                // Put it back where it was
                Location = _mouseDownLocation;
            }
        }
        // Hover behavior
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
        public new void Dispose()
        {
            CurrentNotifications.Remove(this);
            RecalcLocations();
            base.Dispose();
        }
        private Point _mouseDownLocation;
        private int _mouseDownX;
    }
}
