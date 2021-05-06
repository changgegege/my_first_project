using Smobiler.Core;
using System;

namespace cggApp
{
    partial class mainForm : Smobiler.Core.Controls.MobileForm
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
            Smobiler.Core.Controls.IconMenuViewGroup iconMenuViewGroup1 = new Smobiler.Core.Controls.IconMenuViewGroup();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem1 = new Smobiler.Core.Controls.IconMenuViewItem();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem2 = new Smobiler.Core.Controls.IconMenuViewItem();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem3 = new Smobiler.Core.Controls.IconMenuViewItem();
            Smobiler.Core.Controls.ToolBarItem toolBarItem1 = new Smobiler.Core.Controls.ToolBarItem();
            Smobiler.Core.Controls.ToolBarItem toolBarItem2 = new Smobiler.Core.Controls.ToolBarItem();
            Smobiler.Core.Controls.IconMenuViewGroup iconMenuViewGroup2 = new Smobiler.Core.Controls.IconMenuViewGroup();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem4 = new Smobiler.Core.Controls.IconMenuViewItem();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem5 = new Smobiler.Core.Controls.IconMenuViewItem();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem6 = new Smobiler.Core.Controls.IconMenuViewItem();
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.iconMenuView1 = new Smobiler.Core.Controls.IconMenuView();
            this.toolBar1 = new Smobiler.Core.Controls.ToolBar();
            this.imageButton1 = new Smobiler.Core.Controls.ImageButton();
            this.iconMenuView2 = new Smobiler.Core.Controls.IconMenuView();
            this.pageView1 = new Smobiler.Core.Controls.PageView();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.iconMenuView1,
            this.toolBar1,
            this.imageButton1,
            this.iconMenuView2,
            this.pageView1});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(148, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // iconMenuView1
            // 
            this.iconMenuView1.BackColor = System.Drawing.Color.Transparent;
            this.iconMenuView1.ColumnNum = 3;
            this.iconMenuView1.ForeColor = System.Drawing.Color.DimGray;
            this.iconMenuView1.GroupBackColor = System.Drawing.Color.Transparent;
            this.iconMenuView1.GroupForeColor = System.Drawing.Color.DimGray;
            iconMenuViewGroup1.FontSize = 0F;
            iconMenuViewGroup1.IconBorderRadius = 0;
            iconMenuViewGroup1.ItemHeight = 0;
            iconMenuViewItem1.Icon = "摄氏度";
            iconMenuViewItem1.ID = "摄氏度";
            iconMenuViewItem1.Text = "温湿度";
            iconMenuViewItem2.Icon = "提醒";
            iconMenuViewItem2.ID = "提醒";
            iconMenuViewItem2.Text = "历史报警情况";
            iconMenuViewItem3.Icon = "提示";
            iconMenuViewItem3.ID = "提示";
            iconMenuViewItem3.Text = "当前设定阈值";
            iconMenuViewGroup1.Items.AddRange(new Smobiler.Core.Controls.IconMenuViewItem[] {
            iconMenuViewItem1,
            iconMenuViewItem2,
            iconMenuViewItem3});
            iconMenuViewGroup1.ShowTitle = true;
            iconMenuViewGroup1.Text = "温湿度";
            this.iconMenuView1.Groups.AddRange(new Smobiler.Core.Controls.IconMenuViewGroup[] {
            iconMenuViewGroup1});
            this.iconMenuView1.ItemWidth = 47;
            this.iconMenuView1.Location = new System.Drawing.Point(0, 263);
            this.iconMenuView1.MenuItemHeight = 50;
            this.iconMenuView1.MessageForeColor = System.Drawing.Color.White;
            this.iconMenuView1.Name = "iconMenuView1";
            this.iconMenuView1.Size = new System.Drawing.Size(300, 87);
            this.iconMenuView1.ItemPress += new Smobiler.Core.Controls.IconMenuViewItemPressClickHandler(this.iconMenuView1_ItemPress);
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
            this.toolBar1.Location = new System.Drawing.Point(105, 474);
            this.toolBar1.MessageForeColor = System.Drawing.Color.White;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.SelectedIndex = 0;
            this.toolBar1.SelectForeColor = System.Drawing.Color.OrangeRed;
            this.toolBar1.Size = new System.Drawing.Size(100, 35);
            this.toolBar1.ToolbarItemClick += new Smobiler.Core.Controls.ToolbarItemClickEventHandler(this.toolBar1_ToolbarItemClick);
            // 
            // imageButton1
            // 
            this.imageButton1.Location = new System.Drawing.Point(16, 37);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.ResourceID = "Arrow - Left";
            this.imageButton1.Size = new System.Drawing.Size(40, 40);
            this.imageButton1.Press += new System.EventHandler(this.imageButton1_Press);
            // 
            // iconMenuView2
            // 
            this.iconMenuView2.BackColor = System.Drawing.Color.Transparent;
            this.iconMenuView2.ColumnNum = 3;
            this.iconMenuView2.ForeColor = System.Drawing.Color.DimGray;
            this.iconMenuView2.GroupBackColor = System.Drawing.Color.Transparent;
            this.iconMenuView2.GroupForeColor = System.Drawing.Color.DimGray;
            iconMenuViewGroup2.FontSize = 0F;
            iconMenuViewGroup2.IconBorderRadius = 0;
            iconMenuViewGroup2.ItemHeight = 0;
            iconMenuViewItem4.Icon = "水";
            iconMenuViewItem4.ID = "水";
            iconMenuViewItem4.Text = "当前水位和等级";
            iconMenuViewItem5.Icon = "提醒";
            iconMenuViewItem5.ID = "提醒";
            iconMenuViewItem5.Text = "历史报警情况";
            iconMenuViewItem6.Icon = "提示";
            iconMenuViewItem6.ID = "提示";
            iconMenuViewItem6.Text = "当前设定阈值";
            iconMenuViewGroup2.Items.AddRange(new Smobiler.Core.Controls.IconMenuViewItem[] {
            iconMenuViewItem4,
            iconMenuViewItem5,
            iconMenuViewItem6});
            iconMenuViewGroup2.ShowTitle = true;
            iconMenuViewGroup2.Text = "水位";
            this.iconMenuView2.Groups.AddRange(new Smobiler.Core.Controls.IconMenuViewGroup[] {
            iconMenuViewGroup2});
            this.iconMenuView2.ItemWidth = 47;
            this.iconMenuView2.Location = new System.Drawing.Point(0, 350);
            this.iconMenuView2.MenuItemHeight = 50;
            this.iconMenuView2.MessageForeColor = System.Drawing.Color.White;
            this.iconMenuView2.Name = "iconMenuView2";
            this.iconMenuView2.Size = new System.Drawing.Size(300, 87);
            this.iconMenuView2.ItemPress += new Smobiler.Core.Controls.IconMenuViewItemPressClickHandler(this.iconMenuView2_ItemPress);
            // 
            // pageView1
            // 
            this.pageView1.BorderRadius = 6;
            this.pageView1.IsLoop = true;
            this.pageView1.Location = new System.Drawing.Point(0, 85);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(300, 150);
            // 
            // mainForm
            // 
            this.BackgroundImage = "3.jpg";
            this.BackgroundImageSizeMode = Smobiler.Core.Controls.ImageSizeMode.Cover;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Name = "mainForm";

        }
        #endregion
        private System.ComponentModel.IContainer components;
        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.IconMenuView iconMenuView1;
        private Smobiler.Core.Controls.ToolBar toolBar1;
        private Smobiler.Core.Controls.ImageButton imageButton1;
        private Smobiler.Core.Controls.IconMenuView iconMenuView2;
        private Smobiler.Core.Controls.PageView pageView1;
    }
}