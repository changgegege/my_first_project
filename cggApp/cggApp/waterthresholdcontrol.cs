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
    partial class waterthresholdcontrol : Smobiler.Core.Controls.MobileUserControl
    {
        //数据库连接
        SqlConnection conn = connection.connection_cgg();
        operate oper = new operate();

        public waterthresholdcontrol() : base()
        {
            //This call is required by the SmobilerUserControl.
            InitializeComponent();
        }

        private void waterthresholdcontrol_Load(object sender, EventArgs e)
        {
            serialport_set();     //串口初始化
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

        private static int rece_flag = 0;                     //数据接收完成标志
        private static string[] threshold = new string[3];    //存储水位阈值信息
        private static string str = string.Empty;             //存储接收到的字符串
        
        //串口数据接收函数
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            str = string.Empty;
            Thread.Sleep(500);
            str = serialPort1.ReadExisting();                      //接收所有可用字节

            string[] str_split = str.Split(new char[1] { ',' });   //以','分割字符串

            threshold[0] = string.Empty;
            threshold[1] = string.Empty;
            threshold[2] = string.Empty;
            for (int i = 0; i < str_split.Length; i++)
            {
                threshold[i] = str_split[i];       //依次将水位阈值信息存储在数组中
            }

            rece_flag = 1;        //接收完成标志位置1
        }

        //打开串口及发送指令
        private void imageButton2_Press(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();             //打开串口
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
            serialPort1.Write("W2[FINAL]");     //发送W2指令查询当前水位阈值

            timer1.Start();                     //开启控制数据显示的定时器
        }

        //关闭串口及关闭弹窗
        private void imageButton1_Press(object sender, EventArgs e)
        {
            serialPort1.Close();      //关闭串口
            timer1.Stop();            //关闭定时器
            this.Close();             //关闭弹窗
        }

        //数据显示
        private void timer1_Tick(object sender, EventArgs e)
        {
            //若数据接收及处理完成，显示数据
            if(rece_flag == 1)
            {
                threshold1label.Text = threshold[0];      //显示阈值1
                threshold2label.Text = threshold[1];      //显示阈值2
                threshold3label.Text = threshold[2];      //显示阈值3

                rece_flag = 0;                            //标志位清零
            }
        }  
    }
}