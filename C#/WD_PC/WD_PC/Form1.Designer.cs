namespace WD_PC
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chart_temp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_port = new System.Windows.Forms.ComboBox();
            this.btn_com = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_br = new System.Windows.Forms.ComboBox();
            this.cmb_data = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_stop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_check = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rb_sendC = new System.Windows.Forms.RadioButton();
            this.rb_send16 = new System.Windows.Forms.RadioButton();
            this.btn_send = new System.Windows.Forms.Button();
            this.txtb_send = new System.Windows.Forms.TextBox();
            this.btn_sendCheck = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_rev = new System.Windows.Forms.TextBox();
            this.btn_clearRcv = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rb_revC = new System.Windows.Forms.RadioButton();
            this.rb_rev16 = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sta_txt = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txt_temp = new System.Windows.Forms.TextBox();
            this.btn_Caiji = new System.Windows.Forms.Button();
            this.lab_sta = new System.Windows.Forms.Label();
            this.btn_cycCaiJi = new System.Windows.Forms.Button();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tmSend = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_temp)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口设置ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.退出ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 串口设置ToolStripMenuItem
            // 
            this.串口设置ToolStripMenuItem.Name = "串口设置ToolStripMenuItem";
            this.串口设置ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.串口设置ToolStripMenuItem.Text = "串口设置";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem2.Text = "___________";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem1});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.关于ToolStripMenuItem1.Text = "关于";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart_temp);
            this.groupBox1.Location = new System.Drawing.Point(280, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 378);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "温度曲线";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chart_temp
            // 
            this.chart_temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chart_temp.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart_temp.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chart_temp.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart_temp.BorderlineWidth = 2;
            chartArea1.BackColor = System.Drawing.Color.OldLace;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.Silver;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartAreaTemp";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart_temp.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_temp.Legends.Add(legend1);
            this.chart_temp.Location = new System.Drawing.Point(14, 20);
            this.chart_temp.Name = "chart_temp";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.ChartArea = "ChartAreaTemp";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "SeriesTemp";
            this.chart_temp.Series.Add(series1);
            this.chart_temp.Size = new System.Drawing.Size(507, 341);
            this.chart_temp.TabIndex = 1;
            this.chart_temp.Text = "chartTemp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "串口号";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmb_port
            // 
            this.cmb_port.FormattingEnabled = true;
            this.cmb_port.Location = new System.Drawing.Point(63, 29);
            this.cmb_port.Name = "cmb_port";
            this.cmb_port.Size = new System.Drawing.Size(67, 20);
            this.cmb_port.TabIndex = 3;
            // 
            // btn_com
            // 
            this.btn_com.Location = new System.Drawing.Point(169, 27);
            this.btn_com.Name = "btn_com";
            this.btn_com.Size = new System.Drawing.Size(75, 23);
            this.btn_com.TabIndex = 4;
            this.btn_com.Text = "打开串口";
            this.btn_com.UseVisualStyleBackColor = true;
            this.btn_com.Click += new System.EventHandler(this.btn_com_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "波特率";
            // 
            // cmb_br
            // 
            this.cmb_br.FormattingEnabled = true;
            this.cmb_br.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cmb_br.Location = new System.Drawing.Point(64, 65);
            this.cmb_br.Name = "cmb_br";
            this.cmb_br.Size = new System.Drawing.Size(67, 20);
            this.cmb_br.TabIndex = 6;
            // 
            // cmb_data
            // 
            this.cmb_data.FormattingEnabled = true;
            this.cmb_data.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmb_data.Location = new System.Drawing.Point(181, 65);
            this.cmb_data.Name = "cmb_data";
            this.cmb_data.Size = new System.Drawing.Size(64, 20);
            this.cmb_data.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "数据位";
            // 
            // cmb_stop
            // 
            this.cmb_stop.FormattingEnabled = true;
            this.cmb_stop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmb_stop.Location = new System.Drawing.Point(63, 91);
            this.cmb_stop.Name = "cmb_stop";
            this.cmb_stop.Size = new System.Drawing.Size(67, 20);
            this.cmb_stop.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "停止位";
            // 
            // cmb_check
            // 
            this.cmb_check.FormattingEnabled = true;
            this.cmb_check.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.cmb_check.Location = new System.Drawing.Point(181, 91);
            this.cmb_check.Name = "cmb_check";
            this.cmb_check.Size = new System.Drawing.Size(64, 20);
            this.cmb_check.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "校验位";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_check);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmb_stop);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmb_data);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmb_br);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_com);
            this.groupBox2.Controls.Add(this.cmb_port);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(17, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 127);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "串口设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.btn_send);
            this.groupBox3.Controls.Add(this.txtb_send);
            this.groupBox3.Location = new System.Drawing.Point(17, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 102);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送操作";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rb_sendC);
            this.groupBox4.Controls.Add(this.rb_send16);
            this.groupBox4.Location = new System.Drawing.Point(15, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(123, 38);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发送方式";
            // 
            // rb_sendC
            // 
            this.rb_sendC.AutoSize = true;
            this.rb_sendC.Location = new System.Drawing.Point(71, 16);
            this.rb_sendC.Name = "rb_sendC";
            this.rb_sendC.Size = new System.Drawing.Size(47, 16);
            this.rb_sendC.TabIndex = 1;
            this.rb_sendC.TabStop = true;
            this.rb_sendC.Text = "字符";
            this.rb_sendC.UseVisualStyleBackColor = true;
            // 
            // rb_send16
            // 
            this.rb_send16.AutoSize = true;
            this.rb_send16.Location = new System.Drawing.Point(6, 16);
            this.rb_send16.Name = "rb_send16";
            this.rb_send16.Size = new System.Drawing.Size(59, 16);
            this.rb_send16.TabIndex = 0;
            this.rb_send16.TabStop = true;
            this.rb_send16.Text = "16进制";
            this.rb_send16.UseVisualStyleBackColor = true;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(168, 29);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txtb_send
            // 
            this.txtb_send.Location = new System.Drawing.Point(21, 67);
            this.txtb_send.Name = "txtb_send";
            this.txtb_send.Size = new System.Drawing.Size(222, 21);
            this.txtb_send.TabIndex = 2;
            this.txtb_send.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_send_KeyPress);
            // 
            // btn_sendCheck
            // 
            this.btn_sendCheck.Location = new System.Drawing.Point(405, 47);
            this.btn_sendCheck.Name = "btn_sendCheck";
            this.btn_sendCheck.Size = new System.Drawing.Size(75, 23);
            this.btn_sendCheck.TabIndex = 5;
            this.btn_sendCheck.Text = "检查连接";
            this.btn_sendCheck.UseVisualStyleBackColor = true;
            this.btn_sendCheck.Click += new System.EventHandler(this.btn_sendCheck_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_rev);
            this.groupBox5.Controls.Add(this.btn_clearRcv);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Location = new System.Drawing.Point(19, 279);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 187);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "接收内容";
            // 
            // txt_rev
            // 
            this.txt_rev.Location = new System.Drawing.Point(13, 65);
            this.txt_rev.Multiline = true;
            this.txt_rev.Name = "txt_rev";
            this.txt_rev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_rev.Size = new System.Drawing.Size(228, 116);
            this.txt_rev.TabIndex = 1;
            // 
            // btn_clearRcv
            // 
            this.btn_clearRcv.Location = new System.Drawing.Point(166, 36);
            this.btn_clearRcv.Name = "btn_clearRcv";
            this.btn_clearRcv.Size = new System.Drawing.Size(75, 23);
            this.btn_clearRcv.TabIndex = 2;
            this.btn_clearRcv.Text = "清空接收";
            this.btn_clearRcv.UseVisualStyleBackColor = true;
            this.btn_clearRcv.Click += new System.EventHandler(this.btn_clearRcv_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rb_revC);
            this.groupBox6.Controls.Add(this.rb_rev16);
            this.groupBox6.Location = new System.Drawing.Point(13, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(139, 39);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "接收方式";
            // 
            // rb_revC
            // 
            this.rb_revC.AutoSize = true;
            this.rb_revC.Location = new System.Drawing.Point(83, 17);
            this.rb_revC.Name = "rb_revC";
            this.rb_revC.Size = new System.Drawing.Size(47, 16);
            this.rb_revC.TabIndex = 1;
            this.rb_revC.TabStop = true;
            this.rb_revC.Text = "字符";
            this.rb_revC.UseVisualStyleBackColor = true;
            // 
            // rb_rev16
            // 
            this.rb_rev16.AutoSize = true;
            this.rb_rev16.Location = new System.Drawing.Point(18, 17);
            this.rb_rev16.Name = "rb_rev16";
            this.rb_rev16.Size = new System.Drawing.Size(59, 16);
            this.rb_rev16.TabIndex = 0;
            this.rb_rev16.TabStop = true;
            this.rb_rev16.Text = "16进制";
            this.rb_rev16.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sta_txt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(831, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sta_txt
            // 
            this.sta_txt.Name = "sta_txt";
            this.sta_txt.Size = new System.Drawing.Size(75, 17);
            this.sta_txt.Text = "                 ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "当前温度";
            // 
            // txt_temp
            // 
            this.txt_temp.Enabled = false;
            this.txt_temp.HideSelection = false;
            this.txt_temp.Location = new System.Drawing.Point(351, 49);
            this.txt_temp.Name = "txt_temp";
            this.txt_temp.Size = new System.Drawing.Size(48, 21);
            this.txt_temp.TabIndex = 18;
            // 
            // btn_Caiji
            // 
            this.btn_Caiji.Location = new System.Drawing.Point(486, 47);
            this.btn_Caiji.Name = "btn_Caiji";
            this.btn_Caiji.Size = new System.Drawing.Size(94, 23);
            this.btn_Caiji.TabIndex = 19;
            this.btn_Caiji.Text = "单次采集温度";
            this.btn_Caiji.UseVisualStyleBackColor = true;
            this.btn_Caiji.Click += new System.EventHandler(this.btn_Caiji_Click);
            // 
            // lab_sta
            // 
            this.lab_sta.AutoSize = true;
            this.lab_sta.Location = new System.Drawing.Point(349, 76);
            this.lab_sta.Name = "lab_sta";
            this.lab_sta.Size = new System.Drawing.Size(29, 12);
            this.lab_sta.TabIndex = 20;
            this.lab_sta.Text = "信息";
            // 
            // btn_cycCaiJi
            // 
            this.btn_cycCaiJi.Location = new System.Drawing.Point(586, 47);
            this.btn_cycCaiJi.Name = "btn_cycCaiJi";
            this.btn_cycCaiJi.Size = new System.Drawing.Size(91, 23);
            this.btn_cycCaiJi.TabIndex = 21;
            this.btn_cycCaiJi.Text = "开始循环采集";
            this.btn_cycCaiJi.UseVisualStyleBackColor = true;
            this.btn_cycCaiJi.Click += new System.EventHandler(this.btn_cycCaiJi_Click);
            // 
            // txt_time
            // 
            this.txt_time.Location = new System.Drawing.Point(683, 49);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(31, 21);
            this.txt_time.TabIndex = 22;
            this.txt_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_time_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(720, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "秒";
            // 
            // tmSend
            // 
            this.tmSend.Interval = 500;
            this.tmSend.Tick += new System.EventHandler(this.tmSend_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 491);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.btn_cycCaiJi);
            this.Controls.Add(this.lab_sta);
            this.Controls.Add(this.btn_sendCheck);
            this.Controls.Add(this.btn_Caiji);
            this.Controls.Add(this.txt_temp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "无线温度采集";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_temp)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_port;
        private System.Windows.Forms.Button btn_com;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_br;
        private System.Windows.Forms.ComboBox cmb_data;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_stop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_check;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txtb_send;
        private System.Windows.Forms.RadioButton rb_sendC;
        private System.Windows.Forms.RadioButton rb_send16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_rev;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rb_revC;
        private System.Windows.Forms.RadioButton rb_rev16;
        private System.Windows.Forms.Button btn_sendCheck;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sta_txt;
        private System.Windows.Forms.Button btn_clearRcv;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_temp;
        private System.Windows.Forms.Button btn_Caiji;
        private System.Windows.Forms.Label lab_sta;
        private System.Windows.Forms.Button btn_cycCaiJi;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer tmSend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_temp;
    }
}

