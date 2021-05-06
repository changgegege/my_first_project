using Smobiler.Core;
using System;

namespace cggApp
{
    partial class watergridviewcontrol : Smobiler.Core.Controls.MobileUserControl
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
            this.label1 = new Smobiler.Core.Controls.Label();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.label4 = new Smobiler.Core.Controls.Label();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.label2,
            this.label3,
            this.label4});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(119, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // label1
            // 
            this.label1.BorderColor = System.Drawing.Color.DimGray;
            this.label1.DisplayMember = "id";
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(32, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 35);
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BorderColor = System.Drawing.Color.DimGray;
            this.label2.DisplayMember = "报警时水位";
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(81, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 35);
            this.label2.Text = "label1";
            // 
            // label3
            // 
            this.label3.BorderColor = System.Drawing.Color.DimGray;
            this.label3.DisplayMember = "报警时水位等级";
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(140, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 35);
            this.label3.Text = "label1";
            // 
            // label4
            // 
            this.label4.BorderColor = System.Drawing.Color.DimGray;
            this.label4.DisplayMember = "报警时间";
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(192, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 35);
            this.label4.Text = "label1";
            // 
            // watergridviewcontrol
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(300, 40);
            this.Name = "watergridviewcontrol";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Label label3;
        private Smobiler.Core.Controls.Label label4;
    }
}