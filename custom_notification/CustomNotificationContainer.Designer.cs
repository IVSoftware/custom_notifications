
namespace custom_notification
{
    partial class CustomNotificationContainer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxDocked = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxDocked
            // 
            this.checkBoxDocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDocked.AutoSize = true;
            this.checkBoxDocked.Location = new System.Drawing.Point(12, 703);
            this.checkBoxDocked.Name = "checkBoxDocked";
            this.checkBoxDocked.Size = new System.Drawing.Size(99, 29);
            this.checkBoxDocked.TabIndex = 0;
            this.checkBoxDocked.Text = "Docked";
            this.checkBoxDocked.UseVisualStyleBackColor = true;
            // 
            // CustomNotificationContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 744);
            this.Controls.Add(this.checkBoxDocked);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomNotificationContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Container";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxDocked;
    }
}