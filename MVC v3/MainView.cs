using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_v3
{
    public partial class MainView : Form
    {
        MainController mainController;
        Timer mainTimer;
        int timerTicks = 0;
        string sign = "+";

        internal void Init(MainController mainController)
        {
            this.mainController = mainController;
        }

        public MainView()
        {
            InitializeComponent();
            this.mainTimer = new Timer();
            mainTimer.Interval = 250;
            this.mainTimer.Tick += MainTimer_Tick;
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            timerTicks--;
            if (timerTicks <= 0)
            {
                mainTimer.Stop();
            }
            else
            {
                int newSize = sign == "+" ? (int)textBox2.Font.Size + 1 : (int)textBox2.Font.Size - 1;
                Font toSet = new Font(this.textBox2.Font.FontFamily, newSize, this.textBox2.Font.Style);
                textBox2.Font = toSet;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.mainController.TextChanged(textBox1.Text);
        }

        internal void TextChange(string newText)
        {
            textBox2.Text = newText;
        }

        internal void FontChange(Font oldFont, Font newFont)//V3
        {
            Font toSet = new Font(newFont.FontFamily, oldFont.Size, newFont.Style);
            this.textBox2.Font = toSet;
            this.timerTicks = (int)Math.Abs(oldFont.Size - newFont.Size);
            this.sign = (oldFont.Size - newFont.Size) >= 0 ? "-" : "+";
            // a = x==0 ? 3 : 4 
            this.mainTimer.Start();
        }

        internal void ColorChange(Color newColor)//V2
        {
            this.textBox2.ForeColor = newColor;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.mainController.ReverseOption(checkBox1.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.mainController.DeleteVowels(checkBox2.Checked);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.mainController.DeleteConsonants(checkBox3.Checked);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            this.mainController.DeleteDigit(checkBox4.Checked);
        }

        //private void buttonFont_Click(object sender, EventArgs e)//zmieniam czcionke(pierwsza wersja) 
        //{
        //    if (this.fontDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        this.textBox1.Font = this.fontDialog1.Font;
        //        this.textBox2.Font = this.fontDialog1.Font;
        //    }
        //}

        //private void buttonColor_Click(object sender, EventArgs e)//zmieniam kolor(pierwsza wersja)
        //{
        //    if (this.colorDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        this.textBox1.ForeColor = this.colorDialog1.Color;
        //        this.textBox2.ForeColor = this.colorDialog1.Color;
        //    }
        //}

        private void buttonFont_Click(object sender, EventArgs e)//zmieniam czcionke (druga wersja (V2))
        {
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.mainController.SetFont(this.fontDialog1.Font);
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)//zmieniam kolor(druga wersja (V2))
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.mainController.SetColor(this.colorDialog1.Color);
            }
        }
    }
}
