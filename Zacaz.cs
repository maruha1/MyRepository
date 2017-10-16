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
    
    public partial class Zacaz : Form
    {
        
       
        private int sel_ind;//??
        private string kol;//??
        List<int> list_indexes;//??
        List<string> list_tovar;//??
        public Zacaz()
        {
            InitializeComponent();
           
            list_indexes = new List<int>();
            list_tovar = new List<string>();
        }
        private void create_table()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Rows.Add(ProductsList.TOVAR.Count);//net ego. gde ono?
            dataGridView1.AutoSize = true;

            for (int i = 0; i < ProductsList.TOVAR.Count; i++)
            {
                dataGridView1[0, i].Value = ProductsList.TOVAR[i].NAME;
                dataGridView1[1, i].Value = ProductsList.TOVAR[i].post.NAME_FIRM;//dvoinoy object vizivaem?
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void Zacaz_Load(object sender, EventArgs e)
        {
            
            create_table();
        }
        public int Get_index
        {
            get { return sel_ind; }
            set { sel_ind = value; }
        }
        public string Get_kol
        {
            get { return kol; }
            set { kol = value; }
        }
        public List<int> LIST_IND
        {
            get { return list_indexes; }
            set { list_indexes = value; }
        }
        public List<string> LIST_TOV
        {
            get { return list_tovar; }
            set { list_tovar = value; }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//neponyatnaya func
        {
            textBox2.Clear();//brehnya
            LIST_IND.Add(dataGridView1.CurrentRow.Index);
             LIST_TOV.Add(Get_kol);
            int i=0;
            foreach(var t in LIST_IND)
            {
                textBox2.Text += dataGridView1[0, t].Value + "  " + dataGridView1[1, t].Value + "--\t" + LIST_TOV[i] + System.Environment.NewLine;//chto za i??
                i++;
            }
        }

       

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Index);//ego voobshe net =.=
        }

        private void number_of_tovar_TextChanged(object sender, EventArgs e)
        {
            Get_kol = Convert.ToString(number_of_tovar.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//??
        {

        }
    }
}
