using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        readonly Calculator _calculator = new Calculator();
        readonly InfixNotationTransformer _infix = new InfixNotationTransformer();
        private string _result;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0" || richTextBox1.Text == _result)
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0") return;
            richTextBox1.AppendText(button.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0") return;
            richTextBox1.AppendText(String.Format(" {0} ",button.Text));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0") return;
            richTextBox1.AppendText(String.Format(" {0} ", button.Text));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0") return;
            richTextBox1.AppendText(String.Format(" {0} ", button.Text));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0") return;
            richTextBox1.AppendText(String.Format(" {0} ", button.Text));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0") return;
            richTextBox1.AppendText(String.Format(" {0} ", button.Text));
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0")
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (richTextBox1.Text == @"0")
            {
                richTextBox1.Text = button.Text;
            }
            else richTextBox1.AppendText(button.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == @"0" ) return;
            try
            {
                var rpnExpression = _infix.Transform(richTextBox1.Text);
                var localResult = _calculator.CalculateRPN(rpnExpression);
                richTextBox1.Text = localResult;
                _result = richTextBox1.Text;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(@"Please type second number!");
            }
            catch (OverflowException)
            {
                MessageBox.Show(@"The numbers are too big!");
                richTextBox1.Text = @"0";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
