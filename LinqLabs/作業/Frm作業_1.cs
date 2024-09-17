using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);

            var q1 = from o in this.nwDataSet1.Orders
                     select o.OrderDate.Year;

            this.comboBox1.DataSource = q1.Distinct().ToList();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblDetails.Text = "Order details";

                //NOTE
                var OrderID = ((NWDataSet.OrdersRow)this.bindingSource1.Current).OrderID;

                var q = from o in this.nwDataSet1.Order_Details
                        where o.OrderID == OrderID
                        select o;

                this.dataGridView2.DataSource = q.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int.TryParse(this.textBox1.Text, out countPerPage);

            page += 1;
            this.dataGridView1.DataSource = this.nwDataSet1.Products.Skip(countPerPage * page).Take(countPerPage).ToList();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles("*.log");
            var fileList = new List<FileDetail>();

            foreach (var file in files)
            {
                fileList.Add(new FileDetail
                {
                    FileName = file.Name,
                    FileSize = file.Length,
                    CreationTime = file.CreationTime
                });
            }
            this.dataGridView1.DataSource = fileList;
        }
        public class FileDetail
        {
            public string FileName { get; set; }
            public long FileSize { get; set; }
            public DateTime CreationTime { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var fileList = new List<FileDetail>();

            var filteredFiles = files.Where(f => f.CreationTime.Year > 2017);

            foreach (var file in filteredFiles)
            {
                fileList.Add(new FileDetail
                {
                    FileName = file.Name,
                    FileSize = file.Length,
                    CreationTime = file.CreationTime
                });
            }

            this.dataGridView1.DataSource = fileList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            this.dataGridView1.DataSource = files;

            var q = from f in files
                    where f.Length > 2000
                    select f;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NWDataSet NWDataSet = new NWDataSet();
            LinqLabs.NWDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter = new LinqLabs.NWDataSetTableAdapters.OrdersTableAdapter();

            ordersTableAdapter.Fill(NWDataSet.Orders);

            var allOrders = from order in NWDataSet.Orders
                            select new
                            {
                                order.OrderID,
                                order.CustomerID,
                                order.OrderDate,
                                order.ShipCountry
                            };

            this.dataGridView1.DataSource = allOrders.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayAllOrders();
            this.dataGridView2.DataSource = null;
        }

        private void DisplayAllOrders()
        {
            var allOrders = from o in this.nwDataSet1.Orders
                            select o;

            this.dataGridView1.DataSource = allOrders.ToList();

            this.dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;
            this.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        int page = -1;
        int countPerPage = 10;
        private void button12_Click(object sender, EventArgs e)
        {
            int.TryParse(this.textBox1.Text, out countPerPage);

            page -= 1;
            this.dataGridView1.DataSource = this.nwDataSet1.Products.Skip(countPerPage * page).Take(countPerPage).ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    var selectedOrder = (DataRowView)this.dataGridView1.SelectedRows[0].DataBoundItem;

                    int orderId = selectedOrder["OrderID"] != DBNull.Value ? (int)selectedOrder["OrderID"] : 0;

                    MessageBox.Show($"Selected OrderID: {orderId}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var orderDetails = from od in this.nwDataSet1.Order_Details
                                       where od.OrderID == orderId
                                       select od;

                    if (!orderDetails.Any())
                    {
                        MessageBox.Show("No order details found for the selected OrderID.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.dataGridView2.DataSource = orderDetails.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year;
            if (int.TryParse(this.comboBox1.Text, out year))
            {
                var filteredOrders = from o in this.nwDataSet1.Orders
                                     where o.OrderDate.Year == year
                                     select o;

                this.dataGridView1.DataSource = filteredOrders.ToList();
            }
        }


    }
}
