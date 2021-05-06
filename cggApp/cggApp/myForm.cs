using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace cggApp
{
    partial class myForm : Smobiler.Core.Controls.MobileForm
    {
        public myForm() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void myForm_Load(object sender, EventArgs e)
        {
            string username = cggForm1.user;   //获取登录的用户的用户名

            namelabel.Text = username;         //显示当前登录用户的用户名

            //根据登录用户选择相应头像
            if (string.Compare(username, "cgg") == 0)
            {
                photoimage.ResourceID = "7";
            }
            else if (string.Compare(username, "pp") == 0)
            {
                photoimage.ResourceID = "15";
            }
            else if (string.Compare(username, "gg") == 0)
            {
                photoimage.ResourceID = "16";
            }
            else if (string.Compare(username, "yjp") == 0)
            {
                photoimage.ResourceID = "19";
            }
        }

        //底部工具栏菜单项选择
        private void toolBar1_ToolbarItemClick(object sender, ToolbarClickEventArgs e)
        {
            switch (e.Name) {
                case "menu":     //点击主页菜单项，跳转到主页界面
                    mainForm mainform = new mainForm();
                    Show(mainform,(obj,args) => { this.Close(); });
                    break;
                case "me":       //点击我菜单项，现在就在我界面，不进行任何操作
                    break;
                default:
                    break;
            }
        }

        //列表菜单菜单项选择
        private void listMenuView1_ItemPress(object sender, ListMenuViewItemPressEventArgs e)
        {
            switch(e.Item.Name) {
                case "serial":      //跳转到上位机界面
                    serialForm serialform = new serialForm();
                    Show(serialform);
                    break;
                case "help":        //跳转到帮助界面
                    helpForm helpform = new helpForm();
                    Show(helpform);
                    break;
                default:
                    break;
            }
        }

        //列表菜单菜单项选择
        private void listMenuView2_ItemPress(object sender, ListMenuViewItemPressEventArgs e)
        {
            switch (e.Item.Name) {
                case "exit":      //退出登录
                    this.Close();
                    break;
                default:
                    break;

            }
        }
    }
}