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
    partial class cggForm1 : Smobiler.Core.Controls.MobileForm
    {
        //数据字典，用于存储所有存储在数据库中的用户的信息
        public static Dictionary<string, string> users = new Dictionary<string, string>();

        public cggForm1() : base()
        {
            InitializeComponent();
        }

        //数据库连接
        SqlConnection conn = connection.connection_cgg();
        operate oper = new operate();
        DataTableCollection table;

        public static string user;     //存储当前登录用户的用户名

        private void cggForm1_Load(object sender, EventArgs e)
        {
            users.Clear();             //每次切换到登录页面，数据字典的值都重新获取

            //获取数据库中存储的所有用户
            string sql = "select 昵称,密码 from cgguser";
            table = oper.OperateFillDataSet(sql);

            int count = table[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                users.Add(table[0].Rows[i][0].ToString().Trim(), table[0].Rows[i][1].ToString().Trim());  //去除空格
            }
        }

        private static int load_flag = 1;      //判断是否可以登录标志
        
        //登录按钮
        private void button1_Press(object sender, EventArgs e)
        {
            try
            {
                user = usertextBox.Text.Trim();                  //要登录的用户名
                string password = passwordtextBox.Text.Trim();   //输入的密码
                string tmp_pwd;                                  //存储用户对应的正确密码

                //选中记住密码时将密码保存
                if (remecheckBox.Checked == true)
                {
                    try
                    {
                        if(!string.IsNullOrEmpty(passwordtextBox.Text))
                        {
                            LoadClientData(user, password);   //处理在密码处为空时就点记住密码登录
                        }               
                    }
                    catch(Exception ex)
                    {
                        Toast(ex.Message);
                    }
                }

                //若用户名存在，且密码不为空
                if(load_flag == 0)
                {
                    load_flag = 0;

                    users.TryGetValue(user, out tmp_pwd);        //获取与该用户绑定的密码

                    //若输入密码与用户密码不相符
                    if (string.Compare(tmp_pwd, password) != 0)
                    {
                        load_flag = 1;                           //拒绝登录
                        throw new Exception("密码错误");
                    }
                    else
                    {
                        load_flag = 0;
                        Toast(user + "登录成功");

                        usertextBox.Text = "";                   //清空用户名和密码输入框
                        passwordtextBox.Text = "";

                        //跳转到主页界面
                        mainForm mainform = new mainForm();
                        Show(mainform,(obj,args) => { this.Close(); });
                    }   
                }
                else if(load_flag == 1)
                {
                    throw new Exception("用户名或密码无效");
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //注册按钮
        private void button2_Press(object sender, EventArgs e)
        {
            //跳转到注册界面
            registerForm registerform = new registerForm();
            Show(registerform);
        }

        //触摸离开用户名输入框
        private void usertextBox_TouchLeave(object sender, EventArgs e)
        {
            try
            {
                string user = usertextBox.Text.Trim();      //获取用户名

                //用户名为空抛出异常
                if (string.IsNullOrEmpty(user))
                {
                    load_flag = 1;
                    throw new Exception("请输入用户名");
                }
                else
                {
                    //用户不存在抛出异常
                    if (users.ContainsKey(user) == false)
                    {
                        load_flag = 1;
                        throw new Exception("该用户不存在");
                    }
                    else
                    {
                        load_flag = 0;

                        //查看是否已记住该用户的密码
                        ReadClientData(user, (object s, ClientDataResultHandlerArgs arg) =>
                        {
                            //若无错误信息
                            if(string.IsNullOrEmpty(arg.error))
                            {
                                string pwd = arg.Value;
                                passwordtextBox.Text = pwd;     //自动填充该用户的密码
                            }
                            else
                            {
                                throw new Exception("失败");
                            }
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //触摸离开密码输入框
        private void passwordtextBox_TouchLeave(object sender, EventArgs e)
        {
            string user = usertextBox.Text.Trim();            //获取用户名
            string password = passwordtextBox.Text.Trim();    //获取输入的密码

            try
            {
                //密码为空抛出异常
                if (string.IsNullOrEmpty(password))
                {
                    load_flag = 1;
                    throw new Exception("请输入密码");
                }
                else
                {
                    load_flag = 0;
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}