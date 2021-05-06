using Smobiler.Core;
using System;

namespace cggApp
{
    partial class sexcontrol : Smobiler.Core.Controls.MobileUserControl
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
            Smobiler.Core.Controls.IconMenuViewGroup iconMenuViewGroup1 = new Smobiler.Core.Controls.IconMenuViewGroup();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem1 = new Smobiler.Core.Controls.IconMenuViewItem();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem2 = new Smobiler.Core.Controls.IconMenuViewItem();
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.iconMenuView1 = new Smobiler.Core.Controls.IconMenuView();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.iconMenuView1});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(115, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            // 
            // iconMenuView1
            // 
            this.iconMenuView1.BackColor = System.Drawing.Color.Transparent;
            this.iconMenuView1.ColumnNum = 2;
            this.iconMenuView1.ForeColor = System.Drawing.Color.DimGray;
            iconMenuViewGroup1.FontSize = 0F;
            iconMenuViewGroup1.IconBorderRadius = 0;
            iconMenuViewGroup1.ItemHeight = 0;
            iconMenuViewItem1.Icon = "男1";
            iconMenuViewItem1.ID = "男1";
            iconMenuViewItem1.Text = "男生";
            iconMenuViewItem2.Icon = "女1";
            iconMenuViewItem2.ID = "女1";
            iconMenuViewItem2.Text = "女生";
            iconMenuViewGroup1.Items.AddRange(new Smobiler.Core.Controls.IconMenuViewItem[] {
            iconMenuViewItem1,
            iconMenuViewItem2});
            this.iconMenuView1.Groups.AddRange(new Smobiler.Core.Controls.IconMenuViewGroup[] {
            iconMenuViewGroup1});
            this.iconMenuView1.ItemWidth = 30;
            this.iconMenuView1.Location = new System.Drawing.Point(0, 8);
            this.iconMenuView1.Name = "iconMenuView1";
            this.iconMenuView1.Size = new System.Drawing.Size(120, 62);
            this.iconMenuView1.ItemPress += new Smobiler.Core.Controls.IconMenuViewItemPressClickHandler(this.iconMenuView1_ItemPress);
            // 
            // sexcontrol
            // 
            this.BackColor = System.Drawing.Color.OldLace;
            this.BorderRadius = 20;
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Size = new System.Drawing.Size(120, 70);
            this.Name = "sexcontrol";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.IconMenuView iconMenuView1;
    }
}