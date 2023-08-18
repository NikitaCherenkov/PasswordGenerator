using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public readonly string version = "1.1";
        public readonly Dictionary<string, string> symbols = new Dictionary<string, string>
        {
            { "a-z", "abcdefghijklmnopqrstuvwxyz" },
            { "A-Z", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
            { "numbers", "0123456789" },
            { "special", ".,-_=+*" },
            { "special_extended", "?()&^%$#@!<>" }
        };
        public Form1()
        {
            InitializeComponent();
            this.Text = "PasswordGenerator";
            labelVersion.Text = "Version: " + version;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (checkBox1.Checked) textBox1.Enabled = true;
                if (checkBox2.Checked) textBox2.Enabled = true;
                if (checkBox3.Checked) textBox3.Enabled = true;
                if (checkBox4.Checked) textBox4.Enabled = true;
                if (checkBox5.Checked) textBox5.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox6.Text, out int count) & (checkBox1.Checked | checkBox2.Checked | checkBox3.Checked | checkBox4.Checked | checkBox5.Checked))
            {
                string password = string.Empty;
                int temp = 0;
                var rand = new Random();
                if (!checkBox6.Checked)
                {
                    while (password.Length < count)
                    {
                        temp = rand.Next(5);
                        if (temp == 0 & checkBox1.Checked) password += symbols["a-z"][rand.Next(symbols["a-z"].Length)];
                        if (temp == 1 & checkBox2.Checked) password += symbols["A-Z"][rand.Next(symbols["A-Z"].Length)];
                        if (temp == 2 & checkBox3.Checked) password += symbols["numbers"][rand.Next(symbols["numbers"].Length)];
                        if (temp == 3 & checkBox4.Checked) password += symbols["special"][rand.Next(symbols["special"].Length)];
                        if (temp == 4 & checkBox5.Checked) password += symbols["special_extended"][rand.Next(symbols["special_extended"].Length)];
                    }
                }
                else
                {
                    string randomize = string.Empty;
                    Int32.TryParse(textBox1.Text, out int azCount);
                    if (checkBox1.Checked & azCount > 0)
                    {
                        for (int i = 0; i < azCount; i++)
                        {
                            randomize += "0";
                        }
                    }
                    Int32.TryParse(textBox2.Text, out int AZCount);
                    if (checkBox2.Checked & AZCount > 0)
                    {
                        for (int i = 0; i < AZCount; i++)
                        {
                            randomize += "1";
                        }
                    }
                    Int32.TryParse(textBox3.Text, out int numsCount);
                    if (checkBox3.Checked & numsCount > 0)
                    {
                        for (int i = 0; i < numsCount; i++)
                        {
                            randomize += "2";
                        }
                    }
                    Int32.TryParse(textBox4.Text, out int specialCount);
                    if (checkBox4.Checked & specialCount > 0)
                    {
                        for (int i = 0; i < specialCount; i++)
                        {
                            randomize += "3";
                        }
                    }
                    Int32.TryParse(textBox5.Text, out int special_extendedCount);
                    if (checkBox5.Checked & special_extendedCount > 0)
                    {
                        for (int i = 0; i < special_extendedCount; i++)
                        {
                            randomize += "4";
                        }
                    }
                    if (randomize.Length > 0)
                    {
                        while (password.Length < count)
                        {
                            temp = Int32.Parse(randomize[rand.Next(randomize.Length)].ToString());
                            if (temp == 0 & checkBox1.Checked) password += symbols["a-z"][rand.Next(symbols["a-z"].Length)];
                            if (temp == 1 & checkBox2.Checked) password += symbols["A-Z"][rand.Next(symbols["A-Z"].Length)];
                            if (temp == 2 & checkBox3.Checked) password += symbols["numbers"][rand.Next(symbols["numbers"].Length)];
                            if (temp == 3 & checkBox4.Checked) password += symbols["special"][rand.Next(symbols["special"].Length)];
                            if (temp == 4 & checkBox5.Checked) password += symbols["special_extended"][rand.Next(symbols["special_extended"].Length)];
                        }
                    }
                }
                textBoxPassword.Text = password;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (checkBox1.Checked)
                {
                    textBox1.Enabled = true;
                }
                else
                {
                    textBox1.Enabled = false;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (checkBox2.Checked)
                {
                    textBox2.Enabled = true;
                }
                else
                {
                    textBox2.Enabled = false;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (checkBox3.Checked)
                {
                    textBox3.Enabled = true;
                }
                else
                {
                    textBox3.Enabled = false;
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (checkBox4.Checked)
                {
                    textBox4.Enabled = true;
                }
                else
                {
                    textBox4.Enabled = false;
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (checkBox5.Checked)
                {
                    textBox5.Enabled = true;
                }
                else
                {
                    textBox5.Enabled = false;
                }
            }
        }
    }
}
