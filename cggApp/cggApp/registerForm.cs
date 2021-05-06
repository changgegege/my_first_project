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
    partial class registerForm : Smobiler.Core.Controls.MobileForm
    {
        private static int pwdcheck_flag = 1;        //判断注册用户用户名是否合理
        private static int usernamecheck_flag = 1;   //判断注册用户密码是否合理

        //数据库连接
        SqlConnection conn = connection.connection_cgg();
        operate oper = new operate();

        public registerForm() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        //注册
        private void button1_Press(object sender, EventArgs e)
        {
            try
            {
                string username = nametextBox.Text.Trim();       //获取要注册的用户名
                string pwd = pwdtextBox.Text.Trim();             //获取要注册用户的密码
                string sex = sextextBox.Text.Trim();             //获取注册用户的性别
                string phonenumber = phonetextBox.Text.Trim();   //获取注册用户的电话号码
                string email = emailtextBox.Text.Trim();         //获取注册用户的邮箱

                //用户名及密码合理
                if (usernamecheck_flag == 0 && pwdcheck_flag == 0)
                {
                    //将该注册用户的信息存储在数据库中
                    string sql = "insert into cgguser (昵称,密码) values ('" + username + "', '" + pwd + "')";
                    oper.OperateData(sql);

                    //如果用户完善了性别信息，将其性别存储在数据库中
                    if (!string.IsNullOrEmpty(sex))
                    {
                        string sql1 = "update cgguser set 性别 = '" + sex + "' where 昵称 = '" + username + "'";
                        oper.OperateData(sql1);
                    }

                    //如果用户完善了手机号信息，将其手机号存储在数据库中
                    if (!string.IsNullOrEmpty(phonenumber))
                    {
                        string sql2 = "update cgguser set 手机号 = '" + phonenumber + "' where 昵称 = '" + username + "'";
                        oper.OperateData(sql2);
                    }

                    //如果用户完善了邮箱信息，将其邮箱存储在数据库中
                    if (!string.IsNullOrEmpty(email))
                    {
                        string sql3 = "update cgguser set 邮箱 = '" + email + "' where 昵称 = '" + username + "'";
                        oper.OperateData(sql3);
                    }

                    //注册成功显示提示信息，并跳转到登录界面
                    Toast("注册成功");
                    cggForm1 cggform = new cggForm1();
                    Show(cggform);
                }

                //用户名不合理，抛出异常
                else if (usernamecheck_flag == 1)
                {
                    throw new Exception("请输入合法的用户名");
                }

                //密码不合理，抛出异常
                else if (pwdcheck_flag == 1)
                {
                    throw new Exception("请检查密码正确性");
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }       
        }

        //触摸离开昵称输入框，判断输入的用户名是否合理
        private void nametextBox_TouchLeave(object sender, EventArgs e)
        {
            try
            {
                string username = nametextBox.Text.Trim();     //获取输入的用户名

                //注册的用户名已存在
                if (cggForm1.users.ContainsKey(username) == true)
                {
                    usernamecheck_flag = 1;
                    throw new Exception("该用户已存在");
                }
                //未输入用户名
                else if (string.IsNullOrEmpty(username))
                {
                    usernamecheck_flag = 1;
                    throw new Exception("请输入昵称");
                }
                else
                {
                    usernamecheck_flag = 0;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //触摸离开密码输入框
        private void pwdtextBox_TouchLeave(object sender, EventArgs e)
        {
            try
            {
                string pwd = pwdtextBox.Text.Trim();     //获取输入的密码

                //密码为空
                if (string.IsNullOrEmpty(pwd))
                {
                    pwdcheck_flag = 1;
                    throw new Exception("请输入密码");
                }
                else
                {
                    pwdcheck_flag = 0;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //触摸离开确认密码输入框
        private void pwd2textBox_TouchLeave(object sender, EventArgs e)
        {
            try
            {
                string pwd = pwdtextBox.Text.Trim();     //获取输入的密码
                string pwd2 = pwd2textBox.Text.Trim();   //获取输入的确认密码

                //如果两次输入的密码不相符，抛出异常
                if (string.Compare(pwd, pwd2) != 0)
                {
                    pwdcheck_flag = 1;
                    throw new Exception("两次输入密码不一致");
                }
                else
                {
                    pwdcheck_flag = 0;
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //性别选择，弹窗中选择
        private void textBox6_TouchEnter(object sender, EventArgs e)
        {
            ShowDialog(new sexcontrol());
        }

        //触摸离开性别输入框，根据选择的性别填入男或女
        private void textBox6_TouchLeave(object sender, EventArgs e)
        {
            //根据sexcontrol控件返回的标志位的值判断选择的是男或女
            if(sexcontrol.choose_flag == 0)
            {
                sextextBox.Text = "男";
            }
            else if(sexcontrol.choose_flag == 1)
            {
                sextextBox.Text = "女";
            }
        }

        //关闭界面
        private void imageButton1_Press(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}