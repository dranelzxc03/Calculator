using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorOnSteroidsProgram
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
        string opr;
        float result = 0;

        private float inputNo1 = 0, inputNo2 = 0;
        int isOprClickCount = 0;
        bool isEqualClicked = false, isOprClicked = false, isMemoryClicked = false;


        public void btn_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!isOperatorButtonClick(button))// if the button is a number
            {
                if (isOprClicked)
                {
                    inputNo1 = float.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
            
                if (!textBox1.Text.Contains("."))
                {
                    if (textBox1.Text.Equals("0") && !button.Text.Equals("."))
                    {
                       
                        textBox1.Text = button.Text;
                        isOprClicked = false;
                    }
                   
                    else
                    {
                        textBox1.Text += button.Text;
                        isOprClicked = false;
                    }
                }

                else if (!button.Text.Equals("."))
                {
                    textBox1.Text += button.Text;
                    isOprClicked = false;
                }
               
            }
            else // if the button is an operator [+ - / * =]
            {
                if (isOprClickCount == 0)// if it's the first time we click on an operator
                {
                    isOprClickCount++;
                    inputNo1 = float.Parse(textBox1.Text);
                    opr = button.Text;
                    isOprClicked = true;
                }
                else
                {
                    if (!button.Text.Equals("="))// if the operation is not "="
                    {
                        if (!isEqualClicked)
                        {
                            inputNo2 = float.Parse(textBox1.Text);
                            textBox1.Text = Convert.ToString(toCalculate(opr, inputNo1, inputNo2));
                            result = float.Parse(textBox1.Text);
                            opr = button.Text;
                            isOprClicked = true;
                            isEqualClicked = false;
                            if(inputNo2 != 0)
                            {
                                savedintoList();
                            }

                        }
                        else
                        {
                            isEqualClicked = false;
                            opr = button.Text;
                        }
                    }
                    else
                    {
                        inputNo2 = float.Parse(textBox1.Text);
                        textBox1.Text = Convert.ToString(toCalculate(opr, inputNo1, inputNo2));
                        result = float.Parse(textBox1.Text);
                        isOprClicked = true;
                        isEqualClicked = true;
                        savedintoList();



                    }
                }
            }

        }
        public void savedintoList()
        {
            if (!isMemoryClicked)
            {
                var historyItems = new ListViewItem(new[] { inputNo1.ToString() + " " + opr + " " + " " + inputNo2.ToString() + " = " + result });
                listView1.Items.Add(historyItems);
            }
                else
                { 
                var historyItems = new ListViewItem(new[] { textBox1.Text });
                listView2.Items.Add(historyItems);
                }

        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    if(c.Text != "CE" && c.Text != "C" && c.Text != "MS" && c.Text != "M+" && c.Text != "M-" && c.Text != "MC" && c.Text != "MR")
                        c.Click += new EventHandler(btn_click);
                   
                }
            }
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            inputNo1 = 0;
            inputNo2 = 0;
            opr = "";
            isOprClicked = false;
            isEqualClicked = false;
            isOprClickCount = 0;
            textBox1.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            inputNo1 = 0;
            inputNo2 = 0;
            opr = "";
            isOprClicked = false;
            isEqualClicked = false;
            isOprClickCount = 0;
            textBox1.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
                listView1.Items[0].Selected = true;
            float SelectedId = (float.Parse(listView2.SelectedItems[0].Text) + float.Parse(textBox1.Text));
            listView2.SelectedItems[0].Text = Convert.ToString(SelectedId);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
               listView2.Items[0].Selected = true;
            float SelectedId = (float.Parse(listView2.SelectedItems[0].Text) - float.Parse(textBox1.Text));
            listView2.SelectedItems[0].Text = Convert.ToString(SelectedId);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0')
            {
                e.Handled = true;
                button42.PerformClick();
            }
            if(e.KeyChar == '1')
            {
                e.Handled = true;
                button36.PerformClick();
            }
            if (e.KeyChar == '2')
            {
                e.Handled = true;
                button35.PerformClick();
            }
            if (e.KeyChar == '3')
            {
                e.Handled = true;
                button34.PerformClick();
            }
            if (e.KeyChar == '4')
            {
                e.Handled = true;
                button24.PerformClick();
            }
            if (e.KeyChar == '5')
            {
                e.Handled = true;
                button23.PerformClick();
            }
            if (e.KeyChar == '6')
            {
                e.Handled = true;
                button22.PerformClick();
            }
            if (e.KeyChar == '7')
            {
                e.Handled = true;
                button18.PerformClick();
            }
            if (e.KeyChar == '8')
            {
                e.Handled = true;
                button35.PerformClick();
            }
            if (e.KeyChar == '9')
            {
                e.Handled = true;
                button36.PerformClick();
            }
            if (e.KeyChar == '+')
            {
                e.Handled = true;
                button39.PerformClick();
            }
            if (e.KeyChar == '-')
            {
                e.Handled = true;
                button33.PerformClick();
            }
            if (e.KeyChar == '/')
            {
                e.Handled = true;
                button15.PerformClick();
            }
            if (e.KeyChar == '=')
            {
                e.Handled = true;
                button38.PerformClick();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                button38.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           foreach(ListViewItem eachItem in listView2.SelectedItems)
            {
                listView2.Items.Remove(eachItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(textBox1.Text != null)
            {
                textBox1.Text = textBox1.Text;
            }
           else if(textBox1.Text != null)
            {
                textBox1.Text = textBox1.Text;
            }
            isMemoryClicked = true;
            savedintoList();
        }

        public bool isOperatorButtonClick(Button button)
        {
            string buttonOperator = button.Text;

            if (buttonOperator.Equals("+") ||
                buttonOperator.Equals("*") ||
                buttonOperator.Equals("-") ||
                buttonOperator.Equals("/") ||
                buttonOperator.Equals("="))
                return true;
            else
                return false;
        }
        public float toCalculate(string Operator, float input1,float input2)
        {
           
            switch (Operator)
            {
                case "+":
                    result = input1 + input2;
                    break;
                case "-":
                    result = input1 - input2;
                    break;
                case "*":
                    result = input1 * input2;
                    break;
                case "/":
                    if(input1 != 0)
                    result = input1 / input2;
                    break;
            }
            return result;
        }

    }
}
