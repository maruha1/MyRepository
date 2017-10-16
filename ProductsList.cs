using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Bakaleya
{
    public class ProductsList
    {
        public static List<Product> TOVAR = new List<Product>();
        private StreamReader fil;
       private StreamWriter write;

       public ProductsList() { }
       
        public void create_lavka()
        {
            fil = new StreamReader("Test.txt");
            string line;
            int i;
            string[] param;
            while(!fil.EndOfStream)
            {

                i = 0;
                line = fil.ReadLine();
                if (line != String.Empty)
                {
                    param = line.Split(';');
                    TOVAR.Add(new Product(param[i], int.Parse(param[i + 1]), int.Parse(param[i + 2]), new Provisioner(param[i + 3], param[i + 4], param[i + 5])));
                }
            }
            fil.Close();
        }
        public void add(string name_tov, int shelf_, int val, string name_firm, string street, string number)
        {
            TOVAR.Add(new Product(name_tov, shelf_, val, new Provisioner(name_firm, street, number)));
        }
        
        public void delete_product(int ind)
        {
            TOVAR.RemoveAt(ind);
        }
        public List<int> OfThisFirm(string _firm_)
        {
            List<int> indexes = new List<int>();

            for (int count = 0; count < TOVAR.Count; count++)
            {
                if (TOVAR[count].post.NAME_FIRM == _firm_)
                    indexes.Add(count);
            }
            return indexes;
        }
        public List<int> SmallCountTovar()
        {
            List<int> indexes = new List<int>();
            for (int count = 0; count < TOVAR.Count; count++)
            {
                if (TOVAR[count].VALUE < 5)
                    indexes.Add(count);
            }
            return indexes;
        }
        public List<int> InStok()
        {
            List<int> indexes = new List<int>();
            for (int count = 0; count < TOVAR.Count; count++)
            {
                if (TOVAR[count].VALUE != 0)
                    indexes.Add(count);
            }
            return indexes;
        }
       

        public static List <string> NAME_FIRM_
        {
            get {
                List<string> a = new List<string>();
                foreach (var t in TOVAR)
                    {
                        a.Add(t.post.NAME_FIRM);
                    }
                return a;
                }
        }


        public static List<string> NAME_tovar_
        {
            get
            {
                List<string> a = new List<string>();
                foreach (var t in TOVAR)
                {
                    a.Add(t.NAME);
                }
                return a;
            }

        }

        public static List<int> SHELF_
        {
            get
            {
                List<int> a = new List<int>();
                for (int i = 0; i < TOVAR.Count; i++ )
                {
                    a.Add(TOVAR[i].PLACE);
                }
                return a;
            }
        }
        public static void ChangeProvisioner(string name, string addr, string tele, int index)
        {
            TOVAR[index].post.NAME_FIRM = name;
            TOVAR[index].post.ADDRES = addr;
            TOVAR[index].post.TELEPH = tele;
        }

        public void SaveChanges()
        {
            write = new StreamWriter("Test.txt");
            for (int j = 0; j < TOVAR.Count; j++)
            {
                string line = TOVAR[j].NAME + ";" + TOVAR[j].PLACE + ";" + TOVAR[j].VALUE + ";" + TOVAR[j].post.NAME_FIRM + ";" + TOVAR[j].post.ADDRES + ";" + TOVAR[j].post.TELEPH;
                write.WriteLine(line);
            }
            write.Close();
        }
    }
}
