using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiSha
{
    public partial class FM_server : Form
    {
        ChishaServer cs;
        public FM_server()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            label1.Text = getIp();
            btn_kill.Enabled = false;
        }
        public String getIp()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
                return localIP;
            }
        }

        private bool portInUse(int port)
        {
            bool flag = false;
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipendpoints = null;
            ipendpoints = properties.GetActiveTcpListeners();

            foreach (IPEndPoint ipendpoint in ipendpoints)
            {
                if (ipendpoint.Port == port)
                {
                    flag = true;
                    break;
                }
            }
            ipendpoints = null;
            properties = null;
            return flag;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            String ip = getIp();
            int p = (int)port.Value;
            if (portInUse(p))
            {
                MessageBox.Show("该端口已占用！");
                return;
            }
            port.Enabled = false;
            cs = new ChishaServer(p);
            cs.start();
            pictureBox1.Load("https://api.imjad.cn/qrcode?text=http://" + ip + ":" + p.ToString() + "&size=200&level=M&bgcolor=%23ffffff&fgcolor=%23000000");
            btn_start.Enabled = false;
            btn_kill.Enabled = true; 
        }

        private void btn_kill_Click(object sender, EventArgs e)
        {
            cs.kill();
            port.Enabled = true;
            btn_start.Enabled = true;
            btn_kill.Enabled = false;
        }
    }
}
