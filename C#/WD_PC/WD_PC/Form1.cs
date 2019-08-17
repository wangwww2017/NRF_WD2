using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace WD_PC
{
    public partial class Form1 : Form
    {

        private SerialPort sp1 = new SerialPort();
        private StringBuilder builder = new StringBuilder();

        private double Temp = 0;

        private List<byte> buffer = new List<byte>(4096);//默认分配1页内存，并始终限制不允许超过  
        private byte[] binary_data_1 = new byte[9];

        private bool bOneCaiji = false;
        private bool bCycCaiji = false;

        private Series series1 = new Series();
        private ChartArea chartArea1 = new ChartArea();

        private Series SeriesTemp = new Series();
        private ChartArea ChartAreaTemp = new ChartArea();

        private double c_temp = 0;
        private double[] ctemps = new double[60];



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            cmb_br.SelectedIndex = 5;       //9600 波特率
            cmb_data.SelectedIndex = 3;     //8数据位
            cmb_stop.SelectedIndex = 0;     //1个停止位
            cmb_check.SelectedIndex = 0;    //无校验位

            //检查串口
            string[] str = SerialPort.GetPortNames();
            if(str == null){

                MessageBox.Show("本机没有串口！", "Error");
                return;
            }
            //添加串口
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cmb_port.Items.Add(s);
            }
            cmb_port.SelectedIndex = 1;

            sp1.BaudRate = 9600;

            Control.CheckForIllegalCrossThreadCalls = false;
            sp1.DataReceived += new SerialDataReceivedEventHandler(sp1_DataReceived);

            rb_send16.Checked = true;
            rb_rev16.Checked = true;

            sp1.DtrEnable = false;
            sp1.RtsEnable = false;
            sp1.ReadTimeout = 1000;

            sp1.Close();

            tmSend.Enabled = false;
            txt_time.Text = "1";

            bOneCaiji = false;
            bCycCaiji = false;

            Draw_Chart();
            
        }
        //0XAA 0XAB 0XOO 0XNN 0XXX 0xXX 0XSUM 0XAF 
        //接收处理函数
        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           // throw new NotImplementedException();
            //if(Closing)
            if(sp1.IsOpen){

              //  DateTime dt = DateTime.Now;
              //   txt_rev.Text += dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
            
                //   txt_rev.SelectAll();

                try
                {
                    int n = sp1.BytesToRead;
                    byte[] buf = new byte[n];
                    sp1.Read(buf, 0, n);

                    bool data_catched = false;

                    buffer.AddRange(buf);
                    while (buffer.Count >= 4)
                    {
                        if (buffer[0] == 0xaa && buffer[1] == 0xab)
                        {
                            int len = buffer[3];

                            if(buffer.Count < len+5)break;
                 
                            buffer.CopyTo(0,binary_data_1,0,len+5);
                            data_catched = true;
                            buffer.RemoveRange(0,len+5);
                        }
                        else
                        {
                            buffer.RemoveAt(0);
                        }
                    }
                  
                        if (data_catched)
                        {
                            Data_Transfer_Anl(binary_data_1);
                        }
                    
                    //  Data_Transfer(buf);
                    builder.Clear();
                    this.Invoke((EventHandler)(delegate
                    {
                        if (rb_rev16.Checked)
                        {
                            foreach(byte b in buf)
                            {
                                builder.Append(b.ToString("X2") + " ");
                            }
                        } 
                        else
                        {
                            builder.Append(Encoding.ASCII.GetString(buf));
                        }
                        txt_rev.AppendText(builder.ToString());
                        
                    }));

                }
                catch (System.Exception ex)
                {

                    MessageBox.Show(ex.Message, "串口出错");
                    txtb_send.Text = "";
                }

               
                
            }else{

                MessageBox.Show("请打开串口", "串口出错");
            }


        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //
        //打开关闭串口
        private void btn_com_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                try
                {
                    string serialName = cmb_port.SelectedItem.ToString();
                    sp1.PortName = serialName;

                    string strBr = cmb_br.Text;
                    string strData = cmb_data.Text;
                    string strStop = cmb_stop.Text;
                    Int32 iBr = Convert.ToInt32(strBr);
                    Int32 iData = Convert.ToInt32(strData);

                    sp1.BaudRate = iBr;
                    sp1.DataBits = iData;
                    switch (cmb_stop.Text)            //停止位
                    {
                        case "1":
                            sp1.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            sp1.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            sp1.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：参数不正确!", "Error");
                            break;
                    }
                    switch (cmb_check.Text)             //校验位
                    {
                        case "无":
                            sp1.Parity = Parity.None;
                            break;
                        case "奇校验":
                            sp1.Parity = Parity.Odd;
                            break;
                        case "偶校验":
                            sp1.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：参数不正确!", "Error");
                            break;
                    }

                    if (sp1.IsOpen == true)
                    {
                        sp1.Close();
                    }

                    //设置必要控件不可用
                    cmb_port.Enabled = false;
                    cmb_br.Enabled = false;
                    cmb_data.Enabled = false;
                    cmb_stop.Enabled = false;
                    cmb_check.Enabled = false;

                    sp1.Open();     //打开串口
                    btn_com.Text = "关闭串口";

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    //tmSend.Enabled = false;
                    return;
                }
            } 
            else
            {
                cmb_port.Enabled = true;
                cmb_br.Enabled = true;
                cmb_data.Enabled = true;
                cmb_stop.Enabled = true;
                cmb_check.Enabled = true;

                sp1.Close();     //关闭串口
                btn_com.Text = "打开串口";
                tmSend.Enabled = false;
            }
        }

        //
        //检查连接
        private void btn_sendCheck_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
           // int tx_len = 7;
            byte[] tx_data = new byte[7] { 0xaa, 0xab, 0x01, 0x01, 0xcc, 0xbb, 0xaf };

            byte tx_len = 0;
            byte[] data_send = new byte[7];

            data_send[tx_len++] = 0xaa;
            data_send[tx_len++] = 0xab;
            data_send[tx_len++] = 0x01;
            data_send[tx_len++] = 0;

            data_send[tx_len++] = 0x0C;  
            data_send[tx_len++] = 0x0C;  
            data_send[3] = 2;
            data_send[tx_len++] = Get_Sum(data_send, tx_len + 1);
            //data_send[tx_len++] = 0xaf;
            sp1.Write(data_send, 0, data_send.Length);

            //sp1.Write(tx_data, 0, tx_data.Length);
            
        }


        //发送
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            String strSend = txtb_send.Text;
            if (rb_send16.Checked == true)	//“HEX发送” 按钮 
            {
                //处理数字转换
                string sendBuf = strSend;
                string sendnoNull = sendBuf.Trim();
                string sendNOComma = sendnoNull.Replace(',', ' ');    //去掉英文逗号
                string sendNOComma1 = sendNOComma.Replace('，', ' '); //去掉中文逗号
                string strSendNoComma2 = sendNOComma1.Replace("0x", "");   //去掉0x
                strSendNoComma2.Replace("0X", "");   //去掉0X
                string[] strArray = strSendNoComma2.Split(' ');

                int byteBufferLength = strArray.Length;
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "")
                    {
                        byteBufferLength--;
                    }
                }
                // int temp = 0;
                byte[] byteBuffer = new byte[byteBufferLength];
                int ii = 0;
                for (int i = 0; i < strArray.Length; i++)        //对获取的字符做相加运算
                {

                    Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);

                    int decNum = 0;
                    if (strArray[i] == "")
                    {
                        //ii--;     //加上此句是错误的，下面的continue以延缓了一个ii，不与i同步
                        continue;
                    }
                    else
                    {
                        decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 
                    }

                    try    //防止输错，使其只能输入一个字节的字符
                    {
                        byteBuffer[ii] = Convert.ToByte(decNum);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                        tmSend.Enabled = false;
                        return;
                    }

                    ii++;
                }
                sp1.Write(byteBuffer, 0, byteBuffer.Length);
            }
            else		//以字符串形式发送时 
            {
                sp1.WriteLine(txtb_send.Text);    //写入数据
            }
        }


        //
        //清空接收框
        private void btn_clearRcv_Click(object sender, EventArgs e)
        {
            txt_rev.Text = "";
        }


        //
        //采集温度按钮控制
        private void btn_Caiji_Click(object sender, EventArgs e)
        {
            //byte[] tx_data = new byte[7] { 0xaa, 0xab, 0x02, 0x01, 0xcc, 0xbb, 0xaf };
            byte tx_len=0;
	        byte[] data_send=new byte[7];

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
           
	        data_send[tx_len++] = 0xaa;
	        data_send[tx_len++] = 0xab;
	        data_send[tx_len++] = 0x02;
	        data_send[tx_len++] = 0;
	
	        data_send[tx_len++] = 0x0d;    
	        data_send[tx_len++] = 0x0d; 
	        data_send[3] = 2;
	        data_send[tx_len++] = Get_Sum(data_send,tx_len+1);
	//data_send[tx_len++] = 0xaf;
            sp1.Write(data_send, 0, data_send.Length);

            bOneCaiji = true;
        }


        /*
        private void Data_Transfer(byte[] buff) 
        {
            byte[] data_buf = new byte[32];
            int data_count = 0;
            bool brx0=false,brx1=false,brx2=false;
            
            
            for (int i = 0; i < buff.Length; i++)
            {
                if (buff[i] == 0xaa)
                {
                    brx0 = true;
                    data_buf[data_count++] = buff[i];

                }
                if (brx0 && buff[i]==0xab)
                {
                    brx1 = true;
                    data_buf[data_count++] = buff[i];
                }
                if (brx1 && brx0)
                {
                    data_buf[data_count++] = buff[i];
                }
                if (brx0 && brx1 && buff[i]==0xaf)
                {
                    data_buf[data_count++] = buff[i];
                    brx2 = true;
                }
                if (brx0 && brx1 &&brx2)
                {

                    txt_rev.Text += "接收的数据包为"+"\r\n";
                    builder.Clear();
                    foreach (byte b in data_buf)
                    {
                        builder.Append(b.ToString("X2") + " ");
                    }
                    txt_rev.AppendText(builder.ToString()); 


                    Data_Transfer_Anl(data_buf);
                }
            }
        }
        */



        //计算校验和
        //
        private byte Get_Sum(byte[] buff, int len)
        {
            byte i = 0, sum = 0;
            for (i = 0; i < (len - 1); i++)
            {
                sum += buff[i];
            }
            return sum;
        }


        //分析数据包
        //0XAA 0XAB 0XOO 0XNN 0XXX 0XSUM 0XAF 
        private void Data_Transfer_Anl(byte[] data_buf){

            
            txt_rev.Text += "接收的数据包为" + "\r\n";
            builder.Clear();
            foreach (byte b in binary_data_1)
            {
                builder.Append(b.ToString("X2") + " ");
            }
            txt_rev.AppendText(builder.ToString());


           /**/ if (!(Get_Sum(data_buf, data_buf[3] + 5) == data_buf[data_buf[3] + 4]))
            {
                lab_sta.Text = "数据包校验和错误！";
               // lab_sta.Text = data_buf[6].ToString("X2") +" "+ Get_Sum(data_buf, 7).ToString("X2");
            
                return;
            }
            if (!(data_buf[0] == 0xaa && data_buf[1] == 0xab))
            {
                lab_sta.Text = "数据包头错误！";
                return;
            }

            switch(data_buf[2]){

                case 0x01:
                    if (data_buf[3] == 2 && data_buf[4] == 0xcc && data_buf[5] == 0xcc)
                    {
                        lab_sta.Text = "无线连接正常！";
                        //return;
                    }
                    else
                    {
                        lab_sta.Text = "无线连接错误！";
                        //return;

                    }
                    break;
                case 0x02:
                    if (!(data_buf[3] == 4))
                    {
                        lab_sta.Text = "温度数据错误！";
                        return;
                    }
                    int t = 0;
                   
                    t += (data_buf[4]-0x30)*1000;
                    t += (data_buf[5]-0x30)*100;
                    t += (data_buf[6]-0x30)*10;
                    t += data_buf[7]-0x30;
                    /*
                    Temp = (data_buf[5] + data_buf[4]<< 8 );
                    */
                    Temp = t * 0.1; //(float)(t )* 0.1;
                    if ( bOneCaiji == true)
                    {
                        bOneCaiji = false;
                        MessageBox.Show("当前温度为：" + Temp.ToString("0.0") + "℃", "当前温度");
                    }
                    txt_temp.Text = Temp.ToString("0.0") + "℃"; 
                    
                    //txt_temp.Text = strTemp + "℃";
                    break;
                default:
                    break;
            }

        
        }

        /// <循环采集温度>
        /// 循环采集温度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cycCaiJi_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            if (!bCycCaiji)
            {
                try
                {
                    int second = int.Parse(txt_time.Text) * 1000;
                    tmSend.Interval = second;
                }
                catch (System.Exception ex)
                {
                    
                    tmSend.Enabled = false;
                    MessageBox.Show("错误的定时输入！", "Error");
                }
                bCycCaiji = true;
                tmSend.Enabled = true;
                btn_cycCaiJi.Text = "结束循环采集";
                btn_Caiji.Enabled = false;
                btn_sendCheck.Enabled = false;
                btn_com.Enabled = false;
            } 
            else
            {
                bCycCaiji = false;
                tmSend.Enabled = false;
                btn_cycCaiJi.Text = "开始循环采集";
                btn_Caiji.Enabled = true;
                btn_sendCheck.Enabled = true;
                btn_com.Enabled = true;
            }
            
          



        }

        /// <发送窗口 检查输入>
        /// 检查输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtb_send_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rb_send16.Checked == true)
            {
                //正则匹配
                string patten = "[0-9a-fA-F]|\b|0x|0X| "; //“\b”：退格键
                Regex r = new Regex(patten);
                Match m = r.Match(e.KeyChar.ToString());

                if (m.Success)//&&(txtSend.Text.LastIndexOf(" ") != txtSend.Text.Length-1))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }//end of radio1
            else
            {
                e.Handled = false;
            }
        }

        /// <定时器循环采集>
        /// 定时器 循环采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmSend_Tick(object sender, EventArgs e)
        {


            byte tx_len = 0;
            byte[] data_send = new byte[7];

            
                if (tmSend.Enabled == true)
                {
                    data_send[tx_len++] = 0xaa;
                    data_send[tx_len++] = 0xab;
                    data_send[tx_len++] = 0x02;
                    data_send[tx_len++] = 0;

                    data_send[tx_len++] = 0x1d;
                    data_send[tx_len++] = 0x1d;
                    data_send[3] = 2;
                    data_send[tx_len++] = Get_Sum(data_send, tx_len + 1);
                    //data_send[tx_len++] = 0xaf;
                    sp1.Write(data_send, 0, data_send.Length);
                    c_temp += 10.5;
                    Draw_Chart_temp();
                }
                  

        }

        private void txt_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            string patten = "[0-9]|\b|."; //“\b”：退格键
            Regex r = new Regex(patten);
            Match m = r.Match(e.KeyChar.ToString());

            if (m.Success)
            {
                e.Handled = false;   //没操作“过”，系统会处理事件    
            }
            else
            {
                e.Handled = true;
            }
        }



        private void Draw_Chart()
        {
            //绘图前期处理
            chart_temp.Titles.Clear();

            //标题设置
            Title title = new Title();
            title.Text = "无线温度采集";
            title.Font = new Font("宋体", 16f, FontStyle.Bold);
            //标题
            chart_temp.Titles.Add(title);

            // 坐标轴设置
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.IsMarginVisible = false;

            //X 轴坐标最大最小值
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.Minimum = -35;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.Maximum = 100;
           

            // 坐标轴刻度线不延长出来设置
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.MajorTickMark.Enabled = false;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.MajorTickMark.Enabled = false;

            //X 次要辅助线设置
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.MinorGrid.Enabled = true;
            //X 次要辅助线间距
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.MinorGrid.Interval = 1;
            //X 次要辅助线颜色
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.MinorGrid.LineColor = Color.LightGray;

            //Y 次要辅助线设置
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.MinorGrid.Enabled = true;
            //Y 次要辅助线间距
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.MinorGrid.Interval = 10;
            //Y 次要辅助线颜色
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.MinorGrid.LineColor = Color.LightGray;

            //X 主要辅助线设置
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.MajorGrid.Enabled = true;
            //X 主要辅助线间距
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.MajorGrid.Interval = 5;
            //X 主要辅助线颜色
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.MajorGrid.LineColor = Color.Gray;

            //Y 主要辅助线设置
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.MajorGrid.Enabled = true;
            //Y 主要辅助线间距
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.MajorGrid.Interval = 30;
            //Y 主要辅助线颜色
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.MajorGrid.LineColor = Color.Gray;

            //坐标主要辅助线刻度间距
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Interval = 5;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.Interval = 10;

            //坐标轴说明
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Title = "";
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.Title = "温度";
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.TitleFont = new Font("宋体", 10f, FontStyle.Bold);
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.TitleFont = new Font("宋体", 10f, FontStyle.Bold);
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.TitleAlignment = StringAlignment.Far;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisY.TitleAlignment = StringAlignment.Far;

            //边框样式设置
            chart_temp.ChartAreas["ChartAreaTemp"].BorderColor = Color.Black;
            chart_temp.ChartAreas["ChartAreaTemp"].BorderDashStyle = ChartDashStyle.Solid;
            chart_temp.ChartAreas["ChartAreaTemp"].BorderWidth = 1;

            //chart_temp.ChartAreas["ChartAreaTemp"].Area3DStyle.Enable3D = true;
           /* chart_temp.ChartAreas["ChartAreaTemp"].AxisX.ScrollBar.IsPositionedInside = false;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.ScrollBar.Size = 20;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.ScaleView.Size = 30;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.ScaleView.MinSize = 1;*/
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Interval = 10;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Minimum = 0;
            chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Maximum = 30;
            

            //图例文字
            chart_temp.Series["SeriesTemp"].ChartType = SeriesChartType.StepLine;
            chart_temp.Series["SeriesTemp"].BorderWidth = 3;
            chart_temp.Series["SeriesTemp"].ShadowOffset = 0;
             
            chart_temp.Series["SeriesTemp"].Points.AddY(0);
            chart_temp.Series["SeriesTemp"].LegendText = "温度";

            //图例位置、字体设置；坐标轴位置设定
            //chart_temp.Legends[0].Position = new ElementPosition(10, 10, 88, 7);
            // chart_temp.Legends[0].Font = new Font("宋体", 9);
            //chart_temp.ChartAreas[0].InnerPlotPosition = new ElementPosition(6, 5, 90, 82);
        }


        private Random random = new Random();
        private int pointIndex = 0;

        private void Draw_Chart_temp()
        {
             
            //chart_temp.Series["SeriesTemp"].Points.AddY(Temp);

            // Define some variables
            int numberOfPointsInChart = 100;// int.Parse(comboBoxVisiblePoints.Text);
            int numberOfPointsAfterRemoval = numberOfPointsInChart - 1;// int.Parse(comboBoxPointsRemoved.Text);

            // Simulate adding new data points
            int numberOfPointsAddedMin = 5;
            int numberOfPointsAddedMax = 10;
            for (int pointNumber = 0; pointNumber <
               1/*random.Next(numberOfPointsAddedMin, numberOfPointsAddedMax)*/; pointNumber++)
            {
                chart_temp.Series["SeriesTemp"].Points.AddXY(pointIndex + 1, Temp);
                ++pointIndex;
            }
            // Adjust Y & X axis scale
            chart_temp.ResetAutoValues();
            if (chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Maximum < pointIndex)
            {
                chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Maximum = pointIndex;
            }

            // Keep a constant number of points by removing them from the left
            while (chart_temp.Series["SeriesTemp"].Points.Count > numberOfPointsInChart)
            {
                // Remove data points on the left side
                while (chart_temp.Series["SeriesTemp"].Points.Count > numberOfPointsAfterRemoval)
                {
                    chart_temp.Series["SeriesTemp"].Points.RemoveAt(0);
                }

                // Adjust X axis scale
                chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Minimum = pointIndex - numberOfPointsAfterRemoval;
                chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Maximum = chart_temp.ChartAreas["ChartAreaTemp"].AxisX.Minimum + numberOfPointsInChart;
            }

            // Redraw chart
            chart_temp.Invalidate();
 
        }




    }
}
