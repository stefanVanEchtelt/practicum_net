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

            // Console.WriteLine(lambda[0].Split(new string[] { " = " }, StringSplitOptions.None)[1]);

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
                    index = index + 1;
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
