using Smobiler.Core;
using System;

namespace cggApp
{
    partial class wsdcontrol : Smobiler.Core.Controls.MobileUserControl
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
            this.Tlabel = new Smobiler.Core.Controls.Label();
            this.Hlabel = new Smobiler.Core.Controls.Label();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.image2 = new Smobiler.Core.Controls.Image();
            this.imageButton1 = new Smobiler.Core.Controls.ImageButton();
            this.imageButton2 = new Smobiler.Core.Controls.ImageButton();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.timelabel = new Smobiler.Core.Controls.Label();
            this.image3 = new Smobiler.Core.Controls.Image();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer2 = new Smobiler.Core.Controls.Timer();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.label2,
            this.Tlabel,
            this.Hlabel,
            this.image1,
            this.image2,
            this.imageButton1,
            this.imageButton2,
            this.label5,
            this.label4,
            this.timelabel,
            this.image3});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(108, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(48, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 35);
            this.label1.Text = "温度";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(48, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 35);
            this.label2.Text = "湿度";
            // 
            // Tlabel
            // 
            this.Tlabel.ForeColor = System.Drawing.Color.DimGray;
            this.Tlabel.Location = new System.Drawing.Point(100, 74);
            this.Tlabel.Name = "Tlabel";
            this.Tlabel.Size = new System.Drawing.Size(83, 35);
            this.Tlabel.Text = " ";
            // 
            // Hlabel
            // 
            this.Hlabel.ForeColor = System.Drawing.Color.DimGray;
            this.Hlabel.Location = new System.Drawing.Point(100, 109);
            this.Hlabel.Name = "Hlabel";
            this.Hlabel.Size = new System.Drawing.Size(83, 35);
            this.Hlabel.Text = " ";
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(17, 74);
            this.image1.Name = "image1";
            this.image1.ResourceID = "温度1";
            this.image1.Size = new System.Drawing.Size(25, 25);
            // 
            // image2
            // 
            this.image2.Location = new System.Drawing.Point(17, 109);
            this.image2.Name = "image2";
            this.image2.ResourceID = "湿度";
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
            this.label4.Text = "采集时间";
            // 
            // timelabel
            // 
            this.timelabel.ForeColor = System.Drawing.Color.DimGray;
            this.timelabel.Location = new System.Drawing.Point(100, 144);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(83, 35);
            this.timelabel.Text = " ";
            // 
            // image3
            // 
            this.image3.Location = new System.Drawing.Point(17, 144);
            this.image3.Name = "image3";
            this.image3.ResourceID = "时间2";
            this.image3.Size = new System.Drawing.Size(25, 25);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer2
            // 
            this.timer2.Name = "timer2";
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // wsdcontrol
            // 
            this.BorderRadius = 15;
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.timer2});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(200, 200);
            this.Load += new System.EventHandler(this.wsdcontrol_Load);
            this.Name = "wsdcontrol";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Label Tlabel;
        private Smobiler.Core.Controls.Label Hlabel;
        private System.IO.Ports.SerialPort serialPort1;
        private System.ComponentModel.IContainer components;
        private Smobiler.Core.Controls.Timer timer2;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.Image image2;
        private Smobiler.Core.Controls.ImageButton imageButton1;
        private Smobiler.Core.Controls.ImageButton imageButton2;
        private Smobiler.Core.Controls.Label label4;
        private Smobiler.Core.Controls.Label timelabel;
        private Smobiler.Core.Controls.Image image3;
        private Smobiler.Core.Controls.Label label5;
    }
}