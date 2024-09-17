using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_3 : Form
    {
        List<Student> students_scores;
        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; } // Chinese
            public int Eng { get; set; } // English
            public int Math { get; set; } // Math
            public string Gender { get; set; }
        }
        public Frm作業_3()
        {
            InitializeComponent();

            students_scores = new List<Student>()
        {
            new Student { Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
            new Student { Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
            new Student { Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
            new Student { Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
            new Student { Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
            new Student { Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },
        };
        }
    
        private void button36_Click(object sender, EventArgs e)
        {
            // 將所有學生成績資料顯示在 DataGridView 中
            dataGridView1.DataSource = students_scores.Select(s => new
            {
                Name = s.Name,
                Class = s.Class,
                Chinese = s.Chi,
                English = s.Eng,
                Math = s.Math,
                Gender = s.Gender
            }).ToList();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //個人 sum, min, max, avg
            // 統計 每個學生個人成績 並排序
            // 針對每個學生進行成績統計
            var studentStats = students_scores.Select(s => new
            {
                Name = s.Name,
                Class = s.Class,
                Sum = s.Chi + s.Eng + s.Math,    // 總分
                Min = new[] { s.Chi, s.Eng, s.Math }.Min(),  // 最低分
                Max = new[] { s.Chi, s.Eng, s.Math }.Max(),  // 最高分
                Avg = (s.Chi + s.Eng + s.Math) / 3.0,        // 平均分
                Gender = s.Gender
            })
            // 按總分進行降序排序
            .OrderByDescending(s => s.Sum)
            .ToList();

            // 將統計結果顯示在 DataGridView 中
            dataGridView1.DataSource = studentStats;

        }
    }
}
