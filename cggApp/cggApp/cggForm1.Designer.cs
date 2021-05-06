using Smobiler.Core;

namespace cggApp
{
    partial class cggForm1 : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm Designer generated code "

        //SmobilerForm overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //NOTE: The following procedure is required by the SmobilerForm Designer
        //It can be modified using the SmobilerForm Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.button1 = new Smobiler.Core.Controls.Button();
            this.image1 = new Smobiler.Core.Controls.Image();
            this.fontIcon2 = new Smobiler.Core.Controls.FontIcon();
            this.line1 = new Smobiler.Core.Controls.Line();
            this.fontIcon1 = new Smobiler.Core.Controls.FontIcon();
            this.usertextBox = new Smobiler.Core.Controls.TextBox();
            this.passwordtextBox = new Smobiler.Core.Controls.TextBox();
            this.line2 = new Smobiler.Core.Controls.Line();
            this.remecheckBox = new Smobiler.Core.Controls.CheckBox();
            this.label2 = new Smobiler.Core.Controls.Label();
            this.button2 = new Smobiler.Core.Controls.Button();
            // 
            // panel1
            // 
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.button1,
            this.image1,
            this.fontIcon2,
            this.line1,
            this.fontIcon1,
            this.usertextBox,
            this.passwordtextBox,
            this.line2,
            this.remecheckBox,
            this.label2,
            this.button2});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(52, 210);
            this.panel1.Name = "panel1";
            this.panel1.Scrollable = true;
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // button1
            // 
            this.button1.BorderRadius = 30;
            this.button1.Location = new System.Drawing.Point(95, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.Text = "登录";
            this.button1.Press += new System.EventHandler(this.button1_Press);
            // 
            // image1
            // 
            this.image1.BorderColor = System.Drawing.Color.Transparent;
            this.image1.BorderStyle = Smobiler.Core.Controls.BorderStyle.Dashed;
            this.image1.Location = new System.Drawing.Point(21, 33);
            this.image1.Name = "image1";
            this.image1.ResourceID = "5.jpg";
            this.image1.Size = new System.Drawing.Size(136, 95);
            // 
            // fontIcon2
            // 
            this.fontIcon2.BorderColor = System.Drawing.Color.Transparent;
            this.fontIcon2.ForeColor = System.Drawing.Color.DimGray;
            this.fontIcon2.Location = new System.Drawing.Point(46, 207);
            this.fontIcon2.Name = "fontIcon2";
            this.fontIcon2.ResourceID = "user";
            this.fontIcon2.Size = new System.Drawing.Size(35, 20);
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.White;
            this.line1.BorderColor = System.Drawing.Color.DarkGray;
            this.line1.Location = new System.Drawing.Point(46, 242);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(202, 1);
            // 
            // fontIcon1
            // 
            this.fontIcon1.BorderColor = System.Drawing.Color.Transparent;
            this.fontIcon1.ForeColor = System.Drawing.Color.DimGray;
            this.fontIcon1.Location = new System.Drawing.Point(46, 259);
            this.fontIcon1.Name = "fontIcon1";
            this.fontIcon1.ResourceID = "lock";
            this.fontIcon1.Size = new System.Drawing.Size(35, 20);
            // 
            // usertextBox
            // 
            this.usertextBox.BackColor = System.Drawing.Color.Transparent;
            this.usertextBox.Bold = true;
            this.usertextBox.BorderRadius = 30;
            this.usertextBox.FontSize = 14F;
            this.usertextBox.ForeColor = System.Drawing.Color.DimGray;
            this.usertextBox.Location = new System.Drawing.Point(100, 202);
            this.usertextBox.Name = "usertextBox";
            this.usertextBox.Size = new System.Drawing.Size(148, 30);
            this.usertextBox.WaterMarkText = "账号/手机号/邮箱";
            this.usertextBox.WaterMarkTextColor = System.Drawing.Color.DimGray;
            this.usertextBox.TouchLeave += new System.EventHandler(this.usertextBox_TouchLeave);
            // 
            // passwordtextBox
            // 
            this.passwordtextBox.BackColor = System.Drawing.Color.Transparent;
            this.passwordtextBox.Bold = true;
            this.passwordtextBox.BorderRadius = 30;
            this.passwordtextBox.FontSize = 14F;
            this.passwordtextBox.ForeColor = System.Drawing.Color.DimGray;
            this.passwordtextBox.Location = new System.Drawing.Point(100, 253);
            this.passwordtextBox.Name = "passwordtextBox";
            this.passwordtextBox.SecurityMode = true;
            this.passwordtextBox.Size = new System.Drawing.Size(148, 30);
            this.passwordtextBox.WaterMarkText = "密码";
            this.passwordtextBox.WaterMarkTextColor = System.Drawing.Color.DimGray;
            this.passwordtextBox.TouchLeave += new System.EventHandler(this.passwordtextBox_TouchLeave);
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.White;
            this.line2.BorderColor = System.Drawing.Color.DarkGray;
            this.line2.Location = new System.Drawing.Point(46, 292);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(202, 1);
            // 
            // remecheckBox
            // 
            this.remecheckBox.Location = new System.Drawing.Point(56, 304);
            this.remecheckBox.Name = "remecheckBox";
            this.remecheckBox.Size = new System.Drawing.Size(16, 16);
            this.remecheckBox.TintColor = System.Drawing.Color.White;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(81, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 35);
            this.label2.Text = "记住密码";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Location = new System.Drawing.Point(222, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 35);
            this.button2.Text = "注册";
            this.button2.Press += new System.EventHandler(this.button2_Press);
            // 
            // cggForm1
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = "3.jpg";
            this.BackgroundImageSizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Load += new System.EventHandler(this.cggForm1_Load);
            this.Name = "cggForm1";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Button button1;
        private Smobiler.Core.Controls.Image image1;
        private Smobiler.Core.Controls.FontIcon fontIcon2;
        private Smobiler.Core.Controls.Line line1;
        private Smobiler.Core.Controls.FontIcon fontIcon1;
        private Smobiler.Core.Controls.TextBox usertextBox;
        private Smobiler.Core.Controls.TextBox passwordtextBox;
        private Smobiler.Core.Controls.Line line2;
        private Smobiler.Core.Controls.CheckBox remecheckBox;
        private Smobiler.Core.Controls.Label label2;
        private Smobiler.Core.Controls.Button button2;
    }
}