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
    public partial class ChangeProvisioner : Form
    {
        private string NameF;
        private string AddrF;
        private string TelepF;

        public ChangeProvisioner()
        {
            InitializeComponent();
            button1.Enabled = false;
            FillData();//заполнить комбо-бокс
        }
        private void FillData()
        {
            foreach (var t in ProductsList.NAME_FIRM_)
            {
                comboBox1.Items.Add(t);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameFirm.Text = ProductsList.TOVAR[comboBox1.SelectedIndex].post.NAME_FIRM;
            AddresFirm.Text = ProductsList.TOVAR[comboBox1.SelectedIndex].post.ADDRES;
            telephone.Text = ProductsList.TOVAR[comboBox1.SelectedIndex].post.TELEPH;
        }

        private void NameFirm_TextChanged(object sender, EventArgs e)
        {
            if (NameFirm.Text.Length < 2 || AddresFirm.Text.Length < 2 || telephone.Text.Length < 2)
                button1.Enabled = false;
            else
            {
                button1.Enabled = true;
                NameF = NameFirm.Text;
            }
        }

        private void AddresFirm_TextChanged(object sender, EventArgs e)
        {
            if (AddresFirm.Text.Length < 2||NameFirm.Text.Length < 2 || telephone.Text.Length < 2)
                button1.Enabled = false;
            else
            {
                button1.Enabled = true;
                AddrF = AddresFirm.Text;
            }
        }

        private void telephone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (telephone.Text.Length < 2 || NameFirm.Text.Length < 2 || AddresFirm.Text.Length < 2)
                button1.Enabled = false;
            else
            {
                button1.Enabled = true;
                TelepF = telephone.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductsList.ChangeProvisioner(NameFirm.Text, AddresFirm.Text, telephone.Text, comboBox1.SelectedIndex);
            //ProductsList.TOVAR[comboBox1.SelectedIndex].post.NAME_FIRM = NameFirm.Text;
            //ProductsList.TOVAR[comboBox1.SelectedIndex].post.ADDRES = AddresFirm.Text;
            //ProductsList.TOVAR[comboBox1.SelectedIndex].post.TELEPH = telephone.Text;
            this.Close();
        }

    }
}
