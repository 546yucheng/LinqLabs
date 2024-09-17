namespace LinqLabs.作業
{
    partial class Frm作業_3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button36.Location = new System.Drawing.Point(23, 13);
            this.button36.Margin = new System.Windows.Forms.Padding(4);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(332, 39);
            this.button36.TabIndex = 143;
            this.button36.Text = "搜尋 班級學生成績";
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button37.Location = new System.Drawing.Point(23, 60);
            this.button37.Margin = new System.Windows.Forms.Padding(4);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(332, 39);
            this.button37.TabIndex = 142;
            this.button37.Text = "每個學生個人成績";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(332, 44);
            this.button1.TabIndex = 144;
            this.button1.Text = "隨機統計100個學生分數";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(277, 39);
            this.button2.TabIndex = 145;
            this.button2.Text = "依檔案大小分組檔案(大到小)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(468, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(277, 39);
            this.button3.TabIndex = 145;
            this.button3.Text = "依年分組檔案(大到小)";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(742, 246);
            this.dataGridView1.TabIndex = 146;
            // 
            // Frm作業_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button37);
            this.Name = "Frm作業_3";
            this.Text = "Frm作業_3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}