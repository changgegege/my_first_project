using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace cggApp
{
    partial class waterhistoryForm : Smobiler.Core.Controls.MobileForm
    {
        //数据库连接
        SqlConnection conn = connection.connection_cgg();
        operate oper = new operate();
        public waterhistoryForm() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void waterhistoryForm_Load(object sender, EventArgs e)
        {
            //存储数据库中查询到的表数据
            DataTableCollection Tables;

            //查询数据库中water_history表中所有记录并保存在Tables中
            string sql = "select * from water_history";
            Tables = oper.OperateFillDataSet(sql);

            //设置gridView的模板控件
            gridView1.TemplateControl = new watergridviewcontrol();

            //绑定数据
            if(Tables[0].Rows.Count > 0)
            {
                gridView1.DataSource = Tables[0];
                gridView1.DataBind();
            }
            else
            {
                Toast("无相关记录");
            }
        }

        //关闭页面
        private void imageButton1_Press(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}