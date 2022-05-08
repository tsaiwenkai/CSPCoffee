﻿using System;
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

        public PDcontrol(int x)
        {
            
            InitializeComponent();


            //產品名稱
            var name = db.Products.AsEnumerable().ToArray();
            label1.Text = name[x].ProductName.ToString();
            label1.Click += PDcontrol_Click;
            //產品價格
            string pric = $"{name[x].Price:c2}元";
            label2.Text = pric;
            label2.Click += PDcontrol_Click;
            //產品類別
            var catergory = db.Products.AsEnumerable().Select(p => p.Categories.CategoriesName).ToArray();
            string cat = $"{catergory[x]}";
            label3.Text = cat;
            label3.Click += PDcontrol_Click;
            //產品圖片
            var photo = db.PhotoDetails.AsEnumerable().Select(p => new { p.ProductID, p.Photos.Photo }).ToList();
            byte[] bytes = photo[x].Photo;
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