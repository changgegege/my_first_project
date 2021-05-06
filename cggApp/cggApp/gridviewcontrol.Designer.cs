using Smobiler.Core;
using System;

namespace cggApp
{
    partial class gridviewcontrol : Smobiler.Core.Controls.MobileUserControl
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
            this.label5 = new Smobiler.Core.Controls.Label();
            this.label6 = new Smobiler.Core.Controls.Label();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.label2,
            this.label5,
            this.label6});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(83, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // label1
            // 
            this.label1.DisplayMember = "备注";
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(113, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 35);
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.DisplayMember = "报警时间";
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(202, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 35);
            this.label2.Text = "label1";
            // 
            // label5
            // 
            this.label5.DisplayMember = "报警时温度";
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(64, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 35);
            this.label5.Text = "label1";
            // 
            // label6
            // 
            this.label6.DisplayMember = "id";
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(24, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 35);
            this.label6.Text = "label1";
            // 
            // gridviewcontrol
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(300, 40);
            this.Name = "gridviewcontrol";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Label label5;
        private Smobiler.Core.Controls.Label label6;
        private Smobiler.Core.Controls.Label label2;
    }
}