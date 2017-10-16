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
    public partial class Otchet : Form
    {
        public Otchet(List<Product> prod, List<int> val)
        {
            InitializeComponent();
            prod.Sort((a,b)=>a.post.NAME_FIRM.CompareTo(b.post.NAME_FIRM));
            List<Product> p = new List<Product>();
            List<int> v = new List<int>();
            for (int i = 0; i < prod.Count; i++)
            {
                int sum = prod[i].VALUE;
                int vvv = prod[i].sale;
                while (i != prod.Count - 1 && (prod[i].post.NAME_FIRM.Equals(prod[i + 1].post.NAME_FIRM) && prod[i].NAME.Equals(prod[i + 1].NAME)))
                {
                    sum += prod[i+1].VALUE;
                    vvv += prod[i + 1].sale;
                    i++;
                }
                p.Add(new Product(prod[i].NAME, prod[i].PLACE, sum, new Provisioner(prod[i].post.NAME_FIRM, null, null), vvv));
                v.Add(vvv);
            }
            dataGridView1.Rows.Add(p.Count);
            for(int i=0; i<p.Count;i++)
            {
                dataGridView1[0, i].Value = p[i].NAME;
                dataGridView1[1, i].Value = p[i].post.NAME_FIRM;
                dataGridView1[2, i].Value = p[i].sale;
            }
        }
    }
}
