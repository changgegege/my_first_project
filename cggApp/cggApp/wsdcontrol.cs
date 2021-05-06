using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;  //提供正则表达式功能
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace cggApp
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    [System.ComponentModel.ToolboxItem(true)]

    partial class wsdcontrol : Smobiler.Core.Controls.MobileUserControl
    {
        //数据库连接
        SqlConnection conn = connection.connection_cgg();
        operate oper = new operate();

        private static string[] H_T = new string[3];    //存储温度、湿度及报警标志位

        public wsdcontrol() : base()
        {
            //This call is required by the SmobilerUserControl.
            InitializeComponent();
        }

        private void wsdcontrol_Load(object sender, EventArgs e)
        {
            serialport_set();   //串口初始化 
        }

        //串口配置
        private void serialport_set()
        {
            serialPort1.PortName = "COM12";
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;

            serialPort1.Encoding = System.Text.Encoding.Default;
        }

        private static int rece_flag = 0;           //接收完成标志
        private static string str = string.Empty;   //存储串口接收的字符串

        //串口数据接收函数
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(500);                  //保证可以接收到所有字符
                str = string.Empty;
                str = serialPort1.ReadExisting();   //接收所有可用字节

                string[] str_split = str.Split(new char[2] { '！', ',' });    //以'！'和','分割字符串

                //若数据采集失败则不进行任何处理
                if (string.Compare(str_split[0].Substring(0, 11), "读取DHT11数据失败") == 0)
                {
                    return;
                }
                else
                {
                    H_T[0] = string.Empty;
                    H_T[1] = string.Empty;
                    H_T[2] = string.Empty;
                    for (int i = 1; i < str_split.Length; i++)
                    {
                        H_T[i - 1] = Regex.Replace(str_split[i], @"[^\d.\d]", "");    //只保留分割后的字符串的数值部分数据并依次存储在数组中
                    }

                    rece_flag = 1;      //数据接收完成标志

                    //将采集到的温湿度数据保存在数据库中
                    string time = DateTime.Now.ToString();
                    string sql = "insert into dht11 (温度,湿度,采集时间) values ('" + H_T[1] + "', '" + H_T[0] + "', '" + time + "')";
                    oper.OperateData(sql);

                    //若当前温度达到报警阈值则将该次的信息同时存储在数据库的历史报警记录表中
                    if (string.Compare(H_T[2], "1") == 0)       //温度高于最高温
                    {
                        string sql1 = "insert into dht11_history (报警时温度,备注,报警时间) values ('" + H_T[1] + "', '温度大于最高温', '" + time + "')";
                        oper.OperateData(sql1);
                    }
                    else if (string.Compare(H_T[2], "2") == 0)   //温度低于最低温
                    {
                        string sql1 = "insert into dht11_history (报警时温度,备注,报警时间) values ('" + H_T[1] + "', '温度小于最低温', '" + time + "')";
                        oper.OperateData(sql1);
                    }
                }
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //打开串口及使能串口发送温湿度数据
        private void imageButton2_Press(object sender, EventArgs e)
        {
            try
            { 
                serialPort1.Open();           //打开串口
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
            serialPort1.Write("G1[FINAL]");   //使能串口发送温湿度数据

            timer2.Start();                   //打开控制显示数据的定时器
        }

        //关闭串口及弹窗
        private void imageButton1_Press(object sender, EventArgs e)
        {
            serialPort1.Close();        //关闭串口
            timer2.Stop();              //每次关闭页面的时候需要一起关闭定时器才好
            this.Close();               //关闭弹窗
        }

        //数据显示
        private void timer2_Tick(object sender, EventArgs e)
        {
            //若本次数据接收及处理完成
            if (rece_flag == 1)
            {
                Hlabel.Text = H_T[0] + " %RH";                //显示湿度
                Tlabel.Text = H_T[1] + " ℃";                 //显示温度
                timelabel.Text = DateTime.Now.ToString();     //显示采集时间

                rece_flag = 0;                                //标志位清零
            }
        }   
    }
}