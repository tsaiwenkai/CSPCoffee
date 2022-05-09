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

namespace CSPCoffee
{
    public partial class Productdetail : Form
    {
        CoffeeEntities1 db = new CoffeeEntities1();
        int pdID;
        public Productdetail(int productID)
        {
             pdID = productID;
            InitializeComponent();
            var name = db.Products.AsEnumerable().
                Where(p => p.ProductID == productID).
                Select(p =>
                new
                {
                    p.ProductName,
                    p.Categories.CategoriesName,                 
                    //p.Country.CountryName,     
                    //p.Coffee.Roasting.RoastingName,
                    //p.Coffee.Process.ProcessName,
                    //p.Coffee.Package.PackageName,
                    p.Price,
                    p.Description,
                    p.Stock,                   
                }).ToArray();            
            label1.Text = name[0].ProductName.ToString();
            lbcate.Text = name[0].CategoriesName.ToString();
            lbstock.Text = name[0].Stock.ToString();
            string pric = $"{name[0].Price:c2}元";
            lbprice.Text = pric;
            lbdescription.Text = name[0].Description.ToString();

            var coffee = db.Products.AsEnumerable().
                Where(p => p.ProductID == productID & p.CategoryID == 1).
                Select(p =>
                new
                {
                    p.ProductName,
                    p.Categories.CategoriesName,
                    p.Country.CountryName,
                    p.Coffee.Roasting.RoastingName,
                    p.Coffee.Process.ProcessName,
                    p.Coffee.Package.PackageName,
                    p.Price,
                    p.Description,
                    p.Stock,
                }).ToArray();

            if (coffee.Length != 0)
            {
                lbcountry.Text = coffee[0].CountryName.ToString();
                lbroast.Text = coffee[0].RoastingName.ToString();
                lbprocess.Text = coffee[0].ProcessName.ToString();
                lbpack.Text = coffee[0].PackageName.ToString();
            }
            else
            {
                lbcountry.Text = "";
                lbroast.Text = "";
                lbprocess.Text = "";
                lbpack.Text = "";
            }
            //圖片
            var photo = db.PhotoDetails.AsEnumerable().Where(p => p.ProductID == productID).Select(p => new { p.ProductID, p.Photos.Photo }).ToList();
            byte[] bytes = photo[0].Photo;
            MemoryStream ms = new MemoryStream(bytes);
            pictureBox1.Image = Image.FromStream(ms);
            //combobox

            var stock = db.Products.Where(p => p.ProductID == productID).Select(p => p.Stock ).ToArray();
              foreach(int a in stock)
            {
                for (int i = 1; i <=a && i<=10; i++)
                {
                    comboBox1.Items.Add(i);
                }                   
            }
        }
        int memberID = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //Productdetail pdd = (Productdetail)sender;

            if (memberID == 0)
            {
                MessageBox.Show("請登入會員");
            }
            else
            {
                //db.ShoppingCarDetail.Add(new ShoppingCarDetail { MemberID = memberID, ProductsID = pdID, Quantity = comboBox1.SelectedIndex + 1 });

                var q = new ShoppingCarDetail { MemberID = memberID, ProductsID = pdID, Quantity = comboBox1.SelectedIndex + 1 };
                db.ShoppingCarDetail.Add(q);
                db.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            memberID = 1;
        }
    }
}
