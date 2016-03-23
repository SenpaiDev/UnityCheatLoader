using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace UnityLoader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e) {
            using (WebClient client = new WebClient()) {
                string supported_games = client.DownloadString("http://senpaidev.github.io/UnityCheatLoader/").Split(new string[] { "<ul>" }, StringSplitOptions.None)[1].Split(new string[] { "</ul>" }, StringSplitOptions.None)[0];
                int NumOfSupGames = supported_games.Split(new string[] {"<li>"}, StringSplitOptions.None).Length - 1;
                for (int x = 1; x <= NumOfSupGames; x++) {
                    listBox1.Items.Add(supported_games.Split(new string[]{ "<li>" }, StringSplitOptions.None)[x].Split(new string[] {"</li>"}, StringSplitOptions.None)[0]);
                }
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e) {
            if(listBox1.SelectedItem != null) {

            }
        }
    }
}
