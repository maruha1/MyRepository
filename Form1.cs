using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
namespace Bakaleya
{
    public partial class Form1 : Form
    {
        ProductsList sp;
        PrintDataToExcel exc;
        string filename;
        public Form1()
        {
            InitializeComponent();
            sp = new ProductsList();
            exc = new PrintDataToExcel();
            filename = "";
            Open_Excel.Enabled = false;
            this.KeyUp += new KeyEventHandler(KEY);
        }
        private void table_after_add_goods()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 6;
            dataGridView1.Rows.Add(ProductsList.TOVAR.Count);
            dataGridView1.AutoSize = true;
            for (int i = 0; i < ProductsList.TOVAR.Count; i++)
            {
                dataGridView1[0, i].Value = ProductsList.TOVAR[i].NAME;
                dataGridView1[1, i].Value = ProductsList.TOVAR[i].PLACE;
                dataGridView1[2, i].Value = ProductsList.TOVAR[i].VALUE;
                dataGridView1[3, i].Value = ProductsList.TOVAR[i].post.NAME_FIRM;
                dataGridView1[4, i].Value = ProductsList.TOVAR[i].post.ADDRES;
                dataGridView1[5, i].Value = ProductsList.TOVAR[i].post.TELEPH;
            }
        }
        private void headers_name()
        {
            List<string> header_name = new List<string>();
            header_name.Add("Продукт");
            header_name.Add("Полка");
            header_name.Add("Количество");
            header_name.Add("Фирма");
            header_name.Add("Адрес");
            header_name.Add("Телефон");
            for (int k = 0; k < header_name.Count; k++)
                dataGridView1.Columns[k].HeaderText = header_name[k];
            this.Width += 10;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            sp.create_lavka();
            
            table_after_add_goods();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            headers_name();
        }
        private List<int> Count()//4to ona delaet?
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < ProductsList.TOVAR.Count; i++)
                temp.Add(i);
            return temp;
        }
        private void excel_Click(object sender, EventArgs e)
        {
            ChooseFirm choseFirm = new ChooseFirm();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Создать Excel файл?", "Создать", buttons);
            if(result==System.Windows.Forms.DialogResult.Yes)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    choseFirm.ShowDialog();
                    List<int> conter = new List<int>();
                    filename = openFileDialog1.FileName;
                    exc.Open(false,filename);

                    exc.add_data_in_cells(ProductsList.TOVAR,Count(), 1, "Все продукты");

                    conter = sp.OfThisFirm(choseFirm.firma);
                    exc.add_data_in_cells(ProductsList.TOVAR, conter, 2, ("От ") + choseFirm.firma.ToLower());
                    conter = sp.SmallCountTovar();
                    exc.add_data_in_cells(ProductsList.TOVAR, conter, 3, "Пополнить");
                    exc.Save();
                    exc.Quit();
                    Open_Excel.Enabled = true;
                }
            }
        }

        private void Open_Excel_Click(object sender, EventArgs e)
        {
            exc.Open(true,filename);
        }

        

        private void shelfToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Change_shelf sh = new Change_shelf();
           sh.ShowDialog();
           if (sh.DialogResult == System.Windows.Forms.DialogResult.OK)
           ProductsList.TOVAR[sh.in_index].PLACE = sh.out_index;
           for (int j = 0; j < ProductsList.TOVAR.Count; j++)
           {
               dataGridView1[1, j].Value = ProductsList.TOVAR[j].PLACE;
           }
        }

        private void Delete()
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Вы уверены?", "Удалить", buttons, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (ProductsList.TOVAR.Count == 1)
                {
                    MessageBox.Show("Продукт не может быть удалён, так как он единственный.","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sp.delete_product(dataGridView1.CurrentRow.Index);
                table_after_add_goods();
            }
        }

        private void KEY(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Delete();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_tovar a = new Add_tovar();
            if (a.ShowDialog() == DialogResult.OK)
            {
                sp.add(a.GOOD, Convert.ToInt32(a.SHELF), Convert.ToInt32(a.AMOUNT), a.FIRMA, a.STREET, a.TELE);//как мы имеем доступ к этим полям отсюда аж? они ж берутся с формы add_tovar?
                table_after_add_goods();
            }
        }

        private void current_postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_tovar_post a = new Add_tovar_post();
            if (a.ShowDialog() == DialogResult.OK)
            {
                sp.add(a.GOOD, Convert.ToInt32(a.SHELF), Convert.ToInt32(a.AMOUNT), a.FIRMA, a.STREET, a.TELE);
                table_after_add_goods();
            }
        }

        private void productToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Zacaz z = new Zacaz();
            z.ShowDialog();
            int i = 0;
            foreach (var t in z.LIST_IND)//??????
            {
                ProductsList.TOVAR[t].VALUE = ProductsList.TOVAR[t].VALUE + Convert.ToInt32(z.LIST_TOV[i]);//??
                i++;
            }

            for (int j = 0; j < ProductsList.TOVAR.Count; j++)
            {
                dataGridView1[2, j].Value = ProductsList.TOVAR[j].VALUE;
            }
        }

        private void product_shellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_shelf sh = new Change_shelf();
            sh.ShowDialog();
            if (sh.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ProductsList.TOVAR[sh.in_index].PLACE = sh.out_index;
                table_after_add_goods();
            }
        }

        private Random rand = new Random();
        List<Product> otchet;
        List<int> value;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Product product = ProductsList.TOVAR[rand.Next(ProductsList.TOVAR.Count)];
            int val = rand.Next(1, 10);
            product.VALUE -= val;
            value.Add(val);
            product.sale = val;
            otchet.Add(product);


            for (int j = 0; j < ProductsList.TOVAR.Count; j++)
            {
                if (ProductsList.TOVAR[j].VALUE <= 0)
                    ProductsList.TOVAR[j].VALUE =0;
                dataGridView1[2, j].Value = ProductsList.TOVAR[j].VALUE;
            }

            StreamWriter write = new StreamWriter("Test.txt");

            for (int j = 0; j < ProductsList.TOVAR.Count; j++)
            {
                
                string line = ProductsList.TOVAR[j].NAME + ";" + ProductsList.TOVAR[j].PLACE + ";" + ProductsList.TOVAR[j].VALUE + ";" + ProductsList.TOVAR[j].post.NAME_FIRM + ";" + ProductsList.TOVAR[j].post.ADDRES + ";" + ProductsList.TOVAR[j].post.TELEPH;
                write.WriteLine(line);
            }
            write.Close();
        }

        private void Otchet(Product product)
        {
            List<Product> otchet = new List<Product>();
            otchet.Add(product);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Начать продажу")
            {
                value = new List<int>();
                otchet = new List<Product>();
                timer_sell.Enabled = true;
                button1.Text = "Остановить продажу";
            }
            else
            {
                timer_sell.Enabled = false;
                button1.Text = "Начать продажу";
                Otchet o = new Otchet(otchet,value);
                o.ShowDialog();
            }
            
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Сохранить изменения?", "Сохранить", buttons, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                sp.SaveChanges();
            }
        }

        private void provisionerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ChangeProvisioner ch = new ChangeProvisioner();
                ch.ShowDialog();
                table_after_add_goods();
        }
    }
}
