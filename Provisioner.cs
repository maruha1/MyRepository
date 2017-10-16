using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleya
{
    public class Provisioner
    {
         string name_firm, addres, telephone;
        public Provisioner(string n_f, string add, string tel)
        {
            this.name_firm = n_f;
            this.addres = add;
            this.telephone = tel;
        }
        public Provisioner()
        {
            this.name_firm = "";
            this.addres = "";
            this.telephone = "";
        }
        public string NAME_FIRM
        {
            get { return name_firm; }
            set { name_firm = value; }
        }
        public string ADDRES
        {
            get { return addres; }
            set { addres = value; }
        }
        public string TELEPH
        {
            get { return telephone; }
            set { telephone = value; }
        }

        /*public Product Product
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }*/
    }
}
