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
using System.IO;
using System.Diagnostics;
namespace UnityLoader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        // Realy horrible code
        WebClient client = new WebClient();
        private void Form1_Load(object sender, EventArgs e) {
                string supported_games = client.DownloadString("http://senpaidev.github.io/UnityCheatLoader/").Split(new string[] { "<ul>" }, StringSplitOptions.None)[1].Split(new string[] { "</ul>" }, StringSplitOptions.None)[0];
                int NumOfSupGames = supported_games.Split(new string[] {"<li>"}, StringSplitOptions.None).Length - 1;
                for (int x = 1; x <= NumOfSupGames; x++) {
                    listBox1.Items.Add(supported_games.Split(new string[]{ "<li>" }, StringSplitOptions.None)[x].Split(new string[] {"</li>"}, StringSplitOptions.None)[0]);
            }
        }
        string getprocname(string findcheat) {
            return client.DownloadString("https://raw.githubusercontent.com/SenpaiDev/UnityCheatLoader/Repo/.ProcName").Split(new string[] { "["+findcheat+"]" }, StringSplitOptions.None)[1].Split(new string[] {"[windows]"}, StringSplitOptions.None)[0];
        }

        string downloaddll(string findcheat) {
            string cheatname = findcheat.Replace(" ", "_");
            client.DownloadFile("https://github.com/SenpaiDev/UnityCheatLoader/blob/Repo/Cheat_"+cheatname+"/"+cheatname+".dll?raw=true", Path.GetTempPath() + "\\"+ "Cheat_" + cheatname + ".dll");
            Console.Write("Downloaded");
            return (Path.GetTempPath() + "Cheat_" + cheatname + ".dll");
            
        }

        private void Form1_DoubleClick(object sender, EventArgs e) {
            if (listBox1.SelectedItem != null){
                DllInjector.GetInstance.Inject(getprocname((string)listBox1.SelectedItem), downloaddll((string)listBox1.SelectedItem));
            }
        }
    }
}
