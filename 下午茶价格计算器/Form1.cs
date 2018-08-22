using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 下午茶价格计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.Text = "下午茶价格计算器";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.init();
            this.MaximizeBox = false;

        }

        private int high = 20;
        private int index = 0;
        private int kill = 0;

        private void init() {
            //实付金额label
            Label label1 = new Label();
            label1.Name = "label1";
            label1.AutoSize = true;
            //label1.Size = new Size(20, 20);
            label1.Location = new Point(20, 24);
            label1.TabIndex = 0;
            label1.Text = "实付总额";
            this.Controls.Add(label1);


            //实付金额textBox
            TextBox textBox1 = new TextBox();
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(65, 0);
            textBox1.Location = new Point(80,20);
            //textBox1.ReadOnly = true;
            this.Controls.Add(textBox1);

            //初始化第一行人员
            index++;
            addTextBox(index);
            addButton(index, true);
            addLabel(index);

            //初始化增加2人，共3人
            for (int i = 0; i < 2; i++) {
                this.btnInit_Click(null, null);
            }

            //计算按钮
            Button btn1 = new Button();
            btn1.Name = "button1";
            btn1.Text = "计算";
            //btn1.Size = new Size(80, 20);
            btn1.Location = new Point(170,19);
            this.Controls.Add(btn1);
            btn1.Click += new System.EventHandler(this.btn1_Click);

            //清除按钮
            Button btn2 = new Button();
            btn2.Name = "button2";
            btn2.Text = "清除";
            //btn1.Size = new Size(80, 20);
            btn2.Location = new Point(170 + 85, 19);
            this.Controls.Add(btn2);
            btn2.Click += new System.EventHandler(this.btn2_Click);
            /*
            //复制按钮
            Button btn3 = new Button();
            btn3.Name = "button3";
            btn3.Text = "复制";
            btn3.Size = new Size(39, 23);
            btn3.Location = new Point(170 + 82 + 82, 19);
            this.Controls.Add(btn3);
            btn3.Click += new System.EventHandler(this.btn3_Click);
            */
        }


        private void createResultTextBox()
        {
            TextBox tb = new TextBox();
            tb.Name = "createResultTextBox";
            tb.Size = new Size(200, 120);
            tb.Multiline = true;
            tb.Location = new Point(170, 20 + 40);
            tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
 
            this.Controls.Add(tb);
        }


        private void addPeople(int index) {
            addTextBox(index);
            addButton(index, false);
            addLabel(index);


        }

        //新增label
        private void addLabel(int index)
        {
            Label lb = new Label();
            lb.Name = "myLabel_" + index.ToString();
            lb.AutoSize = true;
            lb.Text = string.Format("人员{0}", index - kill);
            //lb.Size = new Size(20, 20);
            lb.Location = new Point(20, 60 + 4 + (30 * ((index - kill) -1 )));
            lb.TabIndex = 0;
            this.Controls.Add(lb);
        }

        //新增textBox
        private void addTextBox(int index) {
            TextBox tb = new TextBox();
            tb.Name = "myTextBox_" + index.ToString();
            //tb.Text = string.Format("人员{0}", index - kill);
            tb.Size = new Size(60, 0);
            tb.Location = new Point(20+40, 60 + (30 * ((index - kill) -1 )));
            this.Controls.Add(tb);
        }

        //新增Button
        private void addButton(int index, Boolean init)
        {
            Button btn = new Button();
            btn.Name = "myButton_" + index.ToString();
            //btn.Text = string.Format("按钮{0}", index - kill);
            btn.Size = new Size(20, 20);
            btn.Location = new Point(20+40+65, 60 + (30 * ((index - kill) -1)));
            btn.Font = new Font(btn.Font.FontFamily.Name, 10);
            btn.TabStop = false;
            this.Controls.Add(btn);
            //添加点击事件
            if (init)
            {
                btn.Text = "+";
                btn.Click += new EventHandler(btnInit_Click);
            }
            else {
                btn.Text = "-";
                btn.Click += new EventHandler(btn_Click);
            }

        }

        void btn_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            this.Controls.Remove(but);
            int index = int.Parse(but.Name.Replace("myButton_", ""));
            this.Controls.Remove(this.Controls.Find("myTextBox_" + index, false)[0]);
            this.Controls.Remove(this.Controls.Find("myLabel_" + index, false)[0]);
            this.kill++;

           

            foreach (Form form in Application.OpenForms)
            {
                int l = 0;
                int t = 0;
                int b = 0;
                foreach (Control item in form.Controls)
                {
                    
                    if (item is TextBox && item.Name.Contains("my"))
                    {
                        t++;
                        TextBox tb = (TextBox)item;
                        tb.Location = new Point(20 + 40 , 60 + (30 * (t - 1)));

                    }
                    if (item is Button && item.Name.Contains("my"))
                    {
                        b++;
                        Button bt = (Button)item;
                        bt.Location = new Point(20 + 40 + 65, 60 + (30 * (b - 1)));
                    }
                    if (item is Label && item.Name.Contains("my"))
                    {
                        l++;
                        Label lb = (Label)item;
                        lb.Text = string.Format("人员{0}", t);
                        lb.Location = new Point(20, 60 + 4 + (30 * (l - 1)));
                    }

                }
            }


        }
        int egg = 0;
        void btnInit_Click(object sender, EventArgs e)
        {
            
            if (index - kill < 10)
            {
                this.index++;
                addPeople(index);
                
            }else if (egg > 999)
            {
                MessageBox.Show("感谢你发现这个彩蛋！", "提示"); 
                egg++;
            }else if (egg > 99)
            {
                MessageBox.Show("！！？", "提示");
                egg++;
            }
            else if (egg > 9)
            {
                MessageBox.Show("你也太无聊了吧！？都点了" + egg + "次了！", "提示");
                egg++;
            }
            else {
                MessageBox.Show("这么多人一起喝奶茶吗？" + (index - kill) + "个了呢！", "提示");
                egg++;
            }

        }
        

        //存下当前变量
        Dictionary<string, string> result = new Dictionary<string, string>();
        private void updateResult() {
            //清空重写
            result.Clear();
            foreach (Form form in Application.OpenForms)
            {
                int t = 0;
                foreach (Control item in form.Controls)
                {

                    if (item is TextBox && item.Name.Contains("my"))
                    {
                        t++;
                        TextBox tb = (TextBox)item;
                        Console.WriteLine(tb.Text);
                        result.Add(tb.Name, tb.Text);
                    }

                }
            }
        }

        Boolean ifResultTextBox = false;
        private void btn1_Click(object sender, EventArgs e)
        {
 
            updateResult();
            if (!ifResultTextBox) {
                createResultTextBox();
                ifResultTextBox = true;
            }
            String tmp = jisuan();
            this.Controls.Find("createResultTextBox", false)[0].Text = tmp;


        }



        private void btn2_Click(object sender, EventArgs e)
        {
            updateResult();
            this.Controls.Find("textBox1", false)[0].Text = "";
            foreach (KeyValuePair<string, string> kv in result)
                {
                this.Controls.Find(kv.Key, false)[0].Text = "";
                }
            //if (this.Controls.Find("createResultTextBox", false).Count(x => x.Name == "createResultTextBox") > 0){}
            if(ifResultTextBox)
            {
                this.Controls.Find("createResultTextBox", false)[0].Text = "";
                //this.Controls.Remove(this.Controls.Find("createResultTextBox", false)[0]);
                //ifResultTextBox = false;
            }
            //彩蛋
            egg = 0;

        }

        /*
        private void btn3_Click(object sender, EventArgs e)
        {

            String tmp = this.Controls.Find("createResultTextBox", false)[0].Text;
            if (tmp != "" && tmp != "请输入正确的金额！")
            {
                Clipboard.SetDataObject(tmp);
            }



        }
        */
        private Boolean ifNumber(String str)
        {
            bool flag = true;
            int count = 0;
            if (str.Length == 0)
            {
                flag = false;
                //MessageBox.Show("请输入金额！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                char[] x = str.ToCharArray();
                for (int i = 0; i < str.Length; i++)
                {   
                    if (!char.IsNumber(x[i]) && x[i] != '.')
                    {
                        flag = false; break;
                    }
                    if (x[i] == '.')
                    {
                        count++;
                        if (i == 0 || i == str.Length - 1) flag = false;
                    }
                }
                if (count > 1) flag = false;
                //if (!flag) MessageBox.Show("输入金额的格式不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return flag;
        }

        private String jisuan() {
            Boolean ifJoking = false;
            double yuanjiaSum = 0;
            double xianjiaSum = 0;
            if (ifNumber(this.Controls.Find("textBox1", false)[0].Text))
            {
                xianjiaSum = Convert.ToDouble(this.Controls.Find("textBox1", false)[0].Text);
                xianjiaSum = Convert.ToDouble(xianjiaSum.ToString("f2"));
            }
            else {
                ifJoking = true;
            }
                
            String startStr = "外卖总共付了" + xianjiaSum  + "元" ;
            String endStr = "咱们下次再约！";
            String tmp = startStr + "\r\n";
            
            foreach (KeyValuePair<string, string> kv in result)
            {
                double yuanjia = 0;
                if (ifNumber(this.Controls.Find(kv.Key, false)[0].Text))
                {
                    yuanjia = Convert.ToDouble(this.Controls.Find(kv.Key, false)[0].Text);
                }
                else {
                    //ifJoking = true;
                }
                    yuanjiaSum += yuanjia;
                
                
            }
            foreach (KeyValuePair<string, string> kv in result)
            {
                double yuanjia = 0;
                if (ifNumber(this.Controls.Find(kv.Key, false)[0].Text))
                {
                    yuanjia = Convert.ToDouble(this.Controls.Find(kv.Key, false)[0].Text);
                    yuanjia = Convert.ToDouble(yuanjia.ToString("f2"));
                }
                else
                {
                    //ifJoking = true;
                }
                
                double xianjia = 0;
                if (yuanjiaSum > 0)
                {
                    xianjia = yuanjia / yuanjiaSum * xianjiaSum;
                    xianjia = Convert.ToDouble(xianjia.ToString("f2"));
                }
                else {
                    ifJoking = true;
                }
                if (xianjia > 0) {
                    tmp += "原价" + yuanjia + "元的同学，";
                    tmp += "现价" + xianjia + "元";
                    tmp += "\r\n";

                }
                
                
                
            }
            tmp += endStr;
            if (ifJoking) {
                tmp = "请输入正确的金额！";
            }

            return tmp;
        }





    }
}
