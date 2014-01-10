namespace pimclient
{
    partial class testForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(testForm));
            this.limiTextBox = new System.Windows.Forms.TextBox();
            this.limitLineLabel = new System.Windows.Forms.Label();
            this.freq2TextBox = new System.Windows.Forms.TextBox();
            this.freq1TextBox = new System.Windows.Forms.TextBox();
            this.power2TextBox = new System.Windows.Forms.TextBox();
            this.power1TextBox = new System.Windows.Forms.TextBox();
            this.testButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.snLabel = new System.Windows.Forms.Label();
            this.snTextBox = new System.Windows.Forms.TextBox();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.messageLabel = new System.Windows.Forms.Label();
            this.imOrdercomboBox = new System.Windows.Forms.ComboBox();
            this.imOrderLabel = new System.Windows.Forms.Label();
            this.stepTextBox = new System.Windows.Forms.TextBox();
            this.stepCheckBox = new System.Windows.Forms.CheckBox();
            this.appNameLabel = new System.Windows.Forms.Label();
            this.line1Label = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.operaterLabel = new System.Windows.Forms.Label();
            this.operaterValLabel = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.modelValLabel = new System.Windows.Forms.Label();
            this.serialNumLabel = new System.Windows.Forms.Label();
            this.serialNumValLabel = new System.Windows.Forms.Label();
            this.line2Label = new System.Windows.Forms.Label();
            this.alcLabel = new System.Windows.Forms.Label();
            this.alcRadioButton1 = new System.Windows.Forms.RadioButton();
            this.alcRadioButton2 = new System.Windows.Forms.RadioButton();
            this.line3Label = new System.Windows.Forms.Label();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.powerLabel = new System.Windows.Forms.Label();
            this.carrier1Label = new System.Windows.Forms.Label();
            this.carrier2Label = new System.Windows.Forms.Label();
            this.freq1UnitLabel = new System.Windows.Forms.Label();
            this.freq2UnitLabel = new System.Windows.Forms.Label();
            this.power1Label = new System.Windows.Forms.Label();
            this.power2Label = new System.Windows.Forms.Label();
            this.sweepStepLabel = new System.Windows.Forms.Label();
            this.sweepStepUnitLabel = new System.Windows.Forms.Label();
            this.line4Label = new System.Windows.Forms.Label();
            this.line5Label = new System.Windows.Forms.Label();
            this.line6Label = new System.Windows.Forms.Label();
            this.orderNumLabel = new System.Windows.Forms.Label();
            this.orderNumTextBox = new System.Windows.Forms.TextBox();
            this.line7Label = new System.Windows.Forms.Label();
            this.developerLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.MeasuredPowerLabel = new System.Windows.Forms.Label();
            this.MeasuredPowerValLabel = new System.Windows.Forms.Label();
            this.imFreqLabel = new System.Windows.Forms.Label();
            this.imFreqValLabel = new System.Windows.Forms.Label();
            this.imPowerLabel = new System.Windows.Forms.Label();
            this.imPowerValLabel = new System.Windows.Forms.Label();
            this.uploadButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imPowerUnitcomboBox = new System.Windows.Forms.ComboBox();
            this.singleTestTimeTextBox = new System.Windows.Forms.TextBox();
            this.singleTestTimeLabel = new System.Windows.Forms.Label();
            this.singleTestTimeUnitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // limiTextBox
            // 
            this.limiTextBox.Location = new System.Drawing.Point(116, 338);
            this.limiTextBox.Name = "limiTextBox";
            this.limiTextBox.Size = new System.Drawing.Size(69, 21);
            this.limiTextBox.TabIndex = 10;
            // 
            // limitLineLabel
            // 
            this.limitLineLabel.AutoSize = true;
            this.limitLineLabel.Location = new System.Drawing.Point(30, 344);
            this.limitLineLabel.Name = "limitLineLabel";
            this.limitLineLabel.Size = new System.Drawing.Size(59, 12);
            this.limitLineLabel.TabIndex = 9;
            this.limitLineLabel.Text = "PIM Limit";
            // 
            // freq2TextBox
            // 
            this.freq2TextBox.Location = new System.Drawing.Point(116, 236);
            this.freq2TextBox.Name = "freq2TextBox";
            this.freq2TextBox.Size = new System.Drawing.Size(69, 21);
            this.freq2TextBox.TabIndex = 8;
            // 
            // freq1TextBox
            // 
            this.freq1TextBox.Location = new System.Drawing.Point(116, 205);
            this.freq1TextBox.Name = "freq1TextBox";
            this.freq1TextBox.Size = new System.Drawing.Size(69, 21);
            this.freq1TextBox.TabIndex = 6;
            // 
            // power2TextBox
            // 
            this.power2TextBox.Location = new System.Drawing.Point(242, 236);
            this.power2TextBox.Name = "power2TextBox";
            this.power2TextBox.Size = new System.Drawing.Size(71, 21);
            this.power2TextBox.TabIndex = 3;
            // 
            // power1TextBox
            // 
            this.power1TextBox.Location = new System.Drawing.Point(242, 206);
            this.power1TextBox.Name = "power1TextBox";
            this.power1TextBox.Size = new System.Drawing.Size(71, 21);
            this.power1TextBox.TabIndex = 1;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(402, 481);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 41);
            this.testButton.TabIndex = 1;
            this.testButton.Text = "测试（F1）";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(542, 481);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "停止（F2）";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // snLabel
            // 
            this.snLabel.AutoSize = true;
            this.snLabel.Location = new System.Drawing.Point(44, 512);
            this.snLabel.Name = "snLabel";
            this.snLabel.Size = new System.Drawing.Size(65, 12);
            this.snLabel.TabIndex = 5;
            this.snLabel.Text = "Product SN";
            // 
            // snTextBox
            // 
            this.snTextBox.Location = new System.Drawing.Point(117, 508);
            this.snTextBox.Name = "snTextBox";
            this.snTextBox.Size = new System.Drawing.Size(196, 21);
            this.snTextBox.TabIndex = 6;
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(393, 110);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(569, 342);
            this.zg1.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.messageLabel.ForeColor = System.Drawing.Color.Black;
            this.messageLabel.Location = new System.Drawing.Point(44, 538);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 12);
            this.messageLabel.TabIndex = 7;
            // 
            // imOrdercomboBox
            // 
            this.imOrdercomboBox.FormattingEnabled = true;
            this.imOrdercomboBox.Location = new System.Drawing.Point(265, 136);
            this.imOrdercomboBox.Name = "imOrdercomboBox";
            this.imOrdercomboBox.Size = new System.Drawing.Size(63, 20);
            this.imOrdercomboBox.TabIndex = 11;
            // 
            // imOrderLabel
            // 
            this.imOrderLabel.AutoSize = true;
            this.imOrderLabel.Location = new System.Drawing.Point(227, 139);
            this.imOrderLabel.Name = "imOrderLabel";
            this.imOrderLabel.Size = new System.Drawing.Size(29, 12);
            this.imOrderLabel.TabIndex = 12;
            this.imOrderLabel.Text = "阶数";
            // 
            // stepTextBox
            // 
            this.stepTextBox.Location = new System.Drawing.Point(116, 268);
            this.stepTextBox.Name = "stepTextBox";
            this.stepTextBox.Size = new System.Drawing.Size(69, 21);
            this.stepTextBox.TabIndex = 14;
            // 
            // stepCheckBox
            // 
            this.stepCheckBox.AutoSize = true;
            this.stepCheckBox.Checked = true;
            this.stepCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stepCheckBox.Location = new System.Drawing.Point(220, 272);
            this.stepCheckBox.Name = "stepCheckBox";
            this.stepCheckBox.Size = new System.Drawing.Size(15, 14);
            this.stepCheckBox.TabIndex = 15;
            this.stepCheckBox.UseVisualStyleBackColor = true;
            this.stepCheckBox.CheckedChanged += new System.EventHandler(this.stepCheckBox_CheckedChanged);
            // 
            // appNameLabel
            // 
            this.appNameLabel.AutoSize = true;
            this.appNameLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.appNameLabel.Location = new System.Drawing.Point(30, 18);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(190, 24);
            this.appNameLabel.TabIndex = 16;
            this.appNameLabel.Text = "PIM自动测试程序";
            // 
            // line1Label
            // 
            this.line1Label.AutoSize = true;
            this.line1Label.Location = new System.Drawing.Point(-3, 57);
            this.line1Label.Name = "line1Label";
            this.line1Label.Size = new System.Drawing.Size(989, 12);
            this.line1Label.TabIndex = 17;
            this.line1Label.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "___";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(892, 45);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(59, 12);
            this.versionLabel.TabIndex = 18;
            this.versionLabel.Text = "版本：1.0";
            // 
            // operaterLabel
            // 
            this.operaterLabel.AutoSize = true;
            this.operaterLabel.Location = new System.Drawing.Point(23, 84);
            this.operaterLabel.Name = "operaterLabel";
            this.operaterLabel.Size = new System.Drawing.Size(65, 12);
            this.operaterLabel.TabIndex = 19;
            this.operaterLabel.Text = "Operater：";
            // 
            // operaterValLabel
            // 
            this.operaterValLabel.AutoSize = true;
            this.operaterValLabel.Location = new System.Drawing.Point(81, 84);
            this.operaterValLabel.Name = "operaterValLabel";
            this.operaterValLabel.Size = new System.Drawing.Size(89, 12);
            this.operaterValLabel.TabIndex = 20;
            this.operaterValLabel.Text = "operaterlabel1";
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(150, 84);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(47, 12);
            this.modelLabel.TabIndex = 21;
            this.modelLabel.Text = "Model：";
            // 
            // modelValLabel
            // 
            this.modelValLabel.AutoSize = true;
            this.modelValLabel.Location = new System.Drawing.Point(192, 83);
            this.modelValLabel.Name = "modelValLabel";
            this.modelValLabel.Size = new System.Drawing.Size(65, 12);
            this.modelValLabel.TabIndex = 22;
            this.modelValLabel.Text = "modellabel";
            // 
            // serialNumLabel
            // 
            this.serialNumLabel.AutoSize = true;
            this.serialNumLabel.Location = new System.Drawing.Point(269, 83);
            this.serialNumLabel.Name = "serialNumLabel";
            this.serialNumLabel.Size = new System.Drawing.Size(77, 12);
            this.serialNumLabel.TabIndex = 23;
            this.serialNumLabel.Text = "Serial Num：";
            // 
            // serialNumValLabel
            // 
            this.serialNumValLabel.AutoSize = true;
            this.serialNumValLabel.Location = new System.Drawing.Point(342, 83);
            this.serialNumValLabel.Name = "serialNumValLabel";
            this.serialNumValLabel.Size = new System.Drawing.Size(65, 12);
            this.serialNumValLabel.TabIndex = 24;
            this.serialNumValLabel.Text = "serial Num";
            // 
            // line2Label
            // 
            this.line2Label.AutoSize = true;
            this.line2Label.BackColor = System.Drawing.SystemColors.Control;
            this.line2Label.ForeColor = System.Drawing.Color.Gray;
            this.line2Label.Location = new System.Drawing.Point(27, 110);
            this.line2Label.Name = "line2Label";
            this.line2Label.Size = new System.Drawing.Size(359, 12);
            this.line2Label.TabIndex = 25;
            this.line2Label.Text = "___________________________________________________________";
            // 
            // alcLabel
            // 
            this.alcLabel.AutoSize = true;
            this.alcLabel.Location = new System.Drawing.Point(29, 140);
            this.alcLabel.Name = "alcLabel";
            this.alcLabel.Size = new System.Drawing.Size(35, 12);
            this.alcLabel.TabIndex = 26;
            this.alcLabel.Text = "ALC：";
            // 
            // alcRadioButton1
            // 
            this.alcRadioButton1.AutoSize = true;
            this.alcRadioButton1.Checked = true;
            this.alcRadioButton1.Location = new System.Drawing.Point(60, 138);
            this.alcRadioButton1.Name = "alcRadioButton1";
            this.alcRadioButton1.Size = new System.Drawing.Size(35, 16);
            this.alcRadioButton1.TabIndex = 27;
            this.alcRadioButton1.TabStop = true;
            this.alcRadioButton1.Text = "ON";
            this.alcRadioButton1.UseVisualStyleBackColor = true;
            // 
            // alcRadioButton2
            // 
            this.alcRadioButton2.AutoSize = true;
            this.alcRadioButton2.Location = new System.Drawing.Point(100, 138);
            this.alcRadioButton2.Name = "alcRadioButton2";
            this.alcRadioButton2.Size = new System.Drawing.Size(41, 16);
            this.alcRadioButton2.TabIndex = 28;
            this.alcRadioButton2.TabStop = true;
            this.alcRadioButton2.Text = "OFF";
            this.alcRadioButton2.UseVisualStyleBackColor = true;
            // 
            // line3Label
            // 
            this.line3Label.AutoSize = true;
            this.line3Label.ForeColor = System.Drawing.Color.Gray;
            this.line3Label.Location = new System.Drawing.Point(28, 156);
            this.line3Label.Name = "line3Label";
            this.line3Label.Size = new System.Drawing.Size(359, 12);
            this.line3Label.TabIndex = 29;
            this.line3Label.Text = "___________________________________________________________";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(114, 183);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(59, 12);
            this.frequencyLabel.TabIndex = 30;
            this.frequencyLabel.Text = "Frequency";
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(240, 183);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(35, 12);
            this.powerLabel.TabIndex = 31;
            this.powerLabel.Text = "Power";
            // 
            // carrier1Label
            // 
            this.carrier1Label.AutoSize = true;
            this.carrier1Label.Location = new System.Drawing.Point(30, 209);
            this.carrier1Label.Name = "carrier1Label";
            this.carrier1Label.Size = new System.Drawing.Size(53, 12);
            this.carrier1Label.TabIndex = 32;
            this.carrier1Label.Text = "Carrier1";
            // 
            // carrier2Label
            // 
            this.carrier2Label.AutoSize = true;
            this.carrier2Label.Location = new System.Drawing.Point(30, 241);
            this.carrier2Label.Name = "carrier2Label";
            this.carrier2Label.Size = new System.Drawing.Size(53, 12);
            this.carrier2Label.TabIndex = 33;
            this.carrier2Label.Text = "Carrier2";
            // 
            // freq1UnitLabel
            // 
            this.freq1UnitLabel.AutoSize = true;
            this.freq1UnitLabel.Location = new System.Drawing.Point(191, 210);
            this.freq1UnitLabel.Name = "freq1UnitLabel";
            this.freq1UnitLabel.Size = new System.Drawing.Size(23, 12);
            this.freq1UnitLabel.TabIndex = 34;
            this.freq1UnitLabel.Text = "MHz";
            // 
            // freq2UnitLabel
            // 
            this.freq2UnitLabel.AutoSize = true;
            this.freq2UnitLabel.Location = new System.Drawing.Point(191, 240);
            this.freq2UnitLabel.Name = "freq2UnitLabel";
            this.freq2UnitLabel.Size = new System.Drawing.Size(23, 12);
            this.freq2UnitLabel.TabIndex = 35;
            this.freq2UnitLabel.Text = "MHz";
            // 
            // power1Label
            // 
            this.power1Label.AutoSize = true;
            this.power1Label.Location = new System.Drawing.Point(320, 211);
            this.power1Label.Name = "power1Label";
            this.power1Label.Size = new System.Drawing.Size(23, 12);
            this.power1Label.TabIndex = 36;
            this.power1Label.Text = "dBm";
            // 
            // power2Label
            // 
            this.power2Label.AutoSize = true;
            this.power2Label.Location = new System.Drawing.Point(320, 241);
            this.power2Label.Name = "power2Label";
            this.power2Label.Size = new System.Drawing.Size(23, 12);
            this.power2Label.TabIndex = 37;
            this.power2Label.Text = "dBm";
            // 
            // sweepStepLabel
            // 
            this.sweepStepLabel.AutoSize = true;
            this.sweepStepLabel.Location = new System.Drawing.Point(31, 272);
            this.sweepStepLabel.Name = "sweepStepLabel";
            this.sweepStepLabel.Size = new System.Drawing.Size(65, 12);
            this.sweepStepLabel.TabIndex = 38;
            this.sweepStepLabel.Text = "Sweep Step";
            // 
            // sweepStepUnitLabel
            // 
            this.sweepStepUnitLabel.AutoSize = true;
            this.sweepStepUnitLabel.Location = new System.Drawing.Point(191, 272);
            this.sweepStepUnitLabel.Name = "sweepStepUnitLabel";
            this.sweepStepUnitLabel.Size = new System.Drawing.Size(23, 12);
            this.sweepStepUnitLabel.TabIndex = 39;
            this.sweepStepUnitLabel.Text = "MHz";
            // 
            // line4Label
            // 
            this.line4Label.AutoSize = true;
            this.line4Label.ForeColor = System.Drawing.Color.Gray;
            this.line4Label.Location = new System.Drawing.Point(29, 313);
            this.line4Label.Name = "line4Label";
            this.line4Label.Size = new System.Drawing.Size(359, 12);
            this.line4Label.TabIndex = 40;
            this.line4Label.Text = "___________________________________________________________";
            // 
            // line5Label
            // 
            this.line5Label.AutoSize = true;
            this.line5Label.ForeColor = System.Drawing.Color.Gray;
            this.line5Label.Location = new System.Drawing.Point(29, 362);
            this.line5Label.Name = "line5Label";
            this.line5Label.Size = new System.Drawing.Size(359, 12);
            this.line5Label.TabIndex = 42;
            this.line5Label.Text = "___________________________________________________________";
            // 
            // line6Label
            // 
            this.line6Label.AutoSize = true;
            this.line6Label.ForeColor = System.Drawing.Color.Gray;
            this.line6Label.Location = new System.Drawing.Point(30, 444);
            this.line6Label.Name = "line6Label";
            this.line6Label.Size = new System.Drawing.Size(359, 12);
            this.line6Label.TabIndex = 43;
            this.line6Label.Text = "___________________________________________________________";
            // 
            // orderNumLabel
            // 
            this.orderNumLabel.AutoSize = true;
            this.orderNumLabel.Location = new System.Drawing.Point(44, 480);
            this.orderNumLabel.Name = "orderNumLabel";
            this.orderNumLabel.Size = new System.Drawing.Size(59, 12);
            this.orderNumLabel.TabIndex = 44;
            this.orderNumLabel.Text = "Order Num";
            // 
            // orderNumTextBox
            // 
            this.orderNumTextBox.Location = new System.Drawing.Point(117, 476);
            this.orderNumTextBox.Name = "orderNumTextBox";
            this.orderNumTextBox.Size = new System.Drawing.Size(196, 21);
            this.orderNumTextBox.TabIndex = 45;
            // 
            // line7Label
            // 
            this.line7Label.AutoSize = true;
            this.line7Label.Location = new System.Drawing.Point(28, 560);
            this.line7Label.Name = "line7Label";
            this.line7Label.Size = new System.Drawing.Size(941, 12);
            this.line7Label.TabIndex = 46;
            this.line7Label.Text = "_________________________________________________________________________________" +
    "___________________________________________________________________________";
            // 
            // developerLabel
            // 
            this.developerLabel.AutoSize = true;
            this.developerLabel.ForeColor = System.Drawing.Color.Silver;
            this.developerLabel.Location = new System.Drawing.Point(479, 584);
            this.developerLabel.Name = "developerLabel";
            this.developerLabel.Size = new System.Drawing.Size(119, 12);
            this.developerLabel.TabIndex = 47;
            this.developerLabel.Text = "Powered by Gemcycle";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultLabel.ForeColor = System.Drawing.Color.White;
            this.resultLabel.Location = new System.Drawing.Point(804, 480);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Padding = new System.Windows.Forms.Padding(50, 5, 50, 5);
            this.resultLabel.Size = new System.Drawing.Size(100, 41);
            this.resultLabel.TabIndex = 48;
            // 
            // MeasuredPowerLabel
            // 
            this.MeasuredPowerLabel.AutoSize = true;
            this.MeasuredPowerLabel.Location = new System.Drawing.Point(34, 391);
            this.MeasuredPowerLabel.Name = "MeasuredPowerLabel";
            this.MeasuredPowerLabel.Size = new System.Drawing.Size(101, 12);
            this.MeasuredPowerLabel.TabIndex = 49;
            this.MeasuredPowerLabel.Text = "Measured Power：";
            // 
            // MeasuredPowerValLabel
            // 
            this.MeasuredPowerValLabel.AutoSize = true;
            this.MeasuredPowerValLabel.Location = new System.Drawing.Point(132, 391);
            this.MeasuredPowerValLabel.Name = "MeasuredPowerValLabel";
            this.MeasuredPowerValLabel.Size = new System.Drawing.Size(0, 12);
            this.MeasuredPowerValLabel.TabIndex = 50;
            // 
            // imFreqLabel
            // 
            this.imFreqLabel.AutoSize = true;
            this.imFreqLabel.Location = new System.Drawing.Point(34, 417);
            this.imFreqLabel.Name = "imFreqLabel";
            this.imFreqLabel.Size = new System.Drawing.Size(89, 12);
            this.imFreqLabel.TabIndex = 51;
            this.imFreqLabel.Text = "IM Frequency：";
            // 
            // imFreqValLabel
            // 
            this.imFreqValLabel.AutoSize = true;
            this.imFreqValLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imFreqValLabel.Location = new System.Drawing.Point(116, 414);
            this.imFreqValLabel.Name = "imFreqValLabel";
            this.imFreqValLabel.Size = new System.Drawing.Size(0, 19);
            this.imFreqValLabel.TabIndex = 52;
            // 
            // imPowerLabel
            // 
            this.imPowerLabel.AutoSize = true;
            this.imPowerLabel.Location = new System.Drawing.Point(215, 418);
            this.imPowerLabel.Name = "imPowerLabel";
            this.imPowerLabel.Size = new System.Drawing.Size(65, 12);
            this.imPowerLabel.TabIndex = 53;
            this.imPowerLabel.Text = "IM Power：";
            // 
            // imPowerValLabel
            // 
            this.imPowerValLabel.AutoSize = true;
            this.imPowerValLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imPowerValLabel.Location = new System.Drawing.Point(265, 414);
            this.imPowerValLabel.Name = "imPowerValLabel";
            this.imPowerValLabel.Size = new System.Drawing.Size(0, 19);
            this.imPowerValLabel.TabIndex = 54;
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(681, 481);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(80, 39);
            this.uploadButton.TabIndex = 55;
            this.uploadButton.Text = "上传（F3）";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imPowerUnitcomboBox
            // 
            this.imPowerUnitcomboBox.FormattingEnabled = true;
            this.imPowerUnitcomboBox.Location = new System.Drawing.Point(191, 339);
            this.imPowerUnitcomboBox.Name = "imPowerUnitcomboBox";
            this.imPowerUnitcomboBox.Size = new System.Drawing.Size(44, 20);
            this.imPowerUnitcomboBox.TabIndex = 56;
            // 
            // singleTestTimeTextBox
            // 
            this.singleTestTimeTextBox.Location = new System.Drawing.Point(116, 296);
            this.singleTestTimeTextBox.Name = "singleTestTimeTextBox";
            this.singleTestTimeTextBox.Size = new System.Drawing.Size(69, 21);
            this.singleTestTimeTextBox.TabIndex = 57;
            // 
            // singleTestTimeLabel
            // 
            this.singleTestTimeLabel.AutoSize = true;
            this.singleTestTimeLabel.Location = new System.Drawing.Point(34, 300);
            this.singleTestTimeLabel.Name = "singleTestTimeLabel";
            this.singleTestTimeLabel.Size = new System.Drawing.Size(77, 12);
            this.singleTestTimeLabel.TabIndex = 58;
            this.singleTestTimeLabel.Text = "Setting Time";
            // 
            // singleTestTimeUnitLabel
            // 
            this.singleTestTimeUnitLabel.AutoSize = true;
            this.singleTestTimeUnitLabel.Location = new System.Drawing.Point(191, 300);
            this.singleTestTimeUnitLabel.Name = "singleTestTimeUnitLabel";
            this.singleTestTimeUnitLabel.Size = new System.Drawing.Size(11, 12);
            this.singleTestTimeUnitLabel.TabIndex = 59;
            this.singleTestTimeUnitLabel.Text = "S";
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 618);
            this.Controls.Add(this.singleTestTimeUnitLabel);
            this.Controls.Add(this.singleTestTimeLabel);
            this.Controls.Add(this.singleTestTimeTextBox);
            this.Controls.Add(this.imPowerUnitcomboBox);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.imPowerValLabel);
            this.Controls.Add(this.imPowerLabel);
            this.Controls.Add(this.imFreqValLabel);
            this.Controls.Add(this.imFreqLabel);
            this.Controls.Add(this.MeasuredPowerValLabel);
            this.Controls.Add(this.MeasuredPowerLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.developerLabel);
            this.Controls.Add(this.line7Label);
            this.Controls.Add(this.orderNumTextBox);
            this.Controls.Add(this.orderNumLabel);
            this.Controls.Add(this.line6Label);
            this.Controls.Add(this.line5Label);
            this.Controls.Add(this.line4Label);
            this.Controls.Add(this.sweepStepUnitLabel);
            this.Controls.Add(this.sweepStepLabel);
            this.Controls.Add(this.power2Label);
            this.Controls.Add(this.power1Label);
            this.Controls.Add(this.freq2UnitLabel);
            this.Controls.Add(this.freq1UnitLabel);
            this.Controls.Add(this.carrier2Label);
            this.Controls.Add(this.carrier1Label);
            this.Controls.Add(this.powerLabel);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.line3Label);
            this.Controls.Add(this.alcRadioButton2);
            this.Controls.Add(this.alcRadioButton1);
            this.Controls.Add(this.alcLabel);
            this.Controls.Add(this.line2Label);
            this.Controls.Add(this.serialNumValLabel);
            this.Controls.Add(this.serialNumLabel);
            this.Controls.Add(this.modelValLabel);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.operaterValLabel);
            this.Controls.Add(this.operaterLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.line1Label);
            this.Controls.Add(this.appNameLabel);
            this.Controls.Add(this.stepCheckBox);
            this.Controls.Add(this.stepTextBox);
            this.Controls.Add(this.imOrderLabel);
            this.Controls.Add(this.imOrdercomboBox);
            this.Controls.Add(this.limiTextBox);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.limitLineLabel);
            this.Controls.Add(this.snTextBox);
            this.Controls.Add(this.freq2TextBox);
            this.Controls.Add(this.snLabel);
            this.Controls.Add(this.freq1TextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.power2TextBox);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.power1TextBox);
            this.Controls.Add(this.zg1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "testForm";
            this.Text = "测试";
            this.Load += new System.EventHandler(this.testForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox power1TextBox;
        private System.Windows.Forms.TextBox power2TextBox;
        private System.Windows.Forms.TextBox freq1TextBox;
        private System.Windows.Forms.TextBox freq2TextBox;
        private System.Windows.Forms.Label limitLineLabel;
        private System.Windows.Forms.TextBox limiTextBox;
        private System.Windows.Forms.Label snLabel;
        private System.Windows.Forms.TextBox snTextBox;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.ComboBox imOrdercomboBox;
        private System.Windows.Forms.Label imOrderLabel;
        private System.Windows.Forms.TextBox stepTextBox;
        private System.Windows.Forms.CheckBox stepCheckBox;
        private System.Windows.Forms.Label appNameLabel;
        private System.Windows.Forms.Label line1Label;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label operaterLabel;
        private System.Windows.Forms.Label operaterValLabel;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label modelValLabel;
        private System.Windows.Forms.Label serialNumLabel;
        private System.Windows.Forms.Label serialNumValLabel;
        private System.Windows.Forms.Label line2Label;
        private System.Windows.Forms.Label alcLabel;
        private System.Windows.Forms.RadioButton alcRadioButton1;
        private System.Windows.Forms.RadioButton alcRadioButton2;
        private System.Windows.Forms.Label line3Label;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.Label carrier1Label;
        private System.Windows.Forms.Label carrier2Label;
        private System.Windows.Forms.Label freq1UnitLabel;
        private System.Windows.Forms.Label freq2UnitLabel;
        private System.Windows.Forms.Label power1Label;
        private System.Windows.Forms.Label power2Label;
        private System.Windows.Forms.Label sweepStepLabel;
        private System.Windows.Forms.Label sweepStepUnitLabel;
        private System.Windows.Forms.Label line4Label;
        private System.Windows.Forms.Label line5Label;
        private System.Windows.Forms.Label line6Label;
        private System.Windows.Forms.Label orderNumLabel;
        private System.Windows.Forms.TextBox orderNumTextBox;
        private System.Windows.Forms.Label line7Label;
        private System.Windows.Forms.Label developerLabel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label MeasuredPowerLabel;
        private System.Windows.Forms.Label MeasuredPowerValLabel;
        private System.Windows.Forms.Label imFreqLabel;
        private System.Windows.Forms.Label imFreqValLabel;
        private System.Windows.Forms.Label imPowerLabel;
        private System.Windows.Forms.Label imPowerValLabel;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox imPowerUnitcomboBox;
        private System.Windows.Forms.TextBox singleTestTimeTextBox;
        private System.Windows.Forms.Label singleTestTimeLabel;
        private System.Windows.Forms.Label singleTestTimeUnitLabel;
    }
}