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
    partial class watercontrol : Smobiler.Core.Controls.MobileUserControl
    {
        //连接数据库
        SqlConnection conn = connection.connection_cgg();
        operate oper = new operate();

        public watercontrol() : base()
        {
            //This call is required by the SmobilerUserControl.
            InitializeComponent();
        }

        private void watercontrol_Load(object sender, EventArgs e)
        {
            serialport_set();      //串口初始化
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

        private static int rece_flag = 0;                    //本次数据接收完成标志
        private static int final_flag = 0;                   //数据接收完成，可关闭串口的标志
        private static string str = string.Empty;            //存储接收到的字符串
        private static string[] water_data = new string[3];  //存储水位、水位等级及持续时间

        //串口数据接收函数
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                str = string.Empty;
                Thread.Sleep(500);                   //线程睡眠500ms
                str = serialPort1.ReadExisting();    //接收所有可用字节

                string[] str_split = str.Split(new char[1] { ',' });   //以','分割字符串

                water_data[0] = string.Empty;
                water_data[1] = string.Empty;
                water_data[2] = string.Empty;
                for (int i = 0; i < str_split.Length; i++)
                {
                    water_data[i] = str_split[i];    //将水位、水位等级以及水位持续时间依次存储在数组中
                }

                //当水位等级大于或等于2级时，触发报警，并将该次报警信息存储在数据库中
                if (int.Parse(water_data[1]) >= 2)
                {
                    string time = DateTime.Now.ToString();
                    string sql = "insert into water_history (报警时水位,报警时水位等级,报警时间) values ('" + water_data[0] + "', '" + water_data[1] + "', '" + time + "')";
                    oper.OperateData(sql);
                }

                rece_flag = 1;      //接收完成标志位置1
                final_flag = 1;     //可关闭串口标志位置1
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        //打开串口
        private void imageButton2_Press(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();     //打开串口
            }
            catch(Exception ex)
            {
                Toast(ex.Message);
            }

            timer1.Start();             //开启发送指令及显示数据的定时器
        }

        //关闭串口
        private void imageButton1_Press(object sender, EventArgs e)
        {
            timer1.Stop();             //停止定时器
            
            //若本次接收（数据处理）完成，关闭串口
            if (final_flag == 1)
            {
                serialPort1.Close();   //关闭串口
                final_flag = 0;        //标志位清零
            }

            this.Close();              //关闭界面
        }

        //发送查询指令及显示数据
        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.Write("W1[FINAL]");      //1s向设备发送一次查询水位信息的命令，即1s更新一次数据

            //若接收并处理数据完成
            if(rece_flag == 1)
            {
                Wlabel.Text = water_data[0] + "cm";     //显示当前水位
                Llabel.Text = water_data[1];            //显示当前水位等级
                timelabel.Text = water_data[2] + "s";   //显示当前水位持续时间

                rece_flag = 0;                          //标志位清零
            }
        }
    }
}