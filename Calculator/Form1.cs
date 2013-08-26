using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        readonly Calculator _calculator = new Calculator();
        readonly InfixNotationTransformer _infix = new InfixNotationTransformer();
        readonly Tokens _tokens = new Tokens();
        private string _result;

        public Form1()
        {
            InitializeComponent();
        }

        #region Buttons

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

        private void button20_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = @"0";
        }

        #endregion

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    var result = ConvertExpressionFromTextBox(NumericSystems.Binary);
                    richTextBox1.Text = result;
                }
            } 
        }

        private string ConvertExpressionFromTextBox(NumericSystems numericSystems)
        {
            List<string> tokenList = new List<string>();
            tokenList.Clear();
            tokenList = richTextBox1.Text.Split(' ').ToList();

            for (int i = 0; i < tokenList.Count; i++)
            {
                if (_tokens.IsNumber(tokenList[i]))
                {
                    int index = tokenList.IndexOf(tokenList[i]);
                    tokenList[index] = ConvertToGivenNumericSystem(tokenList[i], numericSystems);
                }
            }

            string result = string.Join(" ", tokenList);
            return result;
        }

        private string ConvertToGivenNumericSystem(string s, NumericSystems numericSystems)
        {
            string result = "";
            try
            {
                switch (numericSystems)
                {
                    case NumericSystems.Binary:
                        result = Convert.ToString(Convert.ToInt32(s, 10), 2);
                        break;
                    case NumericSystems.Decimal:
                        result = Convert.ToString(Convert.ToInt32(s, 2), 10);
                        break;
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show(@"The number is too big!");
                return "0";
            }

            return result;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    var result = ConvertExpressionFromTextBox(NumericSystems.Decimal);
                    richTextBox1.Text = result;
                }
            } 
        }

        
    }

    enum NumericSystems
    {
        Decimal,
        Binary,
    }
}
