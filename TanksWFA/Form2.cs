using System;
using System.Windows.Forms;
using TanksGameLibrary.Network;
using System.Threading;

namespace TanksWFA
{
    public partial class Form2 : Form
    {
        private Server server;

        private Client client;
        public Form2()
        {
            InitializeComponent();
            ipTextBox.Text = "192.168.96.17";
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string ip = ipTextBox.Text;
            bool player = checkBox1.Checked;
            client = new Client(ip, 8888);
            Form1 form1 = new Form1(client, player);
            form1.Show();
        }

        private void createServerButton_Click(object sender, EventArgs e)
        {
            string ip = ipTextBox.Text;
            server = new Server(ip, 8888);
            Thread thread = new Thread(server.Start);
            thread.Name = "Server thread";
            thread.Start();
        }
    }
}
