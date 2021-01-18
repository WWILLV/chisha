using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiSha
{
    public partial class FM_main : Form
    {
        Config config;
        String configPath = "config.json";
        List<Data> data;
        int dataSize = 0;

        public FM_main()
        {
            InitializeComponent();
            init();
        }
        
        private void init()
        {
            if (File.Exists(configPath))
            {
                config = new ConfigHandle(configPath).getConfig();
                dataPath.Text = config.dataPath;
                pyPath.Text = config.pyPath;
                getDataPath.Text = config.getDataPath;
                if (!settingCheck(config))
                {
                    MessageBox.Show("设置异常！请检查软件设置！");
                    Application.Exit();
                }
                data = new DataHandle(config.dataPath).getData();
                dataSize = data.Count;
                randomNum.Value = 8;
                randomNum.Maximum = dataSize;
            }
            else
            {
                MessageBox.Show("欢迎使用，请及时修改软件设置！\r\n（输入python和更新文件路径后，可以点击更新data获取data.json）");
                tabControl.SelectedTab = tabControl.TabPages[2];
                String path = System.Environment.CurrentDirectory;
                dataPath.Text = path + @"\data.json";
                pyPath.Text = "python3.exe";
                getDataPath.Text = path + @"\getData.py";
            }


        }

        #region 设置
        private bool settingCheck(Config c)
        {
            if (c.dataPath.EndsWith("data.json"))
            {
                if (c.getDataPath.EndsWith(".py"))
                {
                    if (c.pyPath.EndsWith(".exe"))
                    {
                        if (File.Exists(c.dataPath) && File.Exists(c.getDataPath) )
                            return true;
                    }
                }
            }
            return false;
        }
        private void btn_setting_Click(object sender, EventArgs e)
        {
            Config c = new Config();
            c.dataPath = dataPath.Text.Trim();
            c.getDataPath = getDataPath.Text.Trim();
            c.pyPath = pyPath.Text.Trim();
            if (!settingCheck(c))
            {
                MessageBox.Show("设置有误，请检查！");
            }
            else if (new ConfigHandle(configPath).setConfig(c))
            {
                config = c;
                MessageBox.Show("设置修改成功！");
                MessageBox.Show("软件将重新启动以更新设置！");
                Application.Restart();
            }
        }

        private void btn_updateData_Click(object sender, EventArgs e)
        {
            try
            {
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(pyPath.Text.Trim(), getDataPath.Text.Trim());
                myprocess.StartInfo = startInfo;
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                MessageBox.Show("正在更新，请勿手动关闭弹出窗口！\r\n更新结束后会自动关闭窗口", "请稍候");
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新出错！\r\n" + ex.Message);
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/WWILLV");
        }

        #endregion

        #region 吃啥
        private void btn_random_Click(object sender, EventArgs e)
        {
            dataGrid_random.Rows.Clear();
            data = new DataHandle(config.dataPath).getData();
            int num = (int)randomNum.Value;
            List<Data> result = new List<Data> { };
            for (int i = 0; i < num; i++)
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random random = new Random(iSeed);
                Data randomData = data[random.Next(0, dataSize)];
                if (result.Contains(randomData))
                {
                    i--;
                    continue;
                }
                result.Add(randomData);
            }
            foreach (Data d in result)
            {
                int index = dataGrid_random.Rows.Add();
                dataGrid_random.Rows[index].Cells[0].Value = d.url;
                dataGrid_random.Rows[index].Cells[1].Value = d.title;
                foreach (var ing in d.ins.Keys)
                {
                    dataGrid_random.Rows[index].Cells[2].Value += ing + ",";
                }
                foreach (Dictionary<String, String> step in d.steps)
                {
                    foreach (var k in step["text"])
                    {
                        dataGrid_random.Rows[index].Cells[3].Value += k.ToString();
                    }
                    dataGrid_random.Rows[index].Cells[3].Value += "。";
                }
            }
        }

        private void dataGrid_random_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGrid_random.CurrentRow.Index;
            dataGrid_random.Rows[index].Selected = true;
            getRecipe(dataGrid_random.Rows[index].Cells[0].Value.ToString());
            tabControl.SelectedTab = tabControl.TabPages[1];
        }
        private void btn_server_Click(object sender, EventArgs e)
        {
            FM_server son = new FM_server();
            son.Owner = this;
            son.Show();
        }
        #endregion

        #region 浏览菜单
        private void getRecipe(String url)
        {
            recipe.Text = url;
            String html = "";
            chishaBrowser.Navigate("about:blank");
            while (chishaBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            foreach (Data d in data)
            {
                if (d.url == url)
                {
                    html += "<h1>" + d.title + "</h1>";
                    html += "<h3>配料：</h3>";
                    foreach (var ing in d.ins.Keys)
                    {
                        html += "<li>" + ing + " @ " + d.ins[ing] + "</li>";
                    }
                    html += "<h3>步骤：</h3>";
                    html += "<ol>";
                    foreach (Dictionary<String, String> step in d.steps)
                    {
                        html += "<li>" + step["text"] + " <img src='" + step["img"] + "' /></li>";
                    }
                    html += "</ol>";

                    break;
                }
            }
            chishaBrowser.Document.Write(html);
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            String url = "https://www.xiachufang.com" + recipe.Text;
            System.Diagnostics.Process.Start(url);
        }

        private void btn_getRecipe_Click(object sender, EventArgs e)
        {
            getRecipe(recipe.Text);
        }
        #endregion

    }
}
