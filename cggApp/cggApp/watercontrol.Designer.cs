using Smobiler.Core;
using System;

namespace cggApp
{
    partial class watercontrol : Smobiler.Core.Controls.MobileUserControl
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
            this.Wlabel = new Smobiler.Core.Controls.Label();
            this.Llabel = new Smobiler.Core.Controls.Label();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.image2 = new Smobiler.Core.Controls.Image();
            this.imageButton1 = new Smobiler.Core.Controls.ImageButton();
            this.imageButton2 = new Smobiler.Core.Controls.ImageButton();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.timelabel = new Smobiler.Core.Controls.Label();
            this.image3 = new Smobiler.Core.Controls.Image();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new Smobiler.Core.Controls.Timer();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.label2,
            this.Wlabel,
            this.Llabel,
            this.image1,
            this.image2,
            this.imageButton1,
            this.imageButton2,
            this.label5,
            this.label4,
            this.timelabel,
            this.image3});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(201, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(48, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 35);
            this.label1.Text = "水位";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(48, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 35);
            this.label2.Text = "水位等级";
            // 
            // Wlabel
            // 
            this.Wlabel.ForeColor = System.Drawing.Color.DimGray;
            this.Wlabel.Location = new System.Drawing.Point(100, 74);
            this.Wlabel.Name = "Wlabel";
            this.Wlabel.Size = new System.Drawing.Size(83, 35);
            this.Wlabel.Text = " ";
            // 
            // Llabel
            // 
            this.Llabel.ForeColor = System.Drawing.Color.DimGray;
            this.Llabel.Location = new System.Drawing.Point(100, 109);
            this.Llabel.Name = "Llabel";
            this.Llabel.Size = new System.Drawing.Size(83, 35);
            this.Llabel.Text = " ";
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(17, 75);
            this.image1.Name = "image1";
            this.image1.ResourceID = "水2";
            this.image1.Size = new System.Drawing.Size(25, 25);
            // 
            // image2
            // 
            this.image2.Location = new System.Drawing.Point(17, 110);
            this.image2.Name = "image2";
            this.image2.ResourceID = "水表";
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
            this.label4.Text = "持续时间";
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
            this.image3.Location = new System.Drawing.Point(17, 145);
            this.image3.Name = "image3";
            this.image3.ResourceID = "时间4";
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
            // watercontrol
            // 
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BorderRadius = 15;
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.timer1});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(200, 200);
            this.Load += new System.EventHandler(this.watercontrol_Load);
            this.Name = "watercontrol";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Label Wlabel;
        private Smobiler.Core.Controls.Label Llabel;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.Image image2;
        private Smobiler.Core.Controls.ImageButton imageButton1;
        private Smobiler.Core.Controls.ImageButton imageButton2;
        private Smobiler.Core.Controls.Label label5;
        private Smobiler.Core.Controls.Label label4;
        private Smobiler.Core.Controls.Label timelabel;
        private Smobiler.Core.Controls.Image image3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.ComponentModel.IContainer components;
        private Smobiler.Core.Controls.Timer timer1;
    }
}