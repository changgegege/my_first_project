using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cggApp
{
    class connection
    {
       //连接数据库cgg_ks
        public static SqlConnection connection_cgg()
        {
            //定义连接字符串
            string str = "server = .; database = cgg_ks; Persist Security Info=True; uid = sa; pwd = hc200628";
            return new SqlConnection(str);
        } 
    }
}
