using _2023_02_27_homework_test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2023_02_27_homework_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Trim() == "") || (textBox2.Text.Trim() == "") | (textBox3.Text.Trim() == "")| (textBox4.Text.Trim() == ""))
            {
                MessageBox.Show("格式錯誤");
                return;
            }
            Product_Table data = new Product_Table() 
            { 
                product_name = textBox1.Text.Trim(),
                product_quantity = int.Parse(textBox2.Text.Trim()),
                product_price= int.Parse(textBox3.Text.Trim()),
                product_type= textBox4.Text.Trim(),
            };
            try
            {
                ProductModels context = new ProductModels();
                context.Product_Table.Add(data);
                context.SaveChanges();
                MessageBox.Show("存檔完成");
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤 {ex.ToString()}");
            }
        }

        private void button2_Click(object sender, EventArgs e)//修改
        {
            ProductModels db = new ProductModels();
            int a = 0;
            if (textBox5.Text == "")
            {
                MessageBox.Show("格式錯誤");
                return;
            }
            else
            {
                a = int.Parse(textBox5.Text);
            }

            if (a > db.Product_Table.Count())
            {
                MessageBox.Show("查無此物");
            }
            var query = db.Product_Table.Where(x => x.product_id == a);
            var c = query.SingleOrDefault();
            if (c == null)
            {
                return;
            }
            try
            {
                if (textBox1.Text!="")
                {
                    c.product_name = textBox1.Text;
                }
                if (textBox2.Text != "")
                {
                    c.product_quantity = int.Parse(textBox2.Text);
                }
                if (textBox3.Text != "")
                {
                    c.product_price = int.Parse(textBox3.Text);
                }
                if (textBox4.Text != "")
                {
                    c.product_type = textBox4.Text;
                }
                db.SaveChanges();
                MessageBox.Show("修改成功");
                textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤 {ex.ToString()}");
            }
        }

        private void button3_Click(object sender, EventArgs e) //刪除
        {
            ProductModels db = new ProductModels();
            int a = 0;
            if (textBox5.Text == "")
            {
                MessageBox.Show("格式錯誤");
                return;
            }
            else
            {
                a = int.Parse(textBox5.Text);
            }

            if (a > db.Product_Table.Count())
            {
                MessageBox.Show("查無此物");
            }
            var query = db.Product_Table.Where(x => x.product_id == a);
            var c = query.SingleOrDefault();
            db.Product_Table.Remove(c);
            db.SaveChanges();
            textBox5.Clear();
            MessageBox.Show("刪除成功");
        }

        private void button4_Click(object sender, EventArgs e) //查詢商品
        {
            ProductModels db = new ProductModels();
            //string[] userInput = textBox5.Text.Split(',');
            
            int a = 0;
            if (textBox5.Text == "")
            {
                MessageBox.Show("格式錯誤");
                return;
            }
            else
            {
                 a = int.Parse(textBox5.Text);
            }
            
            if (a>db.Product_Table.Count())
            {
                MessageBox.Show("查無此物");
            }
            var query = db.Product_Table.Where(x=> x.product_id == a);
            if (query == null)
            {
                return;
            }
            dataGridView1.DataSource = query.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new ViewForm();
            form.Show();
        }
        private void ClearTextBoxes()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                
                MessageBox.Show("輸入錯誤，請輸入數字");
                e.Handled = true;
            }
        }
        private void AutoSizeColumn(DataGridView dgViewFiles)
         {
             int width = 0;
             
             for (int i = 0; i < dgViewFiles.Columns.Count; i++)
             {
                 dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                 width += dgViewFiles.Columns[i].Width;
             }
             if (width > dgViewFiles.Size.Width)
             {
                 dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
             }
             else
             {
                 dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             }
             dgViewFiles.Columns[1].Frozen = true;
            AutoSizeColumn(dgViewFiles);
        }
        
    }
    
    
}
