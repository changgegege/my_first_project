using Smobiler.Core;
using System;

namespace cggApp
{
    partial class helpForm : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        //SmobilerForm overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //NOTE: The following procedure is required by the SmobilerForm
        //It can be modified using the SmobilerForm.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.pdfView1 = new Smobiler.Plugins.PDFView();
            this.imageButton2 = new Smobiler.Core.Controls.ImageButton();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.pdfView1,
            this.imageButton2});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(71, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // pdfView1
            // 
            this.pdfView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfView1.Location = new System.Drawing.Point(0, 186);
            this.pdfView1.Name = "pdfView1";
            this.pdfView1.ResourceID = "平台帮助";
            this.pdfView1.Size = new System.Drawing.Size(300, 475);
            // 
            // imageButton2
            // 
            this.imageButton2.Location = new System.Drawing.Point(16, 37);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.ResourceID = "Arrow - Left";
            this.imageButton2.Size = new System.Drawing.Size(40, 40);
            this.imageButton2.Press += new System.EventHandler(this.imageButton2_Press);
            // 
            // helpForm
            // 
            this.BackgroundImageSizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Name = "helpForm";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Plugins.PDFView pdfView1;
        private Smobiler.Core.Controls.ImageButton imageButton2;
    }
}