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
    public partial class PDcontrol : UserControl
    {
        CoffeeEntities1 db = new CoffeeEntities1();

        public PDcontrol(int group,int count)
        {
            
            InitializeComponent();


            //產品名稱
            var name = db.Products.AsEnumerable().Where(p=>p.CategoryID==group).ToArray();
            label1.Text = name[count].ProductName.ToString();
            label1.Click += PDcontrol_Click;
            //產品價格
            string pric = $"{name[count].Price:c2}元";
            label2.Text = pric;
            label2.Click += PDcontrol_Click;
            //產品類別
            var Catergory = db.Products.AsEnumerable().Where(p=>p.CategoryID==group).Select(p => p.Categories.CategoriesName).ToArray();
            string ctg = $"{Catergory[count]}";
            label3.Text = ctg;
            label3.Click += PDcontrol_Click;
            //產品圖片
            var photo = db.PhotoDetails.AsEnumerable().Select(p => new { p.Products.CategoryID,p.ProductID, p.Photos.Photo }).ToList();
            byte[] bytes = photo[count].Photo;
            MemoryStream ms = new MemoryStream(bytes);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.Click += PDcontrol_Click;
        }

        private void PDcontrol_Click(object sender, EventArgs e)
        {
            Productdetail pd = new Productdetail(sender);
            pd.Show();
        }
    }
}
