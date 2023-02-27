using _2023_02_27_homework_test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2023_02_27_homework_test
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
            BindData();
        }
        private void BindData()
        {
            var context = new ProductModels();
            var list = context.Product_Table.ToList();
            dataGridView1.DataSource = list;
        }
    }
}
