using LinqLabs;
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

namespace MyHomeWork
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // 創建 DataSet 和 TableAdapter
            AVWDataSet AVWDataSet = new AVWDataSet();
            LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter ProductPhotoTableAdapter = new LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter();

            // 填充資料
            ProductPhotoTableAdapter.Fill(AVWDataSet.ProductPhoto);

            // 使用 LINQ 查詢所有產品，顯示產品ID和產品名稱
            var allProducts = from photo in AVWDataSet.ProductPhoto
                              select new
                              {
                                  ProductID = photo.ProductPhotoID, // 假設這是產品ID
                                  PhotoName = "Product " + photo.ProductPhotoID // 自定義名稱，可以根據需要修改
                              };

            // 將產品列表綁定到 DataGridView
            dataGridView1.DataSource = allProducts.ToList();

            // 設定當前行選擇改變事件
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 取得選中的行
                int selectedProductID = (int)dataGridView1.SelectedRows[0].Cells["ProductID"].Value;

                // 創建 DataSet 和 TableAdapter 再次取得對應的產品照片
                AVWDataSet AVWDataSet = new AVWDataSet();
                LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter ProductPhotoTableAdapter = new LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter();

                // 填充資料
                ProductPhotoTableAdapter.Fill(AVWDataSet.ProductPhoto);

                // 使用 LINQ 查詢選中的產品照片
                var selectedPhoto = (from photo in AVWDataSet.ProductPhoto
                                     where photo.ProductPhotoID == selectedProductID
                                     select photo.LargePhoto).FirstOrDefault();

                // 如果找到照片，顯示在 PictureBox 中
                if (selectedPhoto != null)
                {
                    using (MemoryStream ms = new MemoryStream(selectedPhoto))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("找不到選中產品的照片！");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 創建 DataSet 和 TableAdapter
            AVWDataSet AVWDataSet = new AVWDataSet();
            LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter ProductPhotoTableAdapter = new LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter();

            // 填充資料
            ProductPhotoTableAdapter.Fill(AVWDataSet.ProductPhoto);

            // 取得 DateTimePicker1 和 DateTimePicker2 中選定的日期
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            // 使用 LINQ 查詢在日期區間中的產品
            var filteredProducts = from photo in AVWDataSet.ProductPhoto
                                   where photo.ModifiedDate >= startDate && photo.ModifiedDate <= endDate
                                   select new
                                   {
                                       ProductID = photo.ProductPhotoID,
                                       PhotoName = "Product " + photo.ProductPhotoID,
                                       ModifiedDate = photo.ModifiedDate // 假設有 ModifiedDate 欄位
                                   };

            // 將篩選後的產品列表顯示在 DataGridView 中
            dataGridView1.DataSource = filteredProducts.ToList();

            // 檢查是否有資料
            if (filteredProducts.Count() == 0)
            {
                MessageBox.Show("在所選的日期區間內沒有產品！");
            }
        }

        private void Frm作業_2_Load(object sender, EventArgs e)
        {
            // 創建 DataSet 和 TableAdapter
            AVWDataSet AVWDataSet = new AVWDataSet();
            LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter ProductPhotoTableAdapter = new LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter();

            // 填充資料
            ProductPhotoTableAdapter.Fill(AVWDataSet.ProductPhoto);

            // 使用 LINQ 查詢所有年份
            var allYears = (from photo in AVWDataSet.ProductPhoto
                            select photo.ModifiedDate.Year).Distinct().OrderBy(year => year);

            // 將年份添加到 ComboBox3
            comboBox3.DataSource = allYears.ToList();

            // 設定 DateTimePicker 的日期範圍 (之前的邏輯)
            var dateRange = (from photo in AVWDataSet.ProductPhoto
                             select photo.ModifiedDate);

            if (dateRange.Any())
            {
                DateTime minDate = dateRange.Min();
                DateTime maxDate = dateRange.Max();

                dateTimePicker1.Value = minDate;
                dateTimePicker2.Value = maxDate;
                dateTimePicker1.MinDate = minDate;
                dateTimePicker1.MaxDate = maxDate;
                dateTimePicker2.MinDate = minDate;
                dateTimePicker2.MaxDate = maxDate;
            }
            else
            {
                MessageBox.Show("無法取得產品的日期範圍！");
            }

            // 將四季選項添加到 ComboBox2
            var seasons = new Dictionary<int, string>
            {
                { 1, "第一季 (1-3月)" },
                { 2, "第二季 (4-6月)" },
                { 3, "第三季 (7-9月)" },
                { 4, "第四季 (10-12月)" }
            };

            comboBox2.DataSource = new BindingSource(seasons, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 獲取 ComboBox3 中選定的年份
            int selectedYear = (int)comboBox3.SelectedItem;

            // 創建 DataSet 和 TableAdapter
            AVWDataSet AVWDataSet = new AVWDataSet();
            LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter ProductPhotoTableAdapter = new LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter();

            // 填充資料
            ProductPhotoTableAdapter.Fill(AVWDataSet.ProductPhoto);

            // 使用 LINQ 查詢選定年份的產品
            var filteredProductsByYear = from photo in AVWDataSet.ProductPhoto
                                         where photo.ModifiedDate.Year == selectedYear
                                         select new
                                         {
                                             ProductID = photo.ProductPhotoID,
                                             PhotoName = "Product " + photo.ProductPhotoID,
                                             ModifiedDate = photo.ModifiedDate
                                         };

            // 將篩選結果顯示在 DataGridView 中
            dataGridView1.DataSource = filteredProductsByYear.ToList();

            if (!filteredProductsByYear.Any())
            {
                MessageBox.Show("該年份內沒有產品資料！");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 獲取 ComboBox2 中選定的季度 (Key 對應季度)
            int selectedSeason = ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key;

            // 創建 DataSet 和 TableAdapter
            AVWDataSet AVWDataSet = new AVWDataSet();
            LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter ProductPhotoTableAdapter = new LinqLabs.AVWDataSetTableAdapters.ProductPhotoTableAdapter();

            // 填充資料
            ProductPhotoTableAdapter.Fill(AVWDataSet.ProductPhoto);

            // 根據選定季度篩選產品資料
            var filteredProductsBySeason = from photo in AVWDataSet.ProductPhoto
                                           where GetSeason(photo.ModifiedDate) == selectedSeason
                                           select new
                                           {
                                               ProductID = photo.ProductPhotoID,
                                               PhotoName = "Product " + photo.ProductPhotoID,
                                               ModifiedDate = photo.ModifiedDate
                                           };

            // 將篩選結果顯示在 DataGridView 中
            dataGridView1.DataSource = filteredProductsBySeason.ToList();

            // 顯示符合條件的產品數量
            int productCount = filteredProductsBySeason.Count();
            MessageBox.Show($"選定的季度中有 {productCount} 筆產品資料！");

            if (!filteredProductsBySeason.Any())
            {
                MessageBox.Show("該季度內沒有產品資料！");
            }
        }

        private int GetSeason(DateTime date)
        {

            if (date.Month >= 1 && date.Month <= 3)
            {
                return 1; // 第一季
            }
            else if (date.Month >= 4 && date.Month <= 6)
            {
                return 2; // 第二季
            }
            else if (date.Month >= 7 && date.Month <= 9)
            {
                return 3; // 第三季
            }
            else
            {
                return 4; // 第四季
            }
        }
    }
}
