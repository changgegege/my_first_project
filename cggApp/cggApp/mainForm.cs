using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace cggApp
{
    partial class mainForm : Smobiler.Core.Controls.MobileForm
    {
        public mainForm() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //pageview照片页展示
            DataTable dt = new DataTable();    //定义DataTable用于存储表数据

            dt.Columns.Add("img");             //img是列名，相应的模板控件的image的DisplayMember填写img
            dt.Rows.Add("11");                 //添加图片
            dt.Rows.Add("13");
            dt.Rows.Add("8");
            dt.Rows.Add("9");
            dt.Rows.Add("10");
            dt.Rows.Add("12");
            dt.Rows.Add("14");

            //选择pageView的模板控件
            pageView1.TemplateControl = new pageviewcontrol();

            //数据绑定
            if (dt.Rows.Count > 0)
            {
                pageView1.DataSource = dt;
                pageView1.DataBind();
            }
        }

        //底部工具栏菜单项选择
        private void toolBar1_ToolbarItemClick(object sender, ToolbarClickEventArgs e)
        {
            switch (e.Name)
            {
                case "menu":     //当前在主页界面，当点击主页界面时不执行任何操作
                    break;
                case "me":       //点击我界面，跳转到我界面显示
                    myForm myform = new myForm();
                    Show(myform,(obj,args) => { this.Close(); });
                        break;
                default:
                    break;
            }
        }

        //iconMenuView1菜单项选择
        private void iconMenuView1_ItemPress(object sender, IconMenuViewItemPressEventArgs e)
        {
            switch (e.Item.Text)
            {
                case "温湿度":           //显示温湿度数据的弹窗
                    ShowDialog(new wsdcontrol());
                    break;
                case "历史报警情况":     //跳转到历史报警情况界面
                    wsdbiubiuForm wsdbiubiu = new wsdbiubiuForm();
                    Show(wsdbiubiu);
                    break;
                case "当前设定阈值":     //显示当前温度阈值弹窗
                    ShowDialog(new Tthresholdcontrol());
                    break;
            }
        }

        //iconMenuView1菜单项选择
        private void iconMenuView2_ItemPress(object sender, IconMenuViewItemPressEventArgs e)
        {
            switch (e.Item.Text)
            {
                case "当前水位和等级":   //显示当前水位和水位等级的弹窗
                    ShowDialog(new watercontrol());
                    break;
                case "历史报警情况":     //跳转到历史报警情况界面
                    waterhistoryForm waterhistory = new waterhistoryForm();
                    Show(waterhistory);
                    break;
                case "当前设定阈值":     //显示水位阈值弹窗
                    ShowDialog(new waterthresholdcontrol());
                    break;
            }
        }

        //关闭页面
        private void imageButton1_Press(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}