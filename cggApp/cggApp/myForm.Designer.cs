using Smobiler.Core;
using System;

namespace cggApp
{
    partial class myForm : Smobiler.Core.Controls.MobileForm
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
            Smobiler.Core.Controls.ToolBarItem toolBarItem1 = new Smobiler.Core.Controls.ToolBarItem();
            Smobiler.Core.Controls.ToolBarItem toolBarItem2 = new Smobiler.Core.Controls.ToolBarItem();
            Smobiler.Core.Controls.ListMenuViewGroup listMenuViewGroup2 = new Smobiler.Core.Controls.ListMenuViewGroup();
            Smobiler.Core.Controls.ListMenuViewItem listMenuViewItem3 = new Smobiler.Core.Controls.ListMenuViewItem();
            Smobiler.Core.Controls.ListMenuViewGroup listMenuViewGroup1 = new Smobiler.Core.Controls.ListMenuViewGroup();
            Smobiler.Core.Controls.ListMenuViewItem listMenuViewItem1 = new Smobiler.Core.Controls.ListMenuViewItem();
            Smobiler.Core.Controls.ListMenuViewItem listMenuViewItem2 = new Smobiler.Core.Controls.ListMenuViewItem();
            this.panel3 = new Smobiler.Core.Controls.Panel();
            this.toolBar1 = new Smobiler.Core.Controls.ToolBar();
            this.photoimage = new Smobiler.Core.Controls.Image();
            this.namelabel = new Smobiler.Core.Controls.Label();
            this.panel2 = new Smobiler.Core.Controls.Panel();
            this.listMenuView2 = new Smobiler.Core.Controls.ListMenuView();
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.listMenuView1 = new Smobiler.Core.Controls.ListMenuView();
            // 
            // panel3
            // 
            this.panel3.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.toolBar1,
            this.photoimage,
            this.namelabel,
            this.panel1,
            this.panel2});
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(53, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 100);
            // 
            // toolBar1
            // 
            this.toolBar1.BackColor = System.Drawing.Color.SeaShell;
            this.toolBar1.ForeColor = System.Drawing.Color.DimGray;
            toolBarItem1.IconColor = System.Drawing.Color.Transparent;
            toolBarItem1.IconID = "首页1";
            toolBarItem1.Name = "menu";
            toolBarItem1.SelectIconColor = System.Drawing.Color.Transparent;
            toolBarItem1.SelectIconID = "首页1";
            toolBarItem1.Text = "主页";
            toolBarItem2.IconColor = System.Drawing.Color.Transparent;
            toolBarItem2.IconID = "工人";
            toolBarItem2.Name = "me";
            toolBarItem2.SelectIconColor = System.Drawing.Color.Transparent;
            toolBarItem2.SelectIconID = "工人";
            toolBarItem2.Text = "我";
            this.toolBar1.Items.AddRange(new Smobiler.Core.Controls.ToolBarItem[] {
            toolBarItem1,
            toolBarItem2});
            this.toolBar1.ItemWidth = 40;
            this.toolBar1.Location = new System.Drawing.Point(135, 490);
            this.toolBar1.MessageForeColor = System.Drawing.Color.White;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.SelectedIndex = 1;
            this.toolBar1.SelectForeColor = System.Drawing.Color.OrangeRed;
            this.toolBar1.Size = new System.Drawing.Size(100, 35);
            this.toolBar1.ToolbarItemClick += new Smobiler.Core.Controls.ToolbarItemClickEventHandler(this.toolBar1_ToolbarItemClick);
            // 
            // photoimage
            // 
            this.photoimage.BorderRadius = 90;
            this.photoimage.DisplayMember = "img";
            this.photoimage.Location = new System.Drawing.Point(109, 37);
            this.photoimage.Name = "photoimage";
            this.photoimage.Size = new System.Drawing.Size(70, 70);
            this.photoimage.SizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            // 
            // namelabel
            // 
            this.namelabel.Bold = true;
            this.namelabel.FontSize = 20F;
            this.namelabel.ForeColor = System.Drawing.Color.DimGray;
            this.namelabel.Location = new System.Drawing.Point(138, 107);
            this.namelabel.Name = "namelabel";
            this.namelabel.Size = new System.Drawing.Size(74, 35);
            // 
            // panel2
            // 
            this.panel2.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.listMenuView2});
            this.panel2.Location = new System.Drawing.Point(0, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 88);
            // 
            // listMenuView2
            // 
            this.listMenuView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMenuView2.GroupBackColor = System.Drawing.Color.Transparent;
            this.listMenuView2.GroupFontSize = 14;
            this.listMenuView2.GroupForeColor = System.Drawing.Color.DimGray;
            listMenuViewGroup2.IconBorderRadius = 0;
            listMenuViewItem3.Content = "退出登录";
            listMenuViewItem3.Icon = "叉";
            listMenuViewItem3.IconColor = System.Drawing.Color.Transparent;
            listMenuViewItem3.Name = "exit";
            listMenuViewGroup2.Items.AddRange(new Smobiler.Core.Controls.ListMenuViewItem[] {
            listMenuViewItem3});
            listMenuViewGroup2.ShowTitle = true;
            listMenuViewGroup2.Title = "设置";
            this.listMenuView2.Groups.AddRange(new Smobiler.Core.Controls.ListMenuViewGroup[] {
            listMenuViewGroup2});
            this.listMenuView2.MenuItemHeight = 38;
            this.listMenuView2.Name = "listMenuView2";
            this.listMenuView2.Size = new System.Drawing.Size(300, 59);
            this.listMenuView2.TextForeColor = System.Drawing.Color.DimGray;
            this.listMenuView2.ItemPress += new Smobiler.Core.Controls.ListMenuViewItemPressEventHandler(this.listMenuView2_ItemPress);
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.listMenuView1});
            this.panel1.Location = new System.Drawing.Point(0, 272);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 119);
            // 
            // listMenuView1
            // 
            this.listMenuView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMenuView1.GroupBackColor = System.Drawing.Color.Transparent;
            this.listMenuView1.GroupFontSize = 14;
            this.listMenuView1.GroupForeColor = System.Drawing.Color.DimGray;
            listMenuViewGroup1.IconBorderRadius = 0;
            listMenuViewItem1.Content = "      上位机";
            listMenuViewItem1.Icon = "机器人1";
            listMenuViewItem1.IconColor = System.Drawing.Color.Transparent;
            listMenuViewItem1.Name = "serial";
            listMenuViewItem2.Content = "      帮助";
            listMenuViewItem2.Icon = "帮助";
            listMenuViewItem2.IconColor = System.Drawing.Color.Transparent;
            listMenuViewItem2.Name = "help";
            listMenuViewGroup1.Items.AddRange(new Smobiler.Core.Controls.ListMenuViewItem[] {
            listMenuViewItem1,
            listMenuViewItem2});
            listMenuViewGroup1.ShowTitle = true;
            listMenuViewGroup1.Title = "辅助功能";
            this.listMenuView1.Groups.AddRange(new Smobiler.Core.Controls.ListMenuViewGroup[] {
            listMenuViewGroup1});
            this.listMenuView1.MenuItemHeight = 38;
            this.listMenuView1.Name = "listMenuView1";
            this.listMenuView1.Size = new System.Drawing.Size(300, 102);
            this.listMenuView1.TextForeColor = System.Drawing.Color.DimGray;
            this.listMenuView1.ItemPress += new Smobiler.Core.Controls.ListMenuViewItemPressEventHandler(this.listMenuView1_ItemPress);
            // 
            // myForm
            // 
            this.BackgroundImage = "3.jpg";
            this.BackgroundImageSizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel3});
            this.Load += new System.EventHandler(this.myForm_Load);
            this.Name = "myForm";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel3;
        private Smobiler.Core.Controls.ToolBar toolBar1;
        private Smobiler.Core.Controls.Image photoimage;
        private Smobiler.Core.Controls.Label namelabel;
        private Smobiler.Core.Controls.Panel panel2;
        private Smobiler.Core.Controls.ListMenuView listMenuView2;
        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.ListMenuView listMenuView1;
    }
}