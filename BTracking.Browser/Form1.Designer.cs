namespace BTracking.Browser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            viewMonthly = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)viewMonthly).BeginInit();
            SuspendLayout();
            // 
            // viewMonthly
            // 
            viewMonthly.AllowExternalDrop = true;
            viewMonthly.CreationProperties = null;
            viewMonthly.DefaultBackgroundColor = Color.White;
            viewMonthly.Location = new Point(12, 12);
            viewMonthly.Name = "viewMonthly";
            viewMonthly.Size = new Size(776, 342);
            viewMonthly.TabIndex = 0;
            viewMonthly.ZoomFactor = 1D;
            viewMonthly.Click += viewMonthly_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 366);
            Controls.Add(viewMonthly);
            Name = "Form1";
            Text = "Browser";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)viewMonthly).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 viewMonthly;
    }
}