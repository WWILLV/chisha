namespace ChiSha
{
    partial class FM_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FM_main));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_random = new System.Windows.Forms.Button();
            this.randomNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_updateData = new System.Windows.Forms.Button();
            this.btn_setting = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.getDataPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pyPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataPath = new System.Windows.Forms.TextBox();
            this.dataGrid_random = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.steps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_getRecipe = new System.Windows.Forms.Button();
            this.btn_browser = new System.Windows.Forms.Button();
            this.recipe = new System.Windows.Forms.TextBox();
            this.chishaBrowser = new System.Windows.Forms.WebBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_server = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomNum)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_random)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(96, 30);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_server);
            this.tabPage1.Controls.Add(this.dataGrid_random);
            this.tabPage1.Controls.Add(this.btn_random);
            this.tabPage1.Controls.Add(this.randomNum);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "吃啥？";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_random
            // 
            this.btn_random.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_random.Location = new System.Drawing.Point(191, 6);
            this.btn_random.Name = "btn_random";
            this.btn_random.Size = new System.Drawing.Size(92, 26);
            this.btn_random.TabIndex = 2;
            this.btn_random.Text = "整！";
            this.btn_random.UseVisualStyleBackColor = true;
            this.btn_random.Click += new System.EventHandler(this.btn_random_Click);
            // 
            // randomNum
            // 
            this.randomNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.randomNum.Location = new System.Drawing.Point(90, 6);
            this.randomNum.Name = "randomNum";
            this.randomNum.Size = new System.Drawing.Size(82, 26);
            this.randomNum.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "几个菜？";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chishaBrowser);
            this.tabPage2.Controls.Add(this.recipe);
            this.tabPage2.Controls.Add(this.btn_browser);
            this.tabPage2.Controls.Add(this.btn_getRecipe);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 412);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "浏览菜单";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.btn_updateData);
            this.tabPage3.Controls.Add(this.btn_setting);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.getDataPath);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.pyPath);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.dataPath);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 412);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "设置";
            // 
            // btn_updateData
            // 
            this.btn_updateData.Location = new System.Drawing.Point(191, 185);
            this.btn_updateData.Name = "btn_updateData";
            this.btn_updateData.Size = new System.Drawing.Size(75, 23);
            this.btn_updateData.TabIndex = 7;
            this.btn_updateData.Text = "更新data";
            this.btn_updateData.UseVisualStyleBackColor = true;
            this.btn_updateData.Click += new System.EventHandler(this.btn_updateData_Click);
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(92, 185);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(75, 23);
            this.btn_setting.TabIndex = 6;
            this.btn_setting.Text = "确定";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "更新文件路径";
            // 
            // getDataPath
            // 
            this.getDataPath.Location = new System.Drawing.Point(92, 126);
            this.getDataPath.Name = "getDataPath";
            this.getDataPath.Size = new System.Drawing.Size(334, 21);
            this.getDataPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "python路径";
            // 
            // pyPath
            // 
            this.pyPath.Location = new System.Drawing.Point(92, 69);
            this.pyPath.Name = "pyPath";
            this.pyPath.Size = new System.Drawing.Size(334, 21);
            this.pyPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "data.json";
            // 
            // dataPath
            // 
            this.dataPath.Location = new System.Drawing.Point(92, 17);
            this.dataPath.Name = "dataPath";
            this.dataPath.Size = new System.Drawing.Size(334, 21);
            this.dataPath.TabIndex = 0;
            // 
            // dataGrid_random
            // 
            this.dataGrid_random.AllowUserToAddRows = false;
            this.dataGrid_random.AllowUserToDeleteRows = false;
            this.dataGrid_random.AllowUserToOrderColumns = true;
            this.dataGrid_random.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid_random.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_random.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_random.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.title,
            this.ins,
            this.steps});
            this.dataGrid_random.Location = new System.Drawing.Point(11, 48);
            this.dataGrid_random.Name = "dataGrid_random";
            this.dataGrid_random.ReadOnly = true;
            this.dataGrid_random.RowTemplate.Height = 23;
            this.dataGrid_random.Size = new System.Drawing.Size(764, 356);
            this.dataGrid_random.TabIndex = 3;
            this.dataGrid_random.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_random_CellContentDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // title
            // 
            this.title.HeaderText = "标题";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // ins
            // 
            this.ins.HeaderText = "配料";
            this.ins.Name = "ins";
            this.ins.ReadOnly = true;
            // 
            // steps
            // 
            this.steps.HeaderText = "步骤";
            this.steps.Name = "steps";
            this.steps.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(19, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "菜单：";
            // 
            // btn_getRecipe
            // 
            this.btn_getRecipe.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_getRecipe.Location = new System.Drawing.Point(233, 6);
            this.btn_getRecipe.Name = "btn_getRecipe";
            this.btn_getRecipe.Size = new System.Drawing.Size(82, 32);
            this.btn_getRecipe.TabIndex = 1;
            this.btn_getRecipe.Text = "Get!";
            this.btn_getRecipe.UseVisualStyleBackColor = true;
            this.btn_getRecipe.Click += new System.EventHandler(this.btn_getRecipe_Click);
            // 
            // btn_browser
            // 
            this.btn_browser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_browser.Location = new System.Drawing.Point(336, 6);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(167, 32);
            this.btn_browser.TabIndex = 2;
            this.btn_browser.Text = "浏览器中查看菜单";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // recipe
            // 
            this.recipe.Location = new System.Drawing.Point(74, 12);
            this.recipe.Name = "recipe";
            this.recipe.Size = new System.Drawing.Size(153, 21);
            this.recipe.TabIndex = 3;
            // 
            // chishaBrowser
            // 
            this.chishaBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chishaBrowser.Location = new System.Drawing.Point(8, 44);
            this.chishaBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.chishaBrowser.Name = "chishaBrowser";
            this.chishaBrowser.Size = new System.Drawing.Size(776, 350);
            this.chishaBrowser.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(468, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(465, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "WILL_V @ https://github.com/WWILLV";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_server
            // 
            this.btn_server.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_server.Location = new System.Drawing.Point(289, 6);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(92, 26);
            this.btn_server.TabIndex = 4;
            this.btn_server.Text = "手机看！";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
            // 
            // FM_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FM_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "吃啥？";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomNum)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_random)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dataPath;
        private System.Windows.Forms.TextBox pyPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox getDataPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_updateData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown randomNum;
        private System.Windows.Forms.Button btn_random;
        private System.Windows.Forms.DataGridView dataGrid_random;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn ins;
        private System.Windows.Forms.DataGridViewTextBoxColumn steps;
        private System.Windows.Forms.Button btn_getRecipe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox recipe;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.WebBrowser chishaBrowser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_server;
    }
}

