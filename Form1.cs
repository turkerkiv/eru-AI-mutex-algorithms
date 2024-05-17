namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        Int128 finalNum;
        Int128 num1;
        Int128 num2;
        string opr;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            opr = "+";
            richTextBox1.Text += opr;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            opr = "-";
            richTextBox1.Text += opr;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (opr == "+")
            {
                finalNum = num1 + num2;
            }
            else if (opr == "-")
            {
                finalNum = num1 - num2;
            }
            else if (opr == "*")
            {
                finalNum = num1 * num2;
            }
            else if (opr == "/")
            {
                if(num2 == 0)
                {
                    finalNum = 0;
                    Clear();
                    richTextBox1.Text = "???";
                    return;
                }

                finalNum = num1 / num2;
            }
            else
            {
                return;
            }

            Clear();
            richTextBox1.Text = finalNum.ToString();
            num1 = finalNum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNum(1);

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddNum(2);

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AddNum(3);

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddNum(4);

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddNum(5);

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddNum(6);

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddNum(7);

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddNum(8);

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddNum(9);
        }

        void AddNum(int num)
        {
            if ((num1 * 10 + num) < 0  || (num2 * 10 + num) < 0)
            {
                Clear();
                return;
            }

            if (String.IsNullOrEmpty(opr))
            {
                num1 = num1 * 10 + num;
                richTextBox1.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * 10 + num;
                richTextBox1.Text = num2.ToString();
            }
        }

        void Clear()
        {
            num1 = 0;
            num2 = 0;
            richTextBox1.Text = "";
            opr = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AddNum(0);
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            opr = "/";
            richTextBox1.Text += opr;
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            opr = "*";
            richTextBox1.Text += opr;
        }
    }
}