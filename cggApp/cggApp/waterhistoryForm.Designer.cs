using Smobiler.Core;
using System;

namespace cggApp
{
    partial class waterhistoryForm : Smobiler.Core.Controls.MobileForm
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
            this.imageButton1 = new Smobiler.Core.Controls.ImageButton();
            this.gridView1 = new Smobiler.Core.Controls.GridView();
            this.image1 = new Smobiler.Core.Controls.Image();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.imageButton1,
            this.gridView1,
            this.image1});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(74, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // imageButton1
            // 
            this.imageButton1.Location = new System.Drawing.Point(16, 37);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.ResourceID = "Arrow - Left";
            this.imageButton1.Size = new System.Drawing.Size(40, 40);
            this.imageButton1.Press += new System.EventHandler(this.imageButton1_Press);
            // 
            // gridView1
            // 
            this.gridView1.BackColor = System.Drawing.Color.PapayaWhip;
            this.gridView1.BorderRadius = 15;
            this.gridView1.GridLineColor = System.Drawing.Color.WhiteSmoke;
            this.gridView1.Location = new System.Drawing.Point(0, 154);
            this.gridView1.Name = "gridView1";
            this.gridView1.PageSize = 10;
            this.gridView1.PageSizeLoadText = "加载中...";
            this.gridView1.PageSizeTextColor = System.Drawing.Color.DimGray;
            this.gridView1.PageSizeTextSize = 11F;
            this.gridView1.Size = new System.Drawing.Size(300, 314);
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(29, 72);
            this.image1.Name = "image1";
            this.image1.ResourceID = "18";
            this.image1.Size = new System.Drawing.Size(244, 78);
            // 
            // waterhistoryForm
            // 
            this.BackgroundImage = "3.jpg";
            this.BackgroundImageSizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Load += new System.EventHandler(this.waterhistoryForm_Load);
            this.Name = "waterhistoryForm";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.ImageButton imageButton1;
        private Smobiler.Core.Controls.GridView gridView1;
        private Smobiler.Core.Controls.Image image1;
    }
}