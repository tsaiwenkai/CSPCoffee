using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPCoffee
{
    public partial class Productdetail : Form
    {
        CoffeeEntities1 db = new CoffeeEntities1();
        public Productdetail(object x)
        {
            InitializeComponent();
            x = db.Products.AsEnumerable().ToArray();


        }
    }
}
