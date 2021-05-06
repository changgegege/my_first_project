using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace cggApp
{
    partial class serialForm : Smobiler.Core.Controls.MobileForm
    {
        public serialForm() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void serialForm_Load(object sender, EventArgs e)
        {
            serialport_set();    //初始化串口

           //时间显示
            timelabel.Text = DateTime.Now.ToString();
            timer2.Start();
        }

        //串口参数设置
        private void serialport_set()
        {
            serialPort1.PortName = "COM12";        //端口号
            serialPort1.BaudRate = 9600;           //波特率
            serialPort1.DataBits = 8;              //数据位
            serialPort1.StopBits = StopBits.One;   //停止位
            serialPort1.Parity = Parity.None;      //奇偶校验

            serialPort1.Encoding = System.Text.Encoding.Default;   //自动获取当前页的编码格式
        }

        private static int rece_flag = 0;             //接收数据成功标志
        private static string str = string.Empty;     //存储串口接收字符串
        private static int final_flag = 0;            //关闭串口时判断本次接收是否完成标志

        //数据接收函数
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                str = string.Empty;
                Thread.Sleep(500);                  //线程睡眠500ms，等待所有字节发送完成
                str = serialPort1.ReadExisting();   //读取所有可用字符

                final_flag = 1;                     //本次接收完成，标志位置1，可关闭串口
                rece_flag = 1;                      //接收完成标志置1，可显示数据
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //显示接收数据定时器，1s触发一次
        private void timer1_Tick(object sender, EventArgs e)
        {
            //若本次数据接收完成，将接收到的字符串显示在文本输入框
            if(rece_flag == 1)
            {
                receivetextBox.Text += str;

                rece_flag = 0;    //标志位清零
            }
        }

        //退出 
        private void imageButton2_Press(object sender, EventArgs e)
        {
            //若串口处于打开状态，关闭串口
            if (serialPort1.IsOpen)   
            {
                serialPort1.Close();
            }

            //若定时器1处于打开状态，关闭定时器
            if(timer1.Enabled)
            {
                timer1.Stop();
            }

            this.Close();    //关闭此页面
        }

        //打开串口及接收数据
        private void imageButton1_Press(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();              //打开串口
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
            serialPort1.Write("G1[FINAL]");  //向设备发送指令，使能温湿度发送

            timer1.Start();       //使能定时器1，可开始判断是否有数据准备好
        }

        //关闭串口但不退出页面
        private void imageButton3_Press(object sender, EventArgs e)
        {
            //若本次数据已接收完成
            if(final_flag == 1)
            {
                final_flag = 0;        //标志位清零

                serialPort1.Close();   //关闭串口
                timer1.Stop();         //关闭定时器
            }
        }

        //更新时间
        private void timer2_Tick(object sender, EventArgs e)
        {
            timelabel.Text = DateTime.Now.ToString();   //实现1s更新一次时间，时间实时时钟
        }

        //清空接收区
        private void imageButton4_Press(object sender, EventArgs e)
        {
            receivetextBox.Text = "";
        }

        //发送
        private void imageButton5_Press(object sender, EventArgs e)
        {
            try
            {
                //存储及发送指令
                byte[] send_data = System.Text.Encoding.Default.GetBytes(sendtextBox.Text);
                serialPort1.Write(send_data, 0, send_data.Length);     
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}