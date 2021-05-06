using Smobiler.Core;
using System;

namespace cggApp
{
    partial class Tthresholdcontrol : Smobiler.Core.Controls.MobileUserControl
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.imageButton1 = new Smobiler.Core.Controls.ImageButton();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.maxlabel = new Smobiler.Core.Controls.Label();
            this.minlabel = new Smobiler.Core.Controls.Label();
            this.imageButton2 = new Smobiler.Core.Controls.ImageButton();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.image2 = new Smobiler.Core.Controls.Image();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.checklabel = new Smobiler.Core.Controls.Label();
            this.image3 = new Smobiler.Core.Controls.Image();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new Smobiler.Core.Controls.Timer();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.imageButton1,
            this.label1,
            this.label2,
            this.label3,
            this.maxlabel,
            this.minlabel,
            this.imageButton2,
            this.image1,
            this.image2,
            this.label4,
            this.checklabel,
            this.image3});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(120, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // imageButton1
            // 
            this.imageButton1.Location = new System.Drawing.Point(17, 17);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.ResourceID = "点单";
            this.imageButton1.Size = new System.Drawing.Size(30, 30);
            this.imageButton1.Press += new System.EventHandler(this.imageButton1_Press);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(47, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.Text = "点它点它点它";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(60, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 35);
            this.label2.Text = "最高温";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(60, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 35);
            this.label3.Text = "最低温";
            // 
            // maxlabel
            // 
            this.maxlabel.ForeColor = System.Drawing.Color.DimGray;
            this.maxlabel.Location = new System.Drawing.Point(121, 72);
            this.maxlabel.Name = "maxlabel";
            this.maxlabel.Size = new System.Drawing.Size(52, 35);
            // 
            // minlabel
            // 
            this.minlabel.ForeColor = System.Drawing.Color.DimGray;
            this.minlabel.Location = new System.Drawing.Point(121, 115);
            this.minlabel.Name = "minlabel";
            this.minlabel.Size = new System.Drawing.Size(52, 35);
            // 
            // imageButton2
            // 
            this.imageButton2.Location = new System.Drawing.Point(153, 17);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.ResourceID = "关闭1";
            this.imageButton2.Size = new System.Drawing.Size(30, 30);
            this.imageButton2.Press += new System.EventHandler(this.imageButton2_Press);
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(17, 74);
            this.image1.Name = "image1";
            this.image1.ResourceID = "高温-红";
            this.image1.Size = new System.Drawing.Size(25, 25);
            // 
            // image2
            // 
            this.image2.Location = new System.Drawing.Point(17, 115);
            this.image2.Name = "image2";
            this.image2.ResourceID = "低温";
            this.image2.Size = new System.Drawing.Size(25, 25);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(59, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 35);
            this.label4.Text = "是否处于警报状态";
            // 
            // checklabel
            // 
            this.checklabel.ForeColor = System.Drawing.Color.DimGray;
            this.checklabel.Location = new System.Drawing.Point(121, 156);
            this.checklabel.Name = "checklabel";
            this.checklabel.Size = new System.Drawing.Size(52, 35);
            // 
            // image3
            // 
            this.image3.Location = new System.Drawing.Point(17, 156);
            this.image3.Name = "image3";
            this.image3.ResourceID = "警报信息-01";
            this.image3.Size = new System.Drawing.Size(25, 25);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Name = "timer1";
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Tthresholdcontrol
            // 
            this.BorderRadius = 15;
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.timer1});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(200, 200);
            this.Load += new System.EventHandler(this.Tthresholdcontrol_Load);
            this.Name = "Tthresholdcontrol";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.ComponentModel.IContainer components;
        private Smobiler.Core.Controls.ImageButton imageButton1;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Label label3;
        private Smobiler.Core.Controls.Label maxlabel;
        private Smobiler.Core.Controls.Label minlabel;
        private Smobiler.Core.Controls.ImageButton imageButton2;
        private Smobiler.Core.Controls.Timer timer1;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.Image image2;
        private Smobiler.Core.Controls.Label label4;
        private Smobiler.Core.Controls.Label checklabel;
        private Smobiler.Core.Controls.Image image3;
    }
}