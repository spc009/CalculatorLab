using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        //initilization
        int B = 0, stage = 1;
        double x1, x2;
        bool keep = false, cal = false;
        private bool keepX1 = false, keepX2 = false;

        public Form1()
        {
            InitializeComponent();
        }

        //0-9 click
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            if (stage != 1) //in case that btnEqual_click before
            {
                stage = 1;
                clear();
            }
            if (lblDisplay.Text == "0" || keep) //in case new number
                lblDisplay.Text = "";
            if (lblDisplay.Text.Length <= 8) lblDisplay.Text = lblDisplay.Text + btnX.Text;
            keep = false;
            cal = false;
        }

        //Calculate
        private void Calculate(int B)
        {
            if (!keep)
            {
                if (keepX1)
                {
                    x2 = Convert.ToDouble(lblDisplay.Text);
                    keepX2 = true;
                    keep = true;
                }
                else
                {
                    x1 = Convert.ToDouble(lblDisplay.Text);
                    keepX1 = true;
                    keep = true;
                }
            }
            if (keepX2 && keepX1)
            {
                switch (B)
                {

                    case 1:
                        x1 = x1 + x2;
                        break;
                    case 2:
                        x1 = x1 - x2;
                        break;
                    case 3:
                        x1 = x1 * x2;
                        break;
                    case 4:
                        if (x2 == 0) lblDisplay.Text = "EROR";
                        else x1 = x1 / x2;
                        break;
                }
                cal = true;
            }
            lblDisplay.Text = Convert.ToString(x1);
        }
        //Operator
        //Equal
        private void btnEqual_Click(object sender, EventArgs e)
        {
            ++stage;
            Calculate(B);
            lblDisplay.Text = Convert.ToString(x1);
        }
        //Plus
        private void btnPlus_Click(object sender, EventArgs e)
        {
            stage = 1;
            B = 1;
            keepX2 = false;
            if (!cal) Calculate(B);
        }
        //Sign
        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = Convert.ToString(Convert.ToDouble(lblDisplay.Text) * (-1));
        }
        //Minus
        private void btnMinus_Click(object sender, EventArgs e)
        {
            stage = 1;
            keepX2 = false;
            if (!cal) Calculate(B);
            B = 2;
        }
        //Multiply
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            stage = 1;
            keepX2 = false;
            if (!cal) Calculate(B);
            B = 3;
        }
        //Divide
        private void btnDivide_Click(object sender, EventArgs e)
        {
            stage = 1;
            keepX2 = false;
            if (!cal) Calculate(B);
            B = 4;
        }
        //Percentage
        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (B == 1 || B == 2)
            {
                x2 = (x1 * Convert.ToDouble(lblDisplay.Text) / 100);
                lblDisplay.Text = Convert.ToString(x2);
            }
            else
                x2 = Convert.ToDouble(lblDisplay.Text) / 100;
            
        }
        //Back
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length == 1||(Convert.ToDouble(lblDisplay.Text)<10&& Convert.ToDouble(lblDisplay.Text) > -10)) lblDisplay.Text = "0";
            else if (B != 0)
            {
                B = 0;
                ++stage;
            }
            else lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);

        }
        //Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            lblDisplay.Text = "0";
            stage = 1;
            keepX1 = false;
            keepX2 = false;
            keep = false;
            B = 0;
        }

    }
}
