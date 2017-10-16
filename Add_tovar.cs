using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakaleya
{
    public partial class Add_tovar : Form
    {
        
        string name_good;
        string shelf;
        string amount;
        string name_firm;
        string street;
        string telephone;
      
        public Add_tovar()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        public string GOOD
        {
            get { return name_good; }
            set { name_good = value; }
        }
        public string SHELF
        {
            get { return shelf; }
            set { shelf = value; }
        }
        public string AMOUNT
        {
            get { return amount; }
            set { amount = value; }
        }
        public string FIRMA
        {
            get { return name_firm; }
            set { name_firm = value; }
        }
        public string STREET
        {
            get { return street; }
            set { street = value; }
        }
        public string TELE
        {
            get { return telephone; }
            set { telephone = value; }
        }
        private void povedinka()
        {
            GOOD = name_tovar.Text;
            SHELF = maskedTextBox1.Text;
            AMOUNT = maskedTextBox2.Text;
            FIRMA = textBox3.Text;
            STREET = textBox4.Text;
            TELE = textBox5.Text;
        }
        private void string_message(string text, string caption)//?
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Warning;
            MessageBox.Show(text, caption, buttons, ico);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            povedinka();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Are you sure?", "Apply", buttons, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                bool flag = true;
                if (name_tovar.Text == "")
                {
                    string_message("Enter product name", "Product Name");
                    flag = false;
                }

                if (textBox3.Text == "")
                {
                    string_message("Enter firm name", "Firm Name");
                    flag = false;
                }

                if (textBox4.Text == "")
                {
                    string_message("Enter addres of firm", "Addres");
                    flag = false;
                }

                if (maskedTextBox1.Text == "")
                {
                    string_message("Enter shelf", "Shelf");
                    flag = false;
                }

                if (maskedTextBox2.Text == "")
                {
                    string_message("Enter goods' count", "Count");
                    flag = false;
                }

                if (textBox5.Text == "")
                {
                    string_message("Enter telephone", "Telephone");
                    flag = false;
                }
                if (flag == true)
                {
                    button1.Enabled = true;
                    apply.Enabled = false;
                }
                else
                {
                    button1.Enabled = false;
                    apply.Enabled = true;
                }
            }
        }

        private void Add_tovar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
