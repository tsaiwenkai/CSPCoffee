using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using static CSPCoffee.PDcontrol;




namespace CSPCoffee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyInitializer();
            dataGridView1.DataSource = db.PhotoDetails.AsEnumerable().Where(p => p.ProductID == 1).Select(p => new { p.ProductID, p.Photos.Photo }).ToList();
        }

        CoffeeEntities1 db = new CoffeeEntities1();
        internal void MyInitializer()
        {
            //var q = db.Products.Select(x => x.ProductName).ToArray();
            //var q1 = db.Categories.Select(x => x.CategoryName).ToArray();

            //AutoCompleteStringCollection strings = new AutoCompleteStringCollection();

            //strings.AddRange(q);
            //strings.AddRange(q1);

            //txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtSearch.AutoCompleteCustomSource = strings;
            //txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            var q = db.Products.ToArray();

                PDcontrol con = new PDcontrol(1);
                con.Left += 10;
                con.Cursor= System.Windows.Forms.Cursors.Hand;
                flowLayoutPanel1.Controls.Add(con);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = db.Products.ToArray();

            PDcontrol con = new PDcontrol(4);
            con.Left += 10;
            con.Cursor = System.Windows.Forms.Cursors.Hand;
            flowLayoutPanel1.Controls.Add(con);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = db.Products.ToArray();

            PDcontrol con = new PDcontrol(7);
            con.Left += 10;
            con.Cursor = System.Windows.Forms.Cursors.Hand;
            flowLayoutPanel1.Controls.Add(con);
        }
    }
}
