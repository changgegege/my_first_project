using Smobiler.Core;
using System;

namespace cggApp
{
    partial class pageviewcontrol : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        //SmobilerUserControl overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //NOTE: The following procedure is required by the SmobilerUserControl
        //It can be modified using the SmobilerUserControl.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.pageView1 = new Smobiler.Core.Controls.PageView();
            this.image1 = new Smobiler.Core.Controls.Image();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.pageView1,
            this.image1});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(119, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // pageView1
            // 
            this.pageView1.BorderRadius = 6;
            this.pageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView1.IsLoop = true;
            this.pageView1.Location = new System.Drawing.Point(101, 45);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(300, 300);
            // 
            // image1
            // 
            this.image1.DisplayMember = "img";
            this.image1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image1.Location = new System.Drawing.Point(170, 39);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(45, 45);
            this.image1.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // pageviewcontrol
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(300, 150);
            this.Name = "pageviewcontrol";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.PageView pageView1;
        private Smobiler.Core.Controls.Image image1;
    }
}