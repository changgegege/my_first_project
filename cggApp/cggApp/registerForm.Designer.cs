using Smobiler.Core;
using System;

namespace cggApp
{
    partial class registerForm : Smobiler.Core.Controls.MobileForm
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
            this.panel2 = new Smobiler.Core.Controls.Panel();
            this.nametextBox = new Smobiler.Core.Controls.TextBox();
            this.phonetextBox = new Smobiler.Core.Controls.TextBox();
            this.emailtextBox = new Smobiler.Core.Controls.TextBox();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.label3 = new Smobiler.Core.Controls.Label();
            this.pwdtextBox = new Smobiler.Core.Controls.TextBox();
            this.label4 = new Smobiler.Core.Controls.Label();
            this.pwd2textBox = new Smobiler.Core.Controls.TextBox();
            this.label5 = new Smobiler.Core.Controls.Label();
            this.button1 = new Smobiler.Core.Controls.Button();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.line1 = new Smobiler.Core.Controls.Line();
            this.line2 = new Smobiler.Core.Controls.Line();
            this.line3 = new Smobiler.Core.Controls.Line();
            this.line4 = new Smobiler.Core.Controls.Line();
            this.line5 = new Smobiler.Core.Controls.Line();
            this.image2 = new Smobiler.Core.Controls.Image();
            this.image3 = new Smobiler.Core.Controls.Image();
            this.image4 = new Smobiler.Core.Controls.Image();
            this.image5 = new Smobiler.Core.Controls.Image();
            this.sextextBox = new Smobiler.Core.Controls.TextBox();
            this.label6 = new Smobiler.Core.Controls.Label();
            this.line6 = new Smobiler.Core.Controls.Line();
            this.image6 = new Smobiler.Core.Controls.Image();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.imageButton1,
            this.panel2});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(132, 292);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // imageButton1
            // 
            this.imageButton1.IconColor = System.Drawing.Color.DimGray;
            this.imageButton1.Location = new System.Drawing.Point(16, 37);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.ResourceID = "Arrow - Left";
            this.imageButton1.Size = new System.Drawing.Size(40, 40);
            this.imageButton1.Press += new System.EventHandler(this.imageButton1_Press);
            // 
            // panel2
            // 
            this.panel2.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.nametextBox,
            this.phonetextBox,
            this.emailtextBox,
            this.label1,
            this.label2,
            this.label3,
            this.pwdtextBox,
            this.label4,
            this.pwd2textBox,
            this.label5,
            this.button1,
            this.image1,
            this.line1,
            this.line2,
            this.line3,
            this.line4,
            this.line5,
            this.image2,
            this.image3,
            this.image4,
            this.image5,
            this.sextextBox,
            this.label6,
            this.line6,
            this.image6});
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 406);
            // 
            // nametextBox
            // 
            this.nametextBox.BackColor = System.Drawing.Color.Transparent;
            this.nametextBox.BorderRadius = 30;
            this.nametextBox.FontSize = 14F;
            this.nametextBox.ForeColor = System.Drawing.Color.Pink;
            this.nametextBox.Location = new System.Drawing.Point(141, 7);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(118, 33);
            this.nametextBox.WaterMarkText = "请输入昵称";
            this.nametextBox.TouchLeave += new System.EventHandler(this.nametextBox_TouchLeave);
            // 
            // phonetextBox
            // 
            this.phonetextBox.BackColor = System.Drawing.Color.Transparent;
            this.phonetextBox.BorderRadius = 30;
            this.phonetextBox.FontSize = 14F;
            this.phonetextBox.ForeColor = System.Drawing.Color.Pink;
            this.phonetextBox.Location = new System.Drawing.Point(141, 127);
            this.phonetextBox.Name = "phonetextBox";
            this.phonetextBox.Size = new System.Drawing.Size(118, 33);
            this.phonetextBox.WaterMarkText = "请输入手机号(非必填)";
            // 
            // emailtextBox
            // 
            this.emailtextBox.BackColor = System.Drawing.Color.Transparent;
            this.emailtextBox.BorderRadius = 30;
            this.emailtextBox.FontSize = 14F;
            this.emailtextBox.ForeColor = System.Drawing.Color.Pink;
            this.emailtextBox.Location = new System.Drawing.Point(141, 187);
            this.emailtextBox.Name = "emailtextBox";
            this.emailtextBox.Size = new System.Drawing.Size(118, 33);
            this.emailtextBox.WaterMarkText = "请输入邮箱(非必填)";
            // 
            // label1
            // 
            this.label1.FontSize = 14F;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(80, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 32);
            this.label1.Text = "昵称";
            // 
            // label2
            // 
            this.label2.FontSize = 14F;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(80, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 32);
            this.label2.Text = "手机号";
            // 
            // label3
            // 
            this.label3.FontSize = 14F;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(80, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 32);
            this.label3.Text = "邮箱";
            // 
            // pwdtextBox
            // 
            this.pwdtextBox.BackColor = System.Drawing.Color.Transparent;
            this.pwdtextBox.BorderRadius = 30;
            this.pwdtextBox.FontSize = 14F;
            this.pwdtextBox.ForeColor = System.Drawing.Color.Pink;
            this.pwdtextBox.Location = new System.Drawing.Point(141, 247);
            this.pwdtextBox.Name = "pwdtextBox";
            this.pwdtextBox.SecurityMode = true;
            this.pwdtextBox.Size = new System.Drawing.Size(118, 33);
            this.pwdtextBox.WaterMarkText = "请输入密码";
            this.pwdtextBox.TouchLeave += new System.EventHandler(this.pwdtextBox_TouchLeave);
            // 
            // label4
            // 
            this.label4.FontSize = 14F;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(80, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 32);
            this.label4.Text = "密码";
            // 
            // pwd2textBox
            // 
            this.pwd2textBox.BackColor = System.Drawing.Color.Transparent;
            this.pwd2textBox.BorderRadius = 30;
            this.pwd2textBox.FontSize = 14F;
            this.pwd2textBox.ForeColor = System.Drawing.Color.Pink;
            this.pwd2textBox.Location = new System.Drawing.Point(141, 307);
            this.pwd2textBox.Name = "pwd2textBox";
            this.pwd2textBox.SecurityMode = true;
            this.pwd2textBox.Size = new System.Drawing.Size(118, 33);
            this.pwd2textBox.WaterMarkText = "请确认密码";
            this.pwd2textBox.TouchLeave += new System.EventHandler(this.pwd2textBox_TouchLeave);
            // 
            // label5
            // 
            this.label5.FontSize = 14F;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(80, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 32);
            this.label5.Text = "确认密码";
            // 
            // button1
            // 
            this.button1.BorderRadius = 30;
            this.button1.Location = new System.Drawing.Point(93, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.Text = "注册";
            this.button1.Press += new System.EventHandler(this.button1_Press);
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(49, 314);
            this.image1.Name = "image1";
            this.image1.ResourceID = "检查.png";
            this.image1.Size = new System.Drawing.Size(20, 20);
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.LightGray;
            this.line1.BorderColor = System.Drawing.Color.DarkGray;
            this.line1.Location = new System.Drawing.Point(35, 54);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(232, 1);
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.LightGray;
            this.line2.BorderColor = System.Drawing.Color.DarkGray;
            this.line2.Location = new System.Drawing.Point(40, 174);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(227, 1);
            // 
            // line3
            // 
            this.line3.BackColor = System.Drawing.Color.LightGray;
            this.line3.BorderColor = System.Drawing.Color.DarkGray;
            this.line3.Location = new System.Drawing.Point(40, 234);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(227, 1);
            // 
            // line4
            // 
            this.line4.BackColor = System.Drawing.Color.LightGray;
            this.line4.BorderColor = System.Drawing.Color.DarkGray;
            this.line4.Location = new System.Drawing.Point(40, 294);
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(227, 1);
            // 
            // line5
            // 
            this.line5.BackColor = System.Drawing.Color.LightGray;
            this.line5.BorderColor = System.Drawing.Color.DarkGray;
            this.line5.Location = new System.Drawing.Point(37, 354);
            this.line5.Name = "line5";
            this.line5.Size = new System.Drawing.Size(232, 1);
            // 
            // image2
            // 
            this.image2.Location = new System.Drawing.Point(47, 131);
            this.image2.Name = "image2";
            this.image2.ResourceID = "icon_phone.png";
            this.image2.Size = new System.Drawing.Size(25, 25);
            // 
            // image3
            // 
            this.image3.Location = new System.Drawing.Point(40, 185);
            this.image3.Name = "image3";
            this.image3.ResourceID = "邮箱.png";
            this.image3.Size = new System.Drawing.Size(36, 36);
            // 
            // image4
            // 
            this.image4.Location = new System.Drawing.Point(44, 252);
            this.image4.Name = "image4";
            this.image4.ResourceID = "路标.png";
            this.image4.Size = new System.Drawing.Size(28, 28);
            // 
            // image5
            // 
            this.image5.Location = new System.Drawing.Point(42, 9);
            this.image5.Name = "image5";
            this.image5.ResourceID = "鳄鱼.png";
            this.image5.Size = new System.Drawing.Size(30, 30);
            // 
            // sextextBox
            // 
            this.sextextBox.BackColor = System.Drawing.Color.Transparent;
            this.sextextBox.BorderRadius = 30;
            this.sextextBox.FontSize = 14F;
            this.sextextBox.ForeColor = System.Drawing.Color.Pink;
            this.sextextBox.Location = new System.Drawing.Point(141, 67);
            this.sextextBox.Name = "sextextBox";
            this.sextextBox.Size = new System.Drawing.Size(118, 33);
            this.sextextBox.WaterMarkText = "请选择性别";
            this.sextextBox.TouchEnter += new System.EventHandler(this.textBox6_TouchEnter);
            this.sextextBox.TouchLeave += new System.EventHandler(this.textBox6_TouchLeave);
            // 
            // label6
            // 
            this.label6.FontSize = 14F;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(80, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 32);
            this.label6.Text = "性别";
            // 
            // line6
            // 
            this.line6.BackColor = System.Drawing.Color.LightGray;
            this.line6.BorderColor = System.Drawing.Color.DarkGray;
            this.line6.Location = new System.Drawing.Point(40, 114);
            this.line6.Name = "line6";
            this.line6.Size = new System.Drawing.Size(227, 1);
            // 
            // image6
            // 
            this.image6.Location = new System.Drawing.Point(49, 72);
            this.image6.Name = "image6";
            this.image6.ResourceID = "鸡.png";
            this.image6.Size = new System.Drawing.Size(21, 21);
            // 
            // registerForm
            // 
            this.BackgroundImage = "3.jpg";
            this.BackgroundImageSizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Name = "registerForm";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.ImageButton imageButton1;
        private Smobiler.Core.Controls.Panel panel2;
        private Smobiler.Core.Controls.TextBox nametextBox;
        private Smobiler.Core.Controls.TextBox phonetextBox;
        private Smobiler.Core.Controls.TextBox emailtextBox;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Label label3;
        private Smobiler.Core.Controls.TextBox pwdtextBox;
        private Smobiler.Core.Controls.Label label4;
        private Smobiler.Core.Controls.TextBox pwd2textBox;
        private Smobiler.Core.Controls.Label label5;
        private Smobiler.Core.Controls.Button button1;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.Line line1;
        private Smobiler.Core.Controls.Line line2;
        private Smobiler.Core.Controls.Line line3;
        private Smobiler.Core.Controls.Line line4;
        private Smobiler.Core.Controls.Line line5;
        private Smobiler.Core.Controls.Image image2;
        private Smobiler.Core.Controls.Image image3;
        private Smobiler.Core.Controls.Image image4;
        private Smobiler.Core.Controls.Image image5;
        private Smobiler.Core.Controls.TextBox sextextBox;
        private Smobiler.Core.Controls.Label label6;
        private Smobiler.Core.Controls.Line line6;
        private Smobiler.Core.Controls.Image image6;
    }
}