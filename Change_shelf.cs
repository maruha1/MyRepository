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
    public partial class Change_shelf : Form
    {
        int in_ind;//индекс, который мы будем получать, когда щелкаем по таблице 
        int out_ind;//индекс, который мы выберем из комбо-бокс
       
        public Change_shelf()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        private void create_table()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Rows.Add(ProductsList.TOVAR.Count);
            dataGridView1.AutoSize = true;
            for (int i = 0; i < ProductsList.TOVAR.Count; i++)
            {
                dataGridView1[0, i].Value = ProductsList.TOVAR[i].NAME;
                dataGridView1[1, i].Value = ProductsList.TOVAR[i].post.NAME_FIRM;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void fill_combo_box()
        {
            ProductsList.SHELF_.Sort();
            var uniq = ProductsList.SHELF_.Distinct();//
           
            foreach(var t in uniq)
            {
                comboBox2.Items.Add(t);
            }
        }
        private void Change_shelf_Load(object sender, EventArgs e)
        {
            create_table(); 
            fill_combo_box();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1[1,dataGridView1.CurrentRow.Index].Value);
        }
        public int in_index
        {
            get { return in_ind; }
            set { in_ind = value; }
        }
        public int out_index
        {
            get { return out_ind; }
            set { out_ind = value; }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)//???
        {
            in_ind = dataGridView1.CurrentRow.Index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                in_ind = dataGridView1.CurrentRow.Index;
                out_ind = Convert.ToInt32(comboBox2.Items[comboBox2.SelectedIndex]);
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

    }
}