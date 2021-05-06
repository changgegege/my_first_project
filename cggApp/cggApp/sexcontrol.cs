using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cggApp
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    [System.ComponentModel.ToolboxItem(true)]
    partial class sexcontrol : Smobiler.Core.Controls.MobileUserControl
    {
        public sexcontrol() : base()
        {
            //This call is required by the SmobilerUserControl.
            InitializeComponent();
        }

        public static int choose_flag = 2;   //性别选择标志，0代表男生，1代表女生
        private void iconMenuView1_ItemPress(object sender, IconMenuViewItemPressEventArgs e)
        {
            switch(e.Item.Text)
            {
                case "男生":
                    choose_flag = 0;   //若选择男生，标志位置0
                    this.Close();
                    break;
                case "女生":
                    choose_flag = 1;   //若选择女生，标志位置1
                    this.Close();
                    break;
            } 
        }
    }
}