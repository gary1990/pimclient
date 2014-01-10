using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace pimclient
{
    public partial class login : Form
    {
        private WebClient loginClient;
        private DataTable producttypes;
        private string userName;
        private string passWord;
        private string serverUrl;
        private string controllerUrl;
        private string token;

        public login()
        {
            InitializeComponent();
            loginClient = new WebClient();
            producttypes = new DataTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userName = this.userNameTextBox.Text;
            passWord = this.passWordtextBox.Text;
            serverUrl = this.serverTextBox.Text;
            controllerUrl = this.controllerTextBox.Text;

            //验证工号、密码、服务器地址、仪器地址格式。验证工号密码正确性
            if (this.checkInfo(userName, passWord, serverUrl, controllerUrl))
            //if (true)
            {
                string appStartPath = Application.StartupPath;
                string LoginConfig = System.IO.Path.Combine(appStartPath, "loginConfig.txt");

                try
                {
                    using (TextWriter sr = new StreamWriter(LoginConfig))
                    {
                        sr.Write(userName+";"+serverUrl+";"+controllerUrl);
                        sr.Close();
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("登录信息保存失败："+e1.ToString());
                }


                //选中kaelus
                if (this.kaelusRadioButton.Checked)
                {
                    this.Visible = false;
                    //ConnectAndSweepForm connectAndSweepForm = new ConnectAndSweepForm();
                    //connectAndSweepForm.userName = this.userNameTextBox.ToString();
                    //connectAndSweepForm.Show();
                    //将用户名、密码、token、服务器地址传给testForm定义的变量
                    testForm testform = new testForm();
                    testform.userName = userName;
                    testform.token = this.token;
                    testform.serverUrl = this.serverUrl;
                    testform.controllerUrl = this.controllerUrl;
                    testform.producttyes = this.producttypes;
                    testform.passWord = this.passWord;
                    testform.Show();
                }
                else if (this.rosenbergerRadioButton.Checked)
                {
                    //do nothing
                }
                else
                {
                    //do nothinng
                }
            }
            else
            {
                this.userNameTextBox.Text = userName;
                this.passWordtextBox.Text = passWord;
                this.serverTextBox.Text = serverUrl;
                this.controllerTextBox.Text = controllerUrl;
            }
        }

        private bool checkInfo(string useName, string password, string serverUrl, string controllerUrl)
        {
            bool result = true;
            Regex userName_passWordReg = new Regex(@"([0-9a-zA-Z]+)");
            Regex serverUrlReg = new Regex(@"(([0-9a-zA-Z]+\.){3}([0-9a-zA-Z]+)/[0-9a-zA-Z])|(([0-9a-zA-Z]+\.){2}([0-9a-zA-Z\:]+)/[0-9a-zA-Z])");
            Regex controllerUrlReg = new Regex(@"([0-9a-zA-Z]+\.){3}([0-9a-zA-Z]+)");
            if (userName_passWordReg.IsMatch(useName))
            {
                this.userNameErrorLabel.Text = "";
            }
            else
            {
                this.userNameErrorLabel.Text = "请输入正确的工号密码";
                result = false;
            }
            if (userName_passWordReg.IsMatch(password))
            {
                this.passwordErrorLabel.Text = "";
            }
            else
            {
                this.passwordErrorLabel.Text = "请输入正确的工号密码";
                result = false;
            }
            if (serverUrlReg.IsMatch(serverUrl))
            {
                this.serverErrorLabel.Text = "";
            }
            else
            {
                this.serverErrorLabel.Text = "请输入正确的服务器地址";
                result = false;
            }
            if (controllerUrlReg.IsMatch(controllerUrl))
            {
                this.controllerErrorLabel.Text = "";
            }
            else
            {
                this.controllerErrorLabel.Text = "请输入正确的仪器地址";
                result = false;
            }

            //验证用户名密码
            if (result)
            {
                XmlDocument checkUserDoc = new XmlDocument();
                try
                {
                    string checkUserResponse = this.loginClient.DownloadString("http://" + serverUrl + "/index.php/login/pimClientLogin/" + useName + "/" + password);
                    checkUserDoc.LoadXml(checkUserResponse);
                    string checkuserResult = checkUserDoc.GetElementsByTagName("result").Item(0).InnerXml.ToString();
                    if (checkuserResult == "true")
                    {
                        //解析xml，将producttye保存到DataTable
                        this.producttypes.Columns.Add("id");
                        this.producttypes.Columns.Add("name");
                        this.producttypes.Rows.Add("", "");
                        /*
                        int producttypeCount = checkUserDoc.GetElementsByTagName("producttype").Count;
                        for (int i = 0; i < producttypeCount; i++)
                        {
                            string producttypeId = checkUserDoc.GetElementsByTagName("producttype").Item(i).FirstChild.InnerText;
                            string producttypeName = checkUserDoc.GetElementsByTagName("producttype").Item(i).LastChild.InnerText;
                            this.producttypes.Rows.Add(producttypeId, producttypeName);
                        }
                        */
                    }
                    else
                    {
                        this.userNameErrorLabel.Text = "请输入正确的工号密码";
                        this.passwordErrorLabel.Text = "请输入正确的工号密码";
                        result = false;
                    }
                }
                catch (Exception e)
                {
                    this.serverErrorLabel.Text = "服务器连接失败" + e.Message;
                    result = false;
                }
            }

            //取得token
            if (result)
            {
                XmlDocument getTokenDoc = new XmlDocument();
                try
                {
                    string getTokenResponse = this.loginClient.DownloadString("http://" + controllerUrl + "/api/connect");
                    getTokenDoc.LoadXml(getTokenResponse);
                    string tokenResult = getTokenDoc.GetElementsByTagName("Token").Item(0).InnerXml.ToString();
                    this.token = tokenResult;
                }
                catch (Exception e)
                {
                    this.controllerErrorLabel.Text = "仪器连接失败";
                    result = false;
                }

            }
            return result;
        }

        private void login_Load(object sender, EventArgs e)
        {
            //读取用户信息（工号，服务器地址，仪器地址）
            string appStartPath = Application.StartupPath;
            string LoginConfig = System.IO.Path.Combine(appStartPath, "loginConfig.txt");
            if (File.Exists(LoginConfig)) 
            {
                try
                {
                    using (StreamReader sr = new StreamReader(LoginConfig))
                    {
                        String configStr = sr.ReadToEnd();

                        sr.Close();
                        string[] sArray = Regex.Split(configStr, ";");
                        userNameTextBox.Text = sArray[0];
                        serverTextBox.Text = sArray[1];
                        controllerTextBox.Text = sArray[2];
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("登录信息读取失败："+e1.ToString());
                }
                
            }
        }

    }
}
