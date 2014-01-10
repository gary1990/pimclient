using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using ZedGraph;

namespace pimclient
{
    public partial class testForm : Form
    {
        private WebClient client;
        public DataTable producttyes;
        private GraphPane myPane;

        //上传文件线程
        //public Thread uploadFileThread;

        // 用户设置信息
        private string power1;
        private string power2;
        private string freq1;
        private string freq2;
        private string imOrder;
        private string limitLine;
        private string step;
        private string sn;
        private string orderNum;
        private string singleTestTime;
        
        //取得测试信息
        private string imPower;
        private string imPowerUnit;
        private string imPeakPower;
        private string imFreq;
        private string txPower1;
        private string txPower2;

        //扫频模式下最大的一组值
        private double[] sweepMax1;
        private double[] sweepMax2;
        //单品点模式最大值
        private double[] singleMax;

        //扫频模式下所有值
        private List<string[]> sweepList1;
        private List<string[]> sweepList2;

        //两条线
        private PointPairList list;
        private PointPairList list1;
        //两个最大值对应的线
        private PointPairList maxList;
        private PointPairList maxList1;
        //极限线
        private PointPairList limitList;

        public string userName;
        public string passWord;
        public string token;
        public string serverUrl;
        public string controllerUrl;
        private string model;
        private string serialNum;

        //仪器可设定的F1，F2最小，最大值。Power1,power2最大值
        private string freq1Start;
        private string freq1Stop;
        private string freq2Start;
        private string freq2Stop;
        private string p1Max;
        private string p2Max;

        public testForm()
        {
            InitializeComponent();
            client = new WebClient();
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.testForm_KeyDown);
        }

        //重载方法
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //uploadFileThread.Abort();
        }

        //KeyDown事件
        private void testForm_KeyDown(object sender, KeyEventArgs e)
        {
            //F1开始测试
            if (e.KeyCode == Keys.F1)
            {
                this.testButton_Click(sender, e);
            }
            //F2停止测试
            if (e.KeyCode == Keys.F2)
            {
                this.button1_Click(sender, e);
            }
            //F3上传
            if(e.KeyCode == Keys.F3)
            {
                this.uploadButton_Click(sender, e);
            }
        }

        //窗体加载
        private void testForm_Load(object sender, EventArgs e)
        {
            //起一个线程监听zipFile下是否有文件
            //uploadFileThread = new Thread(new ThreadStart(this.ThreadInvokerMethod));
            //uploadFileThread.Start();
            //uploadFileThread.IsBackground = false;

            //imOrderDataTable赋值
            DataTable imOrderDataTable = new DataTable();
            imOrderDataTable.Columns.Add("id");
            imOrderDataTable.Columns.Add("name");
            imOrderDataTable.Rows.Add(3, 3);
            imOrderDataTable.Rows.Add(5, 5);
            imOrderDataTable.Rows.Add(7, 7);
            imOrderDataTable.Rows.Add(9, 9);
            imOrdercomboBox.DisplayMember = "name";
            imOrdercomboBox.ValueMember = "id";
            imOrdercomboBox.DataSource = imOrderDataTable;

            //imPowerDataTable赋值
            DataTable imPowerDataTable = new DataTable();
            imPowerDataTable.Columns.Add("id");
            imPowerDataTable.Columns.Add("name");
            imPowerDataTable.Rows.Add("dBm", "dBm");
            imPowerDataTable.Rows.Add("dBc", "dBc");
            imPowerUnitcomboBox.DisplayMember = "name";
            imPowerUnitcomboBox.ValueMember = "id";
            imPowerUnitcomboBox.DataSource = imPowerDataTable;
            
            //测试员
            operaterValLabel.Text = userName;

            //单频点测试时间输入框
            singleTestTimeTextBox.Enabled = false;

            //读取测试信息（F1,F2,POWER1,POWER2,STEP,LIMIT,SingleTestTime）
            string appStartPath = Application.StartupPath;
            string testConfig = System.IO.Path.Combine(appStartPath, "testConfig.txt");
            if (File.Exists(testConfig))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(testConfig))
                    {
                        String testConfigStr = sr.ReadToEnd();
                        sr.Close();
                        string[] sArray = Regex.Split(testConfigStr, ";");
                        freq1TextBox.Text = sArray[0];
                        freq2TextBox.Text = sArray[1];
                        power1TextBox.Text = sArray[2];
                        power2TextBox.Text = sArray[3];
                        stepTextBox.Text = sArray[4];
                        limiTextBox.Text = sArray[5];
                        singleTestTimeTextBox.Text = sArray[6];
                        imPowerUnitcomboBox.Text = sArray[7];

                        //单位下拉框值改变事件（不直接定义在imPowerUnitcomboBox定义中，避免form_load时触发该事件）
                        this.imPowerUnitcomboBox.TextChanged += new System.EventHandler(imPowerUnitcomboBox_TextChanged);
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("登录信息读取失败：" + e1.ToString());
                }

            }

            //取得仪器相关信息
            try
            {
                model = this.ApiGetAnalyzers();
                System.Xml.XmlDocument modelDoc = new XmlDocument();
                modelDoc.InnerXml = model;
                XmlNodeList modelDocElemList = modelDoc.GetElementsByTagName("Analyzer");
                if (modelDocElemList.Count != 0)
                {
                    for (int i = 0; i < modelDocElemList.Count; i++)
                    {
                        model = modelDocElemList[i].Attributes["Name"].Value;
                    }
                }
                else
                {
                    model = "未连接";
                    messageLabel.Text += "未连接到仪器。";
                    messageLabel.BackColor = Color.Red;
                }
                modelValLabel.Text = model;

                serialNum = this.ApiGetCalInfo();
                System.Xml.XmlDocument calInfoDoc = new XmlDocument();
                calInfoDoc.InnerXml = serialNum;
                XmlNode serialNumNode = calInfoDoc.GetElementsByTagName("String")[1];
                serialNum = serialNumNode.InnerText;
                serialNumValLabel.Text = serialNum;

                string testSetDef = this.ApiGetTestSetDef();
                System.Xml.XmlDocument testSetDefDoc = new XmlDocument();
                testSetDefDoc.InnerXml = testSetDef;
                XmlNode freq1Node = testSetDefDoc.GetElementsByTagName("TX_1")[0];
                XmlNode freq2Node = testSetDefDoc.GetElementsByTagName("TX_2")[0];
                freq1Start = freq1Node["Fstart_MHz"].InnerText;
                freq1Stop = freq1Node["Fstop_MHz"].InnerText;
                p1Max = freq1Node["Pmax_dBm"].InnerText;
                freq2Start = freq2Node["Fstart_MHz"].InnerText;
                freq2Stop = freq2Node["Fstop_MHz"].InnerText;
                p2Max = freq2Node["Pmax_dBm"].InnerText;
            }
            catch (Exception e1)
            {
                messageLabel.Text = "获取仪器相关信息出错：" + e1.ToString();
                messageLabel.BackColor = Color.Red;
            }

            //图像初始化
            myPane = zg1.GraphPane;
            //设置图像Title,X轴，Y轴内容
            myPane.Title.Text = "PIM测试程序";
            myPane.XAxis.Title.Text = "频率MHz";
            
            //背景
            myPane.Fill = new Fill(Color.White, Color.White, 0F);
            // Fill the axis background with a gradient
            //myPane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),Color.FromArgb(255, 255, 190), 90F);
            myPane.Chart.Fill = new Fill(Color.White, Color.White, 0F);

            //工单号获得焦点
            this.ActiveControl = orderNumTextBox;
        }

        //测试按钮点击
        private void testButton_Click(object sender, EventArgs e)
        {
            //测试开始，测试按钮改变内容
            testButton.Text = "测试中...";
            testButton.BackColor = Color.Red;
            resultLabel.Text = "";
            resultLabel.BackColor = SystemColors.Control;
            this.Refresh();

            //取得单位
            imPowerUnit = imPowerUnitcomboBox.Text;
            //图像显示Y轴
            if (imPowerUnit == "dBm")
            {
                myPane.YAxis.Title.Text = "dBm";
            }
            else
            {
                myPane.YAxis.Title.Text = "dBc";
            }
            //清空图像
            zg1.GraphPane.CurveList.Clear();
            zg1.GraphPane.GraphObjList.Clear();
            
            zg1.AxisChange();
            zg1.Refresh();

            power1 = power1TextBox.Text;
            power2 = power2TextBox.Text;
            freq1 = freq1TextBox.Text;
            freq2 = freq2TextBox.Text;
            limitLine = limiTextBox.Text;
            step = stepTextBox.Text;
            imOrder = imOrdercomboBox.Text;

            sn = snTextBox.Text;
            orderNum = orderNumTextBox.Text;
            singleTestTime = singleTestTimeTextBox.Text;
            if (checkPramFormart(power1, power2, freq1, freq2, limitLine, step, sn, orderNum))
            {
                //保存测试信息
                string appStartPath = Application.StartupPath;
                string testConfig = System.IO.Path.Combine(appStartPath, "testConfig.txt");
                try
                {
                    using (TextWriter sr = new StreamWriter(testConfig))
                    {
                        sr.Write(freq1 + ";" + freq2 + ";" + power1 + ";" + power2 + ";" + step + ";" + limitLine + ";" + singleTestTime + ";" + imPowerUnitcomboBox.Text);
                        sr.Close();
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("测试信息保存失败：" + e1.ToString());
                }

                if (this.stepCheckBox.Checked)
                {
                    myPane.YAxis.Scale.Min = -200;
                    myPane.YAxis.Scale.Max = -60;

                    //执行扫频模式
                    GetSweepResult(power1, power2, freq1, freq2, imOrder, step);

                    //画线1中最大值
                    maxList = new PointPairList();
                    maxList.Add(sweepMax1[0], sweepMax1[1]);
                    LineItem myCurve2 = myPane.AddCurve("", maxList, Color.Red, SymbolType.Circle);
                    myCurve2.Line.Width = 1F;
                    //点的填充色
                    myCurve2.Symbol.Fill = new Fill(Color.Red);
                    // 点的大小
                    myCurve2.Symbol.Size = 10;
                    // 抗锯齿效果
                    myCurve2.Line.IsAntiAlias = true;

                    //画线2中最大值
                    maxList1 = new PointPairList();
                    maxList1.Add(sweepMax2[0], sweepMax2[1]);

                    LineItem myCurve3 = myPane.AddCurve("", maxList1, Color.Red, SymbolType.Circle);
                    myCurve3.Line.Width = 1F;
                    //点的填充色
                    myCurve3.Symbol.Fill = new Fill(Color.Red);
                    // 点的大小
                    myCurve3.Symbol.Size = 10;
                    // 抗锯齿效果
                    myCurve3.Line.IsAntiAlias = true;

                    //画极限线
                    LineItem limitLineCurve = myPane.AddCurve("", limitList, Color.Black, SymbolType.None);
                    limitLineCurve.Line.Width = 2F;
                    //点的填充色
                    limitLineCurve.Symbol.Fill = new Fill(Color.Red);
                    // 抗锯齿效果
                    limitLineCurve.Line.IsAntiAlias = true;

                    zg1.AxisChange();

                    // 判断测试结果
                    double limit = double.Parse(limitLine);
                    if (sweepMax2[1] <= limit && sweepMax1[1] <= limit)
                    {
                        myPane.GraphObjList.Add(this.getPassOrFailTextObj("PASS"));
                    }
                    else
                    {
                        myPane.GraphObjList.Add(this.getPassOrFailTextObj("FAIL"));
                    }
                    zg1.AxisChange();

                    this.zg1.Refresh();

                    //保存测试数据及图片
                    saveCsvAndImage("sweep");
                }
                else
                {
                    //执行单频点模式
                    this.GetSingleResult(power1, power2, freq1, freq2, imOrder);

                    //清空图像
                    zg1.GraphPane.CurveList.Clear();
                    zg1.GraphPane.GraphObjList.Clear();

                    zg1.AxisChange();
                    zg1.Refresh();

                    //单频点画测试时间内最大的值
                    myPane.YAxis.Scale.Min = -200;
                    myPane.YAxis.Scale.Max = -60;

                    maxList = new PointPairList();
                    maxList.Add(singleMax[0], singleMax[1]);
                    maxList.Add(singleMax[0], -200);
                    LineItem myCurve = myPane.AddCurve("", maxList, Color.Red, SymbolType.None);
                    myCurve.Line.Width = 3F;
                    zg1.AxisChange();

                    if (singleMax[1] > double.Parse(limitLine))
                    {
                        myPane.GraphObjList.Add(this.getPassOrFailTextObj("FAIL"));
                    }
                    else
                    {
                        myPane.GraphObjList.Add(this.getPassOrFailTextObj("PASS"));
                    }
                    zg1.AxisChange();
                    zg1.Invalidate();

                    if (imPowerUnit == "dBm")
                    {
                        imPowerValLabel.Text = String.Format("{0:0.00}", singleMax[1]) + "dBm";
                    }
                    else
                    {
                        imPowerValLabel.Text = String.Format("{0:0.00}", singleMax[1]) + "dBc";
                    }


                    //保存测试数据及图片
                    saveCsvAndImage("single");
                }
            }
            else
            {
                //do nothing
            }

            //测试完成，测试按钮改变内容
            testButton.Text = "测试(F1)";
            testButton.BackColor = SystemColors.Control;
            this.Refresh();
        }

        //生成图片上的PASS或FAIL框
        private TextObj getPassOrFailTextObj(string resultPram)
        {
            //测试结果框
            resultLabel.Text = resultPram;
            TextObj resultTextObj;
            if (resultPram == "PASS")
            {
                resultLabel.BackColor = Color.Green;
                //图片上显示结果
                resultTextObj = new TextObj("PASS", myPane.XAxis.Scale.Max, myPane.YAxis.Scale.Max);
                resultTextObj.FontSpec.Fill = new Fill(Color.Green, Color.Green, 0F);
            }
            else
            {
                resultLabel.BackColor = Color.Red;
                //图片上显示结果
                resultTextObj = new TextObj("FAIL", myPane.XAxis.Scale.Max, myPane.YAxis.Scale.Max);
                resultTextObj.FontSpec.Fill = new Fill(Color.Red, Color.Red, 0F);
            }
            // Align the text such that the Bottom-Center is at (175, 80) in user scale coordinates
            resultTextObj.Location.AlignH = AlignH.Right;
            resultTextObj.Location.AlignV = AlignV.Top;
            resultTextObj.FontSpec.StringAlignment = StringAlignment.Center;
            //字体颜色
            resultTextObj.FontSpec.FontColor = Color.White;
            resultTextObj.FontSpec.IsBold = true;
            resultTextObj.FontSpec.Size = 25;

            return resultTextObj;
        }

        //保存csv和图片
        private void saveCsvAndImage(string pram)
        {
            // 取得系统时间
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string currentDay = currentTime.ToString("yyyyMMdd");
            string currentTimeFormart = currentTime.ToString("yyyyMMddHHmmss");
            string currentTimeFormartCsv = currentTime.ToString("yyyyMMdd HHmmss");
            //产品SN
            string currentSn = sn;
            //工单号
            string currentOrderNum = orderNum;

            string appStartPath = Application.StartupPath;
            string resultDataPath = System.IO.Path.Combine(appStartPath, "resultData");
            string testDataPath = System.IO.Path.Combine(resultDataPath, "testData");
            string zipFilePath = System.IO.Path.Combine(resultDataPath, "zipFile");
            string errorZipPath = System.IO.Path.Combine(resultDataPath, "errorZip");

            //判断数据根文件夹是否存在并创建resultData
            if (!Directory.Exists(resultDataPath))
            {
                try
                {
                    Directory.CreateDirectory(resultDataPath);
                }
                catch (Exception e)
                {
                    messageLabel.Text += "创建数据根目录resultData失败：" + e.ToString();
                    messageLabel.BackColor = Color.Red;
                    return;
                }
            }
            //判断数据文件夹是否存在并创建testData
            if (!Directory.Exists(testDataPath))
            {
                try
                {
                    Directory.CreateDirectory(testDataPath);
                }
                catch (Exception e)
                {
                    messageLabel.Text += "创建数据目录testData失败：" + e.ToString();
                    messageLabel.BackColor = Color.Red;
                    return;
                }

            }
            //判断数据文件夹是否存在并创建zipFile
            if (!Directory.Exists(zipFilePath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(zipFilePath);
                }
                catch (Exception e)
                {
                    messageLabel.Text += "创建数据目录zipFile失败：" + e.ToString();
                    messageLabel.BackColor = Color.Red;
                    return;
                }

            }
            //判断压缩出错是否存在并创建errorZip
            if (!Directory.Exists(errorZipPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(errorZipPath);
                }
                catch (Exception e)
                {
                    messageLabel.Text += "创建压缩出错目录errorZip失败：" + e.ToString();
                    messageLabel.BackColor = Color.Red;
                    return;
                }

            }

            //创建当天日期文件夹
            string currentDayPath = System.IO.Path.Combine(testDataPath, currentDay);
            if (!Directory.Exists(currentDayPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(currentDayPath);
                }
                catch (Exception e)
                {
                    messageLabel.Text += "创建今天测试目录errorZip失败：" + e.ToString();
                    messageLabel.BackColor = Color.Red;
                    return;
                }
            }

            //当前sn，工单号文件夹
            string currentSnOrdernumPath = System.IO.Path.Combine(currentDayPath, currentSn + "_" + currentOrderNum);
            if (!Directory.Exists(currentSnOrdernumPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(currentSnOrdernumPath);
                }
                catch (Exception e)
                {
                    messageLabel.Text += "创建当前产品测试数据目录失败：" + e.ToString();
                    messageLabel.BackColor = Color.Red;
                    return;
                }
            }

            //csv文件中要写入的内容
            string space = " ";
            string newLine = "\r\n";
            string freq1Result = "f1" + space + freq1 + space + "MHz,";
            string freq1StartResult = "START" + space + freq1Start + space + "MHz,";
            string freq1StopResult = "STOP" + space + freq1Stop + space + "MHz,";
            string power1Result = "POWER" + space + power1 + space + "dBm,";
            string freq2Result = "f2" + space + freq2 + space + "MHz,";
            string freq2StartResult = "START" + space + freq2Start + space + "MHz,";
            string freq2StopResult = "STOP" + space + freq2Stop + space + "MHz,";
            string power2Result = "POWER" + space + power2 + space + "dBm,";
            string serialNumResult = serialNum + ",";
            //string serialNumResult = "testSerialNum,";
            string imOrderResult = "ORDER" + space + "IM" + imOrder + ",";
            string singelOrSweepResult = "";
            if (pram == "sweep")
            {
                singelOrSweepResult = "SWEEP,";
            }
            else
            {
                singelOrSweepResult = "SINGLE,";
            }
            string modelResult = "Model" + space + "Nr." + space + model + ",";
            string testTimeResult = currentTimeFormartCsv + ",";
            string limitLineResult = "Limit Line:" + space + limitLine + ",";
            string snResult = "Ser No:" + space + sn + ",";
            string operaterResult = "user ID:" + space + userName + ",";

            string result = freq1Result + freq1StartResult + freq1StopResult + power1Result + freq2Result + freq2StartResult + freq2StopResult + power2Result + serialNumResult + imOrderResult + singelOrSweepResult + modelResult + testTimeResult + limitLineResult + snResult + operaterResult;

            if (pram == "sweep")
            {
                foreach (string[] sweepPer in sweepList1)
                {
                    string imFreqPowerResult = "\"" + sweepPer[0] + ";" + sweepPer[1] + newLine + "\",";
                    result += imFreqPowerResult;
                }
                foreach (string[] sweepPer in sweepList2)
                {
                    string imFreqPowerResult = "\"" + sweepPer[0] + ";" + sweepPer[1] + newLine + "\",";
                    result += imFreqPowerResult;
                }
            }
            else
            {
                string imFreqPowerResult = "\"" + String.Format("{0:0.00}", singleMax[0]) + ";" + String.Format("{0:0.00}", singleMax[1]) + newLine + "\",";
                result += imFreqPowerResult;
            }

            result = result.Substring(0, result.Length - 1) + newLine;

            //当前产品的csv文件
            string currentProductCsv = System.IO.Path.Combine(currentSnOrdernumPath, sn + ".csv");

            TextWriter tw = new StreamWriter(currentProductCsv, true);
            tw.Write(result);
            tw.Close();

            // 保存图片
            myPane.GetImage().Save(Path.Combine(currentSnOrdernumPath, currentSn + "_" + currentTimeFormart + ".jpg"));
            //Application.StartupPath;
        }

        //输入内容校验
        private bool checkPramFormart(string power1, string power2, string freq1, string freq2, string limitLine, string step, string sn, string orderNum)
        {
            bool result = true;
            string errorMessage = "";
            Regex floatReg = new Regex(@"^[-+]?[0-9]+(?:\.[0-9]*)?$");
            Regex notNullReg = new Regex(@"^(?!\s*$).+");
            if (floatReg.IsMatch(power1) && notNullReg.IsMatch(power1))
            {
                if(float.Parse(power1) > float.Parse(p1Max))
                {
                    result = false;
                    errorMessage += "发射功率1超出范围。";
                }
            }
            else
            {
                result = false;
                errorMessage += "发射功率1填写不正确。";
            }

            if (floatReg.IsMatch(power2) && notNullReg.IsMatch(power2))
            {
                if (float.Parse(power2) > float.Parse(p2Max))
                {
                    result = false;
                    errorMessage += "发射功率2超出范围。";
                }
            }
            else
            {
                result = false;
                errorMessage += "发射功率2填写不正确。";
            }

            if (floatReg.IsMatch(freq1) && notNullReg.IsMatch(freq1))
            {
                float freq1Float = float.Parse(freq1);
                float freq1StartFloat =  float.Parse(freq1Start);
                float freq1StopFloat =  float.Parse(freq1Stop);
                if (freq1Float < freq1StartFloat || freq1Float > freq1StopFloat)
                {
                    result = false;
                    errorMessage += "F1超出范围。";
                }
            }
            else
            {
                result = false;
                errorMessage += "F1填写不正确。";
            }

            if (floatReg.IsMatch(freq2) && notNullReg.IsMatch(freq2))
            {
                float freq2Float = float.Parse(freq2);
                float freq2StartFloat = float.Parse(freq2Start);
                float freq2StopFloat = float.Parse(freq2Stop);
                if (freq2Float < freq2StartFloat || freq2Float > freq2StopFloat)
                {
                    result = false;
                    errorMessage += "F2超出范围。";
                }
            }
            else
            {
                result = false;
                errorMessage += "F2填写不正确。";
            }

            if (floatReg.IsMatch(limitLine) && notNullReg.IsMatch(limitLine))
            {

            }
            else
            {
                result = false;
                errorMessage += "极限值填写不正确。";
            }

            if (stepCheckBox.Checked)
            {
                if (floatReg.IsMatch(step) && notNullReg.IsMatch(step))
                {

                }
                else
                {
                    result = false;
                    errorMessage += "步径填写不正确。";
                }
            }
            else
            {
                step = "0";
            }

            if (notNullReg.IsMatch(sn))
            {

            }
            else
            {
                result = false;
                errorMessage += "sn填写不正确。";
            }

            if (notNullReg.IsMatch(orderNum))
            {

            }
            else
            {
                result = false;
                errorMessage += "Order Num填写不正确。";
            }

            if (stepCheckBox.Checked)
            {
                //扫频模式，不校验测试时间
            }
            else 
            {
                if (notNullReg.IsMatch(singleTestTime) && floatReg.IsMatch(singleTestTime))
                {

                }
                else 
                {
                    result = false;
                    errorMessage += "Setting Time 填写不正确。";
                }
            }

            messageLabel.Text = errorMessage;
            messageLabel.BackColor = Color.Red;
            return result;
        }

        //单频点模式下取值
        private void GetSingleResult(string power1, string power2, string freq1, string freq2, string imorder)
        {
            DateTime startTime = System.DateTime.Now;
            DateTime stopTime = startTime;
            //单品点模式最大值
            double timeLimit = double.Parse(singleTestTime);
            singleMax = new double[2] { 0, -1000 };

            while((stopTime-startTime).TotalSeconds < timeLimit)
            {
                try
                {
                    this.ApiSetPreset();
                    if (alcRadioButton1.Checked)
                    {
                        this.ApiSetAlc("TRUE");
                    }
                    else
                    {
                        this.ApiSetAlc("FALSE");
                    }
                    this.ApiSetSingleIm();
                    this.ApiSetImOrder(imorder);
                    this.ApiSetTxFreqs(freq1, freq2);
                    this.ApiSetTxPower(power1, power2);
                    this.ApiSetTxOn();
                    this.ApiSetTrigger();

                    //取得imPower,imFreqs,imPeakPower
                    if (imPowerUnit == "dBm")
                    {
                        imPower = this.ApiGetImPower();
                    }
                    else
                    {
                        imPower = this.ApiGetImPowerDbc();
                    }
                    imFreq = this.ApiGetImFreqs();
                    imPeakPower = this.ApiGetImPeakPower();

                    //取得TxPower
                    string txPower = this.ApiGetTxPower();
                    System.Xml.XmlDocument txPowertDoc = new XmlDocument();
                    txPowertDoc.InnerXml = txPower;
                    XmlNode txPower1Node = txPowertDoc.GetElementsByTagName("Double")[0];
                    XmlNode txPower2Node = txPowertDoc.GetElementsByTagName("Double")[1];
                    txPower1 = txPower1Node.InnerText;
                    txPower2 = txPower2Node.InnerText;

                    System.Xml.XmlDocument imPowertDoc = new XmlDocument();
                    System.Xml.XmlDocument imFreqDoc = new XmlDocument();
                    System.Xml.XmlDocument imPeakPowertDoc = new XmlDocument();

                    imPowertDoc.InnerXml = imPower;
                    imPower = imPowertDoc.LastChild.InnerText;

                    imFreqDoc.InnerXml = imFreq;
                    imFreq = imFreqDoc.LastChild.InnerText;

                    imPeakPowertDoc.InnerXml = imPeakPower;
                    imPeakPower = imPeakPowertDoc.LastChild.InnerText;

                    //将imFreq,imPower赋值给list，画图使用
                    list = new PointPairList();
                    double testFreq = double.Parse(imFreq.ToString());
                    double testImPower = double.Parse(imPower.ToString());
                    //添加两个点，单频点画柱状线
                    list.Add(testFreq, testImPower);
                    list.Add(testFreq, -200);

                    //取得测试值中最大值
                    if (testImPower > singleMax[1])
                    {
                        singleMax[0] = testFreq;
                        singleMax[1] = testImPower;
                    }
                }
                catch (Exception e)
                {
                    this.messageLabel.Text = e.Message.ToString();
                    //停止功率输出
                    try
                    {
                        this.ApiSetTxOff();
                    }
                    catch (Exception e1)
                    {
                        messageLabel.Text = "无法停止输出功率" + e1.Message;
                        messageLabel.BackColor = Color.Red;
                    }
                }
                stopTime = System.DateTime.Now;

                //清空图像
                zg1.GraphPane.CurveList.Clear();
                zg1.GraphPane.GraphObjList.Clear();

                zg1.AxisChange();
                zg1.Refresh();

                myPane.YAxis.Scale.Min = -200;
                myPane.YAxis.Scale.Max = -60;

                //显示txPower,imFreq,imPower
                this.MeasuredPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(txPower1)) + "dBm," + String.Format("{0:0.00}", double.Parse(txPower2)) + "dBm";
                imFreqValLabel.Text = String.Format("{0:0.00}", double.Parse(imFreq)) + "MHz";
                if (imPowerUnit == "dBm")
                {
                    imPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(imPower)) + "dBm";
                }
                else
                {
                    imPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(imPower)) + "dBc";
                }
                this.Refresh();
                //画当前测试点
                sweepDrawPerPoint(list, Color.Red, SymbolType.None, 3F, Color.Red);

                //然后再画pass或fail的框（可以取到当前图片X坐标的最大值）
                if (double.Parse(imPower) > double.Parse(limitLine))
                {
                    myPane.GraphObjList.Add(this.getPassOrFailTextObj("FAIL"));
                }
                else
                {
                    myPane.GraphObjList.Add(this.getPassOrFailTextObj("PASS"));
                }
                
                zg1.AxisChange();
                this.zg1.Refresh();
            }
            //停止功率输出
            try 
            { 
                this.ApiSetTxOff();
            }
            catch(Exception e)
            {
                messageLabel.Text = "无法停止输出功率"+e.Message;
                messageLabel.BackColor = Color.Red;
            }
        }

        //扫频模式下取值
        private void GetSweepResult(string power1, string power2, string freq1, string freq2, string imorder, string step)
        {
            double sweepPower1 = double.Parse(power1);
            double sweepPower2 = double.Parse(power2);
            double sweepfreqStart = double.Parse(freq1);
            double sweepfreqStop = double.Parse(freq2);
            double sweepStep = double.Parse(step);
            //取得机器设定的freq1,freq2的最大最小值
            double freq1StopLimit = double.Parse(freq1Stop);
            double freq2StartLimit = double.Parse(freq2Start);

            //sweepfreqStop(大)sweepFreq1扫描至sweepfreqStart(小)sweepFreq2
            double sweepFreq1 = sweepfreqStop;
            double sweepFreq2 = sweepfreqStart;
            list = new PointPairList();
            limitList = new PointPairList();

            // 扫频模式下两组最大值
            sweepMax1 = new double[2] { 0, -1000 };
            sweepMax2 = new double[2] { 0, -1000 };

            //扫频保存两组数的LIST
            sweepList1 = new List<string[]>();
            sweepList2 = new List<string[]>();


            while (sweepFreq1 >= freq2StartLimit)
            {
                this.getSweepPerPoint(power1, power2, sweepFreq2.ToString(), sweepFreq1.ToString(), imorder);

                //取得测试频率和对应值,添加到list，供画图试用
                double testFreq = double.Parse(imFreq.ToString());
                double testImPower = double.Parse(imPower.ToString());
                list.Add(testFreq, testImPower);

                //将值添加到sweepList1
                string[] sweepPerResult = new string[] { String.Format("{0:0.00}", testFreq), String.Format("{0:0.00}", testImPower) };
                sweepList1.Add(sweepPerResult);

                //极限线
                limitList.Add(testFreq, double.Parse(limitLine));

                //取得测试值中最大值
                if (testImPower > sweepMax1[1])
                {
                    sweepMax1[0] = testFreq;
                    sweepMax1[1] = testImPower;
                }
                
                sweepFreq1 = sweepFreq1 - sweepStep;
                
                //显示txPower,imFreq,imPower
                this.MeasuredPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(txPower1)) + "dBm," + String.Format("{0:0.00}", double.Parse(txPower2)) + "dBm";
                imFreqValLabel.Text = String.Format("{0:0.00}", double.Parse(imFreq)) + "MHz";
                if(imPowerUnit == "dBm")
                {
                    imPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(imPower)) + "dBm";
                }
                else
                {
                    imPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(imPower)) + "dBc";
                }
                this.Refresh();

                //刷新图片
                sweepDrawPerPoint(list, Color.Teal, SymbolType.None, 2F, Color.Red);
            }

            ////sweepfreqStart(小)sweepFreq2扫描至sweepfreqStop(大)sweepFreq1
            sweepFreq1 = sweepfreqStart;
            sweepFreq2 = sweepfreqStop;
            list1 = new PointPairList();

            while (sweepFreq1 <= freq1StopLimit)
            {
                this.getSweepPerPoint(power1, power2, sweepFreq1.ToString(), sweepFreq2.ToString(), imorder);
                
                //取得测试频率和对应值,添加到list，供画图试用
                double testFreq = double.Parse(imFreq.ToString());
                double testImPower = double.Parse(imPower.ToString());
                list1.Add(testFreq, testImPower);
                //将值添加到sweepList1
                string[] sweepPerResult = new string[] { String.Format("{0:0.00}", testFreq), String.Format("{0:0.00}", testImPower) };
                sweepList1.Add(sweepPerResult);

                //取得测试值中最大值
                if (testImPower > sweepMax2[1])
                {
                    sweepMax2[0] = testFreq;
                    sweepMax2[1] = testImPower;
                }

                sweepFreq1 = sweepFreq1 + sweepStep;

                //显示txPower,imFreq,imPower
                this.MeasuredPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(txPower1)) + "dBm," + String.Format("{0:0.00}", double.Parse(txPower2)) + "dBm";
                imFreqValLabel.Text = String.Format("{0:0.00}", double.Parse(imFreq)) + "MHz";
                if (imPowerUnit == "dBm")
                {
                    imPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(imPower)) + "dBm";
                }
                else
                {
                    imPowerValLabel.Text = String.Format("{0:0.00}", double.Parse(imPower)) + "dBc";
                }
                this.Refresh();

                //刷新图片
                sweepDrawPerPoint(list1, Color.Blue, SymbolType.None, 2F, Color.Blue);
            }


            //停止功率输出
            try
            {
                this.ApiSetTxOff();
            }
            catch (Exception e)
            {
                messageLabel.Text = "无法停止输出功率" + e.Message;
                messageLabel.BackColor = Color.Red;
            }
        }

        //单频，扫频模式画每个点
        private void sweepDrawPerPoint(PointPairList list, Color lineColor, SymbolType lineType, float lineWidth, Color pointColor)
        {
            LineItem myCurve1 = myPane.AddCurve("", list, lineColor, lineType);
            myCurve1.Line.Width = lineWidth;
            //点的填充色
            myCurve1.Symbol.Fill = new Fill(pointColor);
            //myCurve1.Symbol.Size = 2F;
            myCurve1.Line.IsAntiAlias = true;
            this.zg1.AxisChange();
            this.zg1.Refresh();
        }

        //取得每个点的测试值
        private void getSweepPerPoint(string power1, string power2, string freq1, string freq2, string imorder)
        {
            try
            {
                //this.ApiSetPreset();
                if (alcRadioButton1.Checked)
                {
                    this.ApiSetAlc("TRUE");
                }
                else
                {
                    this.ApiSetAlc("FALSE");
                }
                this.ApiSetSingleIm();
                this.ApiSetImOrder(imorder);
                this.ApiSetTxFreqs(freq1, freq2);
                this.ApiSetTxPower(power1, power2);
                this.ApiSetTxOn();
                this.ApiSetTrigger();
                //取得TxPower
                string txPower = this.ApiGetTxPower();
                System.Xml.XmlDocument txPowertDoc = new XmlDocument();
                txPowertDoc.InnerXml = txPower;
                XmlNode txPower1Node = txPowertDoc.GetElementsByTagName("Double")[0];
                XmlNode txPower2Node = txPowertDoc.GetElementsByTagName("Double")[1];
                txPower1 = txPower1Node.InnerText;
                txPower2 = txPower2Node.InnerText;

                //取得imPower,imFreqs,imPeakPower
                //imPower = this.ApiGetImPower();
                if(imPowerUnit == "dBm")
                {
                    imPower = this.ApiGetImPower();
                }
                else
                {
                    imPower = this.ApiGetImPowerDbc();
                }
                imFreq = this.ApiGetImFreqs();
                imPeakPower = this.ApiGetImPeakPower();

                System.Xml.XmlDocument imPowertDoc = new XmlDocument();
                System.Xml.XmlDocument imFreqDoc = new XmlDocument();
                System.Xml.XmlDocument imPeakPowertDoc = new XmlDocument();

                imPowertDoc.InnerXml = imPower;
                imPower = imPowertDoc.LastChild.InnerText;

                imFreqDoc.InnerXml = imFreq;
                imFreq = imFreqDoc.LastChild.InnerText;

                imPeakPowertDoc.InnerXml = imPeakPower;
                imPeakPower = imPeakPowertDoc.LastChild.InnerText;
            }
            catch (Exception e)
            {
                this.messageLabel.Text = e.Message.ToString();
                //this.ApiSetTxOff();
            }
        }

        //Uri Formart
        private Uri ApiCommand(string command)
        {
            try
            {
                return new Uri("http://" + controllerUrl + "/api/" + token + "/" + command);
            }
            catch (UriFormatException e)
            {
                return null;
            }
        }
        //重新初始化
        private void ApiSetPreset()
        {
            var apiSetPresetResponse = client.DownloadString(ApiCommand("setPreset"));
        }


        private string ApiGetAnalyzers()
        {
            return client.DownloadString(ApiCommand("GetAnalyzers"));
        }

        private string ApiGetCalInfo()
        {
            return client.DownloadString(ApiCommand("GetCalInfo"));
        }

        private string ApiGetTestSetDef()
        {
            return client.DownloadString(ApiCommand("GetTestSetDef"));
        }

        private string ApiSetAlc(string pram)
        {
            return client.DownloadString(ApiCommand("SetAlc?Boolean=" + pram));
        }

        private void ApiSetTxFreqs(string double1, string double2)
        {
            var apisetTxFreqsResponse = client.DownloadString(ApiCommand("SetTxFreqs?Double=" + double1 + "&Double=" + double2));
        }

        private void ApiSetModeSweepTx(string double1, string double2, string double3)
        {
            var apiSetModeSweepTxResponse = client.DownloadString(ApiCommand("setModeSweepTx?Boolean=True&Double=" + double1 + "&Double=" + double2 + "&Dlouble=" + double3));
        }

        private void ApiSetTxPower(string double1, string double2)
        {
            var apiSetTxPowerResponse = client.DownloadString(ApiCommand("SetTxPower?Double=" + double1 + "&Double=" + double2));
        }


        private string ApiSetTrigger()
        {
            return client.DownloadString(ApiCommand("setTrigger"));
        }

        private string ApiGetSamples()
        {
            return client.DownloadString(ApiCommand("getSamples"));
        }

        private string ApiGetError()
        {
            return client.DownloadString(ApiCommand("GetError"));
        }

        private string ApiGetTxFreqs()
        {
            return client.DownloadString(ApiCommand("GetTxFreqs"));
        }

        private string ApiGetTxPower()
        {
            return client.DownloadString(ApiCommand("GetTxPower"));
        }

        private void ApiSetTxOn()
        {
            var apisetTxOnResponse = client.DownloadString(ApiCommand("SetTxOn?Boolean=TRUE&Boolean=TRUE"));
        }

        private string ApiGetTxOn()
        {
            return client.DownloadString(ApiCommand("GetTxOn"));
        }

        private string ApiSetTxOff()
        {
            return client.DownloadString(ApiCommand("SetTxOn?Boolean=FALSE&Boolean=FALSE"));
        }

        //设置阶数
        private string ApiSetImOrder(string orderPram)
        {
            return client.DownloadString(ApiCommand("SetImOrder?Integer=" + orderPram));
        }

        private string ApiGetImOrder()
        {
            return client.DownloadString(ApiCommand("GetImOrder"));
        }

        //设置阶数为单个
        private void ApiSetSingleIm()
        {
            client.DownloadString(ApiCommand("SetSingleIm?Boolean=TRUE"));
        }

        //取得实测值1:Magnitude unit(dBm)
        private string ApiGetImPower()
        {
            return client.DownloadString(ApiCommand("GetImPower"));
        }

        //取得实测值1:Magnitude unit(dBc)
        private string ApiGetImPowerDbc()
        {
            return client.DownloadString(ApiCommand("GetImPowerDbc"));
        }

        //取得实测值2:peak
        private string ApiGetImPeakPower()
        {
            return client.DownloadString(ApiCommand("GetImPeakPower"));
        }
        //取得实测值3:Frequency
        private string ApiGetImFreqs()
        {
            return client.DownloadString(ApiCommand("GetImFreqs"));
        }

        private void ApiDisconnect()
        {
            client.DownloadString(ApiCommand("setExit"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ApiSetTxOff();
        }

        //stepCheckBox改变事件
        private void stepCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.stepCheckBox.Checked)
            {
                stepTextBox.Enabled = true;
                singleTestTimeTextBox.Enabled = false;
            }
            else
            {
                singleTestTimeTextBox.Enabled = true;
                stepTextBox.Enabled = false;
            }
        }

        //上传按钮点击
        private void uploadButton_Click(object sender, EventArgs e)
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string currentDay = currentTime.ToString("yyyyMMdd");

            string appStartPath = Application.StartupPath;
            string resultDataPath = System.IO.Path.Combine(appStartPath, "resultData");
            //三个文件夹testData,zipFile,errorZip
            string testDataPath = System.IO.Path.Combine(resultDataPath, "testData");
            string zipFilePath = System.IO.Path.Combine(resultDataPath, "zipFile");
            string errorZipPath = System.IO.Path.Combine(resultDataPath, "errorZip");
            string currentDayPath = System.IO.Path.Combine(testDataPath, currentDay);

            //上传文件服务器地址
            string uploadServerUrl = serverUrl;
            string currentSn = sn;
            string currentOrderNum = orderNum;
            string operaterId = userName;
            string operaterPassWord = passWord;
            //清空产品序列号输入框
            snTextBox.Text = "";
            //this.ActiveControl = orderNumTextBox;
            this.ActiveControl = snTextBox;

            //当前测试产品的文件夹
            string currentSnOrdernumPath = System.IO.Path.Combine(currentDayPath, currentSn + "_" + currentOrderNum);
            //压缩目标文件
            string zipFileNamePath = System.IO.Path.Combine(zipFilePath, currentOrderNum + "_" + currentSn + ".zip");

            if (!Directory.Exists(currentSnOrdernumPath))
            {
                messageLabel.Text += "未找到测试数据。";
                messageLabel.BackColor = Color.Red;
                return;
            }
            else
            {

                Process process = new Process();

                if (System.IO.File.Exists(@"C:\Program Files\WinRAR\Winrar.exe"))
                {
                    process.StartInfo.FileName = @"C:\Program Files\WinRAR\Winrar.exe";
                }
                else if (System.IO.File.Exists(@"C:\Program Files (x86)\WinRAR\Winrar.exe"))
                {
                    process.StartInfo.FileName = @"C:\Program Files (x86)\WinRAR\Winrar.exe";
                }
                else
                {
                    messageLabel.Text += @"计算机上找不到Winrar压缩程序，请确认！";
                    messageLabel.BackColor = Color.Red;
                    return;
                }

                process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                process.StartInfo.WorkingDirectory = currentSnOrdernumPath;
                process.StartInfo.Arguments = "a -as -r " + zipFileNamePath + " * ";
                
                try 
                {
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                    process.Dispose();
                    messageLabel.Text = currentOrderNum + "_" + currentSn + ".zip压缩成功，等待后台上传。";
                    messageLabel.BackColor = Color.Green;
                }
                catch(Exception e1)
                {
                    messageLabel.Text += "压缩文件失败。"+e1.ToString();
                    messageLabel.BackColor = Color.Red;
                }
                string serverUploadUrl = "http://" + serverUrl + "index.php/login/uploadPimFile";
                try
                {
                    string s = this.UploadFilesToRemoteUrl(serverUploadUrl, zipFileNamePath);
                }
                catch(Exception e1)
                {
                    //MessageBox.Show(e1.ToString());
                }
                
            }
        }

        //上传文件方法
        public string UploadFilesToRemoteUrl(string url, string files)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("username", userName);
            nvc.Add("password", passWord);

            string boundary = "----------------------------" +
            DateTime.Now.Ticks.ToString("x");

            HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest2.ContentType = "multipart/form-data; boundary=" +
            boundary;
            httpWebRequest2.Method = "POST";
            httpWebRequest2.KeepAlive = true;
            httpWebRequest2.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream memStream = new System.IO.MemoryStream();

            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");


            string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";


            foreach (string key in nvc.Keys)
            {
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }

            memStream.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/" + files + "\r\n\r\n";

            string header = string.Format(headerTemplate, "file", files);

            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

            memStream.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(files, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024];

            int bytesRead = 0;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);
            }

            memStream.Write(boundarybytes, 0, boundarybytes.Length);

            fileStream.Close();

            httpWebRequest2.ContentLength = memStream.Length;

            Stream requestStream = httpWebRequest2.GetRequestStream();

            memStream.Position = 0;
            byte[] tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();

            WebResponse webResponse2 = httpWebRequest2.GetResponse();

            Stream stream2 = webResponse2.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);

            //获得返回结果
            string result = reader2.ReadToEnd();

            webResponse2.Close();
            httpWebRequest2 = null;
            webResponse2 = null;

            return result;
        }


        //可以使用跨线程调用控件
        //private void ThreadInvokerMethod()
        //{
        //    MethodInvoker mi = new MethodInvoker(uploadFile);
        //    BeginInvoke(mi);
        //}

        //由线程监听上传文件
        private void uploadFile()
        {
            string appStartPath = Application.StartupPath;
            string resultDataPath = System.IO.Path.Combine(appStartPath, "resultData");
            //三个文件夹testData,zipFile,errorZip
            string zipFilePath = System.IO.Path.Combine(resultDataPath, "zipFile");
            string errorZipPath = System.IO.Path.Combine(resultDataPath, "errorZip");

            //上传文件接口
            string serverUploadUrl = "http://" + serverUrl + "/index.php/login/uploadPimFile";

            if (Directory.Exists(resultDataPath))
            {
                string[] zipFiles = Directory.GetFiles(zipFilePath);

                if (zipFilePath.Count() != 0)
                {
                    foreach (string file in zipFiles)
                    {
                        string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                        string remoteUrl = System.IO.Path.Combine(errorZipPath, fileName);
                        try
                        {
                            string uploadResult = this.UploadFilesToRemoteUrl(serverUploadUrl, file);
                            System.Xml.XmlDocument uploadResultDoc = new XmlDocument();
                            uploadResultDoc.InnerXml = uploadResult;
                            XmlNodeList infoNodeList = uploadResultDoc.GetElementsByTagName("info");
                            uploadResult = infoNodeList[0].InnerText;
                            if (uploadResult == "success")
                            {
                                messageLabel.Text = "文件：" + file + "上传成功。";
                                messageLabel.BackColor = Color.Green;
                            }
                            else
                            {
                                messageLabel.Text = "文件：" + file + "上传失败:" + uploadResult;
                                messageLabel.BackColor = Color.Red;
                                File.Copy(file, remoteUrl,true);
                            }
                        }
                        catch (Exception e)
                        {
                            messageLabel.Text = "文件：" + file + "上传失败:与服务器通信失败。";
                            messageLabel.BackColor = Color.Red;
                            File.Copy(file, remoteUrl,true);
                        }

                        File.Delete(file);
                    }
                }

            }

           
        }

        //定时器定时上传
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //this.timer1.Stop();
            this.uploadFile();
            //this.timer1.Start();
        }

        private void imPowerUnitcomboBox_TextChanged(object sender, System.EventArgs e) 
        {
            string selectedUnit = imPowerUnitcomboBox.Text;
            if (selectedUnit == "dBc")
            {
                limiTextBox.Text = (float.Parse(limiTextBox.Text) - 43).ToString();
            }
            else 
            {
                limiTextBox.Text = (float.Parse(limiTextBox.Text) + 43).ToString();
            }
        }

    }
}
