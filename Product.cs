using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleya
{
    public class Product
    {
         int place, value_;
         string name;
         public Provisioner post;
         public int sale;
         public Product(string name, int plc, int val, Provisioner pst)
        {
            post = new Provisioner();
            this.post.ADDRES = pst.ADDRES;
            this.post.NAME_FIRM = pst.NAME_FIRM;
            this.post.TELEPH = pst.TELEPH;
            this.name = name;
            this.place = plc;
            this.value_ = val;
        }
        public Product(string name, int plc, int val, Provisioner pst, int sales)
        {
            post = new Provisioner();
            this.post.ADDRES = pst.ADDRES;
            this.post.NAME_FIRM = pst.NAME_FIRM;
            this.post.TELEPH = pst.TELEPH;
            this.name = name;
            this.place = plc;
            this.value_ = val;
            this.sale = sales;

        }
        public Product()
        {
            this.name = "";
            this.place = 1;
            this.value_ = 1;
            this.post.ADDRES = "";
            this.post.NAME_FIRM = "";
            this.post.TELEPH = "";
        }
        public int PLACE
        {
            get { return place; }
            set { place = value; }
        }
        public int VALUE
        {
            get { return value_; }
            set { value_ = value; }
        }
  
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

       /* public ProductsList ProductsList
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
