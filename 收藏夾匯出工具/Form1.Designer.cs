namespace 收藏夾匯出工具
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_OsuPath = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // lab_OsuPath
            // 
            this.lab_OsuPath.AutoSize = true;
            this.lab_OsuPath.Location = new System.Drawing.Point(13, 13);
            this.lab_OsuPath.Name = "lab_OsuPath";
            this.lab_OsuPath.Size = new System.Drawing.Size(82, 12);
            this.lab_OsuPath.TabIndex = 0;
            this.lab_OsuPath.Text = "osu資料夾: N/A";
            // 
            // btn_Export
            // 
            this.btn_Export.Enabled = false;
            this.btn_Export.Location = new System.Drawing.Point(357, 310);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 2;
            this.btn_Export.Text = "匯出";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(15, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(417, 276);
            this.treeView1.TabIndex = 3;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.Filter = "收藏夾|*.json";
            this.saveFileDialog1.OverwritePrompt = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 338);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.lab_OsuPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "收藏夾匯出工具  By 孤之界(jun112561)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_OsuPath;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

