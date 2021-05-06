using Smobiler.Core;
using System;

namespace cggApp
{
    partial class waterthresholdcontrol : Smobiler.Core.Controls.MobileUserControl
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
            this.label1 = new Smobiler.Core.Controls.Label();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.threshold1label = new Smobiler.Core.Controls.Label();
            this.threshold2label = new Smobiler.Core.Controls.Label();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.image2 = new Smobiler.Core.Controls.Image();
            this.imageButton1 = new Smobiler.Core.Controls.ImageButton();
            this.imageButton2 = new Smobiler.Core.Controls.ImageButton();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.threshold3label = new Smobiler.Core.Controls.Label();
            this.image3 = new Smobiler.Core.Controls.Image();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new Smobiler.Core.Controls.Timer();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.label2,
            this.threshold1label,
            this.threshold2label,
            this.image1,
            this.image2,
            this.imageButton1,
            this.imageButton2,
            this.label5,
            this.label4,
            this.threshold3label,
            this.image3});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(48, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 35);
            this.label1.Text = "等级1";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(48, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 35);
            this.label2.Text = "等级2";
            // 
            // threshold1label
            // 
            this.threshold1label.ForeColor = System.Drawing.Color.DimGray;
            this.threshold1label.Location = new System.Drawing.Point(100, 74);
            this.threshold1label.Name = "threshold1label";
            this.threshold1label.Size = new System.Drawing.Size(83, 35);
            this.threshold1label.Text = " ";
            // 
            // threshold2label
            // 
            this.threshold2label.ForeColor = System.Drawing.Color.DimGray;
            this.threshold2label.Location = new System.Drawing.Point(100, 109);
            this.threshold2label.Name = "threshold2label";
            this.threshold2label.Size = new System.Drawing.Size(83, 35);
            this.threshold2label.Text = " ";
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(17, 76);
            this.image1.Name = "image1";
            this.image1.ResourceID = "KFC";
            this.image1.Size = new System.Drawing.Size(25, 25);
            // 
            // image2
            // 
            this.image2.Location = new System.Drawing.Point(17, 114);
            this.image2.Name = "image2";
            this.image2.ResourceID = "QQ";
            this.image2.Size = new System.Drawing.Size(25, 25);
            // 
            // imageButton1
            // 
            this.imageButton1.Location = new System.Drawing.Point(153, 17);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.ResourceID = "关闭1";
            this.imageButton1.Size = new System.Drawing.Size(30, 30);
            this.imageButton1.Press += new System.EventHandler(this.imageButton1_Press);
            // 
            // imageButton2
            // 
            this.imageButton2.Location = new System.Drawing.Point(17, 17);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.ResourceID = "点单";
            this.imageButton2.Size = new System.Drawing.Size(30, 30);
            this.imageButton2.Press += new System.EventHandler(this.imageButton2_Press);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(47, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.Text = "点它点它点它";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(48, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 35);
            this.label4.Text = "等级3";
            // 
            // threshold3label
            // 
            this.threshold3label.ForeColor = System.Drawing.Color.DimGray;
            this.threshold3label.Location = new System.Drawing.Point(100, 144);
            this.threshold3label.Name = "threshold3label";
            this.threshold3label.Size = new System.Drawing.Size(83, 35);
            this.threshold3label.Text = " ";
            // 
            // image3
            // 
            this.image3.Location = new System.Drawing.Point(17, 148);
            this.image3.Name = "image3";
            this.image3.ResourceID = "新浪微博";
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
            // waterthresholdcontrol
            // 
            this.BorderRadius = 15;
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.timer1});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(200, 200);
            this.Load += new System.EventHandler(this.waterthresholdcontrol_Load);
            this.Name = "waterthresholdcontrol";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.ComponentModel.IContainer components;
        private Smobiler.Core.Controls.Timer timer1;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Label threshold1label;
        private Smobiler.Core.Controls.Label threshold2label;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.Image image2;
        private Smobiler.Core.Controls.ImageButton imageButton1;
        private Smobiler.Core.Controls.ImageButton imageButton2;
        private Smobiler.Core.Controls.Label label5;
        private Smobiler.Core.Controls.Label label4;
        private Smobiler.Core.Controls.Label threshold3label;
        private Smobiler.Core.Controls.Image image3;
    }
}