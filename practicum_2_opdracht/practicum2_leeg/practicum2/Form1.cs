using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace practicum2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random random = new Random();
            this.num1Text.Text = random.Next(10).ToString();
            this.num2Text.Text = random.Next(10).ToString();
            this.num3Text.Text = random.Next(10).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = Int32.Parse(num1Text.Text);
            int num2 = Int32.Parse(num2Text.Text);
            int num3 = Int32.Parse(num3Text.Text);
            
            String output = MethodRunner.RunAllMethods(num1,num2,num3);
            methodOutput.Text = output;
            String[] method = output.Split(new string[] { "\n" }, StringSplitOptions.None);

            output = LambdaRunner.RunAllMethods(num1,num2,num3);
            lambdaOutput.Text = output;
            String[] lambda = output.Split(new string[] { "\n" }, StringSplitOptions.None);

            int index = 0;
            bool isFalse = false;
            foreach (string s in lambda)
            {
                if (index < 6)
                {
                    if (lambda[index].Split(new string[] { " = " }, StringSplitOptions.None)[1] != method[index].Split(new string[] { " = " }, StringSplitOptions.None)[1])
                    {
                        isFalse = true;
                    }
                    index += 1;
                }
            }

            if (isFalse)
            {
                System.Windows.Forms.MessageBox.Show("Results not Ok");
            } else
            {
                System.Windows.Forms.MessageBox.Show("Results Ok");
            }
        }
    }
}
