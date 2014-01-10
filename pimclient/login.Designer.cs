using System.Drawing;
namespace pimclient
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.loginBtn = new System.Windows.Forms.Button();
            this.titleLabel1 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passWordLabel = new System.Windows.Forms.Label();
            this.passWordtextBox = new System.Windows.Forms.TextBox();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.serverLabel = new System.Windows.Forms.Label();
            this.controllerLabel = new System.Windows.Forms.Label();
            this.controllerTextBox = new System.Windows.Forms.TextBox();
            this.kaelusRadioButton = new System.Windows.Forms.RadioButton();
            this.rosenbergerRadioButton = new System.Windows.Forms.RadioButton();
            this.cciRadioButton = new System.Windows.Forms.RadioButton();
            this.userNameErrorLabel = new System.Windows.Forms.Label();
            this.passwordErrorLabel = new System.Windows.Forms.Label();
            this.serverErrorLabel = new System.Windows.Forms.Label();
            this.controllerErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(392, 331);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(98, 27);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "登录";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // titleLabel1
            // 
            this.titleLabel1.AutoSize = true;
            this.titleLabel1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel1.Location = new System.Drawing.Point(33, 18);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(190, 24);
            this.titleLabel1.TabIndex = 1;
            this.titleLabel1.Text = "PIM自动测试程序";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userNameTextBox.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameTextBox.Location = new System.Drawing.Point(331, 138);
            this.userNameTextBox.Multiline = true;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(223, 29);
            this.userNameTextBox.TabIndex = 2;
            // 
            // userNameLabel
            // 
            this.userNameLabel.Location = new System.Drawing.Point(260, 146);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(41, 12);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "工号";
            // 
            // passWordLabel
            // 
            this.passWordLabel.AutoSize = true;
            this.passWordLabel.Location = new System.Drawing.Point(260, 197);
            this.passWordLabel.Name = "passWordLabel";
            this.passWordLabel.Size = new System.Drawing.Size(29, 12);
            this.passWordLabel.TabIndex = 4;
            this.passWordLabel.Text = "密码";
            // 
            // passWordtextBox
            // 
            this.passWordtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.passWordtextBox.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passWordtextBox.Location = new System.Drawing.Point(331, 188);
            this.passWordtextBox.Multiline = true;
            this.passWordtextBox.Name = "passWordtextBox";
            this.passWordtextBox.PasswordChar = '*';
            this.passWordtextBox.Size = new System.Drawing.Size(223, 29);
            this.passWordtextBox.TabIndex = 5;
            // 
            // serverTextBox
            // 
            this.serverTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.serverTextBox.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverTextBox.Location = new System.Drawing.Point(331, 238);
            this.serverTextBox.Multiline = true;
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(223, 30);
            this.serverTextBox.TabIndex = 6;
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(260, 248);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(65, 12);
            this.serverLabel.TabIndex = 7;
            this.serverLabel.Text = "服务器地址";
            // 
            // controllerLabel
            // 
            this.controllerLabel.AutoSize = true;
            this.controllerLabel.Location = new System.Drawing.Point(260, 294);
            this.controllerLabel.Name = "controllerLabel";
            this.controllerLabel.Size = new System.Drawing.Size(53, 12);
            this.controllerLabel.TabIndex = 8;
            this.controllerLabel.Text = "仪器地址";
            // 
            // controllerTextBox
            // 
            this.controllerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.controllerTextBox.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controllerTextBox.Location = new System.Drawing.Point(331, 284);
            this.controllerTextBox.Multiline = true;
            this.controllerTextBox.Name = "controllerTextBox";
            this.controllerTextBox.Size = new System.Drawing.Size(223, 28);
            this.controllerTextBox.TabIndex = 9;
            // 
            // kaelusRadioButton
            // 
            this.kaelusRadioButton.AutoSize = true;
            this.kaelusRadioButton.Checked = true;
            this.kaelusRadioButton.Location = new System.Drawing.Point(254, 382);
            this.kaelusRadioButton.Name = "kaelusRadioButton";
            this.kaelusRadioButton.Size = new System.Drawing.Size(59, 16);
            this.kaelusRadioButton.TabIndex = 10;
            this.kaelusRadioButton.TabStop = true;
            this.kaelusRadioButton.Text = "Kaelus";
            this.kaelusRadioButton.UseVisualStyleBackColor = true;
            // 
            // rosenbergerRadioButton
            // 
            this.rosenbergerRadioButton.AutoSize = true;
            this.rosenbergerRadioButton.Enabled = false;
            this.rosenbergerRadioButton.Location = new System.Drawing.Point(392, 382);
            this.rosenbergerRadioButton.Name = "rosenbergerRadioButton";
            this.rosenbergerRadioButton.Size = new System.Drawing.Size(89, 16);
            this.rosenbergerRadioButton.TabIndex = 11;
            this.rosenbergerRadioButton.TabStop = true;
            this.rosenbergerRadioButton.Text = "Rosenberger";
            this.rosenbergerRadioButton.UseVisualStyleBackColor = true;
            // 
            // cciRadioButton
            // 
            this.cciRadioButton.AutoSize = true;
            this.cciRadioButton.Enabled = false;
            this.cciRadioButton.Location = new System.Drawing.Point(532, 382);
            this.cciRadioButton.Name = "cciRadioButton";
            this.cciRadioButton.Size = new System.Drawing.Size(41, 16);
            this.cciRadioButton.TabIndex = 12;
            this.cciRadioButton.TabStop = true;
            this.cciRadioButton.Text = "CCI";
            this.cciRadioButton.UseVisualStyleBackColor = true;
            // 
            // userNameErrorLabel
            // 
            this.userNameErrorLabel.AutoSize = true;
            this.userNameErrorLabel.BackColor = System.Drawing.SystemColors.Control;
            this.userNameErrorLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.userNameErrorLabel.Location = new System.Drawing.Point(571, 146);
            this.userNameErrorLabel.Name = "userNameErrorLabel";
            this.userNameErrorLabel.Size = new System.Drawing.Size(0, 15);
            this.userNameErrorLabel.TabIndex = 13;
            // 
            // passwordErrorLabel
            // 
            this.passwordErrorLabel.AutoSize = true;
            this.passwordErrorLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordErrorLabel.Location = new System.Drawing.Point(572, 197);
            this.passwordErrorLabel.Name = "passwordErrorLabel";
            this.passwordErrorLabel.Size = new System.Drawing.Size(0, 15);
            this.passwordErrorLabel.TabIndex = 14;
            // 
            // serverErrorLabel
            // 
            this.serverErrorLabel.AutoSize = true;
            this.serverErrorLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.serverErrorLabel.Location = new System.Drawing.Point(573, 247);
            this.serverErrorLabel.Name = "serverErrorLabel";
            this.serverErrorLabel.Size = new System.Drawing.Size(0, 15);
            this.serverErrorLabel.TabIndex = 15;
            // 
            // controllerErrorLabel
            // 
            this.controllerErrorLabel.AutoSize = true;
            this.controllerErrorLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controllerErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.controllerErrorLabel.Location = new System.Drawing.Point(573, 292);
            this.controllerErrorLabel.Name = "controllerErrorLabel";
            this.controllerErrorLabel.Size = new System.Drawing.Size(0, 15);
            this.controllerErrorLabel.TabIndex = 16;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 515);
            this.Controls.Add(this.controllerErrorLabel);
            this.Controls.Add(this.serverErrorLabel);
            this.Controls.Add(this.passwordErrorLabel);
            this.Controls.Add(this.userNameErrorLabel);
            this.Controls.Add(this.cciRadioButton);
            this.Controls.Add(this.rosenbergerRadioButton);
            this.Controls.Add(this.kaelusRadioButton);
            this.Controls.Add(this.controllerTextBox);
            this.Controls.Add(this.controllerLabel);
            this.Controls.Add(this.serverLabel);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.passWordtextBox);
            this.Controls.Add(this.passWordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.titleLabel1);
            this.Controls.Add(this.loginBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label titleLabel1;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passWordLabel;
        private System.Windows.Forms.TextBox passWordtextBox;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.Label controllerLabel;
        private System.Windows.Forms.TextBox controllerTextBox;
        private System.Windows.Forms.RadioButton kaelusRadioButton;
        private System.Windows.Forms.RadioButton rosenbergerRadioButton;
        private System.Windows.Forms.RadioButton cciRadioButton;
        private System.Windows.Forms.Label userNameErrorLabel;
        private System.Windows.Forms.Label passwordErrorLabel;
        private System.Windows.Forms.Label serverErrorLabel;
        private System.Windows.Forms.Label controllerErrorLabel;


    }
}