using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace cggApp
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    [System.ComponentModel.ToolboxItem(true)]
    partial class Tthresholdcontrol : Smobiler.Core.Controls.MobileUserControl
    {
        //数据库连接
        SqlConnection conn = connection.connection_cgg();
        operate oper = new operate();

        private static string[] max_min = new string[3];    //存储分解后的温度阈值及报警状态

        public Tthresholdcontrol() : base()
        {
            //This call is required by the SmobilerUserControl.
            InitializeComponent();
        }

        private void Tthresholdcontrol_Load(object sender, EventArgs e)
        {
            serialport_set();                       //串口初始化
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

        private static int rece_flag = 0;           //本次数据处理完成标志位
        private static string str = string.Empty;   //存储串口接收到的字符串

        //串口数据接收函数
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);                   //线程睡眠500ms，以一次接收所有可用字节
            str = string.Empty;
            str = serialPort1.ReadExisting();    //存储接收到的字符串数据

            //通过','将接收到的字符串进行分割
            string[] str_split = str.Split(new char[1] { ',' });

            max_min[0] = string.Empty;
            max_min[1] = string.Empty;
            max_min[2] = string.Empty;

            //将最高温、最低温和报警状态分别存储在数组中
            for (int i = 0; i < str_split.Length; i++)
            {
                max_min[i] = str_split[i];
            }

            //判断是否处于报警状态
            if (string.Compare(max_min[2], "1") == 0)
            {
                max_min[2] = "是";
            }
            else if (string.Compare(max_min[2], "0") == 0)
            {
                max_min[2] = "否";
            }

            rece_flag = 1;     //数据处理完成标志位置1
        }

        //打开串口
        private void imageButton1_Press(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();           //打开串口
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
            serialPort1.Write("T1[FINAL]");   //向设备发送T1指令

            timer1.Start();                   //开启定时器1，使能数据显示功能
        }

        //关闭串口并关闭弹窗
        private void imageButton2_Press(object sender, EventArgs e)
        {
            serialPort1.Close();      //关闭串口
            timer1.Stop();            //关闭定时器
            this.Close();             //关闭弹窗
        }

        //实现数据显示
        private void timer1_Tick(object sender, EventArgs e)
        {
            //若接收完成，显示接收的数据
            if(rece_flag == 1)
            {
                maxlabel.Text = max_min[0];      //显示最高温
                minlabel.Text = max_min[1];      //显示最低温
                checklabel.Text = max_min[2];    //显示报警状态

                rece_flag = 0;                   //标志位清零
            }
        }
    }
}