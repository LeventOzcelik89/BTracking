namespace BTracking.Browser
{
    partial class DailyData
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
            browser = new Microsoft.Web.WebView2.WinForms.WebView2();
            browser.Dock = DockStyle.Fill;
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)browser).BeginInit();
            SuspendLayout();
            // 
            // browser
            // 
            browser.AllowExternalDrop = true;
            browser.CreationProperties = null;
            browser.DefaultBackgroundColor = Color.White;
            browser.Location = new Point(12, 12);
            browser.Name = "browser";
            browser.Size = new Size(776, 385);
            browser.TabIndex = 0;
            browser.ZoomFactor = 1D;
            // 
            // button1
            // 
            button1.Location = new Point(604, 403);
            button1.Name = "button1";
            button1.Size = new Size(184, 35);
            button1.TabIndex = 1;
            button1.Text = "Download Historical Data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DailyData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(browser);
            Name = "DailyData";
            Text = "DailyData";
            ((System.ComponentModel.ISupportInitialize)browser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 browser;
        private Button button1;
    }
}