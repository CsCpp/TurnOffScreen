using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace TurnOffScreen
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        private static extern int SendMessage(int hWnd,int hMsg, int wParam,int lParam);
        private void SetMonitorState(MonitorState state)
        {
            SendMessage(0xFFFF, 0x112, 0xF170, (int)state);
        }
        public Form1()
        {
            InitializeComponent();
            Opacity= 0; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetMonitorState(MonitorState.Off);

                Thread.Sleep(1000);
            SetMonitorState(MonitorState.On);

            Application.Exit();
        }
    }
}
