using Smobiler.Core;
using System;

namespace cggApp
{
    partial class serialForm : Smobiler.Core.Controls.MobileForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.imageButton1 = new Smobiler.Core.Controls.ImageButton();
            this.imageButton2 = new Smobiler.Core.Controls.ImageButton();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.imageButton3 = new Smobiler.Core.Controls.ImageButton();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.receivetextBox = new Smobiler.Core.Controls.TextBox();
            this.imageButton4 = new Smobiler.Core.Controls.ImageButton();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.timelabel = new Smobiler.Core.Controls.Label();
            this.sendtextBox = new Smobiler.Core.Controls.TextBox();
            this.imageButton5 = new Smobiler.Core.Controls.ImageButton();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new Smobiler.Core.Controls.Timer();
            this.timer2 = new Smobiler.Core.Controls.Timer();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.imageButton1,
            this.imageButton2,
            this.label1,
            this.imageButton3,
            this.label2,
            this.receivetextBox,
            this.imageButton4,
            this.label3,
            this.image1,
            this.timelabel,
            this.sendtextBox,
            this.imageButton5,
            this.label4});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(154, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // imageButton1
            // 
            this.imageButton1.Location = new System.Drawing.Point(36, 119);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.ResourceID = "打开2";
            this.imageButton1.Size = new System.Drawing.Size(40, 40);
            this.imageButton1.Press += new System.EventHandler(this.imageButton1_Press);
            // 
            // imageButton2
            // 
            this.imageButton2.Location = new System.Drawing.Point(16, 37);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.ResourceID = "Arrow - Left";
            this.imageButton2.Size = new System.Drawing.Size(40, 40);
            this.imageButton2.Press += new System.EventHandler(this.imageButton2_Press);
            // 
            // label1
            // 
            this.label1.FontSize = 14F;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(35, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 35);
            this.label1.Text = "打开串口";
            // 
            // imageButton3
            // 
            this.imageButton3.Location = new System.Drawing.Point(123, 117);
            this.imageButton3.Name = "imageButton3";
            this.imageButton3.ResourceID = "关闭4";
            this.imageButton3.Size = new System.Drawing.Size(40, 40);
            this.imageButton3.Press += new System.EventHandler(this.imageButton3_Press);
            // 
            // label2
            // 
            this.label2.FontSize = 14F;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(124, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 35);
            this.label2.Text = "关闭串口";
            // 
            // receivetextBox
            // 
            this.receivetextBox.BackColor = System.Drawing.Color.PapayaWhip;
            this.receivetextBox.FontSize = 14F;
            this.receivetextBox.ForeColor = System.Drawing.Color.DimGray;
            this.receivetextBox.Location = new System.Drawing.Point(8, 201);
            this.receivetextBox.Multiline = true;
            this.receivetextBox.Name = "receivetextBox";
            this.receivetextBox.ReadOnly = true;
            this.receivetextBox.Size = new System.Drawing.Size(283, 150);
            // 
            // imageButton4
            // 
            this.imageButton4.Location = new System.Drawing.Point(210, 117);
            this.imageButton4.Name = "imageButton4";
            this.imageButton4.ResourceID = "清空";
            this.imageButton4.Size = new System.Drawing.Size(40, 40);
            this.imageButton4.Press += new System.EventHandler(this.imageButton4_Press);
            // 
            // label3
            // 
            this.label3.FontSize = 14F;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(205, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 35);
            this.label3.Text = "清空接收区";
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(181, 77);
            this.image1.Name = "image1";
            this.image1.ResourceID = "时间";
            this.image1.Size = new System.Drawing.Size(25, 25);
            // 
            // timelabel
            // 
            this.timelabel.ForeColor = System.Drawing.Color.DimGray;
            this.timelabel.Location = new System.Drawing.Point(214, 77);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(82, 25);
            // 
            // sendtextBox
            // 
            this.sendtextBox.BackColor = System.Drawing.Color.PapayaWhip;
            this.sendtextBox.FontSize = 15F;
            this.sendtextBox.ForeColor = System.Drawing.Color.DimGray;
            this.sendtextBox.Location = new System.Drawing.Point(8, 365);
            this.sendtextBox.Multiline = true;
            this.sendtextBox.Name = "sendtextBox";
            this.sendtextBox.Size = new System.Drawing.Size(283, 94);
            // 
            // imageButton5
            // 
            this.imageButton5.Location = new System.Drawing.Point(128, 467);
            this.imageButton5.Name = "imageButton5";
            this.imageButton5.ResourceID = "已发送";
            this.imageButton5.Size = new System.Drawing.Size(40, 40);
            this.imageButton5.Press += new System.EventHandler(this.imageButton5_Press);
            // 
            // label4
            // 
            this.label4.FontSize = 14F;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(137, 499);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 28);
            this.label4.Text = "发送";
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
            // timer2
            // 
            this.timer2.Name = "timer2";
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // serialForm
            // 
            this.BackgroundImage = "3.jpg";
            this.BackgroundImageSizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            this.Components.AddRange(new Smobiler.Core.Controls.MobileComponent[] {
            this.timer1,
            this.timer2});
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Load += new System.EventHandler(this.serialForm_Load);
            this.Name = "serialForm";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.ImageButton imageButton1;
        private Smobiler.Core.Controls.ImageButton imageButton2;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.ImageButton imageButton3;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.TextBox receivetextBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.ComponentModel.IContainer components;
        private Smobiler.Core.Controls.Timer timer1;
        private Smobiler.Core.Controls.ImageButton imageButton4;
        private Smobiler.Core.Controls.Label label3;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.Label timelabel;
        private Smobiler.Core.Controls.Timer timer2;
        private Smobiler.Core.Controls.TextBox sendtextBox;
        private Smobiler.Core.Controls.ImageButton imageButton5;
        private Smobiler.Core.Controls.Label label4;
    }
}