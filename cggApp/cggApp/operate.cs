using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace cggApp
{
    class operate
    {
        //定义数据库连接
        SqlConnection conn = connection.connection_cgg();
        
        //执行sql语句
        public int OperateData(string sql)
        {
            conn.Open();                                  //打开数据库连接
            SqlCommand cmd = new SqlCommand(sql, conn);   //执行sql语句
            int count = (int)cmd.ExecuteNonQuery();       //得到受影响的行数
            conn.Close();                                 //关闭数据库连接
            return count;                                 //返回受影响的行数
        }

        //向DataSet数据集中添加数据
        public DataTableCollection OperateFillDataSet(string sql)
        {
            conn.Open();                     //打开数据库连接
            SqlDataAdapter ada = new SqlDataAdapter(sql, conn);     //用于向dataset数据集添加数据
            
            DataSet data = new DataSet();    //初始化DataSet对象的新实例
            ada.Fill(data);                  //添加数据
            conn.Close();                    //关闭数据库连接
            return data.Tables;              //返回DataSet中包含的表
        }
    }
}
