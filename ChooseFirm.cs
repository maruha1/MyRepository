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
    public partial class ChooseFirm : Form
    {

        string outFirm;
        public ChooseFirm()
        {
            InitializeComponent();
        }
        private void fill_combo_box()
        {
            ProductsList.NAME_FIRM_.Sort();
            var uniq = ProductsList.NAME_FIRM_.Distinct();
            foreach (var t in uniq)
            {
                Firms.Items.Add(t);
            }
        }
        public string firma
        {
            get { return outFirm; }
            set { outFirm = value; }
        }
        private void ChooseFirm_Load(object sender, EventArgs e)
        {
            fill_combo_box();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            firma = Convert.ToString(Firms.Items[Firms.SelectedIndex]);
            this.Close();
        }
    }
}
