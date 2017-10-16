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
    public partial class Add_tovar_post : Form
    {
        string name_good;
        string shelf;
        string amount;
        string name_firm;
        string street;
        string telephone;
     

        public Add_tovar_post()
        {
            InitializeComponent();
            FillComboBox();
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
            //+++++++++++++++++++++++++++++++++++
            FIRMA = ProductsList.TOVAR[comboBox1.SelectedIndex].post.NAME_FIRM;
            STREET = ProductsList.TOVAR[comboBox1.SelectedIndex].post.ADDRES;
            TELE = ProductsList.TOVAR[comboBox1.SelectedIndex].post.TELEPH;
        }
       
        private void FillComboBox()
        {
            foreach (var str in ProductsList.NAME_FIRM_)
            {
                comboBox1.Items.Add(str);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void string_message(string text, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;//зачем это ваще? это типо окошко предупреждающее?
            MessageBoxIcon ico = MessageBoxIcon.Warning;
            MessageBox.Show(text, caption, buttons, ico);
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

                if (comboBox1.SelectedIndex == -1)//как он может быть -1? где мы это задаем?
                {
                    string_message("Choose firm", "Firm");
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

        private void button1_Click(object sender, EventArgs e)
        {
            povedinka();
            this.Close();
        }
    }
}
